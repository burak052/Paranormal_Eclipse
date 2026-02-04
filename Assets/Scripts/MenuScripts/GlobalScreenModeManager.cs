using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalScreenModeManager : MonoBehaviour
{
    public static GlobalScreenModeManager Instance;

    const string ScreenModePrefKey = "SCREEN_MODE";
    // 0 = Borderless, 1 = Windowed

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        ApplySavedScreenMode();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySavedScreenMode();
    }

    public void SetScreenMode(int index)
    {
        PlayerPrefs.SetInt(ScreenModePrefKey, index);
        PlayerPrefs.Save();

        ApplyScreenMode(index);
    }

    void ApplySavedScreenMode()
    {
        int index = PlayerPrefs.GetInt(ScreenModePrefKey, 0); // default: Borderless
        ApplyScreenMode(index);
    }

    void ApplyScreenMode(int index)
    {
        switch (index)
        {
            case 0:
                // Çerçevesiz (Borderless Fullscreen)
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                Screen.fullScreen = true;
                break;

            case 1:
                // Pencere Modu
                Screen.fullScreenMode = FullScreenMode.Windowed;
                Screen.fullScreen = false;
                break;
        }
    }
}