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
            throw new NotImplementedException();
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
