using Microsoft.AspNetCore.Mvc;
using TeaPicker.Shared;

namespace TeaPicker.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeaController : ControllerBase
    {
        private static List<Tea> Teas = new()
        {
            new() { Id = 1, Name = "Black", Description = "Many people new to the world of tea are most familiar with black tea. You can find black tea in name-brand teabags at the grocery store like Lipton or Tetley. Popular breakfast blends like English Breakfast and Irish Breakfast are other examples of black tea. Black teas tend to be relatively high in caffeine, with about half as much caffeine as a cup of coffee. They brew up a dark, coppery color, and usually have a stronger, more robust flavor than other types of tea. ", BrewingTemp = 100, BrewingTime = 3, ImageUri = "https://media.istockphoto.com/photos/black-tea-in-glass-cup-picture-id177555555" },
            new() { Id = 2, Name = "Green", Description = "Green tea is another type of tea made from the camellia sinensis plant. Green teas often brew up a light green or yellow color, and tend to have a lighter body and milder taste. They contain about half as much caffeine as black tea (about a quarter that of a cup of coffee.) Popular green teas include Gunpowder, Jasmine Yin Cloud, and Moroccan Mint.", BrewingTemp = 90, BrewingTime = 4, ImageUri = "https://sklep.aspol.info/wp-content/uploads/2019/10/Green-tea.jpg" },           
            new() { Id = 3, Name = "White", Description = "White tea is a delicate, minimally processed tea that is highly sought after by connoisseurs and enjoyed by experts and novices alike. White tea has a light body and a mild flavor with a crisp, clean finish. White tea tends to be very low in caffeine, although some silver tip teas may be slightly higher in caffeine. Popular white teas include Bashan Silver Tip and White Peony.", BrewingTemp = 100, BrewingTime = 5, ImageUri = "https://sklep.aspol.info/wp-content/uploads/2021/06/white-tea-47172F.jpg" },
            new() { Id = 4, Name = "Oolong", Description = "Oolong is a partially oxidized tea, placing it somewhere in between black and green teas in terms of oxidation. Oolong teas can range from around 10-80% oxidation, and can brew up anywhere from a pale yellow to a rich amber cup of tea.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://www.coffeedesk.pl/blog/wp-content/uploads/2020/05/organic-herbata-zaparzona-1920x1280.jpg" },
            new() { Id = 5, Name = "Matcha", Description = "Matcha is a type of powdered green tea popular in Japan. It can be consumed on its own when whisked with water, and can also be added to lattes, smoothies, and baked goods.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://ocdn.eu/pulscms-transforms/1/SF_ktkqTURBXy9mOTE0MmM5YjQ5NDQ5OGU5Y2VkMDk0ZDNlMjNjZmNlMy5qcGVnkZMFzQSwzQJz" },
            new() { Id = 6, Name = "Mate", Description = "Mate is a tea-like drink made from a plant native to South America. Although mate is not related to the camellia sinensis tea plant, it does contain caffeine. Mate is traditionally prepared in a hollow gourd by adding leaves and hot water to the gourd to steep.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://schroniskobukowina.pl/media/magefan_blog/yerba_mate_podana_w_tradycyjnym_naczyniu.jpg" },
            new() { Id = 7, Name = "Rooibos", Description = "Rooibos is a particular type of herbal tea made from a plant native to South Africa. These teas are sometimes also referred to as red tea or red bush tea, and are naturally caffeine free. Rooibos has a full body similar to that of a black tea, which makes it a good option for people who enjoy black tea but are looking to avoid caffeine.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://cdn.galleries.smcloud.net/t/galleries/gf-45EU-8LYj-18cM_rooibos-wlasciwosci-i-zastosowanie-sposob-parzenia-herbaty-rooibos-1008x442.jpg" },
            new() { Id = 8, Name = "Herbal", Description = "Although we colloquially call herbal teas “tea,” they’re not actually related to true teas made from the camellia sinensis plant. Instead, herbal teas are composed of a blend of different herbs and spices. In general, herbal teas contain no caffeine.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://img.redro.pl/plakaty/healthy-herbal-tea-cup-teapot-and-medicinal-herbs-on-table-herbal-medicine-700-195716851.jpg" },
            new() { Id = 9, Name = "Purple", Description = "Purple tea is a relatively new kind of tea, and has only been commercially available for a few years. The tea is produced from a rare purple-leaved tea plant found growing wild in the Assam region of India. Today, purple teas are primarily produced in Kenya, Africa. ", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://cleanplates.com/wp-content/uploads/what-is-purple-tea-610x310.jpg" }
        };

        // Read
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var coffee = Teas.Find(o => o.Id == id);

            if (coffee is not null)
            {
                return Ok(coffee);
            }

            return NotFound("Tea not found");
        }

        // Read
        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(Teas);
        }

        // Create
        [HttpPost]
        public ActionResult Create(Tea tea)
        {
            tea.Id = Teas.Count + 1;
            Teas.Add(tea);

            var newTea = Teas.Find(o => o.Id == tea.Id);

            return Ok(newTea);
        }

        // Update
        [HttpPut]
        public ActionResult Update(Tea newTea)
        {
            var oldTea = Teas.FirstOrDefault(o => o.Id == newTea.Id);

            if (oldTea is not null)
            {
                oldTea.Name = newTea.Name;
                oldTea.Description = newTea.Description;
                oldTea.BrewingTime = newTea.BrewingTime;
                oldTea.BrewingTemp = newTea.BrewingTemp;
                oldTea.ImageUri = newTea.ImageUri;

                return Ok(newTea);
            }

            return NotFound("Tea not found");
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tea = Teas.FirstOrDefault(o => o.Id == id);

            if (tea is not null)
            {
                Teas.Remove(tea);

                return Ok();
            }

            return NotFound("Tea not found");
        }
    }
}