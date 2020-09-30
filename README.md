
![msplib](https://files.catbox.moe/lq201t.jpg)

[![Discord Server](https://img.shields.io/discord/708318629112053841?color=darkcyan&label=Discord&logo=Discord&logoColor=white&style=flat-square)](https://discord.gg/dolo) 
[![Nuget](https://img.shields.io/nuget/v/Dolo.msplib?logo=nuget&style=flat-square)](https://www.nuget.org/packages/Dolo.msplib/)

![Info](https://placehold.it/15/F09B9D/000000?text=+) `This is a library for developing MovieStarPlanet tools. and no hack or cheat. We do not offer ready-made programs.`  

> *the most powerful and best library for moviestarplanet.*   
> *with msplib you can easily create tools or other things for moviestarplanet.* 

# Installation

*Install the msplib with the console **nuget package manager** or browse **MovieStarPlanet** in **visual studio nuget manager***

```
Install-Package Dolo.msplib
```

# Start

*as soon as the library is installed you can start directly. First you have to create an instance of the class **MspClient**. the parameter is the server where the client connects. to be able to use the commands. you have to be logged in.*   

*You can login with **username** &' **password** or with the **username** &' **ticket***

> **simple login with keepalive**

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

Console.WriteLine(mspLogin.LoggedIn ? mspLogin.Actor.Starcoins.ToString() : mspLogin.Status);

```

for more examples [click here](https://github.com/cydolo/mspLib/tree/master/msp)

# Documentation

documentation of the msplib can be found here [msplibdoc](https://msplib.cbkdz.eu)
 
for any help join our discord server or [create a new issue](https://github.com/cydolo/mspLib/issues)

# Changelog

for release notes or changelog examples [click here](https://github.com/cydolo/mspLib/blob/master/msp/changelog.md)
