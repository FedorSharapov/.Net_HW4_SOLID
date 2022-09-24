namespace GuessTheNumber.Levels.Interfaces
{
    public interface ILevelManager
    {
        /// <summary>
        /// Показать игроку текст
        /// </summary>
        /// <param name="message">сообщение для игрока</param>
        void DisplayText(string message);

        /// <summary>
        /// Показать игроку текст ошибки 
        /// </summary>
        /// <param name="message">сообщение об ошибке для игрока</param>
        void DisplayError(string message);

        /// <summary>
        /// Получить число от игрока
        /// </summary>
        /// <returns>предпологаемое число</returns>
        int GetNumber();

        /// <summary>
        /// Проиграть звуковую дорожку
        /// </summary>
        void PlaySoundTrack();
    }
}
