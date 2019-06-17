using L2CC.AppLogic.AppLogic;

namespace L2CC.AppLogic.ServiceLocator
{
    public interface IServiceRegistry
    {
        SerivceInterface LoadService<SerivceInterface>(GameType gameType) where SerivceInterface : class, IAppService;
    }
}
