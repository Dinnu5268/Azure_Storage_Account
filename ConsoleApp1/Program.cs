using Azure.Storage.Blobs;
using System;

namespace BlobStorage
{
    class Program
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=demostacc001;AccountKey=8LFS7aBu1bQHe5qzF6SfG+h2ZMuqnd8qCTOgrA7vIhglSa6BILolvB+HUf45IBmF4MDb+5ME0clu+ASt8MWkaA==;EndpointSuffix=core.windows.net";
        static string ContainerName = "demo";
        static void Main(string[] args)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(ContainerName);

            var blobs = containerClient.GetBlobs();
            foreach (var blob in blobs)
            {
                Console.WriteLine(blob.Name);
                BlobClient blobclient = containerClient.GetBlobClient(blob.Name);
                blobclient.DownloadTo(@"D:\AzureStorageAccount\" +  blob.Name);
            }
            Console.Read();
        }
    }
}
