using UnityEngine;
using TMPro;

public class signal : MonoBehaviour
{
    public GameObject dis1;
    public GameObject dis2;
    public GameObject en1;
    public GameObject laranote;
    public TextMeshProUGUI pass;

    public void SignalOn()
    {
        dis1.SetActive(false);
        dis2.SetActive(false);
        en1.SetActive(true);
        transform.parent.Find("DialogTriggerCube").gameObject.SetActive(true);
        pass.text = "please wait";
    }
    public void PasswordActive()
    {
        pass.text = @"nova code
1327";
        laranote.SetActive(true);
    }
}
