using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GreenBNTU.Design.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Описание")]
        public string Desc { get; set; }
        [Required]
        [DisplayName("Срок подачи заявки")]
        public DateTime SignUpTill { get; set; }
        [Required]
        [DisplayName("Ссылка")]
        public string Link { get; set; }
        public Project()
        {

        }
        public Project(string name, string desc, DateTime date, string link)
        {
            Name = name;
            Desc = desc;
            SignUpTill = date;
            Link = link;
        }
    }
}
