using UnityEngine;

public static class LanguageManager
{
    public static string CurrentLanguage
    {
        get
        {
            return PlayerPrefs.GetString("LANGUAGE", "turkce");
        }
        set
        {
            PlayerPrefs.SetString("LANGUAGE", value);
            PlayerPrefs.Save();
        }
    }
}
