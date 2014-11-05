using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nettbutikkfaq.Models
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var categories = new List<Categories>
            {
                new Categories {Name="Du", Id=1},//1
                new Categories {Name="Jeg", Id=2},//2
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var questions = new List<Questions>
            {

                new Questions{
                    Id = 1,
                    Title = "Hvem er jeg?",
                    Answer = "Du er Ole",
                    categoryid=1},
                new Questions{
                    Id = 2,
                    Title = "Hvem er du?",
                    Answer = "Vet ikke",
                    categoryid=2 },
            };
            questions.ForEach(c => context.Questions.Add(c));
            context.SaveChanges();
        }

    }
}

