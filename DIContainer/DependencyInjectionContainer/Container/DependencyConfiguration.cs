using DependencyInjectionContainer.Container.Exceptions;
using DependencyInjectionContainer.Container.Interface;
using DependencyInjectionContainer.Container.Model;

namespace DependencyInjectionContainer.Container
{
    public class DependencyConfiguration : IDependencyConfiguration
    {
        public Dictionary<Type, HashSet<Dependency>> Container { get; } = [];

        public void Register(Type interfaceType, Type implementationType, LifeCycle lifeCycle = LifeCycle.Transient,
            string? name = null)
        {
            if (implementationType.IsAbstract)
            {
                throw new DependencyConfigurationException(
                    $"Abstract type {implementationType} cannot be used as Implementation");
            }

            if (!Container.ContainsKey(interfaceType))
            {
                Container[interfaceType] = [];
            }
            Container[interfaceType].Add(new Dependency(implementationType, lifeCycle, name));
        }

        public void Register<Interface, Implementation>(LifeCycle lifeCycle = LifeCycle.Transient, string? name = null)
            where Implementation : class =>
            Register(typeof(Interface), typeof(Implementation), lifeCycle, name);

        public void RegisterTransient(Type interfaceType, Type implementationType, string? name = null) =>
            Register(interfaceType, implementationType, name: name);

        public void RegisterSingleton(Type interfaceType, Type implementationType, string? name = null) =>
            Register(interfaceType, implementationType, LifeCycle.Singleton, name);
    }
}
