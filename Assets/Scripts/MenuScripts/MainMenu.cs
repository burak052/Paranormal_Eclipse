using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using EasyPeasyFirstPersonController;
using System.IO;

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
    public GameObject menucanvas;
    public GameObject settingscanvas;
    public GameObject creditscanvas;
    public GameObject selecetlanguage;
    public GameObject fontsize;
    public GameObject mainmusic;
    public GameObject resolution;
    public GameObject screensize;
    public GameObject graphics;
    public GameObject aliasing;
    public GameObject camsensetive;
    public GameObject headbobbing;
    public Slider mainvolumeslider;
    public Slider camerasenstive;
    public AudioSource menumusic;
    public RectTransform content;
    public Dialogs dia;
    public Transform contentscroll; 
    Coroutine creditscoroutine;
    Resolution[] resolutions;

    void Start()
    {
        CheckSaveSlots();
        LanguageMenu();
        LoadSettings();
        blackScreen.gameObject.SetActive(false);
        antialiasing.onValueChanged.AddListener(OnAntiAliasingChanged);
        if (LanguageManager.CurrentLanguage == "turkce")
            languageDropdown.value = 0;
        if (LanguageManager.CurrentLanguage == "english")
            languageDropdown.value = 1;
        if (LanguageManager.CurrentLanguage == "deutsch")
            languageDropdown.value = 2;
        if (LanguageManager.CurrentLanguage == "español")
            languageDropdown.value = 3;
        if (LanguageManager.CurrentLanguage == "pусский")
            languageDropdown.value = 4;
        if (LanguageManager.CurrentLanguage == "français")
            languageDropdown.value = 5;
        if (LanguageManager.CurrentLanguage == "italiano")
            languageDropdown.value = 6;

        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        //load
        menucanvas.GetComponent<Transform>().Find("Continue").GetComponent<Button>().interactable = false;
        menucanvas.GetComponent<Transform>().Find("Load_Game").GetComponent<Button>().interactable = false;
        if(SaveManager.Instance.HasSave())
        {
            menucanvas.GetComponent<Transform>().Find("Continue").GetComponent<Button>().interactable = true;
            menucanvas.GetComponent<Transform>().Find("Load_Game").GetComponent<Button>().interactable = true;
        }
    }

    void Awake()
    {
        antialiasing.onValueChanged.RemoveAllListeners();
    }

    void CheckSaveSlots()
    {
        Transform slot;
        slot = contentscroll.GetChild(0);
        if (!File.Exists(Application.persistentDataPath + "/save7.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date7").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(7).saveDateTime;
        }
            
        slot = contentscroll.GetChild(1);
        if (!File.Exists(Application.persistentDataPath + "/save6.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date6").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(6).saveDateTime;
        }
            
        slot = contentscroll.GetChild(2);
        if (!File.Exists(Application.persistentDataPath + "/save5.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date5").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(5).saveDateTime;
        }
            
        slot = contentscroll.GetChild(3);
        if (!File.Exists(Application.persistentDataPath + "/save4.json")) 
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date4").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(4).saveDateTime;
        }
            
        slot = contentscroll.GetChild(4);
        if (!File.Exists(Application.persistentDataPath + "/save3.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date3").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(3).saveDateTime;
        }
            
        slot = contentscroll.GetChild(5);
        if (!File.Exists(Application.persistentDataPath + "/save2.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date2").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(2).saveDateTime;
        }
            
        slot = contentscroll.GetChild(6);
        if (!File.Exists(Application.persistentDataPath + "/save1.json"))
            slot.gameObject.SetActive(false);
        else
        {
            slot.gameObject.SetActive(true);
            slot.Find("date1").gameObject.GetComponent<TextMeshProUGUI>().text = SaveManager.Instance.LoadGame(1).saveDateTime;
        }
    }

    public void OnAntiAliasingChanged(int value)
    {
        GlobalAAManager.Instance.SetAA(value);
    }

    public void OnLanguageChanged(int index)
    {
        if (index == 0)
            LanguageManager.CurrentLanguage = "turkce";
        if (index == 1)
            LanguageManager.CurrentLanguage = "english";
        if (index == 2)
            LanguageManager.CurrentLanguage = "deutsch";
        if (index == 3)
            LanguageManager.CurrentLanguage = "español";
        if (index == 4)
            LanguageManager.CurrentLanguage = "pусский";
        if (index == 5)
            LanguageManager.CurrentLanguage = "français";
        if (index == 6)
            LanguageManager.CurrentLanguage = "italiano";

        dia.LoadDias();
        LanguageMenu();
    }

    public void NewGame()
    {
        SaveManager.Instance.IsLoadingFromSave = false;
        SaveManager.Instance.DeletePaths();
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(FadeAndStart());
        PlayerPrefs.SetInt("EASTER_EGG_NOTE", 0);
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

    public void ContinueGame()
    {
        SaveManager.Instance.IsLoadingFromSave = true;
        StartCoroutine(ContinueSavedGame());
    }

    IEnumerator ContinueSavedGame()
    {
        blackScreen.color = new Color(0, 0, 0, 0f);
        blackScreen.gameObject.SetActive(true);
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        
        SceneManager.LoadScene(SaveManager.Instance.LastGame().sceneIndex);
    }

    public void LoadGame()
    {
        menucanvas.GetComponent<Transform>().Find("Load_Game").Find("Scroll View").gameObject.SetActive(true);
    }

    public void Slot(int id)
    {
        SaveManager.Instance.IsLoadingFromSave = true;
        SceneManager.LoadScene(SaveManager.Instance.LoadGame(id).sceneIndex);
    }

    public void Settings()
    {
        Camera.Play("Menu2Settings");
        menucanvas.GetComponent<Transform>().Find("Load_Game").Find("Scroll View").gameObject.SetActive(false);
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
        menucanvas.GetComponent<Transform>().Find("Load_Game").Find("Scroll View").gameObject.SetActive(false);
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
        mainvolumeslider.gameObject.SetActive(true);
    }

    public void startmainvolume()
    {
        mainvolumeslider.onValueChanged.AddListener(settingvolume);
    }

    public void settingvolume(float vol)
    {
        menumusic.volume = vol;
        PlayerPrefs.SetFloat("MAIN_VOLUME", vol);
    }

    public void SetResolution(int index)
    {
        GlobalResolutionManager.Instance.SetResolution(index);
    }
    public void SetScreenMode(int index)
    {
        GlobalScreenModeManager.Instance.SetScreenMode(index);
    }

    public void SetGraphicsQuality(int index)
    {
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
    public void chofontsize(int val)
    {
        PlayerPrefs.SetInt("FONT_SIZE", val);
    }
    IEnumerator creditsslider()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.005f;

            Vector2 pos = content.anchoredPosition;
            pos.y = Mathf.Lerp(-900f, 16500f, t);
            content.anchoredPosition = pos;

            yield return null;
        }
    }

    public void LanguageMenu()
    {
        menucanvas.GetComponent<Transform>().Find("Game_Start").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[1];
        menucanvas.GetComponent<Transform>().Find("Continue").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[2];
        menucanvas.GetComponent<Transform>().Find("Load_Game").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[30];
        menucanvas.GetComponent<Transform>().Find("Settings").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[3];
        menucanvas.GetComponent<Transform>().Find("Credits").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[4];
        menucanvas.GetComponent<Transform>().Find("Exit").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[5];

        settingscanvas.GetComponent<Transform>().Find("Grafik").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[6];
        settingscanvas.GetComponent<Transform>().Find("Ses").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[7];
        settingscanvas.GetComponent<Transform>().Find("Kamera").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[8];
        settingscanvas.GetComponent<Transform>().Find("Dil").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[9];
        settingscanvas.GetComponent<Transform>().Find("Back").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[10];
        
        creditscanvas.GetComponent<Transform>().Find("Back").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[10];
        
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Cozunurluk").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[11];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Ekran Boyutu").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[12];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Grafik Ayarı").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[13];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Anti-Aliasing").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[14];
        
        settingscanvas.GetComponent<Transform>().Find("Ses").Find("Ana Müzik").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[15];
        
        settingscanvas.GetComponent<Transform>().Find("Kamera").Find("Camera Sensetive").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[16];
        settingscanvas.GetComponent<Transform>().Find("Kamera").Find("Head Bobbing").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[17];
        
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Select Language").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[18];
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Substitle font size").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[19];
        
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Ekran Boyutu").Find("Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[20];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Ekran Boyutu").Find("Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[21];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Ekran Boyutu").Find("Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();

        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Grafik Ayarı").Find("Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[22];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Grafik Ayarı").Find("Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[23];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Grafik Ayarı").Find("Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[2].text = dia.menuUI[24];
        settingscanvas.GetComponent<Transform>().Find("Grafik").Find("Grafik Ayarı").Find("Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        
        settingscanvas.GetComponent<Transform>().Find("Kamera").Find("Head Bobbing").Find("Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[25];
        settingscanvas.GetComponent<Transform>().Find("Kamera").Find("Head Bobbing").Find("Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[26];
        settingscanvas.GetComponent<Transform>().Find("Kamera").Find("Head Bobbing").Find("Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Substitle font size").Find("FontSize").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[27];
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Substitle font size").Find("FontSize").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[28];
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Substitle font size").Find("FontSize").gameObject.GetComponent<TMP_Dropdown>().options[2].text = dia.menuUI[29];
        settingscanvas.GetComponent<Transform>().Find("Dil").Find("Substitle font size").Find("FontSize").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
    }

    public void LoadSettings()
    {
        resolutionsize.value = PlayerPrefs.GetInt("RESOLUTION_INDEX", 3);
        resolutionsize.RefreshShownValue();

        screensizechoose.value = PlayerPrefs.GetInt("SCREEN_MODE", 0);
        resolutionsize.RefreshShownValue();
        
        graphicsettings.value = PlayerPrefs.GetInt("GRAPHICS_QUALITY", 0);
        graphicsettings.RefreshShownValue();
        
        antialiasing.value = PlayerPrefs.GetInt("AA_MODE", 3);
        antialiasing.RefreshShownValue();


        mainvolumeslider.value = PlayerPrefs.GetFloat("MAIN_VOLUME", 1f);
        menumusic.volume = PlayerPrefs.GetFloat("MAIN_VOLUME", 1f);


        camerasenstive.value = PlayerPrefs.GetFloat("MOUSE_SENS", 20f)/100f;
        
        headbobbingsettings.value = PlayerPrefs.GetInt("HEAD_BOB_ENABLED", 1);
        headbobbingsettings.RefreshShownValue();

        
        fontsizeDropdown.value = PlayerPrefs.GetInt("FONT_SIZE", 1);
        fontsizeDropdown.RefreshShownValue();
    }
}