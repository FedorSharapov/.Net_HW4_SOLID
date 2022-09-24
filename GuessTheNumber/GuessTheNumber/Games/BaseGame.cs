using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.Services
{
    public class BaseGame : IGame
    {
        private protected ILevel _level;

        public BaseGame(ILevel level)
        {
            _level = level;
            _level.Settings = new LevelSettings();
        }

        public virtual void Play()
        {
            _level.Start();
        }
    }
}
