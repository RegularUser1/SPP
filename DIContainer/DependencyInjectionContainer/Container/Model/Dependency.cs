using DependencyInjectionContainer.Container.Interface;

namespace DependencyInjectionContainer.Container.Model
{
    public class Dependency(Type type, LifeCycle lifeCycle, string? name = null)
    {
        public Type Type { get; } = type;
        public LifeCycle LifeCycle { get; } = lifeCycle;
        public string? Name { get; } = name;

        private object? _instance;
        private readonly object _lockObject = new();

        public object GetInstance(IDependencyConfiguration configuration) =>
            LifeCycle == LifeCycle.Singleton ? GetSingleton(configuration) : GetTransient(configuration);

        private object GetSingleton(IDependencyConfiguration configuration)
        {
            if (_instance is null)
            {
                lock (_lockObject)
                {
                    _instance = GetTransient(configuration);
                }
            }

            return _instance;
        }

        private object GetTransient(IDependencyConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object? obj)
        {
            return obj is Dependency dependency && dependency.Type.Equals(Type);
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }
    }
}
