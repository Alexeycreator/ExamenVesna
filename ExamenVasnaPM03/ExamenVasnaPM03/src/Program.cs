using System;
using System.IO;
using System.Text;
using System.Linq;

namespace ExamenVasnaPM03
{
    class Program
    {
        private static int n;
        private static  Weather[] Weathers;

        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Введите массив:");
                string read = Console.ReadLine();
                while (!Int32.TryParse(read, out n))
                {
                    Console.WriteLine("Введите целое число:");
                    read = Console.ReadLine();
                }
                Weathers = new Weather[n];

                FillPogoda();
                Sort();
                SaveInFile();

                Console.ReadKey();
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
        }

        static private void FillPogoda() {
            for (int i = 0; i < n; i++) {
                Weathers[i] = new Weather();
                Console.WriteLine(String.Format("Введите температуру воздуха: ", i));
                string temperaturaT = Console.ReadLine();
                while (string.IsNullOrEmpty(temperaturaT)) {
                    Console.WriteLine("Введите температуру воздуха: ");
                    temperaturaT = Console.ReadLine();
                }
                int temperatura;
                while (!Int32.TryParse(temperaturaT, out temperatura)) {
                    Console.WriteLine("Введите целое число");
                    temperaturaT = Console.ReadLine();
                }
                Weathers[i].Temperatura = temperatura;

                Console.WriteLine(String.Format("Введите влажность воздуха: "));
                string vlagnostV = Console.ReadLine();
                while (string.IsNullOrEmpty(vlagnostV)) {
                    Console.WriteLine("Введите влажность: ");
                    vlagnostV = Console.ReadLine();
                }
                int vlagnost;
                while (!Int32.TryParse(vlagnostV, out vlagnost)) {
                    Console.WriteLine("Введите целое число");
                    vlagnostV = Console.ReadLine();
                }
                Weathers[i].Vlagnost = vlagnost;

                Console.WriteLine(String.Format("Введите давление воздуха: "));
                string davlenieD = Console.ReadLine();
                while (string.IsNullOrEmpty(davlenieD)) {
                    Console.WriteLine("Введите давление: ");
                    davlenieD = Console.ReadLine();
                }
                int davlenie;
                while (!Int32.TryParse(davlenieD, out davlenie)) {
                    Console.WriteLine("Введите целое число");
                    davlenieD = Console.ReadLine();
                }
                Weathers[i].Davlenie = davlenie;
            }

        }
        static private void Sort() {
            Weathers = Weathers.AsQueryable<Weather>().OrderByDescending(c => c.Temperatura).ThenByDescending(c => c.Vlagnost).ToArray();
            Console.WriteLine("Отсортировано!");
        }
        static private void SaveInFile() {
            using (StreamWriter sw = new StreamWriter("file.txt")) {
                foreach (Weather w in Weathers) {
                    sw.WriteLine(w.Temperatura + "°C; " + w.Vlagnost + "мм рт. ст.; " + w.Davlenie + "%; ");
                }
                Console.WriteLine("Сохранено!");
            }
        }
    }
}
