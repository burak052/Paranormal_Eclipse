using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class GlobalAAManager : MonoBehaviour
{
    public static GlobalAAManager Instance;

    const string AAPrefKey = "AA_MODE";

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
        ApplySavedAA();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplySavedAA();
    }

    public void SetAA(int index)
    {
        PlayerPrefs.SetInt(AAPrefKey, index);
        PlayerPrefs.Save();
        ApplyAA(index);
    }

    void ApplySavedAA()
    {
        int index = PlayerPrefs.GetInt(AAPrefKey, 2); // default = SMAA
        ApplyAA(index);
    }

    void ApplyAA(int index)
    {
        Camera cam = Camera.main;
        if (!cam)
        {
            Debug.LogWarning("Camera.main bulunamadı");
            return;
        }

        var data = cam.GetComponent<HDAdditionalCameraData>();
        if (!data)
        {
            Debug.LogWarning("HDAdditionalCameraData yok: " + cam.name);
            return;
        }

        switch (index)
        {
            case 0:
                data.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
                break;
            case 1:
                data.antialiasing = HDAdditionalCameraData.AntialiasingMode.FastApproximateAntialiasing;
                break;
            case 2:
                data.antialiasing = HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing;
                break;
            case 3:
                data.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                break;
        }
    }

}
