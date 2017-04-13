using Ninject.Modules;
using SoftUniStore.Data;
using SoftUniStore.Data.Contracts;

namespace SoftUniStore.DepedencyContainer
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
