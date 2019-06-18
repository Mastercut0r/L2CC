using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace L2CC.AppLogic.ServiceLocator
{
    class ActivatorServiceLocator : IServiceRegistry
    {
        private readonly IDictionary<Type, Type> m_classicLogic = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> m_essenceLogic = new Dictionary<Type, Type>();
        private readonly IServiceLocatorCache m_Cache;

        public ActivatorServiceLocator() : this(null) { }
        internal ActivatorServiceLocator(IServiceLocatorCache cache = null)
        {
            m_Cache = cache ?? new ServiceLocatorCache();
            m_classicLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorClassic));
            m_essenceLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorEssence));
        }

        public SerivceInterface LoadService<SerivceInterface>(GameType gameType) where SerivceInterface : class, IAppService
        {
            var interfaceTypeToLoad = typeof(SerivceInterface);
            var cachedServiceInstance = m_Cache.LookUpInCache(gameType, interfaceTypeToLoad);
            if (cachedServiceInstance != null)
            {
                return cachedServiceInstance as SerivceInterface;
            }
            Type typeToCreate = null;
            if (gameType == GameType.Classic)
            {
                if (m_classicLogic.ContainsKey(interfaceTypeToLoad) == false) throw new NotSupportedException(nameof(interfaceTypeToLoad));
                typeToCreate = m_classicLogic[interfaceTypeToLoad];
            }
            else if (gameType == GameType.Essence)
            {
                if (m_essenceLogic.ContainsKey(interfaceTypeToLoad) == false) throw new NotSupportedException(nameof(interfaceTypeToLoad));
                typeToCreate = m_essenceLogic[interfaceTypeToLoad];
            }
            var serviceInstance = Activator.CreateInstance(typeToCreate, true) as SerivceInterface;
            if (serviceInstance == null)
            {
                throw new NotSupportedException(nameof(SerivceInterface));
            }
            m_Cache.AddToCache(gameType, interfaceTypeToLoad, serviceInstance);
            return serviceInstance;
        }
    }
}
