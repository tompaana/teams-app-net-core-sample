Teams App Sample - .NET Core
============================

[Microsoft Teams apps](https://developer.microsoft.com/en-us/microsoft-teams) are web apps.
The foundation of Teams specific apps is partially based on the building blocks that make up the
[Microsoft Bot Framework](https://dev.botframework.com/). In addition to that Teams app typically
utilize tabs (web content in `iframe`), connectors to allow rich notifications and
[more](https://developer.microsoft.com/en-us/microsoft-teams/scenarios). But that doesn't change the
fact that a Teams app is simply a web app.

![Author's highly technical illustration of a web app.](/doc/webapp.png?size=50)<br />
*Author's highly technical illustration of a web app.*

The short-lived purpose of this sample is to serve as a quick guide on how to implement a Teams app
using [Bot Framework v4](https://github.com/Microsoft/botbuilder-dotnet) - which as of writing this
is still in preview - instead of the current v3.x. A reason one might have to target the preview
version is the fact that while **v3.x is based on .NET Framework 4.x**, the new **v4 targets .NET
Core**. Furthermore, the reason one might care is based on the platform their running their
software; **.NET Core is multi-platform** including Linux support. To learn more, visit
[docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server).

Is there any reason .NET Core/Bot Framework v4 combo wouldn't work as a basis for a Teams app? Not
that I can tell - please refer to the technical outline above. As long as the web app looks the same
outside providing the appropriate inputs and outputs and knows how to handle the messages the same
way, it reasonable to expect everything to just work. If it looks like a duck, swims like a duck,
and quacks like a duck... you get the point.

Moreover, this sample includes the notorious authentication bit in Teams apps. Namely, the sample
provides the code required to authenticate against the
[Microsoft Graph](https://developer.microsoft.com/en-us/graph).

If it's 2019 and you're reading this, then it's fair to assume the information here is no longer of
any use as Bot Framework v4 should be the official version (no longer in preview) now. Thanks for
visiting anyways.

## So, how do I... ##

Before getting into the Teams specific stuff, let's first deploy the app (BOT!) and make sure it
works. Note that the steps described here are for Visual Studio. In case you're using some other
IDE, most of the content still applies, but you may have to consult a web search engine. The other
thing here is that the deployment steps are for Azure. The bot app can be hosted practically
anywhere, but then again you must look for the instructions elsewhere. Isn't life full of choices?

Here goes:

1. Open the solution (`TeamsAppSample.NETCore.sln`) in Visual Studio/your IDE
2. Follow the steps in this article carefully:
   [Deploy your bot to Azure](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-deploy-azure?view=azure-bot-service-4.0)
   * Top tip: Create a new [Azure resource group](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-overview#resource-groups)
     for the app so that if stuff goes wrong, it's really easy to just delete the whole group and
     start over
   * Having issues testing the bot (as in "The dang thing doesn't work!!") - check the following:
     * Did you remember to include `/api/messages` in the messaging endpoint
       (Bot Channels Registration/Settings)?
     * Did you remember to create and add the credentials (`MicrosoftAppId` and `MicrosoftAppPassword`)?

Finally add the credentials (`MicrosoftAppId` and `MicrosoftAppPassword`) to the
[`appsettings.json` file](/TeamsAppSample.NETCore/appsettings.json) and republish the bot - now all
you need to do to republish is to right-click the app project in the **Solution Explorer** in
Visual Studio, select **Publish...** and click the **Pubish** button on the tab (named in the sample
"TeamsAppSample.NETCore").

Well, that was quick and easy (I hope). Next, why not download the
[Bot Framework Emulator](https://docs.microsoft.com/en-us/azure/bot-service/bot-service-debug-emulator?view=azure-bot-service-3.0)
and try it out!

### Enable and install the app in Teams ###

First, we want to make sure our bot is enabled in Teams. Go to the
[Azure portal](https://portal.azure.com) and to the familiar **Bot Channels Registration** resource
you created previously. Select **Channels** under **BOT MANAGEMENT** and click the Teams icon:

![Configuring Microsoft Teams channel in Azure portal](/doc/configure-microsoft-teams-channel.png?size=50)




(WORK IN PROGRESS THIS IS! TEXT BELOW MIND YOU NOT.)

* Getting started with Bot Framework v4: https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-sdk-quickstart?view=azure-bot-service-4.0
* Azure AD: https://docs.microsoft.com/en-us/azure/app-service/app-service-mobile-how-to-configure-active-directory-authentication
