using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace L2CC.AppLogic.ServiceLocator
{
    public class ConstructorServiceLocator : CachedServiceRegistry, IServiceRegistry
    {
        private readonly IDictionary<Type, Type> m_classicLogic = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> m_essenceLogic = new Dictionary<Type, Type>();
        private IDictionary<Type, IAppService> m_instantietedServicesClassic = new Dictionary<Type, IAppService>();
        private IDictionary<Type, IAppService> m_instantietedServicesEssence = new Dictionary<Type, IAppService>();
        public ConstructorServiceLocator()
        {
            m_classicLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorClassic));
        }
        public SerivceInterface LoadService<SerivceInterface>(GameType gameType) where SerivceInterface : class, IAppService
        {
            var interfaceTypeToLoad = typeof(SerivceInterface);
            var cachedServiceInstance = LookUpInCache(gameType, interfaceTypeToLoad);
            if (cachedServiceInstance != null)
            {
                return cachedServiceInstance as SerivceInterface;
            }
            //var typeToCreate = registeredTypes[typeToLoad];
            if (gameType == GameType.Classic)
            {
                if (!m_classicLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                var concreteType = m_classicLogic[interfaceTypeToLoad];
                ConstructorInfo constructor = concreteType.GetConstructor(new Type[0]);
                IAppService service = (SerivceInterface)constructor.Invoke(null);
                m_instantietedServicesClassic.Add(typeof(SerivceInterface), service);
                return service as SerivceInterface;
            }
            else if (gameType == GameType.Essence)
            {
                if (!m_essenceLogic.ContainsKey(interfaceTypeToLoad)) throw new NotSupportedException();
                var concreteType = m_essenceLogic[interfaceTypeToLoad];
                ConstructorInfo constructor = concreteType.GetConstructor(new Type[0]);
                IAppService service = (SerivceInterface)constructor.Invoke(null);
                m_instantietedServicesEssence.Add(typeof(SerivceInterface), service);
                return service as SerivceInterface;
            }
            throw new NotSupportedException(nameof(gameType));
        }
    }
}
