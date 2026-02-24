using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class ESCMenu : MonoBehaviour
{  
    public PlayerAnimationController playeranim;
    public SelectionScript SS;
    public MonoBehaviour playerMovement;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown fontsizeDropdown;
    public TMP_Dropdown resolutionsize;
    public TMP_Dropdown screensizechoose;
    public TMP_Dropdown graphicsettings;
    public TMP_Dropdown antialiasing;
    public TMP_Dropdown headbobbingsettings;
    public Slider mainvolumeslider;
    public Slider camerasenstive;
    public Dialogs dia;
    public bool canOpenMenu = true;
    bool isOpenMenu = false;
    private Transform menu;

    void Start()
    {
        menu = transform.Find("Canvas").Find("Menu");
        menu.gameObject.SetActive(true);
        SetAllSound();
        LoadSettings();
        LanguageMenu();
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

    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) && canOpenMenu))
        {
            isOpenMenu = !isOpenMenu;
            if(isOpenMenu)
                OpenMenu();
            else
                CloseMenu();
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenMenu()
    {
        menu.Find("BlackScreen").gameObject.SetActive(true);
        menu.Find("Missions").gameObject.SetActive(true);
        menu.Find("Menu").gameObject.SetActive(true);
        menu.Find("Settings").gameObject.SetActive(false);
        playeranim.SetAnimator();
        playerMovement.enabled = false;
        playeranim.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu(bool press = false)
    {
        menu.Find("BlackScreen").gameObject.SetActive(false);
        menu.Find("Missions").gameObject.SetActive(false);
        menu.Find("Menu").gameObject.SetActive(false);
        menu.Find("Settings").gameObject.SetActive(false);
        playeranim.isSetAnimator = false;
        playerMovement.enabled = true;
        playeranim.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (press)
            isOpenMenu = false;
    }

    public void GotoSettings()
    {
        menu.Find("Settings").gameObject.SetActive(true);
        menu.Find("Missions").gameObject.SetActive(false);
        menu.Find("Menu").gameObject.SetActive(false);
    }

    public void BacktoMenu()
    {
        menu.Find("Settings").gameObject.SetActive(false);
        menu.Find("Missions").gameObject.SetActive(true);
        menu.Find("Menu").gameObject.SetActive(true);
    }

    public void choseGraphics()
    {
        menu.Find("Settings/Grafik/Cozunurluk").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Ekran Boyutu").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Grafik Ayarı").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Anti-Aliasing").gameObject.SetActive(true);
        menu.Find("Settings/Ses/Ana Müzik").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Camera Sensetive").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Head Bobbing").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Select Language").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Substitle font size").gameObject.SetActive(false);
    }
    public void choseSes()
    {
        menu.Find("Settings/Grafik/Cozunurluk").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing").gameObject.SetActive(false);
        menu.Find("Settings/Ses/Ana Müzik").gameObject.SetActive(true);
        menu.Find("Settings/Kamera/Camera Sensetive").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Head Bobbing").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Select Language").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Substitle font size").gameObject.SetActive(false);
    }
    public void choseCam()
    {
        menu.Find("Settings/Grafik/Cozunurluk").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing").gameObject.SetActive(false);
        menu.Find("Settings/Ses/Ana Müzik").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Camera Sensetive").gameObject.SetActive(true);
        menu.Find("Settings/Kamera/Head Bobbing").gameObject.SetActive(true);
        menu.Find("Settings/Dil/Select Language").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Substitle font size").gameObject.SetActive(false);
    }
    public void choseLang()
    {
        menu.Find("Settings/Grafik/Cozunurluk").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing").gameObject.SetActive(false);
        menu.Find("Settings/Ses/Ana Müzik").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Camera Sensetive").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Head Bobbing").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Select Language").gameObject.SetActive(true);
        menu.Find("Settings/Dil/Substitle font size").gameObject.SetActive(true);
    }

    public void choseResolution()
    {
        menu.Find("Settings/Grafik/Cozunurluk/Cozunurluk Boyutu").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing/Kenar Yumusatma Ayarları").gameObject.SetActive(false);
    }
    public void choseScreenSize()
    {
        menu.Find("Settings/Grafik/Cozunurluk/Cozunurluk Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing/Kenar Yumusatma Ayarları").gameObject.SetActive(false);
    }
    public void choseGrapshicSettings()
    {
        menu.Find("Settings/Grafik/Cozunurluk/Cozunurluk Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.SetActive(true);
        menu.Find("Settings/Grafik/Anti-Aliasing/Kenar Yumusatma Ayarları").gameObject.SetActive(false);
    }
    public void choseAntiAliasing()
    {
        menu.Find("Settings/Grafik/Cozunurluk/Cozunurluk Boyutu").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.SetActive(false);
        menu.Find("Settings/Grafik/Anti-Aliasing/Kenar Yumusatma Ayarları").gameObject.SetActive(true);
    }

    public void choseMusic()
    {
        menu.Find("Settings/Ses/Ana Müzik/Main Music").gameObject.SetActive(true);
    }

    
    public void choseSensitive()
    {
        menu.Find("Settings/Kamera/Camera Sensetive/Camera Sensetive Settings").gameObject.SetActive(true);
        menu.Find("Settings/Kamera/Head Bobbing/Head Bobbing Settings").gameObject.SetActive(false);
    }
    public void choseHead()
    {
        menu.Find("Settings/Kamera/Camera Sensetive/Camera Sensetive Settings").gameObject.SetActive(false);
        menu.Find("Settings/Kamera/Head Bobbing/Head Bobbing Settings").gameObject.SetActive(true);
    }
    
    public void choseSelectLang()
    {
        menu.Find("Settings/Dil/Select Language/Language").gameObject.SetActive(true);
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.SetActive(false);
    }
    public void choseFontSize()
    {
        menu.Find("Settings/Dil/Select Language/Language").gameObject.SetActive(false);
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.SetActive(true);
    }

    //////////////////settings ayarları
    public void startmainvolume()
    {
        mainvolumeslider.onValueChanged.AddListener(settingvolume);
    }

    public void settingvolume(float vol)
    {
        PlayerPrefs.SetFloat("MAIN_VOLUME", vol);
        SetAllSound();
    }
    
    public void FontSizeSetting(int val)
    {
        PlayerPrefs.SetInt("FONT_SIZE", val);
        dia.LoadDias();
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

    public void OnSensitivityChanged(float value)
    {
        GlobalMouseSensitivityManager.Instance.SetSensitivity(value*100f);
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
        Missions m = menu.gameObject.GetComponent<Missions>();
        m.missionText.text = m.missions[m.missionCount];
    }


    public void SetAllSound()
    {
        AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>(true);
        if (allAudioSources == null || allAudioSources.Length == 0)
            return;

        foreach (AudioSource audio in allAudioSources)
        {
            if (audio != null)
                audio.volume = PlayerPrefs.GetFloat("MAIN_VOLUME", 1f);
        }
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


        camerasenstive.value = PlayerPrefs.GetFloat("MOUSE_SENS", 20f)/100f;
        
        headbobbingsettings.value = PlayerPrefs.GetInt("HEAD_BOB_ENABLED", 1);
        headbobbingsettings.RefreshShownValue();

        
        fontsizeDropdown.value = PlayerPrefs.GetInt("FONT_SIZE", 1);
        fontsizeDropdown.RefreshShownValue();
    }

    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void LanguageMenu()
    {
        menu.Find("Menu/Continue").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[2];
        menu.Find("Menu/Main_Menu").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[31];
        menu.Find("Menu/Settings").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[3];
        menu.Find("Menu/Exit").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[5];

        menu.Find("Settings/Grafik").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[6];
        menu.Find("Settings/Ses").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[7];
        menu.Find("Settings/Kamera").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[8];
        menu.Find("Settings/Dil").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[9];
        menu.Find("Settings/Back").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[10];
        
        menu.Find("Settings/Grafik/Cozunurluk").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[11];
        menu.Find("Settings/Grafik/Ekran Boyutu").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[12];
        menu.Find("Settings/Grafik/Grafik Ayarı").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[13];
        menu.Find("Settings/Grafik/Anti-Aliasing").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[14];
        
        menu.Find("Settings/Ses/Ana Müzik").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[15];
        
        menu.Find("Settings/Kamera/Camera Sensetive").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[16];
        menu.Find("Settings/Kamera/Head Bobbing").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[17];
        
        menu.Find("Settings/Dil/Select Language").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[18];
        menu.Find("Settings/Dil/Substitle font size").gameObject.GetComponent<TextMeshProUGUI>().text = dia.menuUI[19];
        
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[20];
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[21];
        menu.Find("Settings/Grafik/Ekran Boyutu/Ekran Boyutu Secenekleri").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();

        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[22];
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[23];
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().options[2].text = dia.menuUI[24];
        menu.Find("Settings/Grafik/Grafik Ayarı/Grafik Ayarı Secenekleri").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        
        menu.Find("Settings/Kamera/Head Bobbing/Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[25];
        menu.Find("Settings/Kamera/Head Bobbing/Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[26];
        menu.Find("Settings/Kamera/Head Bobbing/Head Bobbing Settings").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();
        
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.GetComponent<TMP_Dropdown>().options[0].text = dia.menuUI[27];
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.GetComponent<TMP_Dropdown>().options[1].text = dia.menuUI[28];
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.GetComponent<TMP_Dropdown>().options[2].text = dia.menuUI[29];
        menu.Find("Settings/Dil/Substitle font size/FontSize").gameObject.GetComponent<TMP_Dropdown>().RefreshShownValue();

        if(SS != null)
            SS.SetLangSelect();
    }
}
