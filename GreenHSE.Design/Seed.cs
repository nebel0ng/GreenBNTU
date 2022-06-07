using GreenBNTU.Design.Models;
using GreenBNTU.Design.Repository;

namespace GreenBNTU.Design
{
    public class Seed
    {
        private readonly Context context;

        public Seed(Context context)
        {
            this.context = context;
        }

        public void SeedContext()
        {
            if (!context.Projects.Any())
            {
                var projects = new List<Project>()
                {
                    new Project
                    {
                        Name = "Project1",
                        Desc = "С учётом сложившейся международной обстановки, современная методология разработки, в своём классическом представлении, допускает внедрение распределения внутренних резервов и ресурсов. Кстати, базовые сценарии поведения пользователей рассмотрены исключительно в разрезе маркетинговых и финансовых предпосылок. И нет сомнений, что акционеры крупнейших компаний освещают чрезвычайно интересные особенности картины в целом, однако конкретные выводы, разумеется, разоблачены.",
                        SignUpTill = DateTime.Parse("20.06.2022"),
                        Link = "https://docs.google.com/forms/d/1NXIfxA_oSN4CWkiNn_ja8hK0y18CEMTixGtIMLagSmk/edit"
                    },
                    new Project 
                    { 
                        Name = "Project2", 
                        Desc = "Как уже неоднократно упомянуто, интерактивные прототипы формируют глобальную экономическую сеть и при этом - функционально разнесены на независимые элементы. Противоположная точка зрения подразумевает, что некоторые особенности внутренней политики неоднозначны и будут в равной степени предоставлены сами себе. С другой стороны, начало повседневной работы по формированию позиции в значительной степени обусловливает важность как самодостаточных, так и внешне зависимых концептуальных решений.", 
                        SignUpTill = DateTime.Parse("12.07.2022"), 
                        Link = "https://docs.google.com/forms/d/1NXIfxA_oSN4CWkiNn_ja8hK0y18CEMTixGtIMLagSmk/edit"
                    }

                };

                context.Projects.AddRange(projects);   
                

            }

            if (!context.Locations.Any())
            {
                var locations = new List<Location>()
                {
                    new Location
                    {
                        Address = "ул. Франциска Скорины 25/1",
                        Description = "БНТУ 16 корпус",
                        GeoLat = 53.92899417117913,
                        GeoLong = 27.66917524947183,
                        RecObject = new RecyclableObject
                        {
                            Name = "Батарейки",
                            Color = "#FF0000"
                        }
                    },
                    new Location
                    {
                        Address = "ул. Волгоградская 3",
                        Description = "Копеечка",
                        GeoLat = 53.930169593984196,
                        GeoLong = 27.623708249858776,
                        RecObject = new RecyclableObject
                        {
                            Name = "Пластик", 
                            Color = "#8FCE00"
                        }
                    }
                };

                context.Locations.AddRange(locations);
                
            }

            context.SaveChanges();
        }
    }
}
