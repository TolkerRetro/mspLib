static async Task Main() {

	var (Result, Error, Success) = await mspClient.GetActorIdByName("Pixi Star");

	if (!Success || Result.Value == 0) return;

	SendAutographResult AResult = await mspClient.SendAutograph(Result.Value);

	if (!AResult.Success) return;

	Console.ReadLine();

}
