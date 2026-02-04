using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalResolutionManager : MonoBehaviour
{
    public static GlobalResolutionManager Instance;

    const string ResolutionPrefKey = "RESOLUTION_INDEX";

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
        ApplySavedResolution();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySavedResolution();
    }

    public void SetResolution(int index)
    {
        PlayerPrefs.SetInt(ResolutionPrefKey, index);
        PlayerPrefs.Save();

        ApplyResolution(index);
    }

    void ApplySavedResolution()
    {
        int index = PlayerPrefs.GetInt(ResolutionPrefKey, 0);
        ApplyResolution(index);
    }

    void ApplyResolution(int index)
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;

        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, false);
                break;

            case 1:
                Screen.SetResolution(1366, 768, false);
                break;

            case 2:
                Screen.SetResolution(1280, 800, false);
                break;

            case 3:
                Screen.SetResolution(1280, 720, false);
                break;

            default:
                Screen.SetResolution(1920, 1080, false);
                break;
        }
    }
}