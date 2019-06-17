using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;

namespace L2CC.AppLogic.ServiceLocator
{
    public class LambdaPoweredServiceLocator : CachedServiceRegistry, IServiceRegistry
    {
        private readonly IDictionary<Type, Type> m_classicLogic = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> m_essenceLogic = new Dictionary<Type, Type>();
        private IDictionary<Type, IAppService> m_instantietedServicesClassic = new Dictionary<Type, IAppService>();
        private IDictionary<Type, IAppService> m_instantietedServicesEssence = new Dictionary<Type, IAppService>();
        private readonly IObjectFactory m_Factory;
        public LambdaPoweredServiceLocator() : this(null) { }
        private LambdaPoweredServiceLocator(IObjectFactory factory = null)
        {
            m_Factory = factory ?? new LambdaObjectFactory();
            m_classicLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorClassic));
            m_essenceLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorEssence));
        }
        public SerivceInterface LoadService<SerivceInterface>(GameType gameType) where SerivceInterface : class, IAppService
        {
            var interfaceTypeToLoad = typeof(SerivceInterface);
            var cachedServiceInstance = LookUpInCache(gameType, interfaceTypeToLoad);
            if (cachedServiceInstance != null)
            {
                return cachedServiceInstance as SerivceInterface;
            }

            if (gameType == GameType.Classic)
            {
                if (!m_classicLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                var concreteType = m_classicLogic[interfaceTypeToLoad];
                var serviceInstance = m_Factory.CreateService<SerivceInterface>(concreteType);
                m_instantietedServicesClassic.Add(typeof(SerivceInterface), serviceInstance);
                return serviceInstance;
            }
            else if (gameType == GameType.Essence)
            {
                if (!m_essenceLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                var concreteType = m_essenceLogic[interfaceTypeToLoad];
                var serviceInstance = m_Factory.CreateService<SerivceInterface>(concreteType);
                m_instantietedServicesEssence.Add(typeof(SerivceInterface), serviceInstance);
                return serviceInstance;
            }
            return null;
        }
    }
}
