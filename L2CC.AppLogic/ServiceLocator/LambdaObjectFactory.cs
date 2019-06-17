using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace L2CC.AppLogic.ServiceLocator
{
    internal class LambdaObjectFactory : IObjectFactory
    {
        private delegate T ObjectActivator<T>(params object[] args);
        private static ObjectActivator<T> GetActivator<T>(ConstructorInfo ctor)
        {
            Type type = ctor.DeclaringType;
            ParameterInfo[] paramsInfo = ctor.GetParameters();
            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");
            Expression[] argsExp = new Expression[paramsInfo.Length];
            //pick each arg from the params array 
            //and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;
                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
                argsExp[i] = paramCastExp;
            }
            //make a NewExpression that calls the
            //ctor with the args we just created
            NewExpression newExp = Expression.New(ctor, argsExp);

            //create a lambda with the New
            //Expression as body and our param object[] as arg
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectActivator<T>), newExp, param);

            //compile it
            ObjectActivator<T> compiled = (ObjectActivator<T>)lambda.Compile();
            return compiled;
        }
        public IServiceInterface CreateService<IServiceInterface>(Type typeToCreate) where IServiceInterface : class
        {
            ConstructorInfo ctor = typeToCreate.GetConstructors().First();
            ObjectActivator<IServiceInterface> createdActivator = GetActivator<IServiceInterface>(ctor);
            //create an instance:
            return createdActivator();
        }
    }
}
