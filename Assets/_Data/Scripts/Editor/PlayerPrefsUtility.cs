using UnityEditor;
using UnityEngine;

public class PlayerPrefsUtility
{
    [MenuItem("Tools/Clear Player Prefs")]
    private static void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs cleared.");
    }
}
