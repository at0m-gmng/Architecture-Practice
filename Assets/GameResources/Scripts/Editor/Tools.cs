using UnityEditor;
using UnityEngine;

namespace GameResources.Scripts.Editor
{
    public class Tools
    {
        [MenuItem("Tools/Clear All Prefs")]
        public static void ClearAllPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        } 
    }
}
