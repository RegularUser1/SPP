using DependencyInjectionContainer.Container.Interface;

namespace DependencyInjectionContainer.Container
{
    public class DependencyProvider(IDependencyConfiguration configuration) : IDependencyProvider
    {
        public object Resolve(Type type, string? name = null)
        {
            throw new NotImplementedException();
        }

        public Interface Resolve<Interface>(string? name = null) where Interface : class
        {
            throw new NotImplementedException();
        }

        private IEnumerable<object> ResolveAsEnumerable(Type type, string? name = null)
        {
            throw new NotImplementedException();
        }

        private object ResolveAsObject(Type type, string? name = null)
        {
            throw new NotImplementedException();
        }
    }
}
