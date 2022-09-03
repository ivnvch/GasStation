using HtmlAgilityPack;
using Station.Models;

static List<Refuelling> Parser()
{
    string path = "https://azs.belorusneft.by/sitebeloil/ru/center/azs/center/fuelandService/price";
    try
    {
        using (HttpClientHandler hdl = new HttpClientHandler 
        {AllowAutoRedirect = false,
         AutomaticDecompression = System.Net.DecompressionMethods.Deflate |
         System.Net.DecompressionMethods.GZip |
         System.Net.DecompressionMethods.None
        })
        {
            using (var clnt = new HttpClient(hdl))
            {
                using (HttpResponseMessage responce = clnt.GetAsync(path).Result)
                {
                    if (responce.IsSuccessStatusCode)
                    {
                        var html = responce.Content.ReadAsStringAsync().Result;
                        if (!string.IsNullOrEmpty(html))
                        {
                            HtmlDocument doc = new HtmlDocument();
                            doc.LoadHtml(html);

                            var tables = doc.DocumentNode.SelectNodes(".//div[@class='b-left__informer']//table");

                            if (tables != null && tables.Count > 0)
                            {
                                foreach (var item in tables)
                                {
                                    var rows = item.SelectNodes(".//tr");
                                    if (rows!= null && rows.Count > 0)
                                    {
                                        foreach (var row in rows)
                                        {
                                            var cells = row.SelectNodes(".//th");
                                            if (cells!= null && cells.Count > 0)
                                            {
                                                
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("нет таблицы");
                            }
                        }
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
       // return null;
    }
}