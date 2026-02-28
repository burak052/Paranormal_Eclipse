using UnityEngine;
using TMPro;

public class signal : MonoBehaviour
{
    public GameObject dis1;
    public GameObject dis2;
    public GameObject en1;
    public GameObject laranote;
    public TextMeshProUGUI pass;
    public Dialogs dia;
    bool havesignalon = false;
    bool havepassact = false;

    public void SignalOn()
    {
        dis1.SetActive(false);
        dis2.SetActive(false);
        en1.SetActive(true);
        transform.parent.Find("DialogTriggerCube").gameObject.SetActive(true);
        pass.text = dia.uıUI[42];
        havesignalon = true;
    }
    public void PasswordActive()
    {
        pass.text = $@"{dia.uıUI[44]}
1327";
        laranote.SetActive(true);
        havepassact = true;
    }

    public void SetLang()
    {
        transform.Find("Image2/no signal text1").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[41];
        transform.Find("pass text").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[41];
        if(havesignalon)
            SignalOn();
        if(havepassact)
            PasswordActive();
        
        transform.Find("Image2/Lara note").gameObject.GetComponent<TextMeshProUGUI>().text = dia.uıUI[43];
    }
}
