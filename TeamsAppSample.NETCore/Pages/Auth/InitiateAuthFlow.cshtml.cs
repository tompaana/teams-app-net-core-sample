using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace TeamsAppSample.NETCore.Pages.Auth
{
    public class InitiateAuthFlowModel : PageModel
    {
        [BindProperty]
        public string ClientId
        {
            get
            {
                return Configuration["AuthClientId"];
            }
        }

        private IConfiguration Configuration
        {
            get;
        }

        public InitiateAuthFlowModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void OnGet()
        {
        }
    }
}
