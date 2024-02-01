namespace NurRealEstateWebApp.Models
{
    public class FilterViewModel
    {
        public string SearchValue { get; set; }
        public string BuyRent { get; set; }
        public string PropertyType { get; set; }
        public string bed { get; set;}
        public string bath { get; set; }
        public float  min { get; set; }
        public float  max { get; set; }
    }
}

/* search_value
buy_rent
property_type
beds_baths
price
*/
