using System;

namespace L2CC.AppLogic.ServiceLocator
{
    interface IObjectFactory
    {
        IServiceInterface CreateService<IServiceInterface>(Type typeToCreate) where IServiceInterface : class;
    }
}
