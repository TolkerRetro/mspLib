// load obfuscated picture from eg. looks, images, movies ..

static async Task Main() {
	
	  var R = await mspClient.GetNewUploads(100);

	  if (!R.Success) return;

	  List<(string Url, GetNewUploadsResult Result)> ImageData = new List<(string Url, GetNewUploadsResult Result)>();

	  R.Result.ForEach(async a => { 
   
          (Image Image, string ImageUrl) img = await ServiceCommands.LoadObfuscatedImage(a.ImageUploadId, Server.Germany, ObfuscationType.pictureupload);

          if (img.Image != null) 
	          ImageData.Add((img.ImageUrl, a));
    
	});

	ImageData.ForEach(a = >Console.WriteLine($ "Image: {a.Result.ImageUploadId} ~ {a.Url}"));

}
