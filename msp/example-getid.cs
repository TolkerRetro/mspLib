static async Task Main() {

	var (Result, Error, Success, Json) = await mspClient.GetActorIdByName("Pixi Star");

	if (!Success || Result == 0) return;

	Console.WriteLine($ "ID: {Result} = Pixi Star");

	Console.ReadLine();

}
