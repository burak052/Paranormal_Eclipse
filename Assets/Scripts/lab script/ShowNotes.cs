using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ShowNotes : MonoBehaviour
{
    public GameObject paper;
    public string noteText1 = 
    @"    Deney 27 beklenenden daha erken bir sapma gosterdi. Kronometre dogru calisiyor, fakat gozlemci artik referans kabul edilemez. Zaman duzensizlesiyor.

    Laboratuvarin ikinci seviyesinde manyetik alan duzensizlesti. Ozellikle izolasyon odasinda kalis suresi 4 dakikayi gecmemeli. Daha uzun maruz kalma durumunda hatirlanamayan bosluklar olusuyor.

    Sisteme tekrar erismem gerekirse:
    Kullanici adi: NOVA
    Sifre: 1441

    -Prof. Arthur";
    public string noteTextEN1 =
    @"    Experiment 27 showed an earlier deviation than expected. The chronometer is functioning correctly, but the observer can no longer be considered a reliable reference. Time is becoming unstable.

    Magnetic instability has been detected on the second level of the laboratory. Time spent in the isolation chamber should not exceed four minutes. Prolonged exposure results in memory gaps that cannot be recalled.

    If I need to access the system again:
    Username: NOVA
    Password: 1441

    - Prof. Arthur";
    public string noteText2 = 
    @"    Guvenlik Protokolu – Dahili Kullanım 

    Bu silahlar acil durumlar icin guvenlik odasinda birakilmistir.
Mermiler sinirlidir. Takviye yoktur. 

    Zaman deneyleri sirasinda ortaya cikan anomaliler standart tehditler gibi davranmaz. Ates etmek her zaman cozum degildir; bazen durumu daha da kotulestirir.

     Eger bu silahlardan her hangi birini almak icin bir nedeniniz varsa, protokol coktan ihlal edilmistir. Tek bir karar, birden fazla zamani etkileyebilir. 

Dogru ani bekleyin. 
Yanlis bir karar, yillara mal olabilir.

     Sef Arastirmaci 
     Lara
";
    public string noteTextEN2 =
    @"Security Protocol – Internal Use Only

    These weapons have been placed in the security room for emergency situations. Ammunition is limited. No resupply is available.

    Anomalies that emerge during temporal experiments do not behave like standard threats. Firing a weapon is not always a solution; in some cases, it may make the situation worse.

    If you have a reason to take any of these weapons, the protocol has already been breached. A single decision can affect multiple timelines.

Wait for the right moment.
One wrong decision can cost years.

     Chief Researcher
     Lara  ";
    public string noteText3 = 
    @"Profesor Arthur,

Jenerator odasinda tuhaf bir durum var. Sistem calisiyor ama davranisi normal degil. Kisa sureli duraksamalar ve beklenmedik dalgalanmalar oluyor. Simdilik mudahale etmedim; yanlis bir hamlenin daha buyuk bir soruna yol acmasından endiseliyim.

Kontrol etmenizin iyi olacagini dusunuyorum.

— Jenerator Odasi Teknisyeni
      Bob";
    public string noteTextEN3 =
    @"Professor Arthur,

There is something unusual in the generator room. The system is running, but it does not feel stable. There are brief pauses and unexpected fluctuations. I have not intervened yet, as a wrong move might cause a bigger problem.

I believe it would be best if you take a look.

— Generator Room Technician
      Bob";
    public string noteText4 = 
    @"Aral, 

Isler planladigimiz gibi gitmedi. Deneyi durdurmaya calistim ama bir an icin kontrol benden cikti. Gurultu, Patlama… sonra her sey sessizlesti. Sana seslendim ama cevap vermedin.

Iyiyim… sanirim. Ama burada kalmam guvenli degil. Bir sey beni takip ediyor. Onu tam goremiyorum. Onun ne oldugunu yada kim oldugunu bilmiyorum. Tek bildigim buradan uzaklasmam gerektigi. 

Seni bu ise daha fazla bulastirmak istemedim. Beni merak edecegini biliyorum, hatta pesimden gelecegini de.

 Lutfen dikkat";
    public string noteTextEN4 =
    @"Aral,

Things didn’t go the way we planned. I tried to stop the experiment, but for a moment, I lost control. The noise, the light… and then everything went quiet. I called out to you, but you didn’t answer.

I’m okay… I think. But it isn’t safe for me to stay here. Something is following me. I can’t see it clearly. I don’t know what it is, or who it is. All I know is that I need to get away from here.

 That’s all I could do. I didn’t want to pull you any deeper into this. I know you’ll worry about me, and I know you’ll come looking for me.

Please, be car";
    public string noteText5 = 
    @"Sen bunu okuyorken ben coktan yok olup gitmis olabilirim. Laboratuvarda olanlar kontrol edilemeyen bir anin sonucu. O ana dair hatirladigim son seyler isiklar, alarmlar, ve hemen ardindan gelen o tuhaf sessizlik… Her sey orada basladi.

Bazi dongulerin cikisi yoktur, bende onlardan birinin icindeyim. Fisiltilar duyuyorum. Bana 'Senin yuzunden!' diyorlar. Beni sadece oyaliyorlar mi yoksa bir sey mi anlatmaya calisiyorlar.

Zaman burada bazen ileri bazen geri ilerliyor ama eninde sonunda basladigi noktaya geri geliyor. Ayni hatalar, ayni sonuclar. Acaba gecmis veya gelecek gercekten degistirilemez mi? Acele etmezsen sen de bu dongunun bir parcasi olursun.

Hayat ileri dogru yasanir geriye dogru anlasilir.";
    public string noteTextEN5 =
    @"While you are reading this, I may already be gone. What happened in the laboratory was the result of an uncontrollable moment. The last things I remember from that moment are the lights, the alarms, and the strange silence that followed immediately after… That is where everything began.

Some loops have no exit, and I am trapped inside one of them. I hear whispers. They say, “Because of you.” I can’t tell whether they are trying to distract me or if they are trying to tell me something.

Time here sometimes moves forward, sometimes backward, but in the end it always returns to where it began. The same mistakes, the same outcomes. Is it possible that the past or the future cannot truly be changed? If you do not rush, you too will become part of this loop.

Life is lived forward, but understood backward.";

    
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
        if(paperid == 3)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN3;
        if(paperid == 4)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN4;
        if(paperid == 5)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = noteTextEN5;
        if(paperid == 6)
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = "behind you!";
    }

    public void offpaper()
    {
        paper.SetActive(false);
        paper.transform.Find("papertext").gameObject.GetComponent<TextMeshProUGUI>().text = "";
    }

}
