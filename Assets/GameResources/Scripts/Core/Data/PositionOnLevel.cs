using System;

namespace GameResources.Scripts.Core.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level;

        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }

        public PositionOnLevel(string level)
        {
            Level = level;
        }

        public Vector3Data Position { get; set; }   
    }
}