using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Services.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.Services
{
    public class BaseGame : IGamePlay
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
