using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;

namespace L2CC.AppLogic.ServiceLocator
{
    public class LambdaPoweredServiceLocator : IServiceRegistry
    {
        private readonly IDictionary<Type, Type> m_classicLogic = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> m_essenceLogic = new Dictionary<Type, Type>();
        private readonly IObjectFactory m_Factory;
        private readonly IServiceLocatorCache m_Cache;
        public LambdaPoweredServiceLocator() : this(null, null) { }
        internal LambdaPoweredServiceLocator(IObjectFactory factory = null, IServiceLocatorCache cache = null)
        {
            m_Factory = factory ?? new LambdaObjectFactory();
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
            Type concreteType = null;
            if (gameType == GameType.Classic)
            {
                if (!m_classicLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                concreteType = m_classicLogic[interfaceTypeToLoad];
            }
            else if (gameType == GameType.Essence)
            {
                if (!m_essenceLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                concreteType = m_essenceLogic[interfaceTypeToLoad];
            }
            var serviceInstance = m_Factory.CreateService<SerivceInterface>(concreteType);
            if (serviceInstance == null)
            {
                throw new NotSupportedException(nameof(SerivceInterface));
            }
            m_Cache.AddToCache(gameType, interfaceTypeToLoad, serviceInstance);
            return serviceInstance;
        }
    }
}
