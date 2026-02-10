using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Dialogs : MonoBehaviour
{
    public int scene = 1;
    public TextMeshProUGUI dialog;
    public Missions mis;
    public inventory inv;
    public ShowNotes sho;
    public BoxCollider seaCol;
    public StartEnergySmoke SES;
    public bool Laradia = false;
    
    public string[] dias = new string[300];
    public string[] menuUI = new string[100];
    public string[] uıUI = new string[100];
    string currentLanguage;

    Coroutine activeDialog;

    void OnEnable()
    {
        currentLanguage = LanguageManager.CurrentLanguage;

        if (currentLanguage == "turkce")
            LoadTurkishDialogs();
        else
            LoadEnglishDialogs();
    }

    void Start()
    {
        dialog.text = "";

        if (scene == 1)
            PlayDialog(OutdoorDialog());
        if (scene == 2)
            EventDia(5f, dias[53], 4f);
        if (scene == 3)
            EventDia(3f, dias[136], 6f);
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

    void LoadTurkishDialogs()
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
        dias[97] = "Aral: Ah... Başım.";
        dias[98] = "Aral: Ne oldu?";
        dias[99] = "Aral: Onu bulmalıyım.";
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
        dias[170] = "Aral: Lara?";
        dias[171] = "Aral: Lara hayır!";


        menuUI[1] = "YENİ OYUNA BAŞLA";
        menuUI[2] = "OYUNU YÜKLE";
        menuUI[3] = "AYARLAR";
        menuUI[4] = "JENERİK";
        menuUI[5] = "ÇIKIŞ";
        menuUI[6] = "GRAFİK";
        menuUI[7] = "SES";
        menuUI[8] = "KAMERA";
        menuUI[9] = "DİL VE ERİŞEBİLİRLİK";
        menuUI[10] = "GERİ";
        menuUI[11] = "COZUNURLUK";
        menuUI[12] = "EKRAN BOYUTU";
        menuUI[13] = "GRAFIK AYARLARI";
        menuUI[14] = "KENAR YUMUSATMA";
        menuUI[15] = "MENU MÜZİĞİ";
        menuUI[16] = "FARE HASSASİYETİ";
        menuUI[17] = "KAFA SALLANTISI";
        menuUI[18] = "DİL";
        menuUI[19] = "ALTYAZI BOYUTU";
        menuUI[20] = "CERCEVESİZ EKRAN";
        menuUI[21] = "PENCERE MODU";
        menuUI[22] = "YUKSEK";
        menuUI[23] = "ORTA";
        menuUI[24] = "DUSUK";
        menuUI[25] = "KAPALI";
        menuUI[26] = "AÇIK";
        menuUI[27] = "KÜÇÜK";
        menuUI[28] = "ORTA";
        menuUI[29] = "BÜYÜK";


        uıUI[0] = "Kilitli";
        uıUI[1] = "Levye gerekli";
        uıUI[2] = "Levye kullan";
        uıUI[3] = "Sifreyi gir";
        uıUI[4] = "Giris yap";
        uıUI[5] = "Kiyafetini degistir";
        uıUI[6] = "Asansoru cagir";
        uıUI[7] = "Lutfen bekle";
        uıUI[8] = "2. kat";
        uıUI[9] = "Al";
        uıUI[10] = "Kapsulu yerlestir";
        uıUI[11] = "Bos kapsulun yok";
        uıUI[12] = "ID kart gerekli";
        uıUI[13] = "Once yaka fenerini al";
        uıUI[14] = "Uyu";
        uıUI[15] = "Tamir et";
        uıUI[16] = "Tamir kiti gerekli";
        uıUI[17] = "Devam etmeden once kıyafetini degistir";
        uıUI[18] = "Arastir";
        uıUI[19] = "Arastiriliyor...";
        uıUI[20] = "Enerji kapsulunu yerlestir";
        uıUI[21] = "Kabloyu tak";
        uıUI[22] = "Butona bas";
        uıUI[23] = "Ac";
        uıUI[24] = "1. kat";
        uıUI[25] = "Lara ile konus";
        uıUI[26] = "Jeneratoru calistir";
        uıUI[27] = "Elektrik yok";
        uıUI[28] = "Feneri ac";
        uıUI[29] = "Comelmek";
        uıUI[30] = "Cikis";
        uıUI[31] = "";
        uıUI[32] = "";

        if(mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Gorevler";
            mis.missions[0] = "—Hangarda ID karti bulun";
            mis.missions[1] = "—Konteyner binaya girin";
            mis.missions[2] = "—Hangarda tamir kiti bulun";
            mis.missions[3] = "—radyo kulesindeki arizayi onarin";
            mis.missions[4] = "—lara'nin yanina donun";
            mis.missions[5] = "—biraz uyuyun";
            mis.missions[6] = "—yaka fenerini alin";
            mis.missions[7] = "—lara ile sahilde bulusun";
            mis.missions[8] = "—magaradaki laboratuvara girin";
            mis.missions[9] = "—laboratuvar onlugunu giyin";
            mis.missions[10] = "—enviro odasina gidin";
            mis.missions[11] = "—6 enerji capsulunu alin";
            mis.missions[12] = "—laboratuvarin 2. katina cikin";
            mis.missions[13] = "—kabloyu baglayin";
            mis.missions[14] = "—6 kapsulu yerlestirin";
            mis.missions[15] = "—protokolu baslatin";
            mis.missions[16] = "—laboratuvardan cikin";
            mis.missions[17] = "—lara ile konusun.";
            mis.missions[18] = "—Find the password for the enviro room.";
            mis.missions[19] = "—Find the password for the enviro room.";
            mis.missions[20] = "—Find the password for the enviro room.";
        }


        if(sho != null)
        {
        sho.noteText1 = 
    @"    Deney 27 beklenenden daha erken bir sapma gosterdi. Kronometre dogru calisiyor, fakat gozlemci artik referans kabul edilemez. Zaman duzensizlesiyor.

    Laboratuvarin ikinci seviyesinde manyetik alan duzensizlesti. Ozellikle izolasyon odasinda kalis suresi 4 dakikayi gecmemeli. Daha uzun maruz kalma durumunda hatirlanamayan bosluklar olusuyor.

    Sisteme tekrar erismem gerekirse:
    Kullanici adi: NOVA
    Sifre: 1441

    -Prof. Arthur";
        sho.noteText2 = 
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
        sho.noteText3 = 
    @"Profesor Arthur,

Jenerator odasinda tuhaf bir durum var. Sistem calisiyor ama davranisi normal degil. Kisa sureli duraksamalar ve beklenmedik dalgalanmalar oluyor. Simdilik mudahale etmedim; yanlis bir hamlenin daha buyuk bir soruna yol acmasından endiseliyim.

Kontrol etmenizin iyi olacagini dusunuyorum.

— Jenerator Odasi Teknisyeni
      Bob";
        sho.noteText4 = 
    @"Aral, 

Isler planladigimiz gibi gitmedi. Deneyi durdurmaya calistim ama bir an icin kontrol benden cikti. Gurultu, Patlama… sonra her sey sessizlesti. Sana seslendim ama cevap vermedin.

Iyiyim… sanirim. Ama burada kalmam guvenli degil. Bir sey beni takip ediyor. Onu tam goremiyorum. Onun ne oldugunu yada kim oldugunu bilmiyorum. Tek bildigim buradan uzaklasmam gerektigi. 

Seni bu ise daha fazla bulastirmak istemedim. Beni merak edecegini biliyorum, hatta pesimden gelecegini de.

 Lutfen dikkat";
        sho.noteText5 = 
    @"Sen bunu okuyorken ben coktan yok olup gitmis olabilirim. Laboratuvarda olanlar kontrol edilemeyen bir anin sonucu. O ana dair hatirladigim son seyler isiklar, alarmlar, ve hemen ardindan gelen o tuhaf sessizlik… Her sey orada basladi.

Bazi dongulerin cikisi yoktur, bende onlardan birinin icindeyim. Fisiltilar duyuyorum. Bana 'Senin yuzunden!' diyorlar. Beni sadece oyaliyorlar mi yoksa bir sey mi anlatmaya calisiyorlar.

Zaman burada bazen ileri bazen geri ilerliyor ama eninde sonunda basladigi noktaya geri geliyor. Ayni hatalar, ayni sonuclar. Acaba gecmis veya gelecek gercekten degistirilemez mi? Acele etmezsen sen de bu dongunun bir parcasi olursun.

Hayat ileri dogru yasanir geriye dogru anlasilir.";
        sho.noteText6 = 
    @"Gelecekteki kendime,

     Lara eger bu mektubu okuyorsan bilmeni isterimki Aral'i kurtarmakta basarisiz oldum. Gecmisteki kendimi oldurup onun yerine gecmem gerekti ama bosunaydi. Bu zaman dongusunu kiramadim ve Aral'i icinde bulundugu araftan kurtaramadim.

     Senin kazayi olmadan engellemen gerekiyor. Bu beni oldurup yerime gecmen anlamina gelse bile bunu yapmalisin. Lutfen benim yaptigim hatalari yapma. Ne olursa olsun Aral'i kurtar ve ona yaptiklarindan sakin bahsetme. 

     -Lara";
        sho.noteText7 = "Arkanda!";
        }


        if(inv != null)
        {
            inv.itemName[0] = "ID Kart";
            inv.itemDesc[0] = "Bu kart nova laboratuvarındaki bazi kapilari acar.";
            inv.itemName[1] = "yaka feneri";
            inv.itemDesc[1] = "yakaya takilan bir fener.";
            inv.itemName[2] = "Arthur'un notu";
            if(sho != null)
            inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Bos kapsul";
            inv.itemDesc[3] = "Dolduruldugunda enerji kapsulu olan boş bir kapsul.";
            inv.itemName[4] = "enerji kapsulu";
            inv.itemDesc[4] = "Hayal edilemeyecek miktarda enerji barindiran bir kapsul; Los Angeles sehrini 12 yil boyunca beslemeye yetecek kadar enerji barindirir.";
            inv.itemName[5] = "levye";
            inv.itemDesc[5] = "bu levye bazi kapilari acmak icin kullanilir";
            inv.itemName[6] = "glock 17";
            inv.itemDesc[6] = "Guvenlik odasindan alinan bir Glock 17. Sadece bir mermi kaldi. İkinci bir sans olmayacak.";
            inv.itemName[7] = "guvenlik protokolu";
            if(sho != null)
            inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "personel notu";
            if(sho != null)
            inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Lara'nin notu";
            if(sho != null)
            inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Aral'in notu?";
            if(sho != null)
            inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Lara'nin notu?";
            if(sho != null)
            inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "bilinmeyen not";
            if(sho != null)
            inv.itemDesc[12] = sho.noteText7;
        }
    }
    void LoadEnglishDialogs()      /////////ingilizce dialoglar buraya eklenecek
    {
        dias[0] = "Lara: Before entering the laboratory, we need to wait for the Nova Center to send the access code.";
        dias[1] = "Aral: An access code?";
        dias[2] = "Lara: Yes, a 4-digit code. They will send this code to the computers located in the container building on the island.";
        dias[3] = "Lara: Prof. Arthur mentioned that the container access card was in the hangar.";
        dias[4] = "Lara: You go ahead first, I have a few things I need to grab. Don’t worry, I’ll catch up with you.";
        dias[5] = "Lara: How much longer are you going to stare at me like that?";
        dias[6] = "Aral: It’s right here.";
        dias[7] = "Lara: Looks like you found the card and opened the door.";
        dias[8] = "Aral: Yes, I just opened it—your timing is perfect.";
        dias[9] = "Lara: I’m always punctual.";
        dias[10] = "Lara: Wait a second, what do you mean there’s no signal? Is the system malfunctioning? Did we come all this way for nothing?";
        dias[11] = "Aral: Maybe there’s a malfunction at the radio tower.";
        dias[12] = "Lara: Why do you think that?";
        dias[13] = "Aral: Because the system here looks pretty clean and operational. I think the issue is at the radio tower. I saw some tools in the hangar. I’ll grab them and check it out.";
        dias[14] = "Lara: Alright then, I’ll stay here and see what I can do.";
        dias[15] = "Aral: Wow! What a beautiful view.";
        dias[16] = "Aral: What was that sound?";
        dias[17] = "Aral: It was probably just an animal.";
        dias[18] = "Aral: Alright, I should head to the radio tower now.";
        dias[19] = "Aral: Okay, this should do the job. Now I should head back to Lara.";
        dias[20] = "Aral: Did Lara leave this flashlight?";
        dias[21] = "Aral: It should be useful for opening jammed doors.";
        dias[22] = "Aral: Just in case I need to protect myself.";
        dias[23] = "Aral: Everything’s ready.";
        dias[24] = "Lara: You’re back. After you fixed the malfunction at the tower, the signal came through and I established the connection, but the center hasn’t sent the code yet.";
        dias[25] = "Aral: The electrical panel should be upstairs.";
        dias[26] = "Aral: So, did we arrive too early?";
        dias[27] = "Lara: Actually, no.If we had arrived later, it would have been evening, and I doubt you could’ve fixed the tower malfunction in the dark.";
        dias[28] = "Aral: Do we know when they’ll send the code?";
        dias[29] = "Lara: They’ll probably send it in two or three hours. There are beds here if you want to sleep. We both came a long way and we’re tired.";
        dias[30] = "Aral: Maybe I can explore the island a bit before sleeping.";
        dias[31] = "Lara: Whatever you prefer.";
        dias[32] = "Aral: How many hours have I been sleeping? The center must have sent the code.";
        dias[33] = "Aral: Where is Lara?";
        dias[34] = "Aral: What is this? A shadow of mine? But there’s no one in front of the light...";
        dias[35] = "Aral: What just happened? I must still be groggy since I just woke up. Yes, there can’t be any other explanation.";
        dias[36] = "Aral: Lara.";
        dias[37] = "Lara: You’re such a sleepyhead. I got bored waiting for you and went down to the beach.";
        dias[38] = "Aral: Didn’t you sleep at all?";
        dias[39] = "Lara: I slept like a baby, but I woke up before you. By the way, did you take the flashlight I left?";
        dias[40] = "Aral: Yes, I did. And when I went outside, there was a shadow in front of the door. It disappeared when I got closer.";
        dias[41] = "Lara: A shadow? Maybe it was your own shadow, and when the door closed behind you, it disappeared.";
        dias[42] = "Aral: No, it wasn’t my shadow. It was in front of the light source.";
        dias[43] = "Lara: I’m sure there’s a logical explanation.";
        dias[44] = "Aral: The only thing I can think of is that I imagined it because I was half-asleep.";
        dias[45] = "Lara: See? You already found a logical explanation.";
        dias[46] = "Aral: Anyway, the center sent the code. It’s 1327.";
        dias[47] = "Lara: I know. When I woke up, the code was already on the screen.";
        dias[48] = "Aral: Then are you ready to enter the Nova Laboratory?";
        dias[49] = "Lara: We’re not in a rush. I want to stay a little longer and watch the beach. The beach is beautiful at night, isn’t it?";
        dias[50] = "Aral: Ah… Look, the beach really is beautiful, but I’m heading to the laboratory. You should come as soon as you can.";
        dias[51] = "Lara: Don’t worry, I’m always punctual.";
        dias[52] = "Aral: After all, laboratories are sterile environments.";
        dias[53] = "Aral: I need to put on a lab coat. I wonder where the changing room is.";
        dias[54] = "Aral: Hmm, this lab coat isn’t bad at all.";
        dias[55] = "Lara: The lab coat suits you.";
        dias[56] = "Aral: You… how… when did you get here?";
        dias[57] = "Lara: Like I said, I’m always—";
        dias[58] = "Aral: Punctual, yes, I got it.";
        dias[59] = "Aral: So, can you briefly explain what we’re going to do now ? ";
        dias[60] = "Lara: Sure. First, we’ll take the Aether Core energy capsules from the enviro room. There should be six of them.";
        dias[61] = "Lara: Then, using these capsules, we need to activate the warp engine located in the experiment room on the second floor.";
        dias[62] = "Lara: The warp engine is normally used for interstellar travel.";
        dias[63] = "Lara: But today, we’re trying to combine the warp engine and the Aether Core energy capsules to create a Parallax engine.";
        dias[64] = "Lara: In theory, this engine will be able to manipulate space and time not only forward like a warp engine, but also backward, in a more controlled way.";
        dias[65] = "Lara: This way, we’re trying to make time travel possible.";
        dias[66] = "Lara: What we’re doing here—and what we’re about to do—is very important for humanity.";
        dias[67] = "Aral: Wow! That sounds like magic.";
        dias[68] = "Lara: Any sufficiently advanced technology is indistinguishable from magic.";
        dias[69] = "Aral: You’re right, Lara C.Clarke.";
        dias[70] = "Lara: Haha! Oh, very funny.";
        dias[71] = "Aral: The enviro room is locked. How are we going to get inside?";
        dias[72] = "Lara: Prof.Arthur was responsible for this floor of the laboratory.Maybe you can find some kind of code among his belongings.";
        dias[73] = "Lara: Check the men’s locker room.";
        dias[74] = "Aral: These must be the login credentials for Prof. Arthur’s personal computer.";
        dias[75] = "Aral: I should change my clothes first.";
        dias[76] = "Lara: Did you find anything?";
        dias[77] = "Aral: Yes. It seems Prof. Arthur also conducted experiments in this laboratory. I found notes related to his experiments. By the way, the access code is 1453.";
        dias[78] = "Lara: You’re amazing.";
        dias[79] = "Lara: Alright, now we need to take six Aether Core energy capsules.";
        dias[80] = "Aral: There are five capsules on the shelf here, but two of them are empty.";
        dias[81] = "Lara: Hmm, according to what’s written here, the machine in the corner can produce Aether Core energy capsules. I’ve activated the machine.";
        dias[82] = "Aral: I found the machine, and there’s one more full capsule inside it. So I only need to fill the two empty ones.";
        dias[83] = "Lara: That’s good news.";
        dias[84] = "Aral: All six capsules are ready.";
        dias[85] = "Lara: Look, there’s a list of experiments conducted here. This room was built for environmental protection purposes, but later it started being used for other experiments.";
        dias[86] = "Aral: Yes, like producing these capsules. Come on, let’s go upstairs and start the procedure.";
        dias[87] = "Lara: Okay, call the elevator. I’m coming.";
        dias[88] = "Lara: I wonder what condition the upper floor of the laboratory is in.";
        dias[89] = "Aral: The upper floor of the laboratory was built by a different company called Arc Industries.";
        dias[90] = "Aral: They designed the laboratory to be self-sustaining, so I’m sure it’s in good condition.";
        dias[91] = "Lara: Really? I thought the entire laboratory was built by Nova.";
        dias[92] = "Aral: Nova only built the first floor. Their goal was to protect nature and the environment through the research conducted in the enviro room.";
        dias[93] = "Aral: But since the experiments conducted here no longer served only that purpose, the laboratory was expanded by Arc Industries.";
        dias[94] = "Lara: Do you think the Nova Center is hiding things from us?";
        dias[95] = "Aral: Definitely. That’s why I don’t trust the Nova Center’s personnel… though you might be an exception.";
        dias[96] = "Lara: Since you’re telling me all this, I trust you too.";
        dias[97] = "Aral: Ah… my head.";
        dias[98] = "Aral: What happened?";
        dias[99] = "Aral: I need to find him.";
        dias[100] = "Lara: I think the power cable isn’t connected.";
        dias[101] = "Aral: Let me check the cables.";
        dias[102] = "Aral: There we go, all systems are online.";
        dias[103] = "Lara: Okay, the next step is to insert the energy capsules into the warp engine.";
        dias[104] = "Aral: The warp engine should be in the next room.";
        dias[105] = "Aral: Alright, it’s done.";
        dias[106] = "Lara: I’ve detected an irregularity in the field dynamics.";
        dias[107] = "Aral: Is it something serious?";
        dias[108] = "Lara: I can probably fix it. You start the procedure. There’s a red button on the table to the right of the double doors. That button starts the procedure.";
        dias[109] = "Aral: The elevator… I need to get to the elevator.";
        dias[110] = "Lara: When the warp engine reaches full power, it should tear space-time and send us one hour back.";
        dias[111] = "Aral: What was that sound?";
        dias[112] = "Aral: Lara, is this normal?";
        dias[113] = "Lara: There’s an overload—stop the procedure!";
        dias[114] = "Aral: Lara, I can’t hear you.";
        dias[115] = "Aral: I’m going to stop the procedure.";
        dias[116] = "Unknown: Return to life.";
        dias[117] = "Aral: Not this way. Maybe there’s an exit on the upper floor.";
        dias[118] = "Aral: The laboratory is in ruins. I hope the elevator still works.";
        dias[119] = "Aral: Hey, who’s there?";
        dias[120] = "Aral: Lara? Is that you?";
        dias[121] = "Aral: What the hell is going on here? And what was that thing?";
        dias[122] = "Aral: That shadow again… it’s messing with my mind.";
        dias[123] = "Aral: The generator is here.";
        dias[124] = "Aral: I did it. The elevator is probably working now.";
        dias[125] = "Aral: Lara worked here long before. This must be a note from back then. I’m surprised it’s still here.";
        dias[126] = "Aral: A time loop? Is that what happened in the laboratory? My head is spinning. Did Lara write this?";
        dias[127] = "Aral: Time loop, time loop, time loop… Now I understand. The experiment didn’t fail—it was too successful.";
        dias[128] = "Aral: The shadow I saw and the voices I heard must be connected to this accident.";
        dias[129] = "Aral: Come on! Come on! COME ON!";
        dias[130] = "Aral: Oh my God!";
        dias[131] = "Aral: That thing keeps following me—just like a shadow.";
        dias[132] = "Aral: Who are you? What do you want from me?";
        dias[133] = "Developer: I didn’t expect you to make it this far. Your curiosity led you to the right place. You’re in a secret area, and this note unlocks the game’s third ending.";
        dias[134] = "Aral: I can’t believe it! Did Lara kill her past self and take her place? Was it to save me? Am I alive because of her?";
        dias[135] = "Aral: I have so many questions for her, but first of all, I have to make sure this madness ends.";
        dias[136] = "Aral: The Lara at the beach? I need to talk to her.";
        dias[137] = "Aral: Lara, thank God you’re okay. What are you doing here?";
        dias[138] = "Lara: Aral? Is that you? Why did you come back?";
        dias[139] = "Aral: Yes, it’s me. What do you mean by ‘come back’? And what are you doing here?";
        dias[140] = "Lara: We talked, and you told me that I had to leave. Then we said goodbye.";
        dias[141] = "Aral: When did all this happen? After the accident in the laboratory, you suddenly disappeared. I found the note you left behind.";
        dias[142] = "Lara: Now I understand…";
        dias[143] = "Aral: For God’s sake! Will you finally tell me what’s going on?";
        dias[144] = "Lara: Aral, you’re trapped in limbo. Look at your clothes!";
        dias[145] = "Lara: If you had really come here after the accident in the laboratory, you’d still be wearing your lab coat. But you’re wearing the jacket you had on the day we arrived on the island.";
        dias[146] = "Aral: I can’t believe it… How is this possible?";
        dias[147] = "Lara: The current time is the night of the day we arrived on the island. You’re actually asleep, and I came down to the beach.";
        dias[148] = "Lara: I tried to free you from the limbo you’re trapped in—from this time loop. I did everything for you. I even—";
        dias[149] = "Aral: Even what? What did you do, Lara?";
        dias[150] = "Lara: When you learned the truth, you told me that I had to leave. That’s why I won’t explain it now. You’ll find out eventually.";
        dias[151] = "Lara: Just know that I love you enough to do this.";
        dias[152] = "Aral: Lara… I don’t want you to leave. I would never tell you to go—neither in the future nor in the past. Please don’t go, stay with me.";
        dias[153] = "Lara: Aral, you…";
        dias[154] = "Aral: Whatever the problem is, I’m sure we can overcome it. Until then—and even after that—just stay with me.";
        dias[155] = "Lara: You’re forcing me to make a difficult decision… again.";
        dias[156] = "Lara: To be honest, I never wanted to leave in the first place. I will save you from this limbo.";
        dias[157] = "Aral: We can handle it together. If—";
        dias[158] = "Lara: Aral, hide—quickly. He mustn’t see you.";
        dias[159] = "Aral: Who mustn’t see me?";
        dias[160] = "Lara: There’s no time to explain. Hurry and hide behind that tree.";
        dias[161] = "Aral: Wait a second… is that me coming toward Lara?";
        dias[162] = "Aral: What’s happening? Is this a temporal fracture? I saw my past self, and I’m starting to lose my sense of reality.";
        dias[163] = "Aral: Is that my past self? And I’m standing in front of the light—how can I not see myself?";
        dias[164] = "Aral: Wait… that shadow I keep seeing… could it be…?";
        dias[165] = "Aral: I’m turning into that shadow.";
        dias[166] = "Aral: This is what Lara meant by being trapped in limbo.";
        dias[167] = "Aral: It seems that every time I see my past self, reality fractures and I’m pushed a little further back in time.";
        dias[168] = "Aral: I’m literally becoming a shadow in time.";
        dias[169] = "Unknown: What is this? A shadow of mine? But there’s no one in front of the light…";
        dias[170] = "Aral: Lara?";
        dias[171] = "Aral: Lara, no!";

        
        menuUI[1] = "START NEW GAME";
        menuUI[2] = "LOAD GAME";
        menuUI[3] = "SETTINGS";
        menuUI[4] = "CREDITS";
        menuUI[5] = "EXIT";
        menuUI[6] = "GRAPHICS";
        menuUI[7] = "AUDIO";
        menuUI[8] = "CAMERA";
        menuUI[9] = "LANGUAGE & ACCESIBILITY";
        menuUI[10] = "BACK";
        menuUI[11] = "RESOLUTION";
        menuUI[12] = "SCREEN SIZE";
        menuUI[13] = "GRAPHICS SETTINGS";
        menuUI[14] = "ANTI-ALIASING";
        menuUI[15] = "MENU MUSIC";
        menuUI[16] = "MOUSE SENSITIVITY";
        menuUI[17] = "HEAD BOBBING";
        menuUI[18] = "LANGUAGE";
        menuUI[19] = "SUBTITLE SIZE";
        menuUI[20] = "BORDERLESS FULLSCREEN";
        menuUI[21] = "WINDOWED MODE";
        menuUI[22] = "HIGH";
        menuUI[23] = "MEDIUM";
        menuUI[24] = "LOW";
        menuUI[25] = "CLOSE";
        menuUI[26] = "OPEN";
        menuUI[27] = "SMALL";
        menuUI[28] = "MEDIUM";
        menuUI[29] = "BIG";

        
        uıUI[0] = "Locked";
        uıUI[1] = "need crowbar";
        uıUI[2] = "to use crowbar";
        uıUI[3] = "to enter";
        uıUI[4] = "to Log-in";
        uıUI[5] = "to change clothes";
        uıUI[6] = "to call elevator";
        uıUI[7] = "Please Wait...";
        uıUI[8] = "to floor 2";
        uıUI[9] = "to Take";
        uıUI[10] = "to Place capsule";
        uıUI[11] = "You dont have empty Capsule!";
        uıUI[12] = "Need IDCard";
        uıUI[13] = "Need to take lapel light";
        uıUI[14] = "to sleep";
        uıUI[15] = "to repair";
        uıUI[16] = "need repairkit";
        uıUI[17] = "Firstly, You have to wear lab coat.";
        uıUI[18] = "to search";
        uıUI[19] = "searching...";
        uıUI[20] = "to place energy capsule";
        uıUI[21] = "to connect cable";
        uıUI[22] = "to press button";
        uıUI[23] = "to open";
        uıUI[24] = "to floor 1";
        uıUI[25] = "to speak Lara";
        uıUI[26] = "to start generator";
        uıUI[27] = "no electric";
        uıUI[28] = "to open light";
        uıUI[29] = "to crouch";
        uıUI[30] = "to exit";

        
        if(mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Missions";
            mis.missions[0] = "—Find the ID card in the hangar";
            mis.missions[1] = "—Go to shelter";
            mis.missions[2] = "—Find the repair kit in the hangar";
            mis.missions[3] = "—fix the electric box on the radio tower";
            mis.missions[4] = "—speak with lara";
            mis.missions[5] = "—go to sleep in bed";
            mis.missions[6] = "—take lapel light";
            mis.missions[7] = "—meet with lara in the beach";
            mis.missions[8] = "—open the door in the cave";
            mis.missions[9] = "—put on your lab coat";
            mis.missions[10] = "—Go to enviro lab";
            mis.missions[11] = "—take 6 energy capsules";
            mis.missions[12] = "—go up to the 2nd floor";
            mis.missions[13] = "—connect the cable";
            mis.missions[14] = "—place 6 capsules";
            mis.missions[15] = "—Initiate the protocol";
            mis.missions[16] = "—Exit Lab.";
            mis.missions[17] = "—Speak with lara.";
            mis.missions[18] = "—Find the password for the enviro room.";
            mis.missions[19] = "—Find the password for the enviro room.";
            mis.missions[20] = "—Find the password for the enviro room.";
        }

        if(sho != null)
        {
        sho.noteText1 =
    @"    Experiment 27 showed an earlier deviation than expected. The chronometer is functioning correctly, but the observer can no longer be considered a reliable reference. Time is becoming unstable.

    Magnetic instability has been detected on the second level of the laboratory. Time spent in the isolation chamber should not exceed four minutes. Prolonged exposure results in memory gaps that cannot be recalled.

    If I need to access the system again:
    Username: NOVA
    Password: 1441

    - Prof. Arthur";
        sho.noteText2 =
    @"Security Protocol – Internal Use Only

    These weapons have been placed in the security room for emergency situations. Ammunition is limited. No resupply is available.

    Anomalies that emerge during temporal experiments do not behave like standard threats. Firing a weapon is not always a solution; in some cases, it may make the situation worse.

    If you have a reason to take any of these weapons, the protocol has already been breached. A single decision can affect multiple timelines.

Wait for the right moment.
One wrong decision can cost years.

     Chief Researcher
     Lara  ";
        sho.noteText3 =
    @"Professor Arthur,

There is something unusual in the generator room. The system is running, but it does not feel stable. There are brief pauses and unexpected fluctuations. I have not intervened yet, as a wrong move might cause a bigger problem.

I believe it would be best if you take a look.

— Generator Room Technician
      Bob";
        sho.noteText4 =
    @"Aral,

Things didn’t go the way we planned. I tried to stop the experiment, but for a moment, I lost control. The noise, the light… and then everything went quiet. I called out to you, but you didn’t answer.

I’m okay… I think. But it isn’t safe for me to stay here. Something is following me. I can’t see it clearly. I don’t know what it is, or who it is. All I know is that I need to get away from here.

 That’s all I could do. I didn’t want to pull you any deeper into this. I know you’ll worry about me, and I know you’ll come looking for me.

Please, be car";
        sho.noteText5 =
    @"While you are reading this, I may already be gone. What happened in the laboratory was the result of an uncontrollable moment. The last things I remember from that moment are the lights, the alarms, and the strange silence that followed immediately after… That is where everything began.

Some loops have no exit, and I am trapped inside one of them. I hear whispers. They say, “Because of you.” I can’t tell whether they are trying to distract me or if they are trying to tell me something.

Time here sometimes moves forward, sometimes backward, but in the end it always returns to where it began. The same mistakes, the same outcomes. Is it possible that the past or the future cannot truly be changed? If you do not rush, you too will become part of this loop.

Life is lived forward, but understood backward.";
        sho.noteText6 =
    @"To my future self,

Lara, if you are reading this letter, you must know that I failed to save Aral.
I had to kill my past self and take her place, but it was in vain.
I could not break this time loop, and I could not free Aral from the limbo he is trapped in.

You must prevent the accident before it happens.
Even if it means killing me and taking my place, you have to do it.
Please do not make the same mistakes I did. No matter what, save Aral and never tell him what you did.

— Lara";
        sho.noteText7 = "Behind you!";
        }

        
        if(inv != null)
        {
            inv.itemName[0] = "ID Card";
            inv.itemDesc[0] = "A card that can open some of the doors at Nova Lab.";
            inv.itemName[1] = "Light";
            inv.itemDesc[1] = "A light worn on the lapel.";
            inv.itemName[2] = "Artur's note";
            if(sho != null)
            inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Empty Capsule";
            inv.itemDesc[3] = "An empty capsule that becomes an energy capsule when filled.";
            inv.itemName[4] = "Energy Capsule";
            inv.itemDesc[4] = "A capsule that holds an unimaginable amount of energy, enough to power the city of Los Angeles for 12 years.";
            inv.itemName[5] = "Crowbar";
            inv.itemDesc[5] = "a crowbar you can use to open jammed doors.";
            inv.itemName[6] = "glock 17";
            inv.itemDesc[6] = "A Glock 17 taken from the security room. Only one bullet remains. There will be no second chance.";
            inv.itemName[7] = "Security Protokol";
            if(sho != null)
            inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Bob's Note";
            if(sho != null)
            inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Lara's Note";
            if(sho != null)
            inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Aral's Note?";
            if(sho != null)
            inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Lara's Note?";
            if(sho != null)
            inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Unknown Note";
            if(sho != null)
            inv.itemDesc[12] = sho.noteText7;
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
