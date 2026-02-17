using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SelectionScript : MonoBehaviour
{
    public LaraDead LD;

    void Start()
    {
        SetLangSelect();
    }

    public void SetLangSelect()
    {
        transform.Find("Canvas/Selections/image1/Selection1").gameObject.GetComponent<TextMeshProUGUI>().text = LD.dia.uıUI[32];
        transform.Find("Canvas/Selections/image2/Selection2").gameObject.GetComponent<TextMeshProUGUI>().text = LD.dia.uıUI[33];
        transform.Find("Canvas/Selections/image3/Selection3").gameObject.GetComponent<TextMeshProUGUI>().text = LD.dia.uıUI[34];
        transform.Find("Canvas/Selections/Select_Text").gameObject.GetComponent<TextMeshProUGUI>().text = LD.dia.uıUI[31];
    }

    public void ClickButton(int index)
    {
        if(index == 1)
            LD.finalSelect = 1;
        if(index == 2)
            LD.finalSelect = 2;
        if(index == 3)
            LD.finalSelect = 3;
        
        transform.Find("Canvas/Selections").gameObject.SetActive(false);
    }
}
