using BindOpen.Data;
using BindOpen.Logging;
using BindOpen.Logging.Loggers;
using BindOpen.Messages.Contacts;
using BindOpen.Messages.Email.Connectors;
using BindOpen.Scoping;
using Bogus;
using NUnit.Framework;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace BindOpen.Messages.Tests
{
    [TestFixture, Order(401)]
    public class EmailTests
    {
        private dynamic _testData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var f = new Faker();
            _testData = new ExpandoObject();
            _testData.connectionString = f.Random.Word();
            _testData.host = f.Internet.IpAddress().ToString();
            _testData.port = 587;
            _testData.isSslEnabled = f.Random.Bool();
            _testData.login = f.Name.LastName();
            _testData.password = f.Random.String(12, 'a', 'z');
        }

        [Test, Order(1)]
        public void CreateEmailConnectorTest_FromMetaSet()
        {
            var config =
                BdoData.NewObject()
                .WithDataType(BdoExtensionKinds.Connector, "BINDOPEN.MESSAGES.EMAIL$SMTP")
                .With(
                    BdoData.NewScalar("host", _testData.host as string),
                    BdoData.NewScalar("port", _testData.port as int?),
                    BdoData.NewScalar("isSslEnabled", _testData.isSslEnabled as bool?));
            var connector = SystemData.Scope.CreateConnector<BdoSmtpConnector>(config);

            AssertFake(connector);
        }

        [Test, Order(2)]
        public void CreateEmailConnectorTest_FromConfig()
        {
            var config =
                BdoData.NewObject()
                .WithDataType(BdoExtensionKinds.Connector, "BINDOPEN.MESSAGES.EMAIL$SMTP")
                .With(
                    BdoData.NewScalar("host", _testData.host as string),
                    BdoData.NewScalar("port", _testData.port as int?),
                    BdoData.NewScalar("isSslEnabled", _testData.isSslEnabled as bool?));
            var connector = SystemData.Scope.CreateConnector(config) as BdoSmtpConnector;

            AssertFake(connector);
        }

        [Test, Order(3)]
        public void CreateEmailConnectorTest_FromObject()
        {
            var connector = new BdoSmtpConnector
            {
                ConnectionString = _testData.connectionString,
                Host = _testData.host,
                IsSslEnabled = _testData.isSslEnabled,
                Port = _testData.port as int?
            };

            var meta = connector.ToMeta(SystemData.Scope);
            connector = SystemData.Scope.CreateConnector(meta) as BdoSmtpConnector;

            AssertFake(connector);
        }

        [Test, Order(4)]
        public void PushEmailTest()
        {
            var connector = new BdoSmtpConnector
            {
                ConnectionString = _testData.connectionString,
                Host = _testData.host,
                IsSslEnabled = _testData.isSslEnabled,
                Port = _testData.port as int?,
                Login = _testData.login,
                Password = _testData.password
            };

            IEnumerable<IResultItem> results = new List<IResultItem>();

            // Message without recipient emails

            var message = BdoMessages.NewSendingMessage("<subject>", "<body>");

            connector.UsingConnection((conn, log) =>
            {
                results = conn.Push(null, message);
            });
            Assert.That(results?.FirstOrDefault().Status == ResourceStatus.None, "Bad results");

            // Message without recipient emails

            var log = BdoLogging.NewLog()
                .WithLogger(BdoLogging.NewLogger<BdoTraceLogger>());

            message = BdoMessages.NewSendingMessage("<subject>", "<body>")
                .WithFrom(BdoMessages.NewContact().WithEmail("toto@gmail.com"))
                .WithTo(BdoMessages.NewContact().WithEmail("titi@gmail.com"));

            results = new List<IResultItem>();
            connector.UsingConnection((conn, l) =>
            {
                results = conn.Push(l, message);
            }, log: log);
            Assert.That(results?.FirstOrDefault().Status == ResourceStatus.None, "Bad results");
        }

        private void AssertFake(BdoSmtpConnector connector)
        {
            Assert.That(connector != null, "Connector missing");

            Assert.That(connector.Host == _testData.host as string, "Bad connector");
            Assert.That(connector.Port == _testData.port as int?, "Bad connector");
            Assert.That((connector.IsSslEnabled ?? false) == _testData.isSslEnabled as bool?, "Bad connector");
        }
    }
}
