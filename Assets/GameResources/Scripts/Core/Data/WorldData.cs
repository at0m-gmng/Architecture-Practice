using System;
using GameResources.Scripts.Services;

namespace GameResources.Scripts.Core.Data
{
    [Serializable]
    public class WorldData
    {
        public PositionOnLevel PositionOnLevel;

        public WorldData(string initialLevel)
        {
            PositionOnLevel = new PositionOnLevel(level: initialLevel);
        }
    }
}