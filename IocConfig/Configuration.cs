using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ServiceLayer.ServiceContract;
using StructureMap;
using StructureMap.Web;

namespace IocConfig
{
    public class Configuration
    {
        public static Container Inject()
        {
            return new Container(config =>
            {
                config.For<IApplicatioDbContext>()
                .HybridHttpOrThreadLocalScoped()
                .Use<ApplicationDbContext>();


                config.For<IRequestRepository>().Use<RequestRepository>();
            });
        }
    }
}
