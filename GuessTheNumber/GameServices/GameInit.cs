using GuessTheNumber.GameManager;
using GuessTheNumber.GameServices.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.GameServices
{
    class GameInit : IGameInit
    {
        private readonly IGameManager _manager;

        public GameInit(IGameManager manager)
        {
            _manager = manager;
        }

        #region Реализация IGameInit
        public GameSettings Init()
        {
            var newSettings = new GameSettings();

            _manager.DisplayText("Нижняя граница диапазона: ");
            InitSecretNumberMin(newSettings);

            _manager.DisplayText("Верхняя граница диапазона: ");
            if (!InitSecretNumberMax(newSettings))
                return new GameSettings();
            
            _manager.DisplayText("Количество попыток за которое вы угадаете число: ");
            if (!InitAttemptMax(newSettings))
                return new GameSettings();
            
            return newSettings;
        }
        #endregion

        /// <summary>
        /// Инициализация нижней границы диапазона загадываемого числа
        /// </summary>
        /// <param name="newSettings"> настройки игры</param>
        private void InitSecretNumberMin(GameSettings newSettings)
        {
            newSettings.SecretNumberMin = _manager.GetNumber();
        }

        /// <summary>
        /// Инициализация верхней граница диапазона загадываемого числа
        /// </summary>
        private bool InitSecretNumberMax(GameSettings newSettings)
        {
            newSettings.SecretNumberMax = _manager.GetNumber();
            if (newSettings.SecretNumberMax <= newSettings.SecretNumberMin)
            {
                _manager.DisplayError("Верхняя граница диапазона должна быть больше нижней границы!\r\n");
                DisplayTextDefaultSettings();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Инициализация количества попыток, за каторое необходимо угадать загаданное число
        /// </summary>
        private bool InitAttemptMax(GameSettings newSettings)
        {
            newSettings.AttemptMax = _manager.GetNumber();
            if (newSettings.AttemptMax == 0)
            {
                _manager.DisplayError("Количество попыток должно быть больше нуля!\r\n");
                DisplayTextDefaultSettings();
                return false;
            }

            return true;
        }

        private void DisplayTextDefaultSettings()
        {
            _manager.DisplayText("Применены настройки по умолчанию!\r\n");
        }
    }
}
