using GameResources.Scripts.Core.Data;

namespace GameResources.Scripts.Services.PersistentProgress
{
    public interface ISaveProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }

    public interface ISaveProgress : ISaveProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}