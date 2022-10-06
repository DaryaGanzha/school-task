using System;

namespace CorrectSchoolTask
{
    public class SafeService
    {
        public SafeService()
        {
        }

        private static int GetRandomNum(int cellsNum)
        {
            var randomNum = new Random();
            return randomNum.Next(0, cellsNum);
        }

        public Safe CreateNewClosedSafe(int cellsNum)
        {
            var matrix = new bool[cellsNum, cellsNum];
            for (var i = 0; i < cellsNum; i++)
            {
                for (var j = 0; j < cellsNum; j++)
                {
                    matrix[i, j] = true;
                }
            }

            for (var i = 0; i < cellsNum; i++)
            {
                var line = GetRandomNum(cellsNum);
                var column = GetRandomNum(cellsNum);
                for (var j = 0; j < cellsNum; j++)
                {
                    matrix[line, j] = !matrix[line, j];
                    matrix[j, column] = !matrix[j, column];
                }

                matrix[line, column] = !matrix[line, column];
            }

            var newSafe = new Safe(cellsNum, matrix);
            return newSafe;
        }

        public void ShowSateOfTheSafeOnConsole(Safe safe)
        {
            var cellsNum = safe.GetCellsNum();
            for (var i = 0; i < cellsNum; i++)
            {
                for (var j = 0; j < cellsNum; j++)
                {
                    Console.Write(safe.GetNextStateOfTheSafe()[i, j] == true ? "1" : "0");
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static bool OpenedTheSafe(Safe safe)
        {
            var oneOfTheValues = safe.GetNextStateOfTheSafe()[0, 0];
            for (var i = 0; i < safe.GetCellsNum(); i++)
            {
                for (var j = 0; j < safe.GetCellsNum(); j++)
                {
                    if (safe.GetNextStateOfTheSafe()[i, j] != oneOfTheValues)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void TypingToOpenTheSafe(Safe ourSafe)
        {
            var cellsNum = ourSafe.GetCellsNum();
            Console.WriteLine("Чтобы взаимодействовать с ячейкой введите номер строки, затем номер столбца через Enter.");
            while (!OpenedTheSafe(ourSafe))
            {
                var safe = ourSafe.GetNextStateOfTheSafe();
                Console.WriteLine("Введите номер строки:");
                var lineNum = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
                Console.WriteLine(("Введите номер столбца:"));
                var columnNum = int.Parse(Console.ReadLine() ?? string.Empty) - 1;
                for (var i = 0; i < cellsNum; i++)
                {
                    safe[lineNum, i] = !safe[lineNum, i];
                    safe[i, columnNum] = !safe[i, columnNum];
                }

                safe[lineNum, columnNum] = !safe[lineNum, columnNum];
                ourSafe.SetNextStateOfTheSafe(safe);
                ShowSateOfTheSafeOnConsole(ourSafe);
            }
            Console.WriteLine("Поздравляю! Вы открыли сейф!");
        }
    }
}