static async Task Main() {

    List<MspClient> multiMsp = new List<MspClient>();

    for (int i = 0; i < 5; i++) {
  
      var mspClient = new MspClient(Server.Germany);

      var mspLogin = await mspClient.Login("Username", "Password");

      if (!mspLogin.LoggedIn) continue;

      multiMsp.Add(mspClient);
   
    }

    multiMsp.ForEach(async a => await a.SendAutograph(3));

    Console.ReadLine();
}
