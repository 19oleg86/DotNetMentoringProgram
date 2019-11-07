using System;
using System.Collections.Generic;
using System.Reflection;

namespace MainHost
{
    public class Container
    {
        List<Assembly> allAssemblies = new List<Assembly>();
        List<object> allTypes = new List<object>();

        public void ProcessType(Type incomingType)
        {
            allTypes.Add(AddType(incomingType));
        }

        public object AddType(Type instance)
        {
            Type implementation = instance;
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation);
            }
            return Activator.CreateInstance(implementation, constructorParameters);
        }

        public void AddAssembly(Assembly assembly)
        {
            allAssemblies.Add(assembly);
        }

        public object CreateInstance(Type instanceType)
        {
            foreach (var type in allTypes)
            {
                if (type.ToString() == instanceType.FullName)
                {
                    return Activator.CreateInstance(instanceType);
                }
            }
            return null;
        }
    }
    
}
