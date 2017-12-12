using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HCBBOOK.UCBI.RealPresence.UI.App_Start.Startup))]

namespace HCBBOOK.UCBI.RealPresence.UI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
