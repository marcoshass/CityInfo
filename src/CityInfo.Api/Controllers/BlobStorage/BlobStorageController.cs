using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Api.Controllers.BlobStorage
{
    [Route("api/blobstorage")]
    [ApiController]
    public class BlobStorageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public BlobStorageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("uploadfile")]
        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file,
            CancellationToken cancellationToken = default)
        {
            var blobServiceClient = new BlobServiceClient(_configuration["StorageConnectionString"]);
            var container = blobServiceClient.GetBlobContainerClient("rawimages");
            await container.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);

            BlobClient blobClient = container.GetBlobClient(file.FileName);

            var fileStream = file.OpenReadStream();
            await blobClient.UploadAsync(fileStream, true, cancellationToken);
            fileStream.Close();

            return Created(string.Empty, file.FileName);
        }
    }
}
