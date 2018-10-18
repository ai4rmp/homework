using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace ConsoleApp1
{
    

    class Program
    {
        static void Main(string[] args)
        {
            List<mydataSet> mdataSet = new List<mydataSet>();
            String dataName = "data.xml";
            int NumberOfData = 0;

            XDocument doc = XDocument.Load(dataName);
            XElement root = doc.Root;


            IEnumerable<XElement> xeles = root.Elements();//拿到root底下所有直接子元素
            NumberOfData=xeles.Count();//資料總比數
            foreach (XElement record in xeles)
            {
                if (record != null)
                {                   
                    mydataSet tempdata = new mydataSet(record.Element("區域").Value
                        , record.Element("醫事機構名稱").Value
                        , record.Element("電話").Value
                        , record.Element("地址").Value
                        , record.Element("最後更新日期").Value);
                    mdataSet.Add(tempdata);                  
                }
                else
                {
                    Console.WriteLine("資料有遺失");
                }
            }

            foreach (var item in mdataSet) {
                
                Console.WriteLine("------分隔線------");
                Console.WriteLine(item.region);
                Console.WriteLine(item.organization);
                Console.WriteLine(item.phoneNumber);
                Console.WriteLine(item.address);
                Console.WriteLine(item.updateDay);
                
            }
            Console.WriteLine("臺中市低(中低)收入老人暨原住民活動假牙補助計畫合約診所名單");
            Console.WriteLine("資料總共 : "+NumberOfData+"筆");


            //---刪除資料---
            //try
            //{
            //    XElement removed = root.Elements("RECORD").Where(x => x.Element("醫事機構名稱").Value == "信榮牙醫診所").Single();
            //    removed.Remove();
            //    doc.Save(dataName);
            //}
            //catch
            //{
            //    Console.WriteLine("刪除失敗,找不到資料或是儲存出現問題。");
            //}

            Console.ReadLine();
        }
    }

    public class mydataSet
    {
        public String region { get; set; }
        public String organization { get; set; }
        public String phoneNumber { get; set; }
        public String address { get; set; }
        public String updateDay { get; set; }

        public mydataSet(String region, String organization, String phoneNumber, String address, String updateDay)
        {
            this.region = region;
            this.organization = organization;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.updateDay = updateDay;
        }

    }
}
