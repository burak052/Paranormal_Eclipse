using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Steamworks;


public class GrevyardBlack : MonoBehaviour
{
    public Dialogs dia;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(Grevyard());
    }
    IEnumerator Grevyard()
    {
        yield return new WaitForSeconds(4f);
        float t = 0f;

        while (t < 2f)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / 2f);
            transform.Find("Canvas/Image").gameObject.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(dia.SecondEndDialogPart2());
        yield return StartCoroutine(ActiveBlackGrevyard());
        yield return new WaitForSeconds(5f);
        transform.Find("Canvas/EndCredits").gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        transform.Find("Canvas/EndCredits/End Logo").gameObject.SetActive(false);
        
        bool alreadyUnlocked;
        SteamUserStats.GetAchievement("ACH_ENDING_1", out alreadyUnlocked);

        if (!alreadyUnlocked)
        {
            SteamUserStats.SetAchievement("ACH_ENDING_1");
            SteamUserStats.StoreStats();
            Debug.Log("Achievement gönderildi.");
        } 

        transform.Find("Canvas/EndCredits/Credits").gameObject.SetActive(true);
        yield return StartCoroutine(transform.Find("Canvas/EndCredits/Credits").gameObject.GetComponent<EndGameCradits>().creditsslider());
    }
    
    IEnumerator ActiveBlackGrevyard()
    {
        float t = 0f;

        while (t < 2f)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / 2f);
            transform.Find("Canvas/Image").gameObject.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
