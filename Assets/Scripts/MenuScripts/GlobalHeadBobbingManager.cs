using UnityEngine;
using UnityEngine.SceneManagement;
using EasyPeasyFirstPersonController;

public class GlobalHeadBobbingManager : MonoBehaviour
{
    public static GlobalHeadBobbingManager Instance;

    const string HeadBobPrefKey = "HEAD_BOB_ENABLED";
    // 1 = A��k, 0 = Kapal�

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
        int enabled = PlayerPrefs.GetInt(HeadBobPrefKey, 1); // default A�IK
        ApplyHeadBob(enabled);
    }

    void ApplyHeadBob(int enabled)
    {
        FirstPersonController controller =
            FindObjectOfType<FirstPersonController>();

        if (!controller)
        {
            return;
        }

        // EasyPeasyFirstPersonController i�indeki de�i�ken
        if (enabled == 1)
            controller.bobbingAmount = 0.05f;
        else
            controller.bobbingAmount = 0f;
    }
}