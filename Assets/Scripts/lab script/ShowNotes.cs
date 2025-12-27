using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ShowNotes : MonoBehaviour
{
    public GameObject paper;
    string noteText1 = 
    @"    Deney 27 beklenenden daha erken bir sapma gosterdi. Kronometre dogru calisiyor, fakat gozlemci artik referans kabul edilemez. Zaman duzensizlesiyor.

    Laboratuvarin ikinci seviyesinde manyetik alan duzensizlesti. Ozellikle izolasyon odasinda kalis suresi 4 dakikayi gecmemeli. Daha uzun maruz kalma durumunda hatirlanamayan bosluklar olusuyor.

    Sisteme tekrar erismem gerekirse:
    Kullanici adi: NOVA
    Sifre: 1441

    -Prof. Arthur";
    string noteTextEN1 =
    @"    Experiment 27 showed an earlier deviation than expected. The chronometer is functioning correctly, but the observer can no longer be considered a reliable reference. Time is becoming unstable.

    Magnetic instability has been detected on the second level of the laboratory. Time spent in the isolation chamber should not exceed four minutes. Prolonged exposure results in memory gaps that cannot be recalled.

    If I need to access the system again:
    Username: NOVA
    Password: 1441

    - Prof. Arthur";

    
    void Start()
    {
        paper.SetActive(false);
    }

    public void showpaper(int paperid)
    {
        paper.SetActive(true);
        if(paperid == 1)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN1;
    }

    public void offpaper()
    {
        paper.SetActive(false);
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

}
