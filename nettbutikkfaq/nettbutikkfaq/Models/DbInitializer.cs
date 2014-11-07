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
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Har dere butikker?",
                    Question = "Har dere butikker i Norge eller eksisterer dere kun som nettbutikk?",
                    Answer = "Vi eksisterer for øyeblikket kun som nettbutikk og har foreløping ingen planer om å endre på det.",
                    CategoriesId=1},
                new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Kan jeg være sikker på at det er lovlig å handle fra dere?",
                    Question = "Kan jeg være sikker på at det er lovlig å handle fra dere, og er det i det hele tatt lov å selge alkohol på internett?",
                    Answer = "Du kan ikke være sikker på at det er lovlig å handle fra oss. Du kan faktisk være helt sikker på at det ikke er lov.",
                    CategoriesId=1 },

                new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hvordan fraktes varene?",
                    Question = "Hvordan fraktes varenee fra lager og hjem til meg? Kan jeg være sikker på at noe ikke knuser på veien?",
                    Answer = "Dine varer fraktes fra lageret våres i Oslo og hele veien hjem til din dør av fotgjenger Gudleik Knotten, som forøvrig er er aktivt fargeblind og overkjørt en rekke ganger.",
                    CategoriesId=2 },
                new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hva er leveringstiden?",
                    Question = "Hva er leveringstiden deres?",
                    Answer = "Dette avhenger såklart av hvor i landet du bor. Gudleik Knotten er ikke lenger noen ungkalv og vår levering ligger på ca. 25-30 arbeidsdager, noe avhengig av vær og temperatur.",
                    CategoriesId=2 },

                new Faqs{
                    Name= "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hva er leveringstiden?",
                    Question = "Hva er leveringstiden deres?",
                    Answer = "Dette avhenger såklart av hvor i landet du bor. Gudleik Knotten er ikke lenger noen ungkalv og vår levering ligger på ca. 25-30 arbeidsdager, noe avhengig av vær og temperatur.",
                    CategoriesId=2 },
                new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hvor lang er reklamasjonsfristen?",
                    Question = "Hvor lang reklamasjonsfrist har dere?",
                    Answer = "Vår reklamasjonsfrist er på to måneder etter brukeren har fått varene levert.",
                    CategoriesId=3 },

                 new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hva kreves for at jeg kan reklamere?",
                    Question = "Har dere noen spesielle retningslinjer ang. kjøpte varer i forhold til reklamasjon",
                    Answer = "Tomme flasker kan ikke reklameres på",
                    CategoriesId=3 },

                 new Faqs{
                    Name = "FAQ",
                    Epost = "faq@snublevann.no",
                    Title = "Hvordan kan jeg betale hos dere?",
                    Question = "Hvilke betalingsalternativer har dere?",
                    Answer = "Du kan betale med Visa/MasterCard, faktura, eller ved levering (husk tips til Gudleik)",
                    CategoriesId=4 },


                    // Ubesvarte spørsmål
                 new Faqs{
                    Name = "Linda Hansen",
                    Epost = "coolgirl96@gmail.com",
                    Title = "Jeg er for ung til å drikke. Kan jeg handle hos dere?",
                    Question = "Hei, jeg er 17 og blir 18 om en måned. Kan jeg pliiiiiiiis få kjøpe alkohol hos dere? Klemz",
                    CategoriesId=5 },

                  new Faqs{
                    Name = "Gudleik Knotten",
                    Epost = "gudleik_flaaklypa@ivocaprino.no",
                    Title = "Trenger litt hjelp",
                    Question = "Hei på dekk karer. Ringte dekk men fikk itte no svar. Er i Steinkjær, er ei addresse je itte finn. Sender detta fra den nye telefonen dekk ga meg, Iphone. Den er flott altså. Fint om dekk kan ringe meg.",
                    CategoriesId=6 },
                  new Faqs{
                    Name = "Ole Hansen",
                    Epost = "olehansen@gmail.com",
                    Title = "Har ikke fått min bestilling",
                    Question = "Hei. Bestilte et par flasker rødvin fra dere til Steinkjær for en snau måned siden. Hvor blir de av?",
                    CategoriesId=2 },

                  new Faqs{
                    Name = "Christine Larsen",
                    Epost = "christinelarsen@gmail.com",
                    Title = "Vil dere kjøpe min vin?",
                    Question = "Jeg lager min egen tyttebærvin som jeg kunne tenke meg å få ut på markedet. Jeg plukker og stamper alle bæra sjøl. Tilsetter også noen hemmelige ingredienser. Ring meg så tar vi en prat.",
                    CategoriesId=6 },
            };
            faqs.ForEach(c => context.Faqs.Add(c));
            

            var categories = new List<Categories>
            {
                new Categories {Name="Butikk"},//1
                new Categories {Name="Frakt og levéring"},//2
                new Categories {Name="Reklamasjon"},//3
                new Categories {Name="Betaling"},//4
                new Categories {Name="Kjøp"},//5
                new Categories {Name="Annet"}//6
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();


        }

    }
}

