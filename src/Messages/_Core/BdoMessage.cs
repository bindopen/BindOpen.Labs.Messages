using BindOpen.Kernel;
using BindOpen.Kernel.Data;
using BindOpen.Kernel.Data.Meta;
using System;
using System.Collections.Generic;

namespace BindOpen.Plus.Messages
{
    /// <summary>
    /// This class represents the message.
    /// </summary>
    public class BdoMessage : BdoObject, IBdoMessage
    {
        /// <summary>
        /// Subject of this instance.
        /// </summary>
        public ITBdoDictionary<string> Subject { get; set; }

        /// <summary>
        /// Body of this instance.
        /// </summary>
        public ITBdoDictionary<string> Body { get; set; }

        /// <summary>
        /// Indicates whether the content is in html.
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// Attached files.
        /// </summary>
        public List<string> AttachedFiles { get; set; }

        /// <summary>
        /// Priority of this isntance.
        /// </summary>
        public ActionPriorities Priority { get; set; }

        public BdoMessage() { }

        // IIdentified

        public string Id { get; set; }

        // IReferenced

        public string Key() => Id;

        // IDated

        public DateTime? CreationDate { get; set; }

        public DateTime? LastModificationDate { get; set; }

        // IDetailed
        public IBdoMetaSet Detail { get; set; }
    }
}
