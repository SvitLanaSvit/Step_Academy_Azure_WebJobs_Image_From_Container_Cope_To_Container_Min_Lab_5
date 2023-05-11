using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace Azure_Meeting5_WebJobs
{
    public static class Functions
    {
        public static void ProcessBlobData(
            [BlobTrigger("images/{filename}")] Stream inputFile,
            string filename,
            [Blob("images-min/copy-{filename}", FileAccess.Write)] Stream outputFile,
            ILogger logger
            )
        {
            using(Image image = Image.Load(inputFile))
            {
                if(image != null)
                {
                    image.Mutate(x => x.Resize(200, 100));
                    image.Save(outputFile, new JpegEncoder());
                }
            }
            inputFile.CopyTo(outputFile);
            logger.LogInformation($"File to process: {filename}");
            logger.LogInformation($"{inputFile.Length} bytes");

        }
    }
}
