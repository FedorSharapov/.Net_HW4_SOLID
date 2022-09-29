using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Settings;

namespace GuessTheNumber.Services
{
    public class MultilevelGame : BaseGame
    {
        private LevelSettings[] _levelsSettings;

        public MultilevelGame(ILevel level) : base(level)
        {
            _levelsSettings = new LevelSettings[]
            {
                _level.Settings,
                new LevelSettings(1,50,5),
                new LevelSettings(1,10,1)
            };
        }

        public override void Play()
        {
            foreach(var settings in _levelsSettings)
            {
                _level.Settings = settings;
                if (!_level.Start())
                    break;
            }
        }
    }
}
