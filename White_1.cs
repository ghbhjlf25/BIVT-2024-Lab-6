using System;
using System.Linq;
namespace Lab_6
{
    public class White_1
    {
        public struct Participant
        {
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            
            //Свойства
            public string Surname => _surname ?? string.Empty;
            public string Club => _club ?? string.Empty;
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => _firstJump + _secondJump;

            //Конструктор
            public Participant(string surname, string club)
            {
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
            }

            //Запись результатов
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

            //Сортировка массива
            public static void Sort(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;

                for (int i = 0; i < participants.Length - 1; i++)
                {
                    for (int j = 0; j < participants.Length - i - 1; j++)
                    {
                        if (participants[j].JumpSum < participants[j + 1].JumpSum)
                        {
                            Participant temp = participants[j];
                            participants[j] = participants[j + 1];
                            participants[j + 1] = temp;
                        }
                    }
                }
            
            //Метод для вывода
            public void Print()
            {
                Console.WriteLine($"Фамилия: {_surname}, Клуб: {_club}, " +
                                  $"Первый прыжок: {_firstJump}, Второй прыжок: {_secondJump}, " +
                                  $"Сумма: {JumpSum}");
            }
        }
    }
}