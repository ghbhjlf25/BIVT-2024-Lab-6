using System;
using System.Linq;
namespace Lab_6
{
    public class White_3
    {
        public struct Student
        {
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skipped;

            //Свойства
            public string Surname => _surname;
            public string Name => _name;
            public int Skipped => _skipped;
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return (double)_marks.Sum() / _marks.Length;
                }
            }

            //Конструктор
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }

            //Добавление оценки или пропуска
            public void Lesson(int mark)
            {
                if (mark == 0)
                {
                    _skipped++;
                }
                else
                {
                    int[] newMarks = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        newMarks[i] = _marks[i];
                    }
                    newMarks[newMarks.Length - 1] = mark;
                    _marks = newMarks;
                }
            }

            //Сортировка массива студентов по убыванию пропусков
            public static void SortBySkipped(Student[] students)
            {
                if (students == null || students.Length == 0) return;
                for (int i = 0; i < students.Length - 1; i++)
                {
                    for (int j = 0; j < students.Length - 1 - i; j++)
                    {
                        if (students[j].Skipped < students[j + 1].Skipped)
                        {
                            Student temp = students[j];
                            students[j] = students[j + 1];
                            students[j + 1] = temp;
                        }
                    }
                }
            }

            // Метод для вывода информации о студенте
            public void Print()
            {
                Console.WriteLine($"Имя: {_name}, Фамилия: {_surname}, " +
                                 $"Средняя оценка: {AvgMark:F2}, Пропуски: {_skipped}");
            }
        }
    }
}