using Contracts;
using Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MainHost
{
    public class Container
    {
        Dictionary<Type, Type> registeredDependencies = new Dictionary<Type, Type>();
        public void AddType(Type contract, Type implementation)
        {
            registeredDependencies.Add(contract, implementation);
        }
        object[] dependencies;
        public object CreateInstance(Type instanceType)
        {
            Type implementation = instanceType;
            if (registeredDependencies.ContainsKey(instanceType))
            {
                implementation = registeredDependencies[instanceType];
            }

            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            
            if (constructorParameters.Length == 0)
            {
                var properties = implementation.GetProperties().Where(x => x.CustomAttributes == typeof(ICustomerDAL) || x.CustomAttributes == typeof(Logger));
                dependencies = properties.Select(x => CreateInstance(x.PropertyType)).ToArray();
                var instance = Activator.CreateInstance(implementation);
                foreach (var property in properties)
                {
                    property.SetValue(dependencies.FirstOrDefault(x => x.GetType() == property.PropertyType), instance);
                }
            }
            dependencies = constructorParameters.Select(x => CreateInstance(x.ParameterType)).ToArray();
            return Activator.CreateInstance(implementation, dependencies);
        }
        public void AddAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes().Where(x => x.Attributes.GetType().Name == "ICustomerDAL");
            foreach (var type in types)
            {
                CreateInstance(type);
            }
        }
    } 
}
