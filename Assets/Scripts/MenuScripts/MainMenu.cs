using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Animation Camera;
    public Image blackScreen;    
    public float fadeTime = 1.5f;
    public TMP_Dropdown languageDropdown;
    public TMP_Dropdown fontsizeDropdown;
    public TextMeshProUGUI languageText;
    public GameObject selecetlanguage;
    public GameObject fontsize;
    public GameObject fontcolor;
    public GameObject mainmusic;
    public GameObject gamemusic;
    public Slider mainvolume;
    public Slider gamevolume;

    void Start()
    {
        blackScreen.gameObject.SetActive(false);
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

    public void Exit()
    {
        Application.Quit();
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
        gamevolume.gameObject.SetActive(false);
    }

    public void settinggamemusic()
    {
        gamevolume.gameObject.SetActive(true);
        mainvolume.gameObject.SetActive(false);
    }

    public void music()
    {
        gamemusic.SetActive(true);
        mainmusic.SetActive(true);
        selecetlanguage.SetActive(false);
        fontsize.SetActive(false);
        fontcolor.SetActive(false);
    }

    public void language()
    {
        selecetlanguage.SetActive(true);
        fontsize.SetActive(true);
        fontcolor.SetActive(true);
        gamemusic.SetActive(false);
        mainmusic.SetActive(false);
    }
    public void lanset(int val)
    {
        if (val == 0)
        {
            Debug.Log("Turkish");
        }
        if (val == 1)
        {
            Debug.Log("English");
        }
    }
    public void chofontsize(int val)
    {
        if (val == 0)
        {
            Debug.Log("Small");
        }
        if (val == 1)
        {
            Debug.Log("Medium");
        }
        if (val == 2)
        {
            Debug.Log("Big");
        }
    }
}
