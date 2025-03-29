using System;
using System.Linq;

namespace Lab_6
{
    public class White_4
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _scores;

            //Свойства
            public string Surname => _surname;
            public string Name => _name;
            public double[] Scores
            {
                get
                {
                    if (_scores == null) return Array.Empty<double>();
                    double[] copy = new double[_scores.Length];
                    Array.Copy(_scores, copy, _scores.Length);
                    return copy;
                }
            }
            public double TotalScore => _scores?.Sum() ?? 0;

            //Конструктор
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _scores = new double[0];
            }

            //Добавление результата матча
            public void PlayMatch(double result)
            {
                if (_scores == null) return;
                double[] newScores = new double[_scores.Length + 1];
                for (int i = 0; i < _scores.Length; i++)
                {
                    newScores[i] = _scores[i];
                }
                newScores[newScores.Length - 1] = result;
                _scores = newScores;
            }

            //Сортировка массива участников по убыванию общего результата
            public static void Sort(Participant[] participants)
            {
                if (participants == null || participants.Length == 0) return;
                for (int i = 0; i < participants.Length - 1; i++)
                {
                    for (int j = 0; j < participants.Length - 1 - i; j++)
                    {
                        if (participants[j].TotalScore < participants[j + 1].TotalScore)
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
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, Общий результат: {TotalScore}");
            }
        }
    }
}