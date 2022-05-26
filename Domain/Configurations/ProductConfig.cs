using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product { 
                ProductId = 1,
                Name = "Beyerdynamics DT770 Pro 80", 
                Description = "DT 770 PRO är en sluten dynamisk hörlurar av exceptionell kvalitet som lämpar sig för de mest krävande professionella och audiofiler applikationer. Komfort och exakt prestanda gör DT 770 PRO perfekt hörlurar för inspelningsstudior, produktion eller sändning.",
                CategoryId = 3,
                Stock = 5,
                IsOnSale = false,
                Price = 1749,
                ImageThumbnailUrl = "\\Images\\dt770pro.jpg",
                ImageUrl = "\\Images\\dt770pro.jpg"
            },
            new Product
            {
                ProductId = 2,
                Name = "Sonos ARC Hemmabio paket",
                Description = "Arc utnyttjar Sonos kraftfulla nya mjukvaruplattform för att leverera Sonos mest omslutande hemmabioupplevelse hittills.",
                CategoryId = 3,
                Stock = 420,
                IsOnSale = false,
                Price = 18990,
                ImageThumbnailUrl = "\\Images\\sonos-arc.jpg",
                ImageUrl = "\\Images\\sonos-arc.jpg"
            },
            new Product
            {
                ProductId = 3,
                Name = "LG 65\" OLED 4K TV OLED65C1",
                Description = "LG OLED TV är en glädje att se. Självlysande pixlar ger en häpnadsväckande bildkvalitet och en mängd designmöjligheter, och de senaste banbrytande teknikerna tar upplevelserna till nya oöverträffade höjder. Allt du redan älskar med TV - på en ny och högre nivå.",
                CategoryId = 3,
                Stock = 55,
                IsOnSale = true,
                Price = 15790,
                ImageThumbnailUrl = "\\Images\\lg-tv.jpg",
                ImageUrl = "\\Images\\lg-tv.jpg"
            },
            new Product
            {
                ProductId = 4,
                Name = "Synology DS220+ Nas för 2 hårddiskar",
                Description = "Nas ur Synologys populära DS-serie som passar bra i både hemmiljö och mindre företag. Har plats för två hårddiskar med hot swap-stöd som kan konfigureras med bl.a. Raid 1 (ger dubbel lagringsäkerhet och påverkas inte om en disk fallerar).",
                CategoryId = 2,
                Stock = 99,
                IsOnSale = false,
                Price = 3890,
                ImageThumbnailUrl = "\\Images\\synology-ds220.jpg",
                ImageUrl = "\\Images\\synology-ds220.jpg"
            },
            new Product
            {
                ProductId = 5,
                Name = "TP-link Deco M5 Mesh-system AC1300 3-pack",
                Description = "TP-link Deco M5 är ett paket med Wireless AC-repeatrar som tillsammans kan täcka upp till 400 m² med ett enda wifi-nätverk. Ansluts direkt till fiberanslutning eller till ett befintligt modem eller router.",
                CategoryId = 2,
                Stock = 550,
                IsOnSale = true,
                Price = 2589,
                ImageThumbnailUrl = "\\Images\\deco-m5.jpg",
                ImageUrl = "\\Images\\deco-m5.jpg"
            },
            new Product
            {
                ProductId = 6,
                Name = "Asus RT-AX55 Trådlös router AX1800",
                Description = "Asus RT-AX55 är en Wifi 6-router som passar perfekt för dig som vill ha snabbt och stabilt wifi hemma med de senaste teknikerna. Genom att använda Wifi 6-standarden (802.11ax) kan routern ge upp till 1201 Mbps över 5 GHz bandet",
                CategoryId = 2,
                Stock = 55,
                IsOnSale = false,
                Price = 1290,
                ImageThumbnailUrl = "\\Images\\rt-ax55.jpg",
                ImageUrl = "\\Images\\rt-ax55.jpg"
            },
            new Product
            {
                ProductId = 7,
                Name = "Linocell Powerbank med solcellsladdning 16000 mAh",
                Description = "Kraftfullt extrabatteri för laddning av mobil, surfplatta och andra USB-enheter. Kapacitet på 16000 mAh som räcker för att ladda upp en mobil ca 6 gånger. Utrustat med ficklampa, två USB-portar (totalt 2,1 A) och laddningsindikator.",
                CategoryId = 1,
                Stock = 999,
                IsOnSale = false,
                Price = 699,
                ImageThumbnailUrl = "\\Images\\solcell-powerbank.jpg",
                ImageUrl = "\\Images\\solcell-powerbank.jpg"
            },
            new Product
            {
                ProductId = 8,
                Name = "Ifixit Pro Tech Toolkit Reparationskit",
                Description = "Med data och erfarenheter från tusentals reparationsguider och demonteringar har iFixit sammanställt ett komplett vertygskit för alla typer av reparationer – från gamla vintage-konsoler till moderna Apple-datorer och surfplattor. Innehåller bland annat 64 bits i stål samt alla verktyg som behövs för att t.ex. lossa fastlimmade skärmar och batterier och byta ut olika komponenter. Inkluderar special-bits för bl.a. Apple-enheter, spelkonsoler och kaffemaskiner. Används av allt ifrån NASA till NSA och Edward Snowden.",
                CategoryId = 1,
                Stock = 5000,
                IsOnSale = true,
                Price = 599,
                ImageThumbnailUrl = "\\Images\\ifixit.jpg",
                ImageUrl = "\\Images\\ifixit.jpg"
            },
            new Product
            {
                ProductId = 9,
                Name = "Samsung Galaxy S21 FE 128 GB Svart",
                Description = "Galaxy S21 FE med en magiskt 6.4”-disaplay med 120 Hz-bilduppdatering för en oslagbar upplevelse när du scrollar igenom hemsidor, appar och spel. Stänk- och vattentålig design och med Gorilla Glass Victus för ett ännu starkare skydd mot repor. Fingeravtrycksläsare för säker och smidig upplåsning av telefonen och inloggning i kompatibla appar.",
                CategoryId = 1,
                Stock = 10000,
                IsOnSale = false,
                Price = 8190,
                ImageThumbnailUrl = "\\Images\\galaxy-s21fe.jpg",
                ImageUrl = "\\Images\\galaxy-s21fe.jpg"
            },
            new Product
            {
                ProductId = 10,
                Name = "Jimbee Tropical",
                Description = "Jimbee Tropical är en helt ny variant av Piel de Sapo, Corazón de Oro, med ett orange fruktkött. Sorten har ett mycket sött, saftigt och krispigt fruktkött med en tropisk smak.",
                CategoryId = 4,
                Stock = 1000000,
                IsOnSale = false,
                Price = 49,
                ImageThumbnailUrl = "\\Images\\jimbee-tropical.jpg",
                ImageUrl = "\\Images\\jimbee-tropical.jpg"
            },
            new Product
            {
                ProductId = 11,
                Name = "Limelon",
                Description = "Limelon är en ny melonsort med en fräsch smak av lime. Skalet är grönrandigt och fruktköttet grönvitt. Den har en hög halt av askorbinsyra och citronsyra men är även hög i sötma vilket ger en spännande smak. Passar bra i sallader, juice och smoothies. Testa den ihop med jordgubbar!",
                CategoryId = 4,
                Stock = 5000,
                IsOnSale = false,
                Price = 39,
                ImageThumbnailUrl = "\\Images\\limelon.jpg",
                ImageUrl = "\\Images\\limelon.jpg"
            },
            new Product
            {
                ProductId = 12,
                Name = "Nätmelon italiensk",
                Description = "Denna tjockskaliga, grågröna nätmelon som är lite klyftad i skalet har en alldeles ljuvlig smak! Fruktköttet är laxfärgat, mjukt och smältande, precis som hos cantaloupe melonen. Nätmelon har fått sitt namn efter det typiska nätmönstret på skalet.Det är en dessertfrukt med mycket söt, aromatisk smak.",
                CategoryId = 4,
                Stock = 543,
                IsOnSale = false,
                Price = 59,
                ImageThumbnailUrl = "\\Images\\nätmelon-italiensk.jpg",
                ImageUrl = "\\Images\\nätmelon-italiensk.jpg"
            }
        );
    }
}