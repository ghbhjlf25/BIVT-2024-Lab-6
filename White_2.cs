using System;
using System.Linq;
namespace Lab_6
{
    public class White_2
    {
        public struct Participant
        {
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;

            //Свойства
            public string Surname => _surname;
            public string Name => _name;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => Math.Max(_firstJump, _secondJump);

            //Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;
            }

            //Результаты
            public void Jump(double result)
            {
                if (_firstJump == 0)
                {
                    _firstJump = result;
                }
                else if (_secondJump == 0)
                {
                    _secondJump = result;
                }
            }

            //Сортировка по убыванию лучшего результата
            public static void Sort(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                for (int i = 0; i < participants.Length - 1; i++)
                {
                    for (int j = 0; j < participants.Length - 1 - i; j++)
                    {
                        if (participants[j].BestJump < participants[j + 1].BestJump)
                        {
                            Participant temp = participants[j];
                            participants[j] = participants[j + 1];
                            participants[j + 1] = temp;
                        }
                    }
                }
            }

            //Вывод
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, " +
                                 $"Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, " +
                                 $"Лучший результат: {BestJump}");
            }
        }
    }
}