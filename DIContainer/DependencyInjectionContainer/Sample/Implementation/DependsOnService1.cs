using DependencyInjectionContainer.Sample.Interface;

namespace DependencyInjectionContainer.Sample.Implementation
{
    public class DependsOnService1 : IRepository
    {
        public IService1 Service { get; set; }

        public DependsOnService1(IService1 service)
        {
            Service = service;
        }

        public override string ToString()
        {
            return $"{Service.GetType()}";
        }
    }
}
