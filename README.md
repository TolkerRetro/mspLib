
![msplib](https://files.catbox.moe/lq201t.jpg)


[![Discord Server](https://img.shields.io/discord/708318629112053841?color=darkcyan&label=Discord&logo=Discord&logoColor=white&style=flat-square)](https://discord.gg/dolo) 
[![Nuget](https://img.shields.io/nuget/v/Dolo.msplib?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dolo.msplib/)
[![npm](https://img.shields.io/npm/v/msplib?logo=npm&style=flat-square)](https://www.npmjs.com/package/msplib)  

**for nodejs version of msplib [click here](https://www.npmjs.com/package/msplib)**

![Info](https://placehold.it/15/F09B9D/000000?text=+) `This is a library for developing MovieStarPlanet tools. and no hack or cheat.`   
![Info](https://placehold.it/15/F09B9D/000000?text=+) `We do not offer ready-made programs.`    
![Info](https://placehold.it/15/F09B9D/000000?text=+) `Learn the basics of c# &' js to use this.`  

> *the most powerful and best library for moviestarplanet.*   
> *with msplib you can easily create tools or other things for moviestarplanet.*   


# Installation

Use [Nuget](https://www.nuget.org/profiles/cydolo) to install the [mspLib](https://msplib.cbkdz.eu/installation). 
```
Install-Package Dolo.msplib
```

# Start

> A Simple way to login with KeepAlive.

```cs

var mspClient = new MspClient(new MspClientSocket()
{
    Server = Server.Germany,
    KeepAlive = true
});

var mspLogin = await mspClient.Login("Username", "Password");
var mspLogin = await mspClient.Login(new TicketLogin() {
   Username = "Username",
   Ticket = "Ticket"
});

Console.WriteLine(mspLogin.LoggedIn ? mspLogin.Actor.StarCoins.ToString() : mspLogin.Status);

```

for more examples [click here](https://github.com/cydolo/mspLib/tree/master/msp)

# Documentation

documentation of the msplib can be found here [msplibdoc](https://msplib.cbkdz.eu)
 
for any help join our discord server or [create a new issue](https://github.com/cydolo/mspLib/issues)

# Changelog

for release notes or changelog examples [click here](https://github.com/cydolo/mspLib/blob/master/CHANGELOG.md)
