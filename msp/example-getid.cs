static async Task Main() {

	string username, password, actor;

	username    = "Username";
	password    = "Password";
	actor       = "Pixi Star";

	MspClient mspClient = new MspClient(Server.Germany);

	Login mspLogin = await mspClient.Login(username, password);

	if (!mspLogin.LoggedIn) return;

	var (Result, Error, Success) = await mspClient.GetActorIdByName(actor);

	if (!Success || Result.Value == 0) return;

	Console.WriteLine($ "ID: {Result.Value} = {actor}");

	Console.ReadLine();

}
