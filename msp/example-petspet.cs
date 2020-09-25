static async Task Main() {

	var (Result, Error, Success) = await mspClient.GetBonsterListByActor(mspLogin.Actor.ActorId);

	if (!Success) return;

	Result.ForEach(async a => await mspClient.LovePet(a.ActorBonsterRelId));

	Console.ReadLine();

}
