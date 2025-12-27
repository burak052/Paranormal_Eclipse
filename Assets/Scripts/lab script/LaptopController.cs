using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LaptopController : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public AudioSource laptopsuccess;
    public AudioSource laptopdenied;
    public GameObject canvasLaptop;

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
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window log").gameObject.SetActive(true);
    }
    public void openPass()
    {
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window pass").gameObject.SetActive(true);
    }
    public void ExitLog()
    {
        canvasLaptop.transform.Find("Desktop window pass").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window pass turkish").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window log").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop window log turkish").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(true);
    }
    IEnumerator openSystem()
    {
        yield return new WaitForSeconds(2f);
        canvasLaptop.transform.Find("Background").gameObject.SetActive(false);
        canvasLaptop.transform.Find("Desktop").gameObject.SetActive(true);
    }
}
