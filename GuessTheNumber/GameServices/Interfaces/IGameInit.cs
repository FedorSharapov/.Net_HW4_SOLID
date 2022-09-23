using GuessTheNumber.Settings;

namespace GuessTheNumber.GameServices.Interfaces
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
