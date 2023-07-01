using UnityEngine;

namespace GameResources.Scripts.Core.AssetManager
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}