namespace GuessTheNumber.Games.Interfaces
{
    interface IGameInit
    {
        /// <summary>
        /// Инициализация игры
        /// </summary>
        /// <returns>настройки игры</returns>
        GameSettings Init();
    }
}
