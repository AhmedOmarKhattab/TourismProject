using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Extensions;
using OnlineShop.Models;

namespace BrightMinds.Api.Extensions
{
    public static class DataSeeding
    {
        public static async Task<WebApplication> SeedAppData(this WebApplication application, ApplicationDbContext context)
        {
            if(!context.customers.Any())
            {
                var customers = new List<customer>
                 {
                     new customer { email = "a@gmail.com", name = ".lll", password = "123", adress = "lll", phone = "55555" },
                     new customer { email = "ahmed@gmail.com", name = "ooo", password = "123", adress = "ee", phone = "111111" },
                     new customer { email = "hager@yahoo.com", name = "hager", password = "123456", adress = "egyption", phone = "0216548486" },
                     new customer { email = "hagergg@yahoo.com", name = "رمسيس", password = "123456", adress = "alex", phone = "0115465465" },
                     new customer { email = "hh@yahoo.com", name = "ahmed yaser", password = "123456", adress = "egyption", phone = "01154654684" },
                     new customer { email = "uu500@yahoo.com", name = "lela ahmed", password = "546848", adress = "egyption", phone = "01545464646" },
                     new customer { email = "ytr300@yahoo.com", name = "lela ahmed", password = "78915456", adress = "egyption", phone = "01154544488" },
                     new customer { email = "yur@gmail.com", name = "gamila ahmed", password = "7879464", adress = "egyption", phone = "01465484879" }
                 };

                context.AddRange(customers);
                await context.SaveChangesAsync();
            }
            if(!context.Trips.Any())
            {
                var trips = new List<Trip>
{
    new Trip
    {
        tripplace = "دهب",
        godate = "12/5/2023",
        comingdate = "15/5/2023",
        travelmethod = "باص",
        traveldes = "دهب هي مدينة مصرية سياحية تتبع محافظة جنوب سيناء وتقع على خليج العقبة، وتبعد حوالي 100 كم عن مدينة شرم الشيخ و87 كم عن مدينة نويبع، ولقد سُمّيت بهذا الاسم تيمناً بلون رمالها الذهبي. وتنقسم المدينة إلى قسمين، الأول يقع جنوباً ويسمى قرية العسلة وتشتهر بالحياة البدوية البسيطة، والقسم الثاني يقع شمالاً ويعد روح ونبض المدينة بسبب اشتماله على الأسواق التجارية والأماكن الترفيهية، وتشتهر المدينة بشواطئها البكر الصافية ومواقع الغطس الطبيعية الغنية بالشعاب المرجانية.",
        tiketprice = "1000",
        hotel = "الهيلتون",
        city = "القاهرة",
        image = "706557560bluehole.jpg",
        type = "رحلات داخلية",
        time = "9"
    },
    new Trip
    {
        tripplace = "اسوان",
        godate = "12/6/2023",
        comingdate = "15/6/2023",
        travelmethod = "الطائرة",
        traveldes = "مدينة أسوان هي عاصمة محافظة أسوان في مصر. اعتبرت أسوان تاريخيًا إحدى أهم مدن جنوب مصر والبوابة الجنوبية لها، حيث يقع إلى الجنوب منها الشلال الأول لنهر النيل والذي مَثَّل حدًا طبيعيًا بين صعيد مصر والنوبة. تقع المدينة على الضفة الشرقية لنهر النيل. يصلها بالقاهرة خط سكة حديد وطرق برية صحراوية وزراعية ومراكب نيلية ورحلات جوية محلية. ويبلغ عدد سكانها تقريبا 900 ألف نسمة. وهي واحدة من المدن المبدعة المسجلة في قائمة اليونسكو في مجال الحرف والفنون منذ 2005م.",
        tiketprice = "1000",
        hotel = "ماريوت",
        city = "القاهرة",
        image = "155432567aswan.jpg",
        type = "رحلات داخلية",
        time = "5"
    },
    new Trip
    {
        tripplace = "امريكا",
        godate = "12/6/2023",
        comingdate = "17/6/2023",
        travelmethod = "الطائرة",
        traveldes = "الساحل الشمالي هو الشريط الواقع في أقصى شمال مصر والممتد على مسافة 1050 كم من مدينة رفح في شرق سيناء إلى السلوم في أقصى غرب مصر على الحدود الليبية على ساحل البحر الأبيض المتوسط، ويتميز بمياهه الزرقاء ورماله الذهبية الناعمة. ولكن المقصود اصطلاحا ما كان يعرف بساحل مريوط وهو الجزء الواقع غرب الإسكندرية مرورا بالحمام، العلمين، سيدي عبد الرحمن، الضبعة، فوكة، رأس الحكمة، ومرسى مطروح ثم النجيلة، وسيدي براني، وحتى معبر السلوم.",
        tiketprice = "1000",
        hotel = "الشيرتون",
        city = "القاهرة",
        image = "1774883076sahel.jpg",
        type = "رحلات خارجية",
        time = "10"
    },
    new Trip
    {
        tripplace = "تايلاند",
        godate = "12/7/2024",
        comingdate = "15/8/2024",
        travelmethod = "الطائرة",
        traveldes = "تايلاند بها أجمل الشواطئ الموجودة في العالم مما يجعل قضاء عطلة شاطئية مع العائلة في منتجع على شاطئ رملي رحلة عائلية فريدة من نوعها. أيضاً زيارة المعالم الأثرية أو الإستمتاع بعروض الحيوانات الممتعة مثل عروض الفيلة والقرد والدرافيل تجعل البرنامج فريد من نوعه.",
        tiketprice = "500",
        hotel = "الهيلتون",
        city = "القاهرة",
        image = "372668448download.jpg",
        type = "",
        time = "16:37"
    }
};
                context.Trips.AddRange(trips);
                await context.SaveChangesAsync();

            }
            if(!context.Hotels.Any())
            {
                var hotels = new List<Hotel>
{
    new Hotel
    {
        Name = "فندق قصر الشرق",
        Description = "تجربة إقامة ملكية فاخرة في قلب المدينة مع إطلالات بانورامية خلابة وخدمات متميزة على مدار الساعة.",
        ImageUrl = "hotel1.jpg",
        Price=5000
    },
    new Hotel
    {
        Name = "منتجع شاطئ الياقوت",
        Description = "اهرب من ضجيج المدينة واستمتع بالهدوء على شواطئنا الخاصة والرمال الذهبية والمياه الفيروزية.",
        ImageUrl = "hotel2.webp",
        Price=8000
    },
    new Hotel
    {
        Name = "فندق نسمة الجبل",
        Description = "يقع وسط الجبال الخضراء، ويوفر أجواءً هادئة ومثالية لمحبي الطبيعة والمغامرات الجبلية.",
        ImageUrl = "hotel3.webp"
    },
    new Hotel
    {
        Name = "فندق الواحة التراثي",
        Description = "فندق يجمع بين عبق الماضي وتصاميم التراث العربي الأصيل مع توفير كافة سبل الراحة الحديثة.",
        ImageUrl = "hotel4.jpg",
        Price=7500
    },
    new Hotel
    {
        Name = "أجنحة المدينة العصرية",
        Description = "خيار مثالي لرجال الأعمال والمسافرين، يتميز بموقع استراتيجي بالقرب من المركز التجاري والمطار.",
        ImageUrl = "hotel1.jpg",
        Price=3000

    }
};

                context.AddRange(hotels);
                await context.SaveChangesAsync();

            }
            var t = context.Transportaions.ToList();
            context.RemoveRange(t);
            context.SaveChanges();
            if(!context.Transportaions.Any())
            {
                var transportList = new List<Transportaion>
{
    new Transportaion
    {
        Name = "حافلة النقل السريع",
        Price = 50.00m,
        Description = "حافلة مريحة ومكيفة مخصصة للرحلات الطويلة بين المدن مع مقاعد قابلة للانحناء.",
        ImageUrl = "bus.webp"
    },
    new Transportaion
    {
        Name = "قطار السكك الحديدية",
        Price = 120.50m,
        Description = "وسيلة نقل سريعة وآمنة تصل بين المحافظات الرئيسية، تتميز بدقة المواعيد والراحة التامة.",
        ImageUrl = "train.jpg"
    },
    new Transportaion
    {
        Name = "طائرة الخطوط الجوية",
        Price = 1500.00m,
        Description = "أسرع وسيلة سفر للرحلات الدولية والداخلية، تشمل وجبات خفيفة وخدمات ترفيهية على متن الطائرة.",
        ImageUrl = "plane.webp"
    },
    new Transportaion
    {
        Name = "سفينة نقل الركاب",
        Price = 450.75m,
        Description = "رحلة بحرية ممتعة عبر الموانئ، توفر غرفاً مريحة وإطلالات بحرية رائعة طوال الرحلة.",
        ImageUrl = "ship.png"
    }
};  

                context.AddRange(transportList);
                await context.SaveChangesAsync();
            }


            return application;
        }
      


    }
}