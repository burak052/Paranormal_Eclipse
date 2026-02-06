using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using EasyPeasyFirstPersonController;

public class MainMenu : MonoBehaviour
{
    public Animation Camera;
    public Image blackScreen;    
    public float fadeTime = 1.5f;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown fontsizeDropdown;
    public TMP_Dropdown resolutionsize;
    public TMP_Dropdown screensizechoose;
    public TMP_Dropdown graphicsettings;
    public TMP_Dropdown antialiasing;
    public TMP_Dropdown headbobbingsettings;
    public TextMeshProUGUI languageText;
    public GameObject selecetlanguage;
    public GameObject fontsize;
    public GameObject mainmusic;
    public GameObject resolution;
    public GameObject screensize;
    public GameObject graphics;
    public GameObject aliasing;
    public GameObject camsensetive;
    public GameObject headbobbing;
    public Slider mainvolume;
    public Slider camerasenstive;
    public AudioSource menumusic;
    public RectTransform content;
    Coroutine creditscoroutine;
    Resolution[] resolutions;

    void Start()
    {
        blackScreen.gameObject.SetActive(false);
        antialiasing.onValueChanged.AddListener(OnAntiAliasingChanged);
        float saved = PlayerPrefs.GetFloat("MOUSE_SENS", 10f);
        camerasenstive.value = saved;
    }

    void Awake()
    {
        antialiasing.onValueChanged.RemoveAllListeners();
    }

    public void OnAntiAliasingChanged(int value)
    {
        GlobalAAManager.Instance.SetAA(value);
    }

    public void NewGame()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(FadeAndStart());
    }
    public void OnSensitivityChanged(float value)
    {
        GlobalMouseSensitivityManager.Instance.SetSensitivity(value*100f);
    }

    IEnumerator FadeAndStart()
    {
        float t = 0f;

        // Yavaşça karart
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Sonra sahneyi yükle
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {

    }

    public void Settings()
    {
        Camera.Play("Menu2Settings");
    }

    public void BacktoMenu()
    {
        Camera.Play("Settings2Menu");
    }

    public void credits()
    {
        Camera.Play("menu2credits");
        creditscoroutine=StartCoroutine(creditsslider());
        menumusic.Stop();
        menumusic.gameObject.GetComponents<AudioSource>()[1].Play();
    }

    public void back2menu()
    {
        Camera.Play("credits2menu");
        StopCoroutine(creditscoroutine);
        creditscoroutine = null;
        menumusic.Play();
        menumusic.gameObject.GetComponents<AudioSource>()[1].Stop();
    }

    public void Exit()
    {
        Debug.Log("Uygulama kapatılıyor...");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void choosefontsize()
    {
        fontsizeDropdown.gameObject.SetActive(true);
        languageDropdown.gameObject.SetActive(false);
    }

    public void sellanguage()
    {
        languageDropdown.gameObject.SetActive(true);
        fontsizeDropdown.gameObject.SetActive(false);
    }

    public void settingmainmusic()
    {
        mainvolume.gameObject.SetActive(true);
    }

    public void startmainvolume()
    {
        mainvolume.value = menumusic.volume;
        mainvolume.onValueChanged.AddListener(settingvolume);
    }

    public void settingvolume(float vol)
    {
        menumusic.volume = vol;
    }

    public void SetResolution(int index)
    {
        Debug.Log("Seçilen çözünürlük: " + resolutionsize.options[index].text);

        GlobalResolutionManager.Instance.SetResolution(index);
    }
    public void SetScreenMode(int index)
    {
        Debug.Log("Seçilen ekran modu: " + screensizechoose.options[index].text);

        GlobalScreenModeManager.Instance.SetScreenMode(index);
    }

    public void SetGraphicsQuality(int index)
    {
        Debug.Log("Seçilen grafik ayarı: " + graphicsettings.options[index].text);

        GlobalGraphicsQualityManager.Instance.SetGraphicsQuality(index);
    }

    public void OnHeadBobOnClicked(int index)
    {
        GlobalHeadBobbingManager.Instance.SetHeadBob(index);
    }

    public void choreso()
    {
        resolutionsize.gameObject.SetActive(true);
        screensizechoose.gameObject.SetActive(false);
        graphicsettings.gameObject.SetActive(false);
        antialiasing.gameObject.SetActive(false);
    }

    public void choscreen()
    {
        resolutionsize.gameObject.SetActive(false);
        screensizechoose.gameObject.SetActive(true);
        graphicsettings.gameObject.SetActive(false);
        antialiasing.gameObject.SetActive(false);
    }
    public void chografik()
    {
        resolutionsize.gameObject.SetActive(false);
        screensizechoose.gameObject.SetActive(false);
        graphicsettings.gameObject.SetActive(true);
        antialiasing.gameObject.SetActive(false);
    }

    public void choaliasing()
    {
        resolutionsize.gameObject.SetActive(false);
        screensizechoose.gameObject.SetActive(false);
        graphicsettings.gameObject.SetActive(false);
        antialiasing.gameObject.SetActive(true);
    }

    public void chocamsensetive()
    {
        camerasenstive.gameObject.SetActive(true);
        headbobbingsettings.gameObject.SetActive(false);
    }

    public void choheadbobbing()
    {
        camerasenstive.gameObject.SetActive(false);
        headbobbingsettings.gameObject.SetActive(true);
    }

    public void grafik()
    {
        mainmusic.SetActive(false);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        resolution.SetActive(true);
        screensize.SetActive(true);
        graphics.SetActive(true);
        aliasing.SetActive(true);
        camsensetive.SetActive(false);
        headbobbing.SetActive(false);
    }

    public void music()
    {
        mainmusic.SetActive(true);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        resolution.SetActive(false);
        screensize.SetActive(false);
        graphics.SetActive(false);
        aliasing.SetActive(false);
        camsensetive.SetActive(false);
        headbobbing.SetActive(false);
    }

    public void cam()
    {
        camsensetive.SetActive(true);
        headbobbing.SetActive(true);
        mainmusic.SetActive(false);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        resolution.SetActive(false);
        screensize.SetActive(false);
        graphics.SetActive(false);
        aliasing.SetActive(false);
    }

    public void language()
    {
        selecetlanguage.SetActive(true);
        fontsize.SetActive(true);
        mainmusic.SetActive(false);
        resolution.SetActive(false);
        screensize.SetActive(false);
        graphics.SetActive(false);
        aliasing.SetActive(false);
        camsensetive.SetActive(false);
        headbobbing.SetActive(false);
    }
    public void lanset(int val)
    {
        
    }
    public void chofontsize(int val)
    {
        Debug.Log(fontsizeDropdown.options[val].text);
    }
    public void resultresosize(int val)
    {
        Debug.Log(resolutionsize.options[val].text);
    }
    public void resultscreensize(int val)
    {
        Debug.Log(screensizechoose.options[val].text);
    }
    public void resultgrafik(int val)
    {
        Debug.Log(graphicsettings.options[val].text);
    }
    public void resultheadbobbing(int val)
    {
        Debug.Log(headbobbingsettings.options[val].text);
    }
    IEnumerator creditsslider()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.007f;

            Vector2 pos = content.anchoredPosition;
            pos.y = Mathf.Lerp(-900f, 9300f, t);
            content.anchoredPosition = pos;

            yield return null; // 🔥 ZORUNLU
        }
    }
}