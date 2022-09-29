using ConsoleProvider.Menu;
using GuessTheNumber.Rules;
using GuessTheNumber.Services.Interfaces;

namespace ConsoleProvider
{
    class ConsoleGameMenu : IGameMenu
    {
        private readonly MainMenu _menu;
        private readonly IGamePlay _game;
        private readonly IGamePlay _userGame;
        private readonly IGameInit _userGameInit;
        private readonly IGameDescription _gameDescription;

        public ConsoleGameMenu(GamePlayProvider game, GamePlayProvider usergame, IGameInit userGameInit, IGameDescription gameDescription)
        {
            _game = game("multi");
            _userGame = usergame("user");
            _userGameInit = userGameInit;
            _gameDescription = gameDescription;

            // инициализация меню
            _menu = new MainMenu("Игра \"Угадай число\"");
            _menu.Add(new Item("- Начать игру", _game.Play));
            _menu.Add(new Item("- Начать пользовательскую игру", _userGame.Play));
            _menu.Add(new Item("- Настройки пользовательской игры", _userGameInit.Init));
            _menu.Add(new Item("- Описание игры", _gameDescription.Display));
        }

        public void Start()
        {
            _menu.Updating();
        }
    }
}
