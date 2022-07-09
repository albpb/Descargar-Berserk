using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace DescargarPNGs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                string capitulo;

                Console.WriteLine("---------- CAPITULO (Formato de tres digitos, Ej: 002: ---------");
                capitulo = Console.ReadLine();

                string s = client.DownloadString("https://readberserk.com/chapter/berserk-chapter-"+ capitulo+@"/");
                Regex r = new Regex(@"<a.*?href=(""|')(?<href>.*?)(""|').*?>(?<value>.*?)</a>");
                Regex r2 = new Regex(@"<img.*?src=(""|')(?<src>.*?)(""|').*?");
                int contador = 1;
                //Console.WriteLine(s);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("---------- DESCARGAR PANELES BERSERK ---------");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("----------------------------------------------");
                //foreach (Match match in r.Matches(s))
                //{
                //    Console.WriteLine(match.Groups["href"].Value + " | " + match.Groups["value"].Value);
                //}

                DirectoryInfo directory = Directory.CreateDirectory(@"C:\Users\"+ Environment.UserName +@"\Desktop\Paneles Berserk\capitulo "+ capitulo);

                foreach (Match match in r2.Matches(s))
                {
                    Console.WriteLine(match.Groups["src"].Value);
                    client.DownloadFile(new Uri(match.Groups["src"].Value), @"C:\Users\" + Environment.UserName + @"\Desktop\Paneles Berserk\capitulo " + capitulo + @"\pagina" + contador + ".jpeg");
                    contador++;
                }

            }
        }
    }
}