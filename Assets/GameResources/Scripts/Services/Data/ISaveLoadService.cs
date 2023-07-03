using GameResources.Scripts.Core.Data;

namespace GameResources.Scripts.Services.Data
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();

        PlayerProgress LoadProgress();
    }
}