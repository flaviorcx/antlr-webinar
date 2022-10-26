using System;
using System.IO;

namespace JsonToXml.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args.Length > 0 ? args[0] : string.Empty;
            
            if (!File.Exists(path))
            {
                Console.WriteLine("No file found!");
                return;
            }
            
            var content = File.ReadAllText(path);

            var xmlBuilder = new XmlBuilder();
            var tree = xmlBuilder.ParseJson(content);
            var result = xmlBuilder.CreateXml(tree);

            Console.WriteLine(result);
        }
    }
}
