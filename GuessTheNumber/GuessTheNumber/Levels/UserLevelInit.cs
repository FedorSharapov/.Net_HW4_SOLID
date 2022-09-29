using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.Levels
{
    public class UserLevelInit : IUserLevelInit
    {
        private readonly ILevelManager _manager;

        public UserLevelInit(ILevelManager manager)
        {
            _manager = manager;
        }

        public LevelSettings Init()
        {
            var newSettings = new LevelSettings();

            _manager.DisplayText("Нижняя граница диапазона: ");
            InitSecretNumberMin(newSettings);

            _manager.DisplayText("Верхняя граница диапазона: ");
            if (!InitSecretNumberMax(newSettings))
                return DefaultSettings();

            _manager.DisplayText("Количество попыток за которое вы угадаете число: ");
            if (!InitAttemptMax(newSettings))
                return DefaultSettings();

            return newSettings;
        }

        /// <summary>
        /// Инициализация нижней границы диапазона загадываемого числа
        /// </summary>
        /// <param name="newSettings"> настройки игры</param>
        private void InitSecretNumberMin(LevelSettings newSettings)
        {
            newSettings.SecretNumberMin = _manager.GetNumber();
        }

        /// <summary>
        /// Инициализация верхней граница диапазона загадываемого числа
        /// </summary>
        private bool InitSecretNumberMax(LevelSettings newSettings)
        {
            newSettings.SecretNumberMax = _manager.GetNumber();
            if (newSettings.SecretNumberMax <= newSettings.SecretNumberMin)
            {
                _manager.DisplayError("Верхняя граница диапазона должна быть больше нижней границы!\r\n");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Инициализация количества попыток, за каторое необходимо угадать загаданное число
        /// </summary>
        private bool InitAttemptMax(LevelSettings newSettings)
        {
            newSettings.AttemptMax = _manager.GetNumber();
            if (newSettings.AttemptMax == 0)
            {
                _manager.DisplayError("Количество попыток должно быть больше нуля!\r\n");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Настройки по умолчанию
        /// </summary>
        /// <returns>новые настройки по умолчанию</returns>
        private LevelSettings DefaultSettings()
        {
            _manager.DisplayText("Применены настройки по умолчанию!\r\n");
            return new LevelSettings();
        }
    }
}
