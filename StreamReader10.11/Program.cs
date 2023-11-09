using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //запись в файл
            using (StreamWriter sw = new StreamWriter("result.txt", true))
            {
                //чтение из файла
                using (StreamReader sr = new StreamReader("supplier_b_import.txt", Encoding.UTF8))
                {
                    string line;
                    String qualityResult;
                    

                    while ((line = sr.ReadLine()) != null)
                    {
                        StringBuilder str = new StringBuilder();
                        string[] array = line.Trim().Split(',');
                        string name = array[0].Trim();
                        string type = array[1].Trim();
                        string inn = array[2].Trim();
                        string quality = array[3].Trim();
                        string date = array[4].Trim();


                        foreach (var item in quality)
                        {
                            if (Char.IsDigit(item))
                            {
                                str.Append(item);
                            }
                        }
                        qualityResult = str.ToString();




                        DateTime dates;
                        if (DateTime.TryParse(date, out dates))
                        {
                            
                            string dateResult = dates.ToString("yyyy\\-MM\\-dd");

                            
                            string editedLine = $"{name}, {type}, {inn}, {qualityResult}, {dateResult}";
                            sw.WriteLine(editedLine);
                        }






                    }
                    
                }
                

            }
            
            Console.ReadKey();
        }
    }
}
