using Ninject;
using PizzaForum.DepedencyContainer;
using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = DependencyKernel.Kernel.Get<IUnitOfWork>();
        }

        protected IUnitOfWork Context { get; }
    }

}
