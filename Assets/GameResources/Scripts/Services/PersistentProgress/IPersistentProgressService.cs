using GameResources.Scripts.Core.Data;

namespace GameResources.Scripts.Services.PersistentProgress
{
    public interface IPersistentProgressService : IService

    {
    PlayerProgress Progress { get; set; }
    }
}