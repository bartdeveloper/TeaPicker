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
            new() { Id = 1, Name = "Black", Description = "Typical black tea", BrewingTemp = 100, BrewingTime = 3, ImageUri = "https://media.istockphoto.com/photos/black-tea-in-glass-cup-picture-id177555555" },
            new() { Id = 2, Name = "Pu-erh", Description = "Pu-erh tea is an aged, partially fermented tea that is similar to black tea in character. Pu-erh teas brew up an inky brown-black color and have a full body with a rich, earthy, and deeply satisfying taste.", BrewingTemp = 100, BrewingTime = 3, ImageUri = "https://dhb3yazwboecu.cloudfront.net/1007/fotosProducto/tes/11001_PuErhOriginal_1000x1000_l.jpg" },
            new() { Id = 3, Name = "Green", Description = "Green tea is another type of tea made from the camellia sinensis plant. Green teas often brew up a light green or yellow color, and tend to have a lighter body and milder taste.", BrewingTemp = 90, BrewingTime = 4, ImageUri = "https://sklep.aspol.info/wp-content/uploads/2019/10/Green-tea.jpg" },
            new() { Id = 4, Name = "White", Description = "White tea is a delicate, minimally processed tea that is highly sought after by connoisseurs and enjoyed by experts and novices alike. White tea has a light body and a mild flavor with a crisp, clean finish. ", BrewingTemp = 100, BrewingTime = 5, ImageUri = "https://sklep.aspol.info/wp-content/uploads/2021/06/white-tea-47172F.jpg" },
            new() { Id = 5, Name = "Oolong", Description = "Oolong is a partially oxidized tea, placing it somewhere in between black and green teas in terms of oxidation. Oolong teas can range from around 10-80% oxidation, and can brew up anywhere from a pale yellow to a rich amber cup of tea.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://www.coffeedesk.pl/blog/wp-content/uploads/2020/05/organic-herbata-zaparzona-1920x1280.jpg" },
            new() { Id = 6, Name = "Matcha", Description = "Matcha is a type of powdered green tea popular in Japan. It can be consumed on its own when whisked with water, and can also be added to lattes, smoothies, and baked goods.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://ocdn.eu/pulscms-transforms/1/SF_ktkqTURBXy9mOTE0MmM5YjQ5NDQ5OGU5Y2VkMDk0ZDNlMjNjZmNlMy5qcGVnkZMFzQSwzQJz" },
            new() { Id = 7, Name = "Mate", Description = "Mate is a tea-like drink made from a plant native to South America. Although mate is not related to the camellia sinensis tea plant, it does contain caffeine. Mate is traditionally prepared in a hollow gourd by adding leaves and hot water to the gourd to steep.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://schroniskobukowina.pl/media/magefan_blog/yerba_mate_podana_w_tradycyjnym_naczyniu.jpg" },
            new() { Id = 8, Name = "Rooibos", Description = "Rooibos is a particular type of herbal tea made from a plant native to South Africa. These teas are sometimes also referred to as red tea or red bush tea, and are naturally caffeine free. Rooibos has a full body similar to that of a black tea, which makes it a good option for people who enjoy black tea but are looking to avoid caffeine.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://cdn.galleries.smcloud.net/t/galleries/gf-45EU-8LYj-18cM_rooibos-wlasciwosci-i-zastosowanie-sposob-parzenia-herbaty-rooibos-1008x442.jpg" },
            new() { Id = 9, Name = "Herbal", Description = "Although we colloquially call herbal teas “tea,” they’re not actually related to true teas made from the camellia sinensis plant. Instead, herbal teas are composed of a blend of different herbs and spices. In general, herbal teas contain no caffeine.", BrewingTemp = 95, BrewingTime = 8, ImageUri = "data:image/jpeg;base64,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" },
            new() { Id = 10, Name = "Purple", Description = "Purple tea is a relatively new kind of tea, and has only been commercially available for a few years. The tea is produced from a rare purple-leaved tea plant found growing wild in the Assam region of India. Today, purple teas are primarily produced in Kenya, Africa. ", BrewingTemp = 95, BrewingTime = 8, ImageUri = "https://cleanplates.com/wp-content/uploads/what-is-purple-tea-610x310.jpg" },
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