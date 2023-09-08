using BindOpen.Core.Application.Scopes;
using BindOpen.Core.Data.Common;
using BindOpen.Core.Data.Helpers.Strings;
using BindOpen.Core.Extensions.Attributes;
using BindOpen.Core.Extensions.Runtime.Tasks;
using BindOpen.Core.System.Diagnostics;
using BindOpen.Core.System.Script;
using meltingFlow.Messages.Extension.Entities.Rss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace meltingFlow.Messages.Extension.Tasks
{

    /// <summary>
    /// This class represents a business task that: Evalutes the condition.
    /// </summary>
    public class Task_RssLoader : Task
    {

        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Enumerations

        /// <summary>
        /// This enumeration lists all the possible kinds of RSS item sorting.
        /// </summary>
        public enum RssItemSortingKind
        {
            /// <summary>
            /// No sorting.
            /// </summary>
            None,
            /// <summary>
            /// By date.
            /// </summary>
            Date,
            /// <summary>
            /// By title.
            /// </summary>
            Title
        }

        #endregion


        // ------------------------------------------
        // VARIABLES
        // ------------------------------------------

        #region Variables

        // Custom (variables are private) ---->

        private String _RssChannelUri;
        private int _MinimumItemIndex = 0;
        private int _MaximumItemIndex = -1;
        private List<String> _Languages = null;
        private List<String> _Categories = null;
        private RssItemSortingKind _SortingKind = RssItemSortingKind.Date;

        private RssChannel _RssChannel = null;
        private int _TotalItemCount = 0;

        // <---- Custom

        #endregion


        // ------------------------------------------
        // PROPERTIES
        // ------------------------------------------

        #region Properties

        // Custom (properties are public) ---->

        /// <summary>
        /// The RSS channel URI of this instance.
        /// </summary>
        [TaskInput()]
        public String RssChannelUri
        {
            get { return this._RssChannelUri; }
            set { this._RssChannelUri = value; }
        }

        /// <summary>
        /// The minimum item index of this instance.
        /// </summary>
        [TaskInput()]
        public int MinimumItemIndex
        {
            get { return this._MinimumItemIndex; }
            set { this._MinimumItemIndex = value; }
        }

        /// <summary>
        /// The maximum item index of this instance.
        /// </summary>
        [TaskInput()]
        public int MaximumItemIndex
        {
            get { return this._MaximumItemIndex; }
            set { this._MaximumItemIndex = value; }
        }

        /// <summary>
        /// The languages of this instance.
        /// </summary>
        [TaskInput()]
        public List<String> Languages
        {
            get { return this._Languages; }
            set { this._Languages = value; }
        }

        /// <summary>
        /// The categories of this instance.
        /// </summary>
        [TaskInput()]
        public List<String> Categories
        {
            get { return this._Categories; }
            set { this._Categories = value; }
        }

        /// <summary>
        /// The sorting kind of this instance.
        /// </summary>
        [TaskInput()]
        public RssItemSortingKind SortingKind
        {
            get { return this._SortingKind; }
            set { this._SortingKind = value; }
        }

        /// <summary>
        /// The RSS items of this instance.
        /// </summary>
        [TaskOutput()]
        public RssChannel RssChannel
        {
            get { return this._RssChannel; }
            set { this._RssChannel = value; }
        }

        /// <summary>
        /// The total item count of this instance.
        /// </summary>
        [TaskOutput()]
        public int TotalItemCount
        {
            get { return this._TotalItemCount; }
            set { this._TotalItemCount = value; }
        }

        // <---- Custom

        #endregion


        // ------------------------------------------
        // PROCESSING
        // ------------------------------------------

        #region Processing

        private DateTime GetDateTimeFromString(String st)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParse(st, out dateTime);
            return dateTime;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="log">The log to consider.</param>
        /// <param name="appScope">The application scope to consider.</param>
        /// <param name="scriptVariableSet">The script variable set to use for execution.</param>
        /// <param name="runtimeMode">The runtime mode to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public override void Execute(
            Log log,
            AppScope appScope = null,
            ScriptVariableSet scriptVariableSet = null,
            RuntimeMode runtimeMode = RuntimeMode.Normal)
        {
            log = log ?? new Log();

            if (!String.IsNullOrEmpty(this._RssChannelUri))
            {
                String rssChannelUri = this._RssChannelUri;
                if (rssChannelUri.ToLower().StartsWith("http"))
                    rssChannelUri += "?_=" + System.DateTime.Now.Ticks.ToString();
                try
                {
                    XElement rootXElement = XElement.Load(rssChannelUri);

                    if (rootXElement!=null)
                    {
                        XElement channelXElement = rootXElement.Elements("channel").FirstOrDefault();
                        if (channelXElement != null)
                        {
                            this._RssChannel = new RssChannel(
                                channelXElement.Element("title")?.Value,
                                channelXElement.Element("description")?.Value,
                                null);

                            var items = channelXElement.Elements("item")
                                .Where(p =>
                                    (this._Languages == null || this._Languages.Any(q => q?.ToLower() == p.Element("language")?.Value?.ToLower()))
                                    && (this._Categories == null || this._Categories.Any(q => q?.ToLower() == p.Element("category")?.Value?.ToLower())))
                                .Select(p =>
                                    new RssItem()
                                    {
                                        Name = p.Element("guid")?.Value,
                                        Title = p.Element("title")?.Value,
                                        Description = p.Element("description")?.Value,
                                        Link = p.Element("link")?.Value,
                                        PublicationDate = p.Element("pubDate")?.Value?.ToDateTime(),
                                        Language = p.Element("language")?.Value,
                                        Category = p.Element("category")?.Value
                                    });

                            this._TotalItemCount = items.Count();

                            switch (_SortingKind)
                            {
                                case RssItemSortingKind.Date:
                                    items = items.OrderByDescending(p => p.PublicationDate);
                                    break;
                                case RssItemSortingKind.Title:
                                    items = items.OrderByDescending(p => p.Title);
                                    break;
                            }
                            if (this._MinimumItemIndex < -1)
                                this._MinimumItemIndex = 0;

                            if (this._MinimumItemIndex > 0)
                                items = items.Skip(this._MinimumItemIndex);
                            if (this._MaximumItemIndex > -1 && this._MaximumItemIndex > this._MinimumItemIndex)
                                items = items.Take(this._MaximumItemIndex - this._MinimumItemIndex);

                            this._RssChannel.Items = items.ToList();
                        }

                    }
                }
                catch
                {
                }
            }

        }

        #endregion

    }
}