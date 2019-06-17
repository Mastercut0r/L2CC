using L2CC.AppLogic.AppLogic;
using System;
using System.Collections.Generic;

namespace L2CC.AppLogic.ServiceLocator
{
    class ActivatorServiceLocator : IServiceRegistry
    {
        private readonly IDictionary<Type, Type> m_classicLogic = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, Type> m_essenceLogic = new Dictionary<Type, Type>();
        public ActivatorServiceLocator()
        {
            m_classicLogic.Add(typeof(IExpCalculator), typeof(ExpCalculatorClassic));
        }

        public SerivceInterface LoadService<SerivceInterface>(GameType gameType) where SerivceInterface : class, IAppService
        {
            var interfaceTypeToLoad = typeof(SerivceInterface);
            if (gameType == GameType.Classic)
            {
                if (m_classicLogic.ContainsKey(interfaceTypeToLoad) == false) throw new NotSupportedException();
                var typeToCreate = m_classicLogic[interfaceTypeToLoad];
                return Activator.CreateInstance(typeToCreate, true) as SerivceInterface;
            }
            else if (gameType == GameType.Essence)
            {
                if (m_essenceLogic.ContainsKey(interfaceTypeToLoad) == false) throw new NotSupportedException();
                var typeToCreate = m_essenceLogic[interfaceTypeToLoad];
                return Activator.CreateInstance(typeToCreate, true) as SerivceInterface;
            }
            return null;
        }
    }
}
