namespace NurRealEstateWebApp.Service
{
    public interface IImageService
    {
        public Task<bool> UploadImages(Guid propertyId, IFormFile[] images);
    }
}
