namespace GuessTheNumber.Settings
{
    class LevelSettings : ILevelSettings
    {
        /// <summary>
        /// Нижняя граница диапазона загадываемого числа
        /// </summary>
        /// 
        public int SecretNumberMin { get; set; }

        /// <summary>
        /// Верхняя граница диапазона загадываемого числа
        /// </summary>
        public int SecretNumberMax { get; set; }

        /// <summary>
        /// Количество попыток, за каторое необходимо угадать загаданное число
        /// </summary>
        public int AttemptMax { get; set; }

        public LevelSettings()
        {
            SecretNumberMin = 1;
            SecretNumberMax = 100;
            AttemptMax = 10;
        }
        public LevelSettings(int secretNumberMin, int secretNumberMax, int attemptMax)
        {
            SecretNumberMin = secretNumberMin;
            SecretNumberMax = secretNumberMax;
            AttemptMax = attemptMax;
        }
    }
}
