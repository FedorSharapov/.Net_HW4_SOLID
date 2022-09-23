using GuessTheNumber.GameMenu.ConsoleMenu;
using GuessTheNumber.GameServices.Interfaces;

namespace GuessTheNumber.GameMenu
{
    class ConsoleGameMenu : IGameMenu
    {
        Menu _menu;
        IGame _game;

        public ConsoleGameMenu(IGame game)
        {
            _game = game;

            // инициализация меню
            _menu = new Menu("Игра \"Угадай число\"");
            _menu.Add(new Item("- Начать игру", _game.Play));
            _menu.Add(new Item("- Правила", _game.DisplayRules));
            _menu.Add(new Item("- Настройки", () => _game.Init()));
        }

        public void Start()
        {
            _menu.Updating();
        }
    }
}
