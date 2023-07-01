using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using BindOpen.Framework.Core.Data.Helpers.Objects;
using BindOpen.Framework.Core.Data.Helpers.Strings;
using BindOpen.Framework.Core.System.Diagnostics;
using BindOpen.Framework.Labs.Messages.Extension.Entities.Atom;

namespace BindOpen.Framework.Labs.Messages.Handlers.Data.Atom
{
    /// <summary>
    /// This class represents a RSS loader.
    /// </summary>
    public static class FeedHandler
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
        // PROCESSING
        // ------------------------------------------

        #region Processing

        private static DateTime GetDateTimeFromString(this string st)
        {
            DateTime dateTime = new DateTime();
            DateTime.TryParse(st, out dateTime);
            return dateTime;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="rssChannelUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="totalItemCount">The total item count to consider.</param>
        /// <param name="sortingKind">The sorting kind to consider.</param>
        /// <param name="minimumItemIndex">The minimum item index to consider.</param>
        /// <param name="maximumItemIndex">The maximum item index to consider.</param>
        /// <param name="languages">The languages to consider.</param>
        /// <param name="categories">The categories to consider.</param>
        /// <param name="titleMaxCharacterNumber">The number of title maximum characters to consider.</param>
        /// <param name="descriptionMaxCharacterNumber">The number of description maximum characters to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static AtomFeed GetFeedChannel(
            string rssChannelUri,
            ILog log,
            out int totalItemCount,
            RssItemSortingKind sortingKind = RssItemSortingKind.Date,
            int minimumItemIndex = 0,
            int maximumItemIndex = -1,
            List<String> languages = null,
            List<String> categories = null,
            int titleMaxCharacterNumber = -1,
            int descriptionMaxCharacterNumber = -1)
        {
            log = log ?? new Log();
            totalItemCount = -1;
            AtomFeed rssChannel = null;

            if (!String.IsNullOrEmpty(rssChannelUri))
            {
                if (rssChannelUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    rssChannelUri += "?_=" + System.DateTime.Now.Ticks.ToString();
                try
                {
                    XElement rootXElement = XElement.Load(rssChannelUri);

                    if (rootXElement!=null)
                    {
                        XElement channelXElement = rootXElement.Elements("channel").FirstOrDefault();
                        if (channelXElement != null)
                        {
                            rssChannel = new AtomFeed(
                                channelXElement.Element("title")?.Value.GetShortString(titleMaxCharacterNumber),
                                channelXElement.Element("description")?.Value.GetShortString(descriptionMaxCharacterNumber),
                                null);

                            var items = channelXElement.Elements("item")
                                .Where(p =>
                                    (languages == null || languages.Any(q => q?.ToLower() == p.Element("language")?.Value?.ToLower()))
                                    && (categories == null || categories.Any(q => q?.ToLower() == p.Element("category")?.Value?.ToLower())))
                                .Select(p => p.ToFeedEntry());

                            totalItemCount = items.Count();

                            switch (sortingKind)
                            {
                                case RssItemSortingKind.Date:
                                    items = items.OrderByDescending(p => p.PublicationDate);
                                    break;
                                case RssItemSortingKind.Title:
                                    items = items.OrderByDescending(p => p.Title);
                                    break;
                            }
                            if (minimumItemIndex < -1)
                                minimumItemIndex = 0;

                            if (minimumItemIndex > 0)
                                items = items.Skip(minimumItemIndex);
                            if (maximumItemIndex > -1 && maximumItemIndex > minimumItemIndex)
                                items = items.Take(maximumItemIndex - minimumItemIndex);

                            rssChannel.Items = items.ToList();
                        }
                    }
                }
                catch(Exception ex)
                {
                    log.AddException(ex);
                }
            }

            return rssChannel;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="rssChannelUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="itemId">The total item count to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static AtomFeedEntry GetFeedItem(
            string rssChannelUri,
            ILog log,
            string itemId)
        {
            log = log ?? new Log();
            AtomFeedEntry rssItem = null;

            if (!String.IsNullOrEmpty(rssChannelUri))
            {
                if (rssChannelUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    rssChannelUri += "?_=" + System.DateTime.Now.Ticks.ToString();
                try
                {
                    XElement rootXElement = XElement.Load(rssChannelUri);

                    if (rootXElement != null)
                    {
                        XElement channelXElement = rootXElement.Elements("channel").FirstOrDefault();
                        if (channelXElement != null)
                        {
                            var itemsXelement= channelXElement.Elements("item")
                                .FirstOrDefault(p => p.Element("guid")?.Value.KeyEquals(itemId) == true);

                            if (itemsXelement != null)
                                rssItem = itemsXelement.ToFeedEntry();
                        }

                    }
                }
                catch (Exception ex)
                {
                    log.AddException(ex);
                }
            }

            return rssItem;
        }

        /// <summary>
        /// Converts the specified Xml element to a feed entry.
        /// </summary>
        /// <param name="xElement">The Xml element to consider.</param>
        /// <returns>Returns the converted feed entry.</returns>
        public static AtomFeedEntry ToFeedEntry(this XElement xElement)
        {
            return xElement == null ? null : new AtomFeedEntry()
            {
                Name = xElement.Element("guid")?.Value,
                Title = xElement.Element("title")?.Value,
                Description = xElement.Element("description")?.Value,
                Link = xElement.Element("link")?.Value,
                PublicationDate = xElement.Element("pubDate")?.Value?.GetDateTimeFromString(),
                Language = xElement.Element("language")?.Value,
                Category = xElement.Element("category")?.Value
            };
        }

        #endregion

    }
}