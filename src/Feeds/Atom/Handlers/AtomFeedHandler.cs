using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Helpers;
using BindOpen.Kernel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BindOpen.Labs.Messages.Feeds.Atom
{
    /// <summary>
    /// This class represents a RSS loader.
    /// </summary>
    public static class AtomFeedHandler
    {
        public static AtomFeedDto GetFeed(
            string feedUri,
            Func<IEnumerable<XElement>, IEnumerable<XElement>> itemTransformer = null,
            int titleMaxCharacterNumber = -1,
            int descriptionMaxCharacterNumber = -1,
            IBdoLog log = null)
        {
            return GetFeed(
                feedUri,
                out int totalItemCount,
                itemTransformer,
                titleMaxCharacterNumber,
                descriptionMaxCharacterNumber,
                log);
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="totalItemCount">The total item count to consider.</param>
        /// <param name="titleMaxCharacterNumber">The number of title maximum characters to consider.</param>
        /// <param name="descriptionMaxCharacterNumber">The number of description maximum characters to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static AtomFeedDto GetFeed(
            string feedUri,
            out int totalItemCount,
            Func<IEnumerable<XElement>, IEnumerable<XElement>> itemTransformer = null,
            int titleMaxCharacterNumber = -1,
            int descriptionMaxCharacterNumber = -1,
            IBdoLog log = null)
        {
            totalItemCount = -1;
            AtomFeedDto feed = null;

            if (!string.IsNullOrEmpty(feedUri))
            {
                if (feedUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    feedUri += "?_=" + DateTime.Now.Ticks.ToString();
                try
                {
                    XElement rootXElement = XElement.Load(feedUri);

                    if (rootXElement != null)
                    {
                        XElement channelXElement = rootXElement.Elements("channel").FirstOrDefault();
                        if (channelXElement != null)
                        {
                            feed = new AtomFeedDto(
                                channelXElement.Element("title")?.Value.ToShortString(titleMaxCharacterNumber),
                                channelXElement.Element("description")?.Value.ToShortString(descriptionMaxCharacterNumber),
                                null);

                            var items = channelXElement.Elements("item");
                            totalItemCount = items.Count();

                            if (itemTransformer != null)
                            {
                                itemTransformer?.Invoke(items);
                            }

                            feed.Entries = items.Select(p => p.ToFeedEntry()).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {
                    log?.AddException(ex);
                }
            }

            return feed;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
        /// <param name="languages">The languages to consider.</param>
        /// <param name="categories">The categories to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static IEnumerable<XElement> Filter(
            this IEnumerable<XElement> elements,
            string[] languages = null,
            string[] categories = null)
        {
            elements = elements.Where(p =>
                (languages == null || languages.Any(q => q?.ToLower() == p.Element("language")?.Value?.ToLower()))
                && (categories == null || categories.Any(q => q?.ToLower() == p.Element("category")?.Value?.ToLower())));
            return elements;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="itemId">The total item count to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static IEnumerable<XElement> Sort(
            this IEnumerable<XElement> elements,
            RssItemSortingKind sortingKind = RssItemSortingKind.Date,
            DataSortingModes sortingMode = DataSortingModes.Any)
        {
            if (sortingKind != RssItemSortingKind.None)
            {
                switch (sortingMode)
                {
                    case DataSortingModes.Ascending:
                        elements = elements.OrderBy(p => GetItemValue(p));
                        break;
                    case DataSortingModes.Descending:
                        elements = elements.OrderByDescending(p => GetItemValue(p));
                        break;
                }
            }

            return elements;
        }

        private static string GetItemValue(
            this XElement element,
            RssItemSortingKind sortingKind = RssItemSortingKind.Date)
        {
            var st = "";
            switch (sortingKind)
            {
                case RssItemSortingKind.Date:
                    st = element.Element("date")?.Value;
                    break;
                case RssItemSortingKind.Title:
                    st = element.Element("title")?.Value;
                    break;
            }
            return st;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="itemId">The total item count to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static IEnumerable<XElement> Keep(
            this IEnumerable<XElement> elements,
            int minIndex = 0,
            int maxIndex = -1)
        {
            if (minIndex < -1)
                minIndex = 0;

            if (minIndex > 0)
                elements = elements.Skip(minIndex);
            if (maxIndex > -1 && maxIndex > minIndex)
                elements = elements.Take(maxIndex - minIndex);

            return elements;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
        /// <param name="log">The log to consider.</param>
        /// <param name="itemId">The total item count to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static AtomFeedEntryDto GetItem(
            string feedUri,
            IBdoLog log,
            string itemId)
        {
            AtomFeedEntryDto rssItem = null;

            if (!string.IsNullOrEmpty(feedUri))
            {
                if (feedUri.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    feedUri += "?_=" + DateTime.Now.Ticks.ToString();
                try
                {
                    XElement rootXElement = XElement.Load(feedUri);

                    if (rootXElement != null)
                    {
                        XElement channelXElement = rootXElement.Elements("channel").FirstOrDefault();
                        if (channelXElement != null)
                        {
                            var itemsXelement = channelXElement.Elements("item")
                                .FirstOrDefault(p => p.Element("guid")?.Value?.Equals(itemId, StringComparison.OrdinalIgnoreCase) == true);

                            if (itemsXelement != null)
                                rssItem = itemsXelement.ToFeedEntry();
                        }

                    }
                }
                catch (Exception ex)
                {
                    log?.AddException(ex);
                }
            }

            return rssItem;
        }

        /// <summary>
        /// Converts the specified Xml element to a feed entry.
        /// </summary>
        /// <param name="xElement">The Xml element to consider.</param>
        /// <param name="titleMaxCharacterNumber">The number of title maximum characters to consider.</param>
        /// <param name="descriptionMaxCharacterNumber">The number of description maximum characters to consider.</param>
        /// <returns>Returns the converted feed entry.</returns>
        public static AtomFeedEntryDto ToFeedEntry(
            this XElement xElement,
            int titleMaxCharacterNumber = -1,
            int descriptionMaxCharacterNumber = -1)
        {
            return xElement == null ? null : new AtomFeedEntryDto()
            {
                Id = xElement.Element("guid")?.Value,
                Title = xElement.Element("title")?.Value.ToShortString(titleMaxCharacterNumber),
                Description = xElement.Element("description")?.Value.ToShortString(descriptionMaxCharacterNumber),
                //Link = xElement.Element("link")?.Value,
                PublicationDate = xElement.Element("pubDate")?.Value?.ToString(),
                //Language = xElement.Element("language")?.Value,
                //Category = xElement.Element("category")?.Value
            };
        }
    }
}