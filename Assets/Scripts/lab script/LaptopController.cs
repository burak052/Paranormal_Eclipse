using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LaptopController : MonoBehaviour
{
    public Dialogs dia;
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public AudioSource laptopsuccess;
    public AudioSource laptopdenied;
    public AudioSource openLogSound;
    public GameObject canvasLaptop;
    public BoxCollider col;
    public BoxCollider seaCol;
    public bool isload = false;

    void Start()
    {
        SetLangLaptop();
    }

    public void TryLogin()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        if (username.ToLower() == "nova" && password.ToLower() == "1441")
        {
            laptopsuccess.Play();
            canvasLaptop.transform.Find("Login Image").gameObject.SetActive(false);
            canvasLaptop.transform.Find("Background").gameObject.SetActive(true);
            StartCoroutine(openSystem());
        }
        else
        {
            laptopdenied.Play();
            usernameInput.text = "";
            passwordInput.text = "";
        }
    }
    public void openLog()
    {
        openLogSound.Play();
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window log").gameObject.SetActive(true);
    }
    public void openPass()
    {
        openLogSound.Play();
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window pass").gameObject.SetActive(true);
        if(col != null && !isload)
            col.enabled = true;
        if(seaCol != null && !isload)
            seaCol.enabled = false;
    }
    public void ExitLog()
    {
        canvasLaptop.transform.Find("Desktop window pass").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window log").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(true);
    }
    IEnumerator openSystem()
    {
        yield return new WaitForSeconds(2f);
        canvasLaptop.transform.Find("Background").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(true);
    }

    public void SetLangLaptop()
    {
        transform.Find("Canvas laptop/Login Image/username/Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[35];

        transform.Find("Canvas laptop/Login Image/password/Text Area/Placeholder").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[36];

        transform.Find("Canvas laptop/Background/welcome txt").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[37];

        transform.Find("Canvas laptop/Desktop/Image/password").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[38];
        transform.Find("Canvas laptop/Desktop window pass/password").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[38];
        transform.Find("Canvas laptop/Desktop window pass/window password").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[38] + " 1453";
        transform.Find("Canvas laptop/Desktop window log/password").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[38];

        transform.Find("Canvas laptop/Desktop/Image (1)/personal").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[39];
        transform.Find("Canvas laptop/Desktop window pass/personal").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[39];
        transform.Find("Canvas laptop/Desktop window log/personal").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[39];

        transform.Find("Canvas laptop/Desktop window log/window log").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[40];
    }
}
