using BindOpen.Kernel.Logging;

namespace BindOpen.Plus.Messages.Services
{
    /// <summary>
    /// This enumeration lists the possible media used to send a message.
    /// </summary>
    public interface IBdoMessagePoolManager
    {
        void Push(IBdoSendigRequest request, IBdoLog log = null);

        IBdoSendigRequest Pop(IBdoLog log = null);
    }
}
