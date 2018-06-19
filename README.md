Teams App Sample - .NET Core
============================

[Microsoft Teams apps](https://developer.microsoft.com/en-us/microsoft-teams) are web apps.
The foundation of Teams specific apps is partially based on the building blocks that make up the
[Microsoft Bot Framework](https://dev.botframework.com/). In addition to that Teams app typically
utilize tabs (web content in `iframe`), connectors to allow rich notifications and
[more](https://developer.microsoft.com/en-us/microsoft-teams/scenarios). But that doesn't change the
fact that a Teams app is simply a web app.

![Author's highly technical illustration of a web app.](/doc/webapp.png){:height="75%" width="75%"}<br />
*Author's highly technical illustration of a web app.*

The short-lived purpose of this sample is to serve as a quick guide on how to implement a Teams app
using [Bot Framework v4](https://github.com/Microsoft/botbuilder-dotnet) - which as of writing this
is still in preview - instead of the current v3.x. A reason one might have to target the preview
version is the fact that while **v3.x is based on .NET Framework 4.x**, the new **v4 targets .NET
Core**. Furthermore, the reason one might care is based on the platform their running their
software; **.NET Core is multi-platform** including Linux. To learn more, visit
[docs.microsoft.com](https://docs.microsoft.com/en-us/dotnet/standard/choosing-core-framework-server).

Is there any reason .NET Core/Bot Framework v4 combo wouldn't work as a basis for a Teams app? Not
that I can tell - please refer to the technical outline above. As long as the web app looks the same
outside providing appropriate input and output and knows how to handle the messages the same way,
it reasonable to expect everything to just work. If it looks like a duck, swims like a duck, and
quacks like a duck... you get the point.

If it's 2019 and you're reading this, then it's fair to assume the information here is no longer of
any use as Bot Framework v4 should be the official version (no longer in preview) now. Thanks for
visiting anyways.

## So, how do I... ##

(WORK IN PROGRESS THIS IS! TEXT BELOW MIND YOU NOT.)


Deploying the bot: https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-howto-deploy-azure?view=azure-bot-service-4.0
Getting started with Bot Framework v4: https://docs.microsoft.com/en-us/azure/bot-service/dotnet/bot-builder-dotnet-sdk-quickstart?view=azure-bot-service-4.0
Azure AD: https://docs.microsoft.com/en-us/azure/app-service/app-service-mobile-how-to-configure-active-directory-authentication
