static async Task Main() {

	string username, password, actor;

	username = "Username";
	password = "Password";
	actor = "Pixi Star";

	var mspClient = new MspClient(Server.Germany);

	var mspLogin = await mspClient.Login(username, password);

	if (!mspLogin.LoggedIn) return;

	var (Result, Error, Success) = await mspClient.GetActorIdByName(actor);

	if (!Success || Result.Value == 0) return;

	var AResult = await mspClient.SendAutograph(Result.Value);

	if (!AResult.Success) return;

	Console.ReadLine();

}
