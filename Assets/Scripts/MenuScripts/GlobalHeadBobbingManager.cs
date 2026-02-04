using UnityEngine;
using UnityEngine.SceneManagement;
using EasyPeasyFirstPersonController;

public class GlobalHeadBobbingManager : MonoBehaviour
{
    public static GlobalHeadBobbingManager Instance;

    const string HeadBobPrefKey = "HEAD_BOB_ENABLED";
    // 1 = Açýk, 0 = Kapalý

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
        ApplySavedHeadBob();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySavedHeadBob();
    }

    public void SetHeadBob(int enabled)
    {
        PlayerPrefs.SetInt(HeadBobPrefKey, enabled == 1 ? 1 : 0);
        PlayerPrefs.Save();

        ApplyHeadBob(enabled);
    }

    void ApplySavedHeadBob()
    {
        int enabled = PlayerPrefs.GetInt(HeadBobPrefKey, 1); // default AÇIK
        ApplyHeadBob(enabled);
    }

    void ApplyHeadBob(int enabled)
    {
        FirstPersonController controller =
            FindObjectOfType<FirstPersonController>();

        if (!controller)
        {
            Debug.LogWarning("FirstPersonController bulunamadý");
            return;
        }

        // EasyPeasyFirstPersonController içindeki deðiþken
        if (enabled == 1)
            controller.bobbingAmount = 0.05f;
        else
            controller.bobbingAmount = 0f;
    }
}