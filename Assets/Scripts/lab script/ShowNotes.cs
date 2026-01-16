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
    string noteText2 = 
    @"    Guvenlik Protokolu – Dahili Kullanım 

    Bu silahlar acil durumlar icin guvenlik odasinda birakilmistir.
Mermiler sinirlidir. Takviye yoktur. 

    Zaman deneyleri sirasinda ortaya cikan anomaliler standart tehditler gibi davranmaz. Ates etmek her zaman cozum degildir; bazen durumu daha da kotulestirir.

     Eger bu silahlardan her hangi birini almak icin bir nedeniniz varsa, protokol coktan ihlal edilmistir. Tek bir karar, birden fazla zamani etkileyebilir. 

Dogru ani bekleyin. 
Yanlıs bir karar, yillara mal olabilir.

     Sef Arastirmaci 
     Lara
";
    string noteTextEN2 =
    @"Security Protocol – Internal Use Only

    These weapons have been placed in the security room for emergency situations. Ammunition is limited. No resupply is available.

    Anomalies that emerge during temporal experiments do not behave like standard threats. Firing a weapon is not always a solution; in some cases, it may make the situation worse.

    If you have a reason to take any of these weapons, the protocol has already been breached. A single decision can affect multiple timelines.

Wait for the right moment.
One wrong decision can cost years.

     Chief Researcher
     Lara  ";

    
    void Start()
    {
        paper.SetActive(false);
    }

    public void showpaper(int paperid)
    {
        paper.SetActive(true);
        if(paperid == 1)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN1;
        if(paperid == 2)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN2;
    }

    public void offpaper()
    {
        paper.SetActive(false);
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

}
