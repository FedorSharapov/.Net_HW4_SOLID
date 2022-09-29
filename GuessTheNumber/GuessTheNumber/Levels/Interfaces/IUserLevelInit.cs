using GuessTheNumber.Settings;

namespace GuessTheNumber.Levels.Interfaces
{
    public interface IUserLevelInit
    {
        /// <summary>
        /// Инициализация уровня игры
        /// </summary>
        /// <returns>настройки уровня игры</returns>
        LevelSettings Init();
    }
}
