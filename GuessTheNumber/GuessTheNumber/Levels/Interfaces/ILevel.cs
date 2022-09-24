using GuessTheNumber.Settings;

namespace GuessTheNumber.Levels.Interfaces
{
    public interface ILevel
    {
        /// <summary>
        /// Настройки уровня
        /// </summary>
        public ILevelSettings Settings { get; set; }

        /// <summary>
        /// Начать уровень игры
        /// </summary>
        /// <returns>статус победы: true - победа, false - проигрыш</returns>
        bool Start();
    }
}
