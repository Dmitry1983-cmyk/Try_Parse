using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReferenseCard();
           // Parse_Card();
        }

        public string path_href = "Ссылки.txt";

        private void ReferenseCard()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;// без нее выскакивание исключения

            for (int i = 1; i <= 10; i++)
            {
                //перевел сайт в документ НАЧАЛО
                WebClient client = new WebClient();
                string htmlCode = client.DownloadString($"https://inspections.gov.ua/inspection/all-unplanned?planning_period_id=2&page={i}");
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(htmlCode);
                //перевел сайт в документ КОНЕЦ


                //получаем все ссылки на карточки и записываем в простой текстовик НАЧАЛО
                foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='table_action_btn icon-details']"))
                {
                    WebClient cl = new WebClient();
                    string path_data_card = "Данные.txt";
                    //считываем текстовик где записаны все ссылкиб и записываем в Htmldoc НАЧАЛО
                    string html = cl.DownloadString("https://inspections.gov.ua" + node.GetAttributeValue("href", null));
                    HtmlAgilityPack.HtmlDocument doc_card = new HtmlAgilityPack.HtmlDocument();
                    doc_card.LoadHtml(html);

                    //считываем каждую ссылку НАЧАЛО
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='vertical_table table table-bordered table-striped']/tbody/tr[3]"))
                    {
                        var inn = data_client.SelectSingleNode("td[2]");
                        txt.Text += "Inn : " + inn.InnerText + "\t";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); break;
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody/tr[3]"))
                    {
                        var inn = data_client.SelectSingleNode("td[2]");
                        txt.Text += "Organ : " + inn.InnerText + "\t";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody/tr[5]"))
                    {
                        var inn = data_client.SelectSingleNode("td[2]");
                        txt.Text += "Sfera : " + inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='page_header']"))
                    {
                        var inn = data_client.SelectSingleNode("h1");
                        txt.Text += inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
                    {
                        var inn = data_client.SelectSingleNode("tr[1]");
                        txt.Text += inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='vertical_table table table-bordered table-striped']/tbody"))
                    {
                        var inn = data_client.SelectSingleNode("tr[7]");
                        txt.Text += inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); break;
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
                    {
                        var inn = data_client.SelectSingleNode("tr[2]");
                        txt.Text += inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
                    {
                        var inn = data_client.SelectSingleNode("tr[7]");
                        txt.Text += inn.InnerText + "  ";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
                    {
                        var inn = data_client.SelectSingleNode("tr[4]");
                        txt.Text += inn.InnerText + "\r\n";
                        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
                        {
                            sw.WriteLine(txt.Text); 
                        }
                    }
                    using (StreamReader sr = new StreamReader(path_data_card))
                    {
                        txt.Text = (sr.ReadToEnd());
                    }
                }
            }

            

            ////перевел сайт в документ НАЧАЛО
            //WebClient client = new WebClient();
            //string htmlCode = client.DownloadString("https://inspections.gov.ua/inspection/all-unplanned?planning_period_id=2&page=1");
            //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //doc.LoadHtml(htmlCode);
            ////перевел сайт в документ КОНЕЦ


            ////получаем все ссылки на карточки и записываем в простой текстовик НАЧАЛО
            //foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//a[@class='table_action_btn icon-details']"))
            //{
            //    WebClient cl = new WebClient();
            //    string path_data_card = "Данные.txt";
            //    //считываем текстовик где записаны все ссылкиб и записываем в Htmldoc НАЧАЛО
            //    string html = cl.DownloadString("https://inspections.gov.ua" + node.GetAttributeValue("href", null));
            //    HtmlAgilityPack.HtmlDocument doc_card = new HtmlAgilityPack.HtmlDocument();
            //    doc_card.LoadHtml(html);
            //    //считываем текстовик где записаны все ссылки и записываем в Htmldoc КОНЕЦ

            //    //считываем каждую ссылку НАЧАЛО
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='vertical_table table table-bordered table-striped']/tbody/tr[3]"))
            //    {
            //        var inn = data_client.SelectSingleNode("td[2]");
            //        txt.Text += "Inn : " + inn.InnerText + "\t";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody/tr[3]"))
            //    {
            //        var inn = data_client.SelectSingleNode("td[2]");
            //        txt.Text += "Organ : " + inn.InnerText + "\t";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody/tr[5]"))
            //    {
            //        var inn = data_client.SelectSingleNode("td[2]");
            //        txt.Text += "Sfera : " + inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='page_header']"))
            //    {
            //        var inn = data_client.SelectSingleNode("h1");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
            //    {
            //        var inn = data_client.SelectSingleNode("tr[1]");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='vertical_table table table-bordered table-striped']/tbody"))
            //    {
            //        var inn = data_client.SelectSingleNode("tr[7]");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
            //    {
            //        var inn = data_client.SelectSingleNode("tr[2]");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
            //    {
            //        var inn = data_client.SelectSingleNode("tr[7]");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }
            //    foreach (HtmlNode data_client in doc_card.DocumentNode.SelectNodes("//*[@class='inspection_table']/tbody"))
            //    {
            //        var inn = data_client.SelectSingleNode("tr[4]");
            //        txt.Text += inn.InnerText + "  ";
            //        using (StreamWriter sw = new StreamWriter(path_data_card, false, Encoding.Default))
            //        {
            //            sw.WriteLine(txt.Text); break;
            //        }
            //    }

            //    using (StreamReader sr = new StreamReader(path_data_card))
            //    {
            //        txt.Text = (sr.ReadToEnd());
            //    }
            //}
            //считываем каждую ссылку КОНЕЦ
        }
    }
}
