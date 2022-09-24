using ConsoleProvider.Menu;
using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Rules;

namespace ConsoleProvider
{
    class ConsoleGameMenu : IGameMenu
    {
        private readonly MainMenu _menu;
        private readonly IGame _game;
        private readonly IUserGame _userGame;
        private readonly IGameDescription _gameDescription;

        public ConsoleGameMenu(IGame game, IUserGame userGame, IGameDescription gameDescription)
        {
            _game = game;
            _userGame = userGame;
            _gameDescription = gameDescription;

            // инициализация меню
            _menu = new MainMenu("Игра \"Угадай число\"");
            _menu.Add(new Item("- Начать игру", _game.Play));
            _menu.Add(new Item("- Начать пользовательскую игру", _userGame.Play));
            _menu.Add(new Item("- Настройки пользовательской игры", _userGame.Init));
            _menu.Add(new Item("- Описание игры", _gameDescription.Display));
        }

        public void Start()
        {
            _menu.Updating();
        }
    }
}
