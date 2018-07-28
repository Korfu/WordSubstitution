using System;
using System.IO;
using System.Windows.Forms;

namespace WordSubstitution
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj wędrowcze!");

            Console.WriteLine("Podaj plik konfiguracyjny: ");
            var config = FileOperationsProvider.GetFileContent();
           
            Console.WriteLine("Podaj plik z JSONem: ");
            var replace = FileOperationsProvider.GetFileContent();
            var replaceJSON = FileOperationsProvider.JsonConverter(replace);

            var result = FileOperationsProvider.ReplaceString(config, replaceJSON);
            Console.WriteLine(result);

            FileOperationsProvider.SaveFile(result);

            Console.ReadKey();
        }
    }
}
