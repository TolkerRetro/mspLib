##### 6.4.1

- hotfix ~ a invalid key in login result has been fixed.

##### 6.3.0

- Added new property Image in Login result to get the image of a actor
- Fixed a issue with Piggy and Nebula properties

###### example Image
```cs
Login Result = await mspClient.Login("Username", "Password");

if(!Result.LoggedIn)
   return;

PictureBox.Image = Result.Image.Thumbnail;
PictureBox.Load(Result.Image.ThumbnailUrl);
```

##### 6.2.0

- Added a new method to send custom commands
- Added more properties in login result
- Fixed a issue where some properties does not been used in login result
- Some Changes and Improvements

###### example custom commands
```cs
await mspClient.SendCommand("MovieStarPlanet.WebService....", TicketRequired: true, new object[] { "test" });
```

##### 6.1.1

- Added in ServerParser class a method to convert server string into type
- Added in ServerParser class a method to get all servers

###### example ServerParser
```cs
Server S = ServerParser.ParseToServer("Germany");
```
```cs
foreach (var server in ServerParser.GetAllServer())
        Console.WriteLine(server.ToString());

```
