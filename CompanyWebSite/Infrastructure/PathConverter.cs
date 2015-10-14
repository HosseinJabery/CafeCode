using System.Web;

namespace CompanyWebSite.Infrastructure
{

        public static class PathConverter
        {
            public static string PhysicalPathToVirtualConverter(this HttpServerUtilityBase utility, string path, HttpRequestBase context)
            {
                return path.Replace(context.ServerVariables["APPL_PHYSICAL_PATH"], "/").Replace(@"\", "/");
            }

        }
    }
