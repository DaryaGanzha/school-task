using System;

namespace CorrectSchoolTask
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var safeService = new SafeService();
            Console.WriteLine("Сейф NxN. На сейфе множество поворачиваемых рукояток, которые могут быть расположены горизонтально или вертикально. \n" +
                              "При повороте рукоятки поворачиваются все рукоятки в одной строке и в одном столбце. \n" +
                              "Сейф открывается, только если удается расположить все ручки параллельно друг другу (т.е. все вертикально или все горизонтально). \n" +
                              "В сейфе 0 и 1 это горизонтальное и вертикальное расположение рукоядки. \n" +
                              "Введите N: ");
            var cellsNum = int.Parse(Console.ReadLine() ?? string.Empty);
            var newSafe = safeService.CreateNewClosedSafe(cellsNum);
            safeService.ShowSateOfTheSafeOnConsole(newSafe);
            safeService.TypingToOpenTheSafe(newSafe);
        }
    }
}