using BindOpen.Data.Helpers;
using BindOpen.Messages.Email;
using BindOpen.Scoping;
using BindOpen.Scoping.Script;

namespace BindOpen.Tests.Messages
{
    public static class SystemData
    {
        /// <summary>
        /// The storage URI folder.
        /// </summary>
        public static readonly string StorageUri = "https://storage.bindopen.org/";

        static IBdoScope _appScope = null;

        /// <summary>
        /// The global scope.
        /// </summary>
        public static IBdoScope Scope
        {
            get
            {
                if (_appScope == null)
                {
                    _appScope = BdoScoping.NewScope();
                    _appScope.LoadExtensions(q => q.AddEmail());
                }

                return _appScope;
            }
        }

        static string _workingFolder;
        static IBdoScriptInterpreter _scriptInterpreter;

        /// <summary>
        /// The global working folder.
        /// </summary>
        public static string WorkingFolder
        {
            get
            {
                if (_workingFolder == null)
                {
                    _workingFolder = (FileHelper.GetAppRootFolderPath() + @"temp\").ToPath();
                }

                return _workingFolder;
            }
        }

        public static IBdoScriptInterpreter ScriptInterpreter
        {
            get
            {
                if (_scriptInterpreter == null)
                {
                    _scriptInterpreter = Scope.Interpreter; ;
                }

                return _scriptInterpreter;
            }
        }
    }
}
