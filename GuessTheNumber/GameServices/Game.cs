using GuessTheNumber.GameServices.Interfaces;
using GuessTheNumber.GameManager;
using GuessTheNumber.Generator;
using GuessTheNumber.Settings;

namespace GuessTheNumber.GameServices
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
            _settings = _gameInit.Init();
            return _settings;
        }

        public void DisplayRules()
        {
            _manager.DisplayText("Отгадайте число за наименьшее количество попыток.\r\nПосле каждой попытки вы получите подсказку, ваше число больше или меньше загаданного.\r\n");
        }
    }
}
