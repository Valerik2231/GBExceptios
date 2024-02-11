using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model.MyAppExceptions;

namespace ConsoleApp5.Model
{
    internal class Human
    {

        public string Firstname { get; set; }
        public string Surname{ get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string TelephoneNumber { get; set; }
        public string Sex { get; set; }

        public Human(string surname, string firstname, string patronymic, string birthday, string telephoneNumber, string sex)
        {
            Firstname = NameValidator(firstname); //Сделать эксепшен не должен содержать чисел
            Surname = NameValidator(surname);
            Patronymic = NameValidator(patronymic);
            Birthday = DateValidator(birthday); //Сделать эксепшен
            TelephoneNumber = TelNumberValidator(telephoneNumber); //Сделать эксепшен
            Sex = SexValidator(sex); //Сделать эксепшен
        }



        private string NameValidator(string str)
        {
            if (str.All(char.IsLetter))
            {
                return str;
            }
            throw new NotImplementedException();
        }
        private string DateValidator(string dateStr) 
        {
            var data = dateStr.Split(".");
            if (data.Length is not 3) {
                throw new HumanBirthdayNotValidException("Дата введена не проавильно. Пример проавильного ввода: dd.mm.yyyy " +$"Ваш ввод: {dateStr}");
            }

            if (data[0].All(char.IsDigit))
            {
                var day = int.Parse(data[0]);
                if (day < 0 || day > 31)
                {
                    throw new HumanBirthdayNotValidException($"день не может быть {day}");
                }
            }
            else throw new HumanBirthdayNotValidException("Дата введена не правильно");
            if (data[1].All(char.IsDigit))
            {
                var mouth = int.Parse(data[1]);
                if (mouth < 0 || mouth > 12)
                {
                    throw new HumanBirthdayNotValidException($"Месяц не может быть {mouth}");
                }
            }
            else throw new HumanBirthdayNotValidException("Дата введена не правильно");
            if (data[2].All(char.IsDigit))
            {
                var year = int.Parse(data[2]);
                if (year > DateTime.Today.Year)
                {
                    throw new HumanBirthdayNotValidException($"год не может не может быть {year}");
                }
            }
            else throw new HumanBirthdayNotValidException("Дата введена не правильно");
            return dateStr;
        }
        private string SexValidator(string str)
        {
            if(str == "f" || str == "m")
            {
                return str;
            }
            throw new HumanSexNotValidExeption($"Параметр пола не верный. Требуется \"f\" или \"m\". Введено: {str}");
        }
        private string TelNumberValidator(string telNum)
        {
            if (telNum.StartsWith("+7") is not true) throw new TelephonNumberException("Номер телефона должен начинаться с \"+7\"");
            if (telNum.Substring(1).All(char.IsDigit) is not true) throw new TelephonNumberException("Телефонный номер должен состоять только из цифр");
            if (telNum.Length is not 12) throw new TelephonNumberException("Длина номера телефона не соответсвует требованиям");
            return telNum;
        }

        public override string ToString()
        {
            return $"<{Surname}><{Firstname}><{Patronymic}><{Birthday}><{TelephoneNumber}><{Sex}>";
        }








    }
}
