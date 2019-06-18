using L2CC.AppLogic.AppLogic;
using System;

namespace L2CC.AppLogic.ServiceLocator
{
    internal interface IServiceLocatorCache
    {
        IAppService LookUpInCache(GameType gameType, Type serviceType);
        void AddToCache(GameType gameType, Type interfaceTypeToAdd, IAppService serviceInstance);
    }
}