using BindOpen.Data;
using System.Linq;

namespace BindOpen.Messages;

/// <summary>
/// This class represents the delivery method for a message send request.
/// </summary>
public static class IBdoMessageExtensions
{
    /// <summary>
    /// Media of this instance.
    /// </summary>
    public static T WithSubject<T>(this T obj, ITBdoDictionary<string> subject)
        where T : IBdoMessage
    {
        if (obj != null)
        {
            obj.Subject = subject;
        }

        return obj;
    }

    /// <summary>
    /// Mode of this instance.
    /// </summary>
    public static T WithBody<T>(this T obj, ITBdoDictionary<string> body)
        where T : IBdoMessage
    {
        if (obj != null)
        {
            obj.Body = body;
        }

        return obj;
    }

    /// <summary>
    /// Mode of this instance.
    /// </summary>
    public static T WithBodyHtml<T>(this T obj, bool isBodyHtml)
        where T : IBdoMessage
    {
        if (obj != null)
        {
            obj.IsBodyHtml = isBodyHtml;
        }

        return obj;
    }

    /// <summary>
    /// Mode of this instance.
    /// </summary>
    public static T WithPriority<T>(this T obj, string[] attachedFiles)
        where T : IBdoMessage
    {
        if (obj != null)
        {
            obj.AttachedFiles = attachedFiles?.ToList();
        }

        return obj;
    }

    /// <summary>
    /// Mode of this instance.
    /// </summary>
    public static T WithPriority<T>(this T obj, ActionPriorities priority)
        where T : IBdoMessage
    {
        if (obj != null)
        {
            obj.Priority = priority;
        }

        return obj;
    }
}
