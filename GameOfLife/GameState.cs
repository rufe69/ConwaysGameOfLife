namespace GameOfLife
{
    /// <summary>
    /// Определяет состояние игры
    /// </summary>
    public class GameState
    {
        public GameState()
        {
            Status = GameStatus.NotSet;
            IsEnd = false;
        }

        /// <summary>
        /// Статус игры
        /// </summary>
        public GameStatus Status { get; private set; }

        /// <summary>
        /// Возвращает статус игры true - сыграна, false - не сыграна
        /// </summary>
        public bool IsEnd { get; private set; }

        /// <summary>
        /// Устанавливает статус окончания игры
        /// </summary>
        /// <param name="status"></param>
        public void EndGame(GameStatus status)
        {
            Status = status;
            IsEnd = true;
        }
    }
}
