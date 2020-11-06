static async Task Main() {

	var (Result, Error, Success, Json) = await mspClient.GetActorIdByName("Pixi Star");

	if (!Success || Result.Value == 0) return;

	SendAutograph AResult = await mspClient.SendAutograph(Result);

	if (!AResult.Success) return;

	Console.ReadLine();

}
