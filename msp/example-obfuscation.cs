// load obfuscated picture from eg. looks, images, movies ..

static async Task Main() {

            var R = await mspClient.GetNewUploads(100);

            if (!R.Success) return;

            List<(string Url, UploadImage Result)> ImageData = new List<(string Url, UploadImage Result)>();

            R.Result.Images.ForEach(async a => {

                (Image Image, string ImageUrl) img = await MspClientCommands.LoadObfuscatedImage(a.Id, Server.Germany, ObfuscationType.pictureupload);

                if (img.Image != null)
                    ImageData.Add((img.ImageUrl, a));

            });

            ImageData.ForEach(a => Console.WriteLine($"Image: {a.Result.Id} ~ {a.Url}"));
}
