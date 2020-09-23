static async Task Main() {

	string username, password;

	username = "Username";
	password = "Password";

	MspClient mspClient = new MspClient(Server.Germany);

	Login mspLogin = await mspClient.Login(username, password);

	if (!mspLogin.LoggedIn) return;

	var (Result, Error, Success) = await mspClient.GetBonsterListByActor(mspLogin.Actor.ActorId);

	if (!Success) return;

	Result.ForEach(async a => await mspClient.LovePet(a.ActorBonsterRelId));

	Console.ReadLine();

}
