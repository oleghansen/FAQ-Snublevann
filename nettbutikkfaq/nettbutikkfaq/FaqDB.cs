using nettbutikkfaq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace nettbutikkfaq
{
    public class FaqDB
    {
        DatabaseContext db = new DatabaseContext();

        public List<Faq> hentAlleFaqs()
        {
            List<Faq> alleFaqs = new List<Faq>();
            var faqs = db.Faqs.Where(p => p.Answer != null).ToList();
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
                    category = f.Category.Name,
                    frequency = f.Frequency
                };
                alleFaqs.Add(faq);
            }
            return alleFaqs;

        }

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
                    category = f.Category.Name,
                    frequency = f.Frequency
                };
                katFaqs.Add(faq);
            }
            return katFaqs;
        }
        public Faq hentFaq(int id)
        {
            var enFaq = new Faq();
            var faq2 = db.Faqs.Where(p => p.Id == id).ToList();
            foreach (var f in faq2)
            {
                enFaq = new Faq()
                {
                    id = f.Id,
                    name = f.Name,
                    epost = f.Epost,
                    title = f.Title,
                    question = f.Question,
                    answer = f.Answer,
                    category = f.Category.Name,
                    frequency = f.Frequency
                };
            }
            return enFaq;
            
        }

        public bool likeFaq(int id, Faq innFaq)
        {
            var faq2 = db.Faqs.Where(p => p.Id == id).ToList();
            foreach (var f in faq2)
            {
               f.Frequency++;
            }

           try
            {
                db.SaveChanges();
            }
            catch(Exception feil)
            {
                return false;
            }
           return true;

        }

        public bool leggTilFaq(Faq innFaq)
        {
            var nyFaq = new Faqs()
            {
                Id = innFaq.id,
                Name = innFaq.name,
                Title = innFaq.title,
                Epost = innFaq.epost,
                Question = innFaq.question,
                CategoriesId = innFaq.categoryid,
                Frequency = innFaq.frequency
            };
            try
            {
                db.Faqs.Add(nyFaq);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }
}