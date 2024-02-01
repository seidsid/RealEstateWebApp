using NurRealEstateWebApp.Entities;

namespace NurRealEstateWebApp.Models
{
    public class PropertyListViewModel
    {
        public List<Property> Model { get; set; }
        public FilterViewModel Filter { get; set; }
    }

}
