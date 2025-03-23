using System;
using System.Linq;
namespace Lab_6
{
    public class White_5
    {
        public struct Match
        {
            private int _goals;
            private int _misses;

            //Свойства
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => Goals - Misses;
            public int Score => Goals > Misses ? 3 : Goals == Misses ? 1 : 0;

            // Конструктор
            public Match(int goals, int misses)
            {
                if (goals < 0 || misses < 0)
                {
                    _goals = 0;
                    _misses = 0;
                }
                else
                {
                    _goals = goals;
                    _misses = misses;
                }
            }

            //Вывод
            public void Print()
            {
                Console.WriteLine($"Забито: {_goals}, Пропущено: {_misses}, Очки: {Score}");
            }
        }

        public struct Team
        {
            private string _name;
            private Match[] _matches;

            //Свойства
            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore
            {
                get
                {
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score;
                    }
                    return total;
                }
            }
            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;
                    }
                    return total;
                }
            }

            //Конструктор
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }

            //Добавление нового матча
            public void PlayMatch(int goals, int misses)
            {
                if (_matches == null) return;
                Match[] newMatches = new Match[_matches.Length + 1];
                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }
                newMatches[newMatches.Length - 1] = new Match(goals, misses);
                _matches = newMatches;
            }

            //Сортировка команд
            public static void SortTeams(Team[] teams)
            {
                if (teams == null || teams.Length == 0) return;

                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if ((teams[j].TotalScore < teams[j + 1].TotalScore) ||
                            (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j].TotalDifference < teams[j + 1].TotalDifference))
                        {
                            Team temp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = temp;
                        }
                    }
                }
            }

            //Вывод
            public void Print()
            {
                Console.WriteLine($"Команда: {_name}, Очки: {TotalScore}, Разность голов: {TotalDifference}");
            }
        }
    }
}