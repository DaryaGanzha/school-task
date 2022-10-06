namespace CorrectSchoolTask
{
    public class Safe
    {
        private readonly int _cellsNum;
        private readonly bool[,] _firstStateOfTheSafe; // первоначальное состояние сейфа
        private bool[,] _nextStateOfTheSafe; // каждое следующее изменение конфигурации сейфа

        public Safe(int cellsNum, bool[,] safe)
        {
            _cellsNum = cellsNum;
            _firstStateOfTheSafe = safe;
            _nextStateOfTheSafe = safe;
        }

        public int GetCellsNum()
        {
            return _cellsNum;
        }

        public bool[,] GetFirstStateOfTheSafe()
        {
            return _firstStateOfTheSafe;
        }

        public bool[,] GetNextStateOfTheSafe()
        {
            return _nextStateOfTheSafe;
        }

        public void SetNextStateOfTheSafe(bool[,] newSafe)
        {
            _nextStateOfTheSafe = newSafe;
        }
    }
}