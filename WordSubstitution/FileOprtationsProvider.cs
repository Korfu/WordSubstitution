using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WordSubstitution
{
     class FileOperationsProvider
    {
        [STAThread]
        public static string GetFileContent()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;
                //Console.WriteLine("Ścieżka pliku: " + path); // full path

                //Read file as string c#
                string fileAsString = File.ReadAllText(path);
                //Console.WriteLine("Plik jako string: " + fileAsString);
                    
                return fileAsString;
            }
            throw new Exception("You should've sselected a file, yo!");
        }

        [STAThread]
        public static void SaveFile(string contents)
        {
            SaveFileDialog sFile = new SaveFileDialog();
            if (sFile.ShowDialog() == DialogResult.OK)
            {
                var path = sFile.FileName;
                System.IO.File.WriteAllText(path, contents);
            }
            Console.ReadKey();
        }

        public static JObject JsonConverter(string file)
        {
            JObject fileAsJSON = JObject.Parse(file);
            Console.WriteLine("Plik jako JSON: " + fileAsJSON);
            return fileAsJSON;
        }

        public static string ReplaceString(string config, JObject replacer)
        {
            foreach (var jToken in replacer)
            {
                config = config.Replace("{{"+jToken.Key+"}}", jToken.Value.ToString());
            }
            return config;
        }

   }
}
