namespace GuessTheNumber.Settings
{
    class GameSettings
    {
        /// <summary>
        /// Нижняя граница диапазона загадываемого числа
        /// </summary>
        /// 
        public int SecretNumberMin { get; set; } = 0;

        /// <summary>
        /// Верхняя граница диапазона загадываемого числа
        /// </summary>
        public int SecretNumberMax { get; set; } = 100;

        /// <summary>
        /// Количество попыток, за каторое необходимо угадать загаданное число
        /// </summary>
        public int AttemptMax { get; set; } = 15;
    }
}
