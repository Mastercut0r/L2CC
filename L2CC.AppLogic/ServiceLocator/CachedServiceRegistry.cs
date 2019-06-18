using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;

namespace L2CC.AppLogic.ServiceLocator
{
    internal class ServiceLocatorCache : IServiceLocatorCache
    {
        public IDictionary<Type, IAppService> m_instantietedServicesClassic = new Dictionary<Type, IAppService>();
        public IDictionary<Type, IAppService> m_instantietedServicesEssence = new Dictionary<Type, IAppService>();

        public void AddToCache(GameType gameType, Type interfaceTypeToAdd, IAppService serviceInstance)
        {
            switch (gameType)
            {
                case GameType.Classic:
                    if (m_instantietedServicesClassic.ContainsKey(interfaceTypeToAdd))
                    {
                        m_instantietedServicesClassic.Add(interfaceTypeToAdd, serviceInstance);
                    }
                    break;
                case GameType.Essence:
                    if (m_instantietedServicesEssence.ContainsKey(interfaceTypeToAdd))
                    {
                        m_instantietedServicesEssence.Add(interfaceTypeToAdd, serviceInstance);
                    }
                    break;
                default:
                    break;
            }
        }

        public IAppService LookUpInCache(GameType gameType, Type serviceType)
        {
            if (gameType == GameType.Classic)
            {
                if (m_instantietedServicesClassic.ContainsKey(serviceType))
                {
                    return m_instantietedServicesClassic[serviceType];
                }
                return null;
            }
            else if (gameType == GameType.Essence)
            {
                if (m_instantietedServicesEssence.ContainsKey(serviceType))
                {
                    return m_instantietedServicesEssence[serviceType];
                }
                return null;
            }
            else
            {
                throw new NotSupportedException(nameof(serviceType));
            }
        }
    }
}
