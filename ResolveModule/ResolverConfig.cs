using System.Data.Entity;
using BLL.Interface.Services;
using BLL.Services;
using Dal.Repository;
using Dal.Interface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using Dal.Interface.DTO;

namespace ResolverConfig
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRepository<DalUser>>().To<UserRepository>();

            kernel.Bind<IAuthorizationService>().To<AuthorizationServices>();
            kernel.Bind<IRepository<DalAuthorization>>().To<AuthrizationRepository>();

            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository<DalRole>>().To<RoleRepository>();
        }
    }
}