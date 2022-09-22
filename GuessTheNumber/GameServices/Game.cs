using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.GameManager;
using GuessTheNumber.Generator;

namespace GuessTheNumber.Games
{
    class Game : GamePlay, IGame
    {
        private IGameInit _gameInit;

        public Game(IGameManager manager, INumberGenerator secretNumber, IGameInit gameInit) : 
            base(manager, secretNumber)
        {
            _gameInit = gameInit;
        }

        public GameSettings Init()
        {
            var newSettings = _gameInit.Init();

            if (newSettings != null)
                _settings = newSettings;
            else
                _manager.DisplayText("Применены настройки по умолчанию!\r\n");

            return _settings;
        }

        public void DisplayRules()
        {
            _manager.DisplayText("Отгадайте число за наименьшее количество попыток.\r\nПосле каждой попытки вы получите подсказку, ваше число больше или меньше загаданного.\r\n");
        }
    }
}
