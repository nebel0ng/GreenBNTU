using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenBNTU.Design.Models
{
    public class RecyclableObject
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Название типа")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Путь к файлу маркера")]
        public string Color { get; set; }

        public RecyclableObject()
        {

        }
        public RecyclableObject(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
