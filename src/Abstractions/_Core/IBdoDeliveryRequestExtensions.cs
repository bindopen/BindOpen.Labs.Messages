﻿using BindOpen.Labs.Messages.Contacts;
using System.Linq;

namespace BindOpen.Labs.Messages
{
    /// <summary>
    /// This class represents the delivery method for a message send request.
    /// </summary>
    public static class IBdoDeliveryRequestExtensions
    {
        /// <summary>
        /// Media of this instance.
        /// </summary>
        public static T WithMethod<T>(T obj, IBdoDeliveryMethod method)
            where T : IBdoDeliveryRequest
        {
            if (obj != null)
            {
                obj.Method = method;
            }

            return obj;
        }

        /// <summary>
        /// Mode of this instance.
        /// </summary>
        public static T WithTo<T>(T obj, params IBdoContact[] contacts)
            where T : IBdoDeliveryRequest
        {
            if (obj != null)
            {
                obj.To = contacts?.ToList();
            }

            return obj;
        }
    }
}