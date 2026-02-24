using UnityEngine;
using Steamworks;

public class SteamManager : MonoBehaviour
{
    private static SteamManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (!SteamAPI.Init())
        {
            Debug.LogError("Steam başlatılamadı!");
            return;
        }

        Debug.Log("Steam initialized successfully");
    }

    private void Update()
    {
        SteamAPI.RunCallbacks();
    }

    private void OnDestroy()
    {
        SteamAPI.Shutdown();
    }
}
