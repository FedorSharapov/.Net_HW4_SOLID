using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.Services
{
    public class UserGame : BaseGame, IUserGame
    {
        private ILevelSettings _userSettings;
        IUserLevelInit _levelInit;

        public UserGame(ILevel level, IUserLevelInit levelInit) : base(level)
        {
            _levelInit = levelInit;
            _userSettings = new LevelSettings();
        }

        public void Init()
        {
            _userSettings = _levelInit.Init();
        }

        public override void Play()
        {
            _level.Settings = _userSettings;
            _level.Start();
        }
    }
}
