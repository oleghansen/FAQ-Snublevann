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
                    Title = "Hvem er jeg?",
                    Question = "Hvem er egentlig jeg? Har jeg rett til å være noen andre?",
                    Answer = "Du er Ole. Du har ikke rett til å være noen andre",
                    CategoriesId=1},
                new Faqs{
                    Title = "Hvem er du?",
                    Question = "Hvem er egentlig du? Må du være deg selv?",
                    Answer = "Vet ikke. Det kan du velge selv. Stort sett.",
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

