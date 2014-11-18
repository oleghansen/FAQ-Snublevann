using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Data.Common;
using nettbutikkfaq;
using nettbutikkfaq.Models;

namespace nettbutikkfaq
{
    public class FaqController : ApiController
    {
        FaqDB faqDb = new FaqDB();

        // GET api/faq
        public HttpResponseMessage GetAll()
        {
            List<Faq> alleFaqs = faqDb.hentAlleFaqs();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(alleFaqs);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage GetUbesvarte()
        {
            List<Faq> ubesvarte = faqDb.hentUbesvarte();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(ubesvarte);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage GetCategoryFaqs(int id)
        {
            List<Faq> katFaqs = faqDb.hentKategoriFaqs(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(katFaqs);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage GetFaq(int id)
        {
            Faq faq = faqDb.hentFaq(id);
            

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(faq);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        public HttpResponseMessage PutLikeFaq(int id, Faq innFaq)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.likeFaq(id, innFaq);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke endre Faq i DB")
            };
        }


        public HttpResponseMessage PostFaq(Faq innFaq)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.leggTilFaq(innFaq);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke sette inn FAQ i DB")
            };
        }

        // GET api/Kunde/5
     /* public HttpResponseMessage Get(int id)
        {
            kunde enKunde = kundeDb.hentEnKunde(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(enKunde);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/Kunde
        public HttpResponseMessage Post(kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool OK = kundeDb.lagreEnKunde(innKunde);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke sette inn kunden i DB")
            };
        }

        // PUT api/Kunde/5
        public HttpResponseMessage Put(int id, [FromBody]kunde innKunde)
        {
            if (ModelState.IsValid)
            {
                bool OK = kundeDb.endreEnKunde(id, innKunde);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke endre kunden i DB")
            };

        }

        // DELETE api/Kunde/5
        public HttpResponseMessage Delete(int id)
        {
            bool OK = kundeDb.slettEnKunde(id);
            if (!OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke slette kunden i DB")
                };
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
      */
    }
}