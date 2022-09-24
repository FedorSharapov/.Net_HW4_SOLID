namespace GuessTheNumber.Settings
{
    public interface ILevelSettings
    {
        /// <summary>
        /// Нижняя граница диапазона загадываемого числа
        /// </summary>
        public int SecretNumberMin { get; set; }

        /// <summary>
        /// Верхняя граница диапазона загадываемого числа
        /// </summary>
        public int SecretNumberMax { get; set; }

        /// <summary>
        /// Количество попыток, за каторое необходимо угадать загаданное число
        /// </summary>
        public int AttemptMax { get; set; }
    }
}
