using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Animation Camera;
    public Image blackScreen;    
    public float fadeTime = 1.5f;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown fontsizeDropdown;
    public TMP_Dropdown fontcolorDropdown;
    public TMP_Dropdown resolutionsize;
    public TMP_Dropdown screensizechoose;
    public TMP_Dropdown graphicsettings;
    public TMP_Dropdown antialiasing;
    public TextMeshProUGUI languageText;
    public GameObject selecetlanguage;
    public GameObject fontsize;
    public GameObject fontcolor;
    public GameObject mainmusic;
    public GameObject gamemusic;
    public GameObject resolution;
    public GameObject screensize;
    public GameObject graphics;
    public GameObject aliasing;
    public Slider mainvolume;
    public Slider gamevolume;
    public AudioSource menumusic;

    void Start()
    {
        blackScreen.gameObject.SetActive(false);
    }

    void Awake()
    {
        antialiasing.onValueChanged.RemoveAllListeners();
        antialiasing.onValueChanged.AddListener(resultaliasing);
    }

    public void resultaliasing(int val)
    {
        Debug.Log("SECILEN: " + val);
    }

    public void NewGame()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(FadeAndStart());
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
    }

    public void back2menu()
    {
        Camera.Play("credits2menu");
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
        fontcolorDropdown.gameObject.SetActive(false);
    }

    public void sellanguage()
    {
        languageDropdown.gameObject.SetActive(true);
        fontsizeDropdown.gameObject.SetActive(false);
        fontcolorDropdown.gameObject.SetActive(false);
    }

    public void choosefontcolor()
    {
        fontcolorDropdown.gameObject.SetActive(true);
        languageDropdown.gameObject.SetActive(false);
        fontsizeDropdown.gameObject.SetActive(false);
    }

    public void settingmainmusic()
    {
        mainvolume.gameObject.SetActive(true);
        gamevolume.gameObject.SetActive(false);
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

    public void settinggamemusic()
    {
        gamevolume.gameObject.SetActive(true);
        mainvolume.gameObject.SetActive(false);
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

    public void grafik()
    {
        gamemusic.SetActive(false);
        mainmusic.SetActive(false);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        fontcolor.SetActive(false);
        resolution.SetActive(true);
        screensize.SetActive(true);
        graphics.SetActive(true);
        aliasing.SetActive(true);
    }

    public void music()
    {
        gamemusic.SetActive(true);
        mainmusic.SetActive(true);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        fontcolor.SetActive(false);
        resolution.SetActive(false);
        screensize.SetActive(false);
        graphics.SetActive(false);
        aliasing.SetActive(false);
    }

    public void language()
    {
        selecetlanguage.SetActive(true);
        fontsize.SetActive(true);
        fontcolor.SetActive(true);
        gamemusic.SetActive(false);
        mainmusic.SetActive(false);
        resolution.SetActive(false);
        screensize.SetActive(false);
        graphics.SetActive(false);
        aliasing.SetActive(false);
    }
    public void lanset(int val)
    {
        Debug.Log(languageDropdown.options[val].text);
    }
    public void chofontsize(int val)
    {
        Debug.Log(fontsizeDropdown.options[val].text);
    }
    public void chofontcolor(int val)
    {
        Debug.Log(fontcolorDropdown.options[val].text);
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
    /*public void resultaliasing(int val)
    {
        Debug.Log(antialiasing.options[val].text);
    }*/

}