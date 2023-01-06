using BindOpen.Data;
using BindOpen.Logging;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BindOpen.Messages.Feeds.Atom
{
    /// <summary>
    /// This class represents a RSS loader.
    /// </summary>
    public static class AtomFeedHandler
    {
        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <param name="feedUri">The RSS channel URI to consider.</param>
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
        public static AtomFeedDto GetAtomFeed(
            string feedUri,
            out int totalItemCount,
            RssItemSortingKind sortingKind = RssItemSortingKind.Date,
            int minimumItemIndex = 0,
            int maximumItemIndex = -1,
            string[] languages = null,
            string[] categories = null,
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

                            feed.Entries = items.ToList();
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
        /// <param name="log">The log to consider.</param>
        /// <param name="itemId">The total item count to consider.</param>
        /// <returns>Returns the output value of the execution.</returns>
        public static AtomFeedEntryDto GetFeedItem(
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
        /// <returns>Returns the converted feed entry.</returns>
        public static AtomFeedEntryDto ToFeedEntry(this XElement xElement)
        {
            return xElement == null ? null : new AtomFeedEntryDto()
            {
                Name = xElement.Element("guid")?.Value,
                Title = xElement.Element("title")?.Value,
                Description = xElement.Element("description")?.Value,
                //Link = xElement.Element("link")?.Value,
                PublicationDate = xElement.Element("pubDate")?.Value?.ToString(),
                //Language = xElement.Element("language")?.Value,
                //Category = xElement.Element("category")?.Value
            };
        }
    }
}