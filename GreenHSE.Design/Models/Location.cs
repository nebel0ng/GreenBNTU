using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenBNTU.Design.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Адрес")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Долгота")]
        public double GeoLong { get; set; }
        [Required]
        [DisplayName("Широта")]
        public double GeoLat { get; set; }
        [DisplayName("Тип отходов")]
        public RecyclableObject RecObject { get; set; }

        public Location()
        {

        }
        public Location(string address, string desc, double geoLat, double geoLong, RecyclableObject recObject)
        {
            Address = address;
            Description = desc;
            GeoLong = geoLong;
            GeoLat = geoLat;
            RecObject = recObject;
        }
    }
}
