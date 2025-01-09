namespace BindOpen.Messages;

/// <summary>
/// This class represents the delivery method for a message send request.
/// </summary>
public interface IBdoDeliveryMethod
{
    /// <summary>
    /// Media of this instance.
    /// </summary>
    MessageSendMedium Medium { get; set; }

    /// <summary>
    /// Mode of this instance.
    /// </summary>
    MessageSendMode Mode { get; set; }

    /// <summary>
    /// To mode of this instance.
    /// </summary>
    MessageSendToMode ToMode { get; set; }
}
