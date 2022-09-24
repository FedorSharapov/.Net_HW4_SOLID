using GuessTheNumber.Levels.Interfaces;

namespace GuessTheNumber.Rules
{
    public class GameDescription : IGameDescription
    {
        private readonly ILevelManager _manager;

        public GameDescription(ILevelManager manager)
        {
            _manager = manager;
        }

        public void Display()
        {
            _manager.DisplayText("Отгадайте число за наименьшее количество попыток.\r\nПосле каждой попытки вы получите подсказку, ваше число больше или меньше загаданного.\r\n");
        }
    }
}
