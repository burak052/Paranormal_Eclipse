using UnityEngine;
using UnityEngine.SceneManagement;
using EasyPeasyFirstPersonController;

public class GlobalMouseSensitivityManager : MonoBehaviour
{
    public static GlobalMouseSensitivityManager Instance;

    const string SensPrefKey = "MOUSE_SENS";

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
        ApplySavedSensitivity();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySavedSensitivity();
    }

    public void SetSensitivity(float value)
    {
        PlayerPrefs.SetFloat(SensPrefKey, value);
        PlayerPrefs.Save();

        ApplySensitivity(value);
    }

    void ApplySavedSensitivity()
    {
        float value = PlayerPrefs.GetFloat(SensPrefKey, 20f);
        ApplySensitivity(value);
    }

    void ApplySensitivity(float value)
    {
        FirstPersonController controller =
            FindObjectOfType<FirstPersonController>();

        if (!controller)
        {
            return;
        }

        controller.mouseSensitivity = value;
    }
}
