using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Levels.Interfaces;

namespace GuessTheNumber.Services
{
    public class UserGame : BaseGame, IUserGame
    {
        IUserLevelInit _levelInit;

        public UserGame(ILevel level, IUserLevelInit levelInit) : base(level)
        {
            _levelInit = levelInit;
        }

        public void Init()
        {
            _level.Settings = _levelInit.Init();
        }

        public override void Play()
        {
            _level.Start();
        }
    }
}
