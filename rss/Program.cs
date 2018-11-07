using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Net;

namespace rss
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = XDocument.Load("https://habrahabr.ru/rss/interesting/");
             
            List<Item> list = new List<Item>();
 
            var  xml = new XmlDocument();
          
            xml.Load(doc.CreateReader());
            xml.Save("data4.xml");

            var root = xml.DocumentElement;
           
            XmlNodeList linkList = xml.GetElementsByTagName("link");          
            XmlNodeList tileList = xml.GetElementsByTagName("title");           
            XmlNodeList descriptionList = xml.GetElementsByTagName("description");           
            XmlNodeList pubDateList = xml.GetElementsByTagName("pubDate");
         
            int[] array = { tileList.Count, linkList.Count, descriptionList.Count, pubDateList.Count };
            int max=array[0], min = array[0];
            foreach(int a in array)
            {
                if (max < a) max = a;
                if (min > a) min = 0;
            }
            List<Item> loadedItem = new List<Item>(max);
            for(int i = 0; i < max; i++)
            {
                loadedItem.Add(new Item());
            }
            for (int i = 0; i < max; i++)
            {
                if (i <= tileList.Count)
                {
                    loadedItem[i].Title = tileList[i].InnerText;
                }
                if (i <= linkList.Count)
                {
                    loadedItem[i].Link = linkList[i].InnerText;
                }
                if (i <= pubDateList.Count)
                {
                    loadedItem[i].PubDate = pubDateList[i].InnerText;
                }
                if (i <= descriptionList.Count)
                {
                    loadedItem[i].Discription = descriptionList[i].InnerText;
                }
                Console.WriteLine(loadedItem[i].Link+","+loadedItem[i].Title+
                    loadedItem[i].PubDate+" , "+loadedItem[i].Discription);
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
            
        }
    }
}
