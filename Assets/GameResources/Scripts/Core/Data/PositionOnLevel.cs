using System;

namespace GameResources.Scripts.Core.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }

        public PositionOnLevel(string level)
        {
            Level = level;
        }

        public string Level;
        
        public Vector3Data Position;
    }
}