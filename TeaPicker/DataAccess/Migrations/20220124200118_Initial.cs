using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaPicker.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    BrewingTemp = table.Column<double>(type: "REAL", nullable: false),
                    BrewingTime = table.Column<double>(type: "REAL", nullable: false),
                    ImageUri = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 1, 100.0, 3.0, "Many people new to the world of tea are most familiar with black tea. You can find black tea in name-brand teabags at the grocery store like Lipton or Tetley. Popular breakfast blends like English Breakfast and Irish Breakfast are other examples of black tea. Black teas tend to be relatively high in caffeine, with about half as much caffeine as a cup of coffee. They brew up a dark, coppery color, and usually have a stronger, more robust flavor than other types of tea. ", "https://media.istockphoto.com/photos/black-tea-in-glass-cup-picture-id177555555", "Black" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 2, 90.0, 4.0, "Green tea is another type of tea made from the camellia sinensis plant. Green teas often brew up a light green or yellow color, and tend to have a lighter body and milder taste. They contain about half as much caffeine as black tea (about a quarter that of a cup of coffee.) Popular green teas include Gunpowder, Jasmine Yin Cloud, and Moroccan Mint.", "https://sklep.aspol.info/wp-content/uploads/2019/10/Green-tea.jpg", "Green" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 3, 100.0, 5.0, "White tea is a delicate, minimally processed tea that is highly sought after by connoisseurs and enjoyed by experts and novices alike. White tea has a light body and a mild flavor with a crisp, clean finish. White tea tends to be very low in caffeine, although some silver tip teas may be slightly higher in caffeine. Popular white teas include Bashan Silver Tip and White Peony.", "https://sklep.aspol.info/wp-content/uploads/2021/06/white-tea-47172F.jpg", "White" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 4, 95.0, 8.0, "Oolong is a partially oxidized tea, placing it somewhere in between black and green teas in terms of oxidation. Oolong teas can range from around 10-80% oxidation, and can brew up anywhere from a pale yellow to a rich amber cup of tea. Many oolongs can be re-infused many times, with subtle differences and nuances of flavor in each successive cup.", "https://www.coffeedesk.pl/blog/wp-content/uploads/2020/05/organic-herbata-zaparzona-1920x1280.jpg", "Oolong" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 5, 95.0, 8.0, "Matcha is a type of powdered green tea popular in Japan. It can be consumed on its own when whisked with water, and can also be added to lattes, smoothies, and baked goods. Matcha has a smooth, rich flavor with notes of umami and just a hint of bitterness", "https://ocdn.eu/pulscms-transforms/1/SF_ktkqTURBXy9mOTE0MmM5YjQ5NDQ5OGU5Y2VkMDk0ZDNlMjNjZmNlMy5qcGVnkZMFzQSwzQJz", "Matcha" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 6, 95.0, 6.0, "Mate is a tea-like drink made from a plant native to South America. Although mate is not related to the camellia sinensis tea plant, it does contain caffeine. Mate is traditionally prepared in a hollow gourd by adding leaves and hot water to the gourd to steep. The tea is then consumed through a filtered straw known as a bombilla. In many South American countries, mate is shared among a group of friends by drinking and refilling the same gourd as it is passed from person to person.", "https://schroniskobukowina.pl/media/magefan_blog/yerba_mate_podana_w_tradycyjnym_naczyniu.jpg", "Mate" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 7, 95.0, 8.0, "Rooibos is a particular type of herbal tea made from a plant native to South Africa. These teas are sometimes also referred to as red tea or red bush tea, and are naturally caffeine free. Rooibos has a full body similar to that of a black tea, which makes it a good option for people who enjoy black tea but are looking to avoid caffeine. It has a pleasant natural sweetness, and is delicious when taken on its own or with a splash of milk. Rooibos can also be mixed with other ingredients to create flavored blends like Earl Grey Rooibos and Rooibos Chai.", "https://cdn.galleries.smcloud.net/t/galleries/gf-45EU-8LYj-18cM_rooibos-wlasciwosci-i-zastosowanie-sposob-parzenia-herbaty-rooibos-1008x442.jpg", "Rooibos" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 8, 99.0, 4.0, "Although we colloquially call herbal teas “tea,” they’re not actually related to true teas made from the camellia sinensis plant. Instead, herbal teas are composed of a blend of different herbs and spices. In general, herbal teas contain no caffeine. There are a wide variety of different kinds of herbal teas, including both single-ingredient teas like Peppermint and Chamomile, as well as creative blends like Lavender Lullaby and Atomic Gold.", "https://img.redro.pl/plakaty/healthy-herbal-tea-cup-teapot-and-medicinal-herbs-on-table-herbal-medicine-700-195716851.jpg", "Herbal" });

            migrationBuilder.InsertData(
                table: "Teas",
                columns: new[] { "Id", "BrewingTemp", "BrewingTime", "Description", "ImageUri", "Name" },
                values: new object[] { 9, 95.0, 8.0, "Purple tea is a relatively new kind of tea, and has only been commercially available for a few years. The tea is produced from a rare purple-leaved tea plant found growing wild in the Assam region of India. Today, purple teas are primarily produced in Kenya, Africa. They have a light body and mellow flavor, and are extremely low in caffeine and high in antioxidants and anthocyanins.", "https://cleanplates.com/wp-content/uploads/what-is-purple-tea-610x310.jpg", "Purple" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teas");
        }
    }
}
