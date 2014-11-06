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
            List<Faq> alleFaqs = db.Faqs.Select(k => new Faq()
            {
                id = k.Id,
                title = k.Title,
                question = k.Question,
                answer = k.Answer,
                category = k.Category.Name
            }).ToList();
            return alleFaqs;
        }
    }
}