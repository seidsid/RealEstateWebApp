using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;
using NurRealEstateWebApp.Repository;

namespace NurRealEstateWebApp.Service
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IImageService imageService;
        private readonly NurDbContext nurDbContext;

        public PropertyService(IPropertyRepository pr, IImageService imageService, NurDbContext nurDbContext)
        {
            this.propertyRepository = pr;
            this.imageService = imageService;
            this.nurDbContext = nurDbContext;
        }

        public async Task CreateProperty(PropertyViewModel pvm)
        {
            var agent = nurDbContext.Agents.Find(pvm.Agent_id);
            var user = nurDbContext.Users.Find(pvm.User_id);

            var address = new Address
            {
                HouseNo = pvm.Address.HouseNo,
                City = pvm.Address.City,
                SubCity = pvm.Address.SubCity
            };

            var property = new Property
            {
                Title = pvm.Title,
                Description = pvm.Description,
                Price = pvm.Price,
                PropertyType = pvm.PropertyType,
                PropertySize = pvm.PropertySize,
                NoBedrooms = pvm.NoBedrooms,
                NoBathrooms = pvm.NoBathrooms,
                HasMaidsRoom = pvm.HasMaidsRoom,
                NoParking = pvm.NoParking,
                ListedDate = pvm.ListedDate,
                Status = pvm.Status,
                Address = address,
                Agent = agent,
                User = user
            };

            await propertyRepository.Persist(property);

            bool uploadedImageNames = await imageService.UploadImages(property.PropertyId, pvm.Images.ToArray());
        }

        public async Task<List<Property>> GetFilter(FilterViewModel fvm)
        {
            return await propertyRepository.GetFilters(fvm);
        }
    }
}
