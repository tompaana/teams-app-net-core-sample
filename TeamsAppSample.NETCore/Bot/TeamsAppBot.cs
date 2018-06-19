using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading.Tasks;

namespace TeamsAppSample.NETCore.Bot
{
    public class TeamsAppBot : IBot
    {    
        public async Task OnTurn(ITurnContext context)
        {
            if (context.Activity.Type == ActivityTypes.Message)
            {
                await context.SendActivity($"You wrote '{context.Activity.Text}'");
            }
        }
    }
}
