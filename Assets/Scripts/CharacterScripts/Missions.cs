using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Missions : MonoBehaviour
{
    public float startdelay = 3f;
    public bool isfinal= false;
    public int missionCount = 0;
    public TextMeshProUGUI missionText;
    public string[] missions = new string[50];
    void Start()
    {
        if(!isfinal)
            StartCoroutine(StartScene(missions[missionCount]));
    } 
    public void DisMis(int i)
    {
        StartCoroutine(DisMission(missions[i]));
    }
    public IEnumerator DisMission(string s)
    {
        transform.Find("Missions").Find("Mission").gameObject.GetComponent<TMP_Text>().fontStyle = FontStyles.Strikethrough;
        transform.Find("Missions").Find("Mission").gameObject.GetComponent<TMP_Text>().color = Color.green;
        if (missionText.text != "")
        {
            GetComponent<AudioSource>().Play();
            transform.Find("Missions").gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
        }
        transform.Find("Missions").gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        GetComponents<AudioSource>()[1].Play();
        transform.Find("Missions").Find("Mission").gameObject.GetComponent<TMP_Text>().fontStyle &= ~FontStyles.Strikethrough;
        transform.Find("Missions").Find("Mission").gameObject.GetComponent<TMP_Text>().color = Color.white;
        missionText.text = s;
        transform.Find("Missions").gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        transform.Find("Missions").gameObject.SetActive(false);
    }
    
    public void StartMis(int i)
    {
        StartCoroutine(StartScene(missions[i]));
    }
    public IEnumerator StartScene(string s)
    {
        yield return new WaitForSeconds(startdelay);
        missionText.text = s;
        GetComponents<AudioSource>()[1].Play();
        transform.Find("Missions").gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        transform.Find("Missions").gameObject.SetActive(false);
    }
}
