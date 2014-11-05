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
            var faqs = new List<Faqs>
            {

                new Faqs{
                    Id = 1,
                    Title = "Hvem er jeg?",
                    Answer = "Du er Ole",
                    CategoriesId=1},
                new Faqs{
                    Id = 2,
                    Title = "Hvem er du?",
                    Answer = "Vet ikke",
                    CategoriesId=2 },
            };
            faqs.ForEach(c => context.Faqs.Add(c));
            

            var categories = new List<Categories>
            {
                new Categories {Name="Du"},//1
                new Categories {Name="Jeg"},//2
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();


        }

    }
}

