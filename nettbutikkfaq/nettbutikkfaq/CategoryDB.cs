using nettbutikkfaq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nettbutikkfaq
{
    public class CategoryDB
    {
        DatabaseContext db = new DatabaseContext();

        public List<Category> hentAlleCategories()
        {
            List<Category> alleCats = new List<Category>();
            var cats = db.Categories.ToList();
            foreach (var c in cats)
            {
                var cat = new Category()
                {
                    id = c.Id,
                    name = c.Name
                };
                alleCats.Add(cat);
            }
            return alleCats;

        }
        /*
               public List<Faq> hentUbesvarte()
               {
                   List<Faq> alleUbesvarte = new List<Faq>();
                   var ubesvarte = db.Faqs.Where(p => p.Answer == null).ToList();
                   foreach (var f in ubesvarte)
                   {
                       var spors = new Faq()
                       {
                           id = f.Id,
                           name = f.Name,
                           epost = f.Epost,
                           title = f.Title,
                           question = f.Question,
                           answer = f.Answer,
                           category = f.Category.Name
                       };
                       alleUbesvarte.Add(spors);
                   }
                   return alleUbesvarte;

               }

               public List<Faq> hentKategoriFaqs(int id)
               {
                   List<Faq> katFaqs = new List<Faq>();
                   var faqs = db.Faqs.Where(p => p.CategoriesId == id && p.Answer != null).OrderBy(p=>p.Title).ToList();
                   foreach (var f in faqs)
                   {
                       var faq = new Faq()
                       {
                           id = f.Id,
                           name = f.Name,
                           epost = f.Epost,
                           title = f.Title,
                           question = f.Question,
                           answer = f.Answer,
                           category = f.Category.Name
                       };
                       katFaqs.Add(faq);
                   }
                   return katFaqs;
               }*/
    }
}