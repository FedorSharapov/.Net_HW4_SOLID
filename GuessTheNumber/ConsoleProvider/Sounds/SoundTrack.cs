namespace ConsoleProvider.Sounds
{
    class SoundTrack
    {
        public string Name { get; }
        public Sound[] Track { get; }

        public SoundTrack(string name, Sound[] track)
        {
            Name = name;
            Track = track;
        }
    }
}
