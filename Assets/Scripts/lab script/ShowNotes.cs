using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ShowNotes : MonoBehaviour
{
    public GameObject paper;
    public string noteText1;
    public string noteText2;
    public string noteText3;
    public string noteText4;
    public string noteText5;
    public string noteText6;
    public string noteText7;
    
    void Start()
    {
        paper.SetActive(false);
    }

    public void showpaper(int paperid)
    {
        paper.SetActive(true);
        if(paperid == 1)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText1;
        if(paperid == 2)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText2;
        if(paperid == 3)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText3;
        if(paperid == 4)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText4;
        if(paperid == 5)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText5;
        if(paperid == 6)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText6;
        if(paperid == 7)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteText7;
    }

    public void offpaper()
    {
        paper.SetActive(false);
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

}
