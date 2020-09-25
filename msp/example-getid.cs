static async Task Main() {

	var (Result, Error, Success) = await mspClient.GetActorIdByName("Pixi Star");

	if (!Success || Result.Value == 0) return;

	Console.WriteLine($ "ID: {Result.Value} = Pixi Star");

	Console.ReadLine();

}
