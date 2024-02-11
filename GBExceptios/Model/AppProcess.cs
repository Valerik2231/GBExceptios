using ConsoleApp5.Model.MyAppExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Model
{
    internal static class AppProcess
    {

        public static void Start()
        {
            Console.WriteLine("Введите данные в формате:\n" +
                "Иванов Иван Иванович 01.01.2024 +78005553535 f или m");
            var human = CreateHuman(Console.ReadLine());
            Write(human);

        }

        private static void Write(Human human)
        {
            string fileName = human.Surname + ".txt";
            try
            {
                File.AppendAllText(fileName, human.ToString() + "\n");
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Запись прошла успешно");
        }

        private static Human CreateHuman(string line)
        {
            string[] humanData = line.Split(' ');
            if (humanData.Length is not 6 ) 
            {
                throw new HumanDataInputInvalidException("Parameter human's in not valid. Is required 6 parameters. " +
                    $"Entered {humanData.Length} parameters");
            }
            return new Human(humanData[0], humanData[1], humanData[2], humanData[3], humanData[4], humanData[5]);

        }




    }
}
