
![msplib](https://files.catbox.moe/3cggf5.png)

> *the most powerful and best library for moviestarplanet.*   
> *with msplib you can easily create tools or other things for moviestarplanet.* 

# Installation

*Install the msplib with the nuget package manager.*

```
Install-Package COMINGSOON
```

# Start

> *as soon as the library is installed you can start directly.*  
> *First you have to create an instance of the class **MspClient**. the parameter is the server where the client connects.*  
> *to be able to use the commands. you have to be logged in.*   
> *you can login with **username** &' **password** or with the **username** &' **ticket***

```cs

var mspClient = new MspClient(Server.Germany);

var mspLogin = await mspClient.Login("Username", "Password");
var mspLogin = await mspClient.Login(new TicketLogin() {
   Username = "Username",
   Ticket = "Ticket"
});

Console.WriteLine(mspLogin.LoggedIn ? mspLogin.Actor.StarCoins : mspLogin.Status);

```

# Documentation

documentation of the msplib can be found here [msplibdoc](https://msplib.cbkdz.eu)
