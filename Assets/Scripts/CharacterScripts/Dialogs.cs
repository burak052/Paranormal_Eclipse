using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Dialogs : MonoBehaviour
{
    public int scene = 1;
    public TextMeshProUGUI dialog;
    public Missions mis;
    public BoxCollider seaCol;
    public StartEnergySmoke SES;
    public bool Laradia = false;
    public string Language = "turkce";
    public string[] dias = new string[300];

    Coroutine activeDialog;
    void Start()
    {
        if(Language == "turkce")
        {
            dias[0] = "Lara: Laboratuvara girmeden önce Nova merkezinin giriş kodunu göndermesini beklemeliyiz.";
            dias[1] = "Aral: Giriş kodu mu?";
            dias[2] = "Lara: Evet 4 haneli bir kod. Bu kodu adadaki konteyner binada bulunan bilgisayarlara gönderecekler.";
            dias[3] = "Lara: Prof. Arthur Konteynera giriş kartının hangarda olduğundan söz etmişti.";
            dias[4] = "Lara: Sen önden git, benim almam gereken bir kaç eşya var. Merak etme sana yetişirim.";
            dias[5] = "Lara: Daha ne kadar bana öyle bakacaksın?";
            dias[6] = "Aral: İşte burada.";
            dias[7] = "Lara: Görünen o ki, kartı bulup kapıyı açmışsın.";
            dias[8] = "Aral: Evet şimdi açtım, yani zamanlaman mükemmel.";
            dias[9] = "Lara: Ben her zaman dakikimdir.";
            dias[10] = "Lara: Bekle bir dakika sinyal yokta ne demek. Sistem arızalı mı yani? Bunca yolu boşuna mı geldik?";
            dias[11] = "Aral: Belkide radyo kulesinde bir arıza vardır.";
            dias[12] = "Lara: Neden böyle düşündün?";
            dias[13] = "Aral: Çünkü burdaki sistem oldukça temiz ve çalışıyor gibi görünüyor. Bence sorun radyo kulesinde. Hangarda bir kaç alet edevat görmüştüm. Onlarıda alıp bir kontrol edeyim.";
            dias[14] = "Lara: Tamam o halde, bende burada kalıp neler yapabileceğime bir bakarım.";
            dias[15] = "Aral: Vay! güzel manzara.";
            dias[16] = "Aral: O ses te neydi?";
            dias[17] = "Aral: Sanırım sadece bir hayvandı.";
            dias[18] = "Aral: Pekala şimdi radyo kulesine gitmeliyim.";
            dias[19] = "Aral: Pekala bu iş görür. Şimdi lara'nın yanına dönmeliyim.";
            dias[20] = "Aral: Bu feneri Lara'mı bırakmış?";
            dias[21] = "Aral: Sıkışan kapıları açmak için iş görür.";
            dias[22] = "Aral: Kendimi korumam gerekirse diye.";
            dias[23] = "Aral: Hepsi tamam.";
            dias[24] = "Lara: Gelmişsin. Sen kuledeki arızayı düzelttikten sonra sinyal geldi ve bende bağlantıyı sağladım ama merkez henüz kodu göndermemiş.";
            dias[25] = "Aral: Elektrik kutusu yukarıda olmalı.";
            dias[26] = "Aral: Yani erken mi gelmişiz?";
            dias[27] = "Lara: Aslında hayır, daha geç gelseydik akşam olurdu ve kuledeki arızayı karanlıkta düzeltebileceğinden şüpheliyim.";
            dias[28] = "Aral: Peki kodu ne zaman gönderecekleri belli mi?";
            dias[29] = "Lara: iki, üç saate gönderirler. Burada yataklar da var istersen uyuyabilirsin. Uzun yoldan geldik ikimizde yorgunuz.";
            dias[30] = "Aral: Belki uyumadan önce adayı biraz gezebilirim.";
            dias[31] = "Lara: Sen nasıl istersen.";
            dias[32] = "Aral: Kaç saattir uyuyorum ben. Merkez şifreyi göndermiş olmalı.";
            dias[33] = "Aral: Lara nerede?";
            dias[34] = "Aral: Bu da ne? Bir gölgemi? Ama ışığın önünde kimse yokki...";
            dias[35] = "Aral: Az önce ne oldu öyle? Sanırım yeni uyandığım için henüz kendime gelemedim. Evet başka açıklaması olamaz.";
            dias[36] = "Aral: Lara.";
            dias[37] = "Lara: Ne kadar da uykucusun, seni beklerken canım sıkıldı sahile indim.";
            dias[38] = "Aral: Sen hiç uyumadın mı?";
            dias[39] = "Lara: Bir bebek gibi uyudum ama senden önce uyandım. Bu arada bıraktığım feneri aldın mı?";
            dias[40] = "Aral: Evet aldım ve dışarı çıktığımda kapının önünde bir gölge vardı yaklaşınca kayboldu.";
            dias[41] = "Lara: Gölge mi? Belkide senin gölgendi ve kapı arkandan kapanınca gölgende kayboldu.";
            dias[42] = "Aral: Hayır benim gölgem değildi dışarıdaki ışığın önündeydi.";
            dias[43] = "Lara: Eminim mantıklı bir açıklaması vardır.";
            dias[44] = "Aral: Aklıma gelen tek şey uyku sersemi olduğum için hayal görme ihtimalim.";
            dias[45] = "Lara: Bak gördünmü mantıklı bir açıklama buldun bile.";
            dias[46] = "Aral: Her neyse merkez kodu göndermiş kod 1327.";
            dias[47] = "Lara: Biliyorum ben uyandığımda kod ekrandaydı.";
            dias[48] = "Aral: O halde Nova Laboratuvarına girmeye hazır mısın?";
            dias[49] = "Lara: Acelemiz yok biraz daha kalıp sahili izlemek istiyorum, sahil gece çok güzel değil mi?";
            dias[50] = "Aral: Ah... Bak sahil gerçekten çok güzel ama ben laboratuvara gidiyorum. Sen de bir an önce gelsen iyi olur.";
            dias[51] = "Lara: Merak etme ben her zaman dakikimdir.";
            dias[52] = "Aral: Ne de olsa laboratuvarlar steril ortamlardır.";
            dias[53] = "Aral: Laboratuvar önlüğünü giymem gerek. Soyunma odası nerede acaba?";
            dias[54] = "Aral: Hmm bu önlük hiç fena değil.";
            dias[55] = "Lara: Önlük yakışmış.";
            dias[56] = "Aral: Sen... nasıl... hangi ara geldin?";
            dias[57] = "Lara: Söylediğim gibi ben her zaman-";
            dias[58] = "Aral: Dakiksindir tamam anladım.";
            dias[59] = "Aral: Peki şimdi yapıcaklarımızdan kısaca bahseder misin?";
            dias[60] = "Lara: Tabi, ilk önce enviro odasından Aether core enerji kapsüllerini alacağız. 6 tane olması lazım.";
            dias[61] = "Lara: Daha sonra bu kapsülleri kullanarak 2. kattaki deney odasında bulunan warp moturunu çalıştırmalıyız.";
            dias[62] = "Lara: Warp moturu normalde yıldızlar arası seyahat içindir.";
            dias[63] = "Lara: Ama biz bugün warp moturunu ve Aether core enerji kapsüllerini bir arada çalıştırıp bir Parallax motoru yapmaya çalışıyoruz.";
            dias[64] = "Lara: Teoride bu motor uzay ve zamanı warp motorunda olduğu gibi sadece ileri yönlü değil de aynı zamanda geri yönlü ve daha kontrollü bir şekilde değiştirecek.";
            dias[65] = "Lara: Bu sayede zamanda yolculuğu mümkün kılmaya çalışıyoruz.";
            dias[66] = "Lara: Burada yaptıklarımız ve yapacaklarımız insanlık için çok önemli.";
            dias[67] = "Aral: Vay! bu kulağı sihir gibi geliyor.";
            dias[68] = "Lara: Yeterince gelişmiş bir teknolojinin sihirden farkı yoktur.";
            dias[69] = "Aral: Haklısın Lara C. Clarke.";
            dias[70] = "Lara: Haha! Aman ne komik.";
            dias[71] = "Aral: Enviro odası kilitli nasıl içeri giriceğiz?";
            dias[72] = "Lara: Laboratuvarın bu katından Prof. Arthur sorumluydu. Belki onun eşyalarının arasında bir tür şifre felan bulabilirsin.";
            dias[73] = "Lara: Erkekler soyunma odasına bak.";
            dias[74] = "Aral: Bunlar Prof. Arthur'un kişisel bilgisayarının kullanıcı bilgileri olmalı.";
            dias[75] = "Aral: Önce üstümü değişmeliyim.";
            dias[76] = "Lara: bir şey bulabildin mi?";
            dias[77] = "Aral: Evet. Anlaşılan Prof. Arthur'da bu laboratuvarda deneyler yapmış. Yaptığı deneylere ait notlar buldum. Bu arada giriş kodu 1453";
            dias[78] = "Lara: Harikasın.";
            dias[79] = "Lara: Pekala şimdi 6 tane Aether Core enerji kapsülü almalıyız.";
            dias[80] = "Aral: Burada rafta 5 tane kapsül var ama 2 tanesi boş.";
            dias[81] = "Lara: Hmm burada yazana göre köşedeki makine Aether Core enerji kapsülü üretebilirmiş. Makineyi aktif hale getirdim.";
            dias[82] = "Aral: Makineyi buldum ve makinenin içinde 1 tane daha dolu kapsül var. Yani sadece boş olan 2 tanesini doldurmalıyım.";
            dias[83] = "Lara: İşte bu iyi haber.";
            dias[84] = "Aral: Altı kapsülün altısı da hazır.";
            dias[85] = "Lara: Baksana burada yapılan deneylerin bir listesi var. Bu oda doğayı koruma amaçlı yapılmış, ama daha sonra başka deneylerde kullanılmaya başlanmış.";
            dias[86] = "Aral: Evet mesela bu kapsüllerden üretmek gibi. Hadi artık üst kata çıkalım ve prosedürü başlatalım.";
            dias[87] = "Lara: Tamam sen asansörü çağır ben geliyorum.";
            dias[88] = "Lara: Acaba laboratuvarın üst katı ne durumda.";
            dias[89] = "Aral: Laboratuvarın üst katı farklı bir şirket olan Arc endüstrileri tarafından yapıldı.";
            dias[90] = "Aral: Onlar laboratuvarı kendi kendini idare edecebilecek şekilde yaptılar. O yüzden iyi durumda olduğundan eminim.";
            dias[91] = "Lara: Öyle mi? Ben tüm laboratuvarı Nova şirketinin yaptığını sanıyordum.";
            dias[92] = "Aral: Nova şirketi sadece birinci katı yaptı. Amaçları enviro odasını inşa ederek oradaki araştırmalar sayesinde doğayı ve çevreyi korumaktı.";
            dias[93] = "Aral: Ama burada yapılan deneyler artık sadece o amaca hizmet etmediğinden laboratuvar Arc endüstrileri tarafından büyütüldü.";
            dias[94] = "Lara: Sence Nova merkezinin bizden sakladığı şeyler mi var?";
            dias[95] = "Aral: Kesinlikle, bu yüzden Nova Merkezinin elemanlarına güvenmiyorum... Tabi sen istisna olabilirsin.";
            dias[96] = "Lara: Bunları bana anlattığına göre bende sana güveniyorum.";
            dias[97] = "Ah... Başım.";
            dias[98] = "Ne oldu?";
            dias[99] = "Onu bulmalıyım.";
            dias[100] = "Lara: Sanırım güç kablosu takılmamış.";
            dias[101] = "Aral: Ben kabloları kontrol edeyim.";
            dias[102] = "Aral: İşte oldu, tüm sistemler açıldı.";
            dias[103] = "Lara: Tamam sıradaki adım enerji kapsüllerini warp motoruna yerleştirmek.";
            dias[104] = "Aral: Warp motoru yan odada olmalı.";
            dias[105] = "Aral: Tamamdır hallettim.";
            dias[106] = "Lara: Alan dinamiklerinde bir düzensizlik fark ettim.";
            dias[107] = "Aral: Önemli bir şey mi?";
            dias[108] = "Lara: Muhtemelen düzeltirim sen prosedürü başlat. Çift kapının sağındaki masada kırmızı bir düğme bulunuyor. Bu düğme prosedürü başlatır.";
            dias[109] = "Aral: Asansör... Asansöre gitmeliyim.";
            dias[110] = "Lara: Warp motoru tam güce geldiğinde uzay zamanda bir yırtık açmalı ve bizi 1 saat öncesine göndermeli.";
            dias[111] = "Aral: O seste ne?";
            dias[112] = "Aral: Lara bu normal mi?";
            dias[113] = "Lara: Aşırı yüklenme oldu prosedürü durdur!";
            dias[114] = "Aral: Lara seni duyamıyorum.";
            dias[115] = "Aral: Prosedürü durduracağım.";
            dias[116] = "Unknown: Hayata dön.";
            dias[117] = "Aral: Buradan olmaz. Belkide üst katta bir çıkış vardır.";
            dias[118] = "Aral: Laboratuvar harap olmuş. Umarım asansör çalışıyordur.";
            dias[119] = "Aral: Hey kim var orada?";
            dias[120] = "Aral: Lara? Sen misin?";
            dias[121] = "Aral: Burada ne sikim oluyor böyle, o şeyde neydi?";
            dias[122] = "Aral: Yine şu gölge... Aklımla oynuyor.";
            dias[123] = "Aral: Jenerator burada.";
            dias[124] = "Aral: Başardım, muhtemelen şuan asansör çalışıyordur.";
            dias[125] = "Aral: Lara çok önceden burada çalışıyordu. O zamanlardan kalma bir not olmalı. Hala burada olmasına şaşırdım.";
            dias[126] = "Aral: Zaman döngüsü mü? Laboratuvar da olanlar mı? Kafam çok karıştı. Bunu Lara mı yazmış?";
            dias[127] = "Aral: Zaman döngüsü, zaman döngüsü, zaman döngüsü... Şimdi anlıyorum deney başarısız olmadı, fazla başarılı oldu.";
            dias[128] = "Aral: Gördüğüm o gölgenin ve duyduğum seslerin bu kaza ile bir bağlantısı olmalı.";
            dias[129] = "Aral: Hadi! hadi! HADİ!";  
            dias[130] = "Aral: Aman tanrım!";       
            dias[131] = "Aral: O şey beni sürekli takip ediyor. Tıpkı bir gölge gibi.";         
            dias[132] = "Aral: Sen de kimsin? Ne istiyorsun benden?";
            dias[133] = "Developer: Buraya kadar gelmeni beklemiyordum. Merakın seni doğru yere getirdi. Gizli bir bölgedesin ve buradaki not, oyunun üçüncü finalinin kilidini açıyor.";
            dias[134] = "Aral: İnanamıyorum! Lara geçmişteki kendini öldürüp onun yerine mi geçmiş? Beni kurtarmak için mi? Ben onun sayesinde mi hayattayım?";
            dias[135] = "Aral: Ona sormam gereken çok soru var ama hepsinden önce bu çılgınlığa bir son vermesini sağlamalıyım.";
            dias[136] = "Aral: Sahildeki Lara mı? Onunla konuşmalıyım.";
            dias[137] = "Aral: Lara, şükürler olsun ki iyisin. Burada ne yapıyorsun?";
            dias[138] = "Lara: Aral? Bu sensin değil mi? Neden geri döndün?";
            dias[139] = "Aral: Evet benim. Geri dönmek derken neden söz ediyorsun? Ayrıca burada ne yapıyorsun?";
            dias[140] = "Lara: Seninle konuştuk ve bana gitmem gerektiğini söyledin, ardından vedalaştık.";
            dias[141] = "Aral: Tüm bunlar ne zaman oldu? Laboratuvardaki kazadan sonra bir anda kayboldun. Bıraktığın notu buldum.";
            dias[142] = "Lara: Şimdi anlıyorum...";
            dias[143] = "Aral: Tanrı aşkına! Artık ne olup bittiğini anlatır mısın?.";
            dias[144] = "Lara: Aral, sen arafta sıkışıp kaldın. Kıyafetine bak!";
            dias[145] = "Lara: Eğer dediğin gibi Laboratuvardaki kazadan sonra buraya gelmiş olsan hala laboratuvar önlüğünü giyiyor olurdun, ama adaya geldiğimiz gün giydiğin ceketi giyiyorsun.";
            dias[146] = "Aral: İnanamıyorum... Bu nasıl olabilir?";
            dias[147] = "Lara: Şuanki zaman adaya geldiğimiz günün gecesi. Sen aslında uyuyorsun bense sahile geldim.";
            dias[148] = "Lara: Seni bulunduğun araftan, bu zaman döngüsünden kurtarmaya çalıştım. Her şeyi senin için yaptım. Hatta...";
            dias[149] = "Aral: Hatta ne? Ne yaptın lara?";
            dias[150] = "Lara: Sen bunu öğrendiğin zaman gitmem gerektiğini söylemiştin. O yüzden şuanda bunu açıklamayacağım. Nasıl olsa öğreneceksin.";
            dias[151] = "Lara: Sadece seni bunu yapacak kadar sevdiğimi bil.";
            dias[152] = "Aral: Lara... Gitmeni istemiyorum. Sana gitmeni asla söylemem ne gelecekte ne geçmişte. Ne olur gitme benimle kal.";
            dias[153] = "Lara: Aral sen...";
            dias[154] = "Aral: Sorun neyse üstesinden gelebiliriz eminim. O zamana kadar ve hatta ondan sonrasında da sadece benimle kal.";
            dias[155] = "Lara: Beni zor bir karar vermeye zorluyorsun. yine...";
            dias[156] = "Lara: Aslına bakarsan gitmeyi zaten hiç istememiştim. Seni bu araftan kurtaracağım.";
            dias[157] = "Aral: İkimiz halledebiliriz. Eğer-";
            dias[158] = "Lara: Aral Çabuk saklan seni görmemeli.";
            dias[159] = "Aral: Kim beni görmemeli?";
            dias[160] = "Lara: Anlatacak vakit yok acele et ve şu ağacın arkasına saklan hadi.";
            dias[161] = "Aral: Bir dakika... Laranın yanına gelen ben miyim?";
            dias[162] = "Aral: Neler oluyor? Bu zaman kırılması mı? Geçmişteki kendimi gördüm ve gerçeklik algımı yitirmeye başladım.";
            dias[163] = "Aral: Bu geçmişteki halim mi? Ayrıca ışığın önünde duruyorum nasıl kendimi göremem?";
            dias[164] = "Aral: Bir dakika o sürekli gördüğüm gölge... Yoksa...";
            dias[165] = "Aral: Ben o gölgeye dönüşüyorum.";
            dias[166] = "Aral: Lara'nın arafta sıkışmak derken kastettiği buydu.";
            dias[167] = "Aral: Görünen o ki geçmişteki kendimi her gördüğümde gerçeklik kırılıyor ve zamanda biraz daha geri gidiyorum.";
            dias[168] = "Aral: Tam anlamıyla zamanda bir gölge oluyorum.";
            dias[169] = "Unknown: Bu da ne? Bir gölgemi? Ama ışığın önünde kimse yokki...";
        }
        else        /////////ingilizce dialoglar buraya eklenecek
        {
        }

        dialog.text = "";
        if (scene == 1)
            PlayDialog(OutdoorDialog());
        if (scene == 2)
            EventDia(5f,dias[53],4f);
        if (scene == 3)
            EventDia(3f,dias[136],6f);
    }

    void Update()
    {
        if(dialog.text != "")
        {
            if(dialog.text.StartsWith("Aral"))
                dialog.color = new Color32(0xBD, 0xE7, 0xFF, 0xFF);
            else
                dialog.color = new Color32(0xFF, 0xBD, 0xE5, 0xFF);
        }
    }

    void PlayDialog(IEnumerator dialogRoutine)
    {
        if (activeDialog != null)
        {
            StopCoroutine(activeDialog);
            activeDialog = null;
        }

        dialog.text = ""; // ekranda kalan yazıyı temizle
        activeDialog = StartCoroutine(dialogRoutine);
    }
    
    IEnumerator OutdoorDialog()
    {
        yield return new WaitForSeconds(4f);
        dialog.text = dias[0];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[1];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[2];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[3];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[4];
        yield return new WaitForSeconds(4.5f);
        dialog.text = "";
        mis.StartMis(mis.missionCount);
        Laradia = true;
    }

    public void EventDia(float delayafter, string s, float delaybefore=0f)
    {
        PlayDialog(EventDialog(delayafter, s, delaybefore));
    }
    IEnumerator EventDialog(float delayafter, string s, float delaybefore=0f)
    {
        if(delaybefore != 0f)
            yield return new WaitForSeconds(delaybefore);
        dialog.text = s;
        yield return new WaitForSeconds(delayafter);
        dialog.text = "";
    }

    public void SleepDoor()
    {
        PlayDialog(SleepDoorOpen());
    }
    IEnumerator SleepDoorOpen()
    {
        dialog.text = dias[7];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[8];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[9];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[10];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[11];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[12];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[13];
        yield return new WaitForSeconds(8f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[14];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        mis.DisMis(++mis.missionCount);
    }
    
    public void WakeUp()
    {
        PlayDialog(WakeUpStart());
    }
    IEnumerator WakeUpStart()
    {
        dialog.text = dias[32];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[33];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }
    
    
    public void BeachSpeak()
    {
        PlayDialog(BeachSpeakStart());
    }
    IEnumerator BeachSpeakStart()
    {
        dialog.text = dias[36];
        yield return new WaitForSeconds(1.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[37];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[38];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[39];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[40];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[41];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[42];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[43];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[44];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[45];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[46];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[47];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[48];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[49];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[50];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[51];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        mis.DisMis(++mis.missionCount);
    }

    
    public void Steam()
    {
        PlayDialog(SteamStart());
    }
    IEnumerator SteamStart()
    {
        dialog.text = dias[32];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[33];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }
    
    public void LabCoat(ActiveBlackScreen ABS, LaraMovement Lara)
    {
        PlayDialog(LabCoatDialog(ABS, Lara));
    }
    IEnumerator LabCoatDialog(ActiveBlackScreen ABS, LaraMovement Lara)
    {
        ABS.DisablePlayer();
        dialog.text = dias[55];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[56];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[57];
        yield return new WaitForSeconds(3f);
        dialog.text = dias[58];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        ABS.ActivePlayer();
        Lara.LaraXray();
        yield return new WaitForSeconds(2.5f);
        dialog.text = dias[59];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[60];
        yield return new WaitForSeconds(7f);
        dialog.text = dias[61];
        yield return new WaitForSeconds(7f);
        dialog.text = dias[62];
        yield return new WaitForSeconds(5f);
        dialog.text = dias[63];
        yield return new WaitForSeconds(8f);
        dialog.text = dias[64];
        yield return new WaitForSeconds(10f);
        dialog.text = dias[65];
        yield return new WaitForSeconds(4f);
        dialog.text = dias[66];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[67];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[68];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[69];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[70];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        seaCol.enabled = true;
    }

    
    public void PassDia()
    {
        PlayDialog(PassDiaStart());
    }
    IEnumerator PassDiaStart()
    {
        dialog.text = dias[76];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[77];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[78];
        yield return new WaitForSeconds(1f);
        dialog.text = "";
    }
    
    public void CapsuleDia()
    {
        PlayDialog(CapsuleDialog());
    }
    IEnumerator CapsuleDialog()
    {
        dialog.text = dias[79];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[80];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[81];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
    }
    
    public void FindMacDia()
    {
        PlayDialog(FindMacDialog());
    }
    IEnumerator FindMacDialog()
    {
        dialog.text = dias[82];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[83];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }
    
    public void ComCapDia()
    {
        PlayDialog(ComCapDialog());
    }
    IEnumerator ComCapDialog()
    {
        dialog.text = dias[23];
        yield return new WaitForSeconds(1.5f);
        dialog.text = dias[84];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[85];
        yield return new WaitForSeconds(8f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[86];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[87];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        mis.DisMis(++mis.missionCount);
        SES.OnElevatorButton();
    }

    
    public void ArcDia()
    {
        PlayDialog(ArcDialog());
    }
    IEnumerator ArcDialog()
    {
        dialog.text = dias[88];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[89];
        yield return new WaitForSeconds(7f);
        dialog.text = dias[90];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[91];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[92];
        yield return new WaitForSeconds(8f);
        dialog.text = dias[93];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[94];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[95];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[96];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(2f);
        dialog.text = dias[100];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[101];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
    }

    
    public void SeaDia()
    {
        PlayDialog(SeaDialog());
    }
    IEnumerator SeaDialog()
    {
        dialog.text = dias[71];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[72];
        yield return new WaitForSeconds(8f);
        dialog.text = dias[73];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
    }

    
    public void WarpDia()
    {
        PlayDialog(WarpDialog());
    }
    IEnumerator WarpDialog()
    {
        dialog.text = dias[102];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[103];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[104];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
    }
    
    public void Warp2Dia()
    {
        PlayDialog(Warp2Dialog());
    }
    IEnumerator Warp2Dialog()
    {
        dialog.text = dias[105];
        yield return new WaitForSeconds(1.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[106];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[107];
        yield return new WaitForSeconds(1.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[108];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        mis.DisMis(++mis.missionCount);
    }

    public void RunSoundDia()
    {
        PlayDialog(RunSoundDialog());
    }
    IEnumerator RunSoundDialog()
    {
        dialog.text = dias[119];
        yield return new WaitForSeconds(1.5f);
        dialog.text = dias[120];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
    }
    
    public void ShadowDia()
    {
        PlayDialog(ShadowDialog());
    }
    IEnumerator ShadowDialog()
    {
        yield return new WaitForSeconds(5f);
        dialog.text = dias[126];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[127];
        yield return new WaitForSeconds(6f);
        dialog.text = dias[128];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
    }

    public void EasterEggDia()
    {
        PlayDialog(EasterEggDialog());
    }
    IEnumerator EasterEggDialog()
    {
        dialog.text = dias[134];
        yield return new WaitForSeconds(7f);
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[135];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
    }
    
    public void BoatDia()
    {
        PlayDialog(BoatDialog());
    }
    IEnumerator BoatDialog()
    {
        dialog.text = dias[137];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[138];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[139];
        yield return new WaitForSeconds(4.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[140];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[141];
        yield return new WaitForSeconds(5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[142];
        yield return new WaitForSeconds(1.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[143];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[144];
        yield return new WaitForSeconds(4f);
        dialog.text = dias[145];
        yield return new WaitForSeconds(9f);
        dialog.text = dias[146];
        yield return new WaitForSeconds(2f);
        dialog.text = dias[147];
        yield return new WaitForSeconds(6f);
        dialog.text = dias[148];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[149];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[150];
        yield return new WaitForSeconds(6f);
        dialog.text = dias[151];
        yield return new WaitForSeconds(3f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[152];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[153];
        yield return new WaitForSeconds(1.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[154];
        yield return new WaitForSeconds(6f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[155];
        yield return new WaitForSeconds(3f);
        dialog.text = dias[156];
        yield return new WaitForSeconds(4f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[157];
        yield return new WaitForSeconds(3f);
        dialog.text = dias[158];
        yield return new WaitForSeconds(2.5f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[159];
        yield return new WaitForSeconds(2f);
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[160];
        yield return new WaitForSeconds(4.5f);
        dialog.text = "";
    }
}
