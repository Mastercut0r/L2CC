using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;

namespace L2CC.AppLogic.ServiceLocator
{
    public abstract class CachedServiceRegistry
    {
        private IDictionary<Type, IAppService> m_instantietedServicesClassic = new Dictionary<Type, IAppService>();
        private IDictionary<Type, IAppService> m_instantietedServicesEssence = new Dictionary<Type, IAppService>();
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
