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

Then package and upload the app manifest in Teams. Remember when I said (wrote) that a Teams app is
nothing but a web app? Still true. That also means that your app doesn't live inside Teams, but
rather extends its tentacles (endpoints) into the abyss of the Teams registry. For exact details see
[this article](https://docs.microsoft.com/en-us/microsoftteams/platform/concepts/apps/apps-upload),
**but** here's the quick guide:

1. Open the [`manifest.json`](/TeamsAppSample.NETCore/TeamsManifest/manifest.json) in text editor
   and update the base of the URLs to match the URL of your published bot **and** add your bot ID
   (`MicrosoftAppId`) as the value of `botId` within `bots` array
   * Top tip: Use [App Studio for Microsoft Teams](https://docs.microsoft.com/en-us/microsoftteams/platform/get-started/get-started-app-studio)
     to create and manage manifest files (and to see what properties there are)
2. Package the content in the [`TeamsManifest`](/TeamsAppSample.NETCore/TeamsManifest/) folder in a
   `.zip` file so that all the files are in the root of the package (the name of the package is
   insignificant in the grand scheme of things)

Next you can choose whether to install the app for the team only or to install for personal use
(given that the app provides personal features such as
[static tabs](https://docs.microsoft.com/en-us/microsoftteams/platform/concepts/tabs/tabs-static),
which our sample does) and/or for the team.

#### 1. Install for the team only ####

1. In Teams, click the three dots next to the team, where you want to install the app, and select
   **Manage team**:
    ![Team settings](/doc/team-settings.png?size=50)
2. Navigate to the **Apps** tab and locate the **Upload a custom app** link in the bottom-right
   corner and click it, CLICK IT!
3. Browse to the location of your `.zip` package containing the manifest file and the icons and
   select **Open**
   * If there were no errors, you should now see your app in the list - looks something like this:
        ![Entry in apps list](/doc/entry-in-apps-list.png?size=50)
4. You can set up the bot by simply calling it in channel conversation, but there is a guided way to
   do it:
   * Still in the manage apps view in team settings, click the app list item (shown in the image above)
   * Click **Available** link in the pop-up window
        ![First pop-up window](/doc/set-up-bot-1.png)
   * In the new pop-up window, select the desired channel and click the **Set up** button
        ![Second pop-up window](/doc/set-up-bot-2.png)

#### 2. Install for personal use/the team ####

1. In teams, click the three dots on the left-most pane (typically on purple background under the
   **Files** icon) and select **More apps**
    ![More apps menu item](/doc/more-apps-menu-item.png)
2. Select **Upload a custom app** in the menu on the left
    ![Store menu](/doc/store-upload-custom-app.png)
3. Browse to the location of your `.zip` package containing the manifest file and the icons and
   select **Open**
4. Select the desired team to install the app for in the pop-up window and click **Install**
    ![Install app pop-up window](/doc/install-app-pop-up-window.png)
5. Follow the instructions to set up the bot, if you so desire
6. You can now find the app in the app menu:
    ![Sample app menu item](/doc/sample-app-menu-item.png)
7. Click the app in the menu to view the personal tabs, which in the case of the sample look like this:
    ![Sample app tabs](/doc/sample-app-tabs.png)



(WORK IN PROGRESS THIS IS! TEXT BELOW MIND YOU NOT.)

* Getting started with Bot Framework v4: https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-sdk-quickstart?view=azure-bot-service-4.0
* Azure AD: https://docs.microsoft.com/en-us/azure/app-service/app-service-mobile-how-to-configure-active-directory-authentication
