using HtmlAgilityPack;
using Station.Common.Mapper;
using Station.Models;
using System.Net;
namespace Station.Parser
{
    public class AutoParser
    {

        WebClient webClient = new WebClient();
        List<RefuellingDTO> refuellings = new List<RefuellingDTO>();
        public List<RefuellingDTO> Print()
        {
   
            string page = "https://azs.belorusneft.by/sitebeloil/ru/center/azs/center/fuelandService/price";

            HtmlWeb doc = new HtmlWeb();
            var HTML = doc.Load(page);
            var data = HTML.DocumentNode.SelectNodes(".//div[@class='b-left__informer']//table//tr//th");
                foreach (var item in data)
                {
                    RefuellingDTO refuelling = new RefuellingDTO
                    {
                        Name = item.ChildNodes[0].InnerText,
                       // Price = item.HasChildNodes.ToString(),

                    };
                    refuellings.Add(refuelling);

                    Console.WriteLine(item.InnerText);
                }

            var data1 = HTML.DocumentNode.SelectNodes(".//div[@class='b-left__informer']//table//tr//td");
            for (int i = 0; i < data1.Count; i++)
            {
                refuellings[i].Price = data1[i].ChildNodes[0].InnerText;
            }
                return refuellings;
        }
    }
}



