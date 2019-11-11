using Contracts;
using Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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
                var properties = implementation.GetProperties().Where(x => x.CustomAttributes.Any(y => y.AttributeType == typeof(ImportAttribute)));
                var dependencies = properties.Select(x => new KeyValuePair<string, object>(x.Name, CreateInstance(x.PropertyType))).ToArray();
                var instance = Activator.CreateInstance(implementation);
                foreach (var property in properties)
                {
                    property.SetValue(instance, dependencies.FirstOrDefault(x => x.Key == property.Name).Value);
                }
                return instance;
            }
            return Activator.CreateInstance(implementation, constructorParameters.Select(x => CreateInstance(x.ParameterType)).ToArray());
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
