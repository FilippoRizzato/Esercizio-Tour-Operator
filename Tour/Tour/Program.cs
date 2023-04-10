using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome;
            string desti;
            string codice;
            Console.WriteLine("Inserisci il codice");
            codice = Console.ReadLine();
            TourOperator tourOperator = new TourOperator(codice);
            Console.WriteLine("Inserire un nome");
            nome = Console.ReadLine();
            Console.WriteLine("Inserire un nome e una località");
            desti = Console.ReadLine();

            tourOperator.add(nome, desti);
           

            Console.WriteLine("Numero di clienti: " + tourOperator.size());

            var client = (Tuple<string, string>)tourOperator.find(codice);
            Console.WriteLine("Cliente:"+ codice +  client.Item1 + ", " + client.Item2);

                     
            Console.ReadLine();
        }
    }
}
