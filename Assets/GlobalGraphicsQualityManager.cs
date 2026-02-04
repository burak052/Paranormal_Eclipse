using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class GlobalGraphicsQualityManager : MonoBehaviour
{
    public static GlobalGraphicsQualityManager Instance;

    const string QualityPrefKey = "GRAPHICS_QUALITY";

    Volume cachedVolume;

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
        ApplySavedQuality();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CacheVolume();
        ApplySavedQuality();
    }

    void CacheVolume()
    {
        cachedVolume = FindObjectOfType<Volume>();
    }

    public void SetGraphicsQuality(int index)
    {
        PlayerPrefs.SetInt(QualityPrefKey, index);
        PlayerPrefs.Save();

        ApplyQuality(index);
    }

    void ApplySavedQuality()
    {
        int index = PlayerPrefs.GetInt(QualityPrefKey, 0);
        ApplyQuality(index);
    }

    void ApplyQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);

        // KRÝTÝK KISIM
        RefreshVolumeSafely();
    }

    void RefreshVolumeSafely()
    {
        if (!cachedVolume)
        {
            CacheVolume();
        }

        if (!cachedVolume)
            return;

        cachedVolume.enabled = false;
        cachedVolume.enabled = true;
    }
}
