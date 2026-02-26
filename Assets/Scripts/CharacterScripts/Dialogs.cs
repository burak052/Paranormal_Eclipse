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
    public PlayDialogLine PDL;
    public bool Laradia = false;
    
    public string[] dias = new string[300];
    public string[] menuUI = new string[100];
    public string[] uıUI = new string[100];
    string currentLanguage;

    Coroutine activeDialog;

    void OnEnable()
    {
        LoadDias();
    }

    void Start()
    {
        dialog.text = "";

        if (scene == 1)
            PlayDialog(OutdoorDialog());
        if (scene == 2)
            EventDia(53, 4f);
        if (scene == 3)
            EventDia(136, 6f);
        if (scene == 4)
            PlayDialog(StartSinematicDialog());
    }
    
    void Update()
    {
        if(dialog.text != "")
        {
            if(dialog.text.StartsWith("Aral") || dialog.text.StartsWith("Арал") || dialog.text.StartsWith("Developer") || dialog.text.StartsWith("Sviluppatore") ||
             dialog.text.StartsWith("Entwickler") || dialog.text.StartsWith("Desarrollador") || dialog.text.StartsWith("Разработчик") || dialog.text.StartsWith("Développeur"))
                dialog.color = new Color32(0xBD, 0xE7, 0xFF, 0xFF);
            else
                dialog.color = new Color32(0xFF, 0xBD, 0xE5, 0xFF);
        }
    }

    public void LoadDias()
    {
        currentLanguage = LanguageManager.CurrentLanguage;

        if (currentLanguage == "turkce")
            LoadTurkishDialogs();
        if (currentLanguage == "english")
            LoadEnglishDialogs();
        if (currentLanguage == "deutsch")
            LoadDeutschDialogs();
        if (currentLanguage == "español")
            LoadEspañolDialogs();
        if (currentLanguage == "pусский")
            LoadРусскийDialogs();
        if (currentLanguage == "français")
            LoadFrançaisDialogs();
        if (currentLanguage == "italiano")
            LoadItalianoDialogs();

        if(PlayerPrefs.GetInt("FONT_SIZE", 1) == 0)
            dialog.fontSize = 20f;
        if(PlayerPrefs.GetInt("FONT_SIZE", 1) == 1)
            dialog.fontSize = 30f;
        if(PlayerPrefs.GetInt("FONT_SIZE", 1) == 2)
            dialog.fontSize = 40f;
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
        dias[68] = "Lara: Yeterince gelişmiş bir teknoloji, sihirden ayırt edilemez.";
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
        dias[172] = "Aral: Asagi inmeden once bir silah bulsam iyi olur.";
        dias[173] = "Lara: Pasifik’in ortasında, anakara’dan kilometrelerce uzakta bir ada... İnsan buraya gelmeden önce iki kez düşünüyor.";
        dias[174] = "Aral: Zaten amaç da buydu. İzole bir laboratuvar. Zaman deneyi ters giderse, etkisi sadece burada kalmalı.";
        dias[175] = "Lara: Resmî kayıtlarda burası terk edilmiş bir meteoroloji istasyonu olarak görünüyor. Ama aşağıda, kayalıkların altında kurulu o tesis, zamanı kontrol etmemizi sağlayacak.";
        dias[176] = "Aral: Umarım bu adadan başarılı bir sonuçla ayrılırız.";
        dias[177] = "Lara: Adaya yaklaştık, iniş için hazırlanalım.";
        dias[178] = "Aral: Ne yaptın sen…";
        dias[179] = "Aral: Az önce… kendini mi vurdun?";
        dias[180] = "Lara: Ben…";
        dias[181] = "Lara: Hayır… o ben değildim…";
        dias[182] = "Lara: O… başarısız olandı.";
        dias[183] = "Aral: Bu ne demek?!";
        dias[184] = "Lara: ...";
        dias[185] = "Aral: Kaç kere yaptın bunu?";
        dias[186] = "Lara: Hatırlamıyorum.";
        dias[187] = "Aral: Hatırlamıyor musun?!";
        dias[188] = "Lara: Çünkü her seferinde anılarım karışıyor. Amacımı unutmamak için kendime not bırakıp duruyorum.";
        dias[189] = "Lara: İşte bu yüzden bu sefer farklı olacak!";
        dias[190] = "Lara: Bu sefer seni çıkaracağım buradan!";
        dias[191] = "Aral: Lara… Beni kurtarmaya çalışmıyorsun.";
        dias[192] = "Aral: Beni burada tutuyorsun. Şimdi anlıyorum.";
        dias[193] = "Lara: Ben sadece seni kurtarmaya çalıştım… Sen gittikçe o gölgeye dönüşüyorsun. Bunu en başından beri biliyordum.";
        dias[194] = "Aral: Her seferinde bu kaza yeniden oluyor değil mi?";
        dias[195] = "Aral: Her seferinde helikopter geliyor.";
        dias[196] = "Aral: Her seferinde biz geliyoruz ve kaza olduktan sonra ben arafta kayboluyorum.";
        dias[197] = "Aral: Ama sen geçmişteki kendini öldürüp yerine geçerek arafta ilk kaybolan beni kurtarmaya çalışıyorsun.";
        dias[198] = "Aral: Bu kaza ve bu döngü… Sebebi sensin.";
        dias[199] = "Lara: Hayır ben... ilk kaza benim yüzümden değildi. ilk kaza gerçekten bir kazaydı.";
        dias[200] = "Aral: Lara buna bi son verelim.";
        dias[201] = "Aral: Ben gidiyorum bu öldürme döngüsünün bir parçası olmayacağım. Sende benimle geliyorsun.";
        dias[202] = "Aral: Lara?";
        dias[203] = "Lara: Ben gelmeyeceğim.";
        dias[204] = "Aral: Anlamıyor musun? döngüyü bu şekilde sonlandırabiliriz.";
        dias[205] = "Lara: Senin için sonlanacak. Sen gölgeye dönüştüğünde ve geriye senden bir şey kalmadığında benim döngüm yeniden başlayacak.";
        dias[206] = "Lara: Birinin olanları düzeltmesi gerekiyor ve bunun için ne gerekiyorsa yapacağım.";
        dias[207] = "Aral: Seni burada bırakmayı hiç istemiyorum.";
        dias[208] = "Lara: Ama ben istiyorum, o yüzden şimdi git.";
        dias[209] = "Aral: Kendine iyi bak.";
        dias[210] = "Lara: Aral hayır… Bunu yapamazsın… Ben seni kurtarmak istedim sadece!";     //(Aral silahı alır. Lara anlar ve panikler.)
        dias[211] = "Aral: Tam olarak bu yüzden. Her şeye bir son vereceğim.";
        dias[212] = "Lara: Ben sensiz ne yapacağım…"; 
        dias[213] = "Aral: Yaşayacaksın.";
        dias[214] = "Aral: Ben senin nedenin oldum. Şimdi özgürlüğün olacağım.";    //silah sesi ekran kararır mezarlık sahnesi
        dias[215] = "Lara: Ben seni kurtaramadım ama sen beni kurtardın."; 
        dias[216] = "Lara: teşekkürler."; 
        dias[217] = "Aral: Bu işe yaramıyor."; 
        dias[218] = "Lara: Bu sefer farklı."; 
        dias[219] = "Aral: Hayır. Aynısını yaptın."; 
        dias[220] = "Lara: Ne?"; 
        dias[221] = "Aral: Defalarca. Her seferinde kendini öldürdün… Her seferinde yerini aldın."; 
        dias[222] = "Lara: Bunu nereden—"; 
        dias[223] = "Aral: Buldum."; 
        dias[224] = "Aral: Sakladığın notları."; 
        dias[225] = "Aral: Beni kurtarmaya çalışırken döngüyü başlatan kişi oldun."; 
        dias[226] = "Lara: Ben… hatırlamıyorum."; 
        dias[227] = "Aral: Çünkü hatırlarsan devam edemezsin.."; 
        dias[228] = "Aral: Sorun denememen değildi. Sorun vazgeçmemen."; 
        dias[229] = "Lara: Peki ya seni burada bırakırsam…"; 
        dias[230] = "Aral: İlk kez bırakmamış olacaksın."; 
        dias[231] = "Lara: Ya ölürsen…"; 
        dias[232] = "Aral: O zaman gerçekten yaşarsın."; 
        dias[233] = "Lara: Artık denemeyeceğim."; 
        dias[234] = "Lara: Aral… o helikopter…";
        dias[235] = "Aral: Evet, biziz.";
        dias[236] = "Aral: Biz kendi döngümüzü kırdık…";
        dias[237] = "Aral: Size bol şans.";
        dias[238] = "Aral: Güzel saatmiş.";
        dias[239] = "Aral: Acaba kimin...";
        dias[240] = "Lara: Nerede bu saat...";
        dias[241] = "Aral: Galiba zamanda geçmişe gitmeye devam ediyorum... Helikopter... Lara orada olmalı";


        menuUI[1] = "YENİ OYUNA BAŞLA";
        menuUI[2] = "DEVAM ET";
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
        menuUI[30] = "OYUN YÜKLE";
        menuUI[31] = "ANA MENÜ";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";


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
        uıUI[31] = "Karar anı, bir yanıt seç.";
        uıUI[32] = "Larayı yaptıklarıyla yüzleştir ve adayı terk et.";
        uıUI[33] = "Kendini öldürüp Lara'nın bu acı döngüsüne bir son ver.";
        uıUI[34] = "Laraya onun notundan bahsederek ikna et.";

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
            mis.missions[18] = "—Helikoptere don.";
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
        dias[0] =   "Lara: Before entering the laboratory, we need to wait for the Nova Center to send the access code.";
        dias[1] =   "Aral: An access code?";
        dias[2] =   "Lara: Yes, a 4-digit code. They will send this code to the computers located in the container building on the island.";
        dias[3] =   "Lara: Prof. Arthur mentioned that the container access card was in the hangar.";
        dias[4] =   "Lara: You go ahead first, I have a few things I need to grab. Don’t worry, I’ll catch up with you.";
        dias[5] =   "Lara: How much longer are you going to stare at me like that?";
        dias[6] =   "Aral: It’s right here.";
        dias[7] =   "Lara: Looks like you found the card and opened the door.";
        dias[8] =   "Aral: Yes, I just opened it—your timing is perfect.";
        dias[9] =   "Lara: I’m always punctual.";
        dias[10] =  "Lara: Wait a second, what do you mean there’s no signal? Is the system malfunctioning? Did we come all this way for nothing?";
        dias[11] =  "Aral: Maybe there’s a malfunction at the radio tower.";
        dias[12] =  "Lara: Why do you think that?";
        dias[13] =  "Aral: Because the system here looks pretty clean and operational. I think the issue is at the radio tower. I saw some tools in the hangar. I’ll grab them and check it out.";
        dias[14] =  "Lara: Alright then, I’ll stay here and see what I can do.";
        dias[15] =  "Aral: Wow! What a beautiful view.";
        dias[16] =  "Aral: What was that sound?";
        dias[17] =  "Aral: It was probably just an animal.";
        dias[18] =  "Aral: Alright, I should head to the radio tower now.";
        dias[19] =  "Aral: Okay, this should do the job. Now I should head back to Lara.";
        dias[20] =  "Aral: Did Lara leave this flashlight?";
        dias[21] =  "Aral: It should be useful for opening jammed doors.";
        dias[22] =  "Aral: Just in case I need to protect myself.";
        dias[23] =  "Aral: Everything’s ready.";
        dias[24] =  "Lara: You’re back. After you fixed the malfunction at the tower, the signal came through and I established the connection, but the center hasn’t sent the code yet.";
        dias[25] =  "Aral: The electrical panel should be upstairs.";
        dias[26] =  "Aral: So, did we arrive too early?";
        dias[27] =  "Lara: Actually, no.If we had arrived later, it would have been evening, and I doubt you could’ve fixed the tower malfunction in the dark.";
        dias[28] =  "Aral: Do we know when they’ll send the code?";
        dias[29] =  "Lara: They’ll probably send it in two or three hours. There are beds here if you want to sleep. We both came a long way and we’re tired.";
        dias[30] =  "Aral: Maybe I can explore the island a bit before sleeping.";
        dias[31] =  "Lara: Whatever you prefer.";
        dias[32] =  "Aral: How many hours have I been sleeping? The center must have sent the code.";
        dias[33] =  "Aral: Where is Lara?";
        dias[34] =  "Aral: What is this? A shadow? But there’s no one in front of the light...";
        dias[35] =  "Aral: What just happened? I must still be groggy since I just woke up. Yes, there can’t be any other explanation.";
        dias[36] =  "Aral: Lara.";
        dias[37] =  "Lara: You’re such a sleepyhead. I got bored waiting for you and went down to the beach.";
        dias[38] =  "Aral: Didn’t you sleep at all?";
        dias[39] =  "Lara: I slept like a baby, but I woke up before you. By the way, did you take the flashlight I left?";
        dias[40] =  "Aral: Yes, I did. And when I went outside, there was a shadow in front of the door. It disappeared when I got closer.";
        dias[41] =  "Lara: A shadow? Maybe it was your own shadow, and when the door closed behind you, it disappeared.";
        dias[42] =  "Aral: No, it wasn’t my shadow. It was in front of the light source.";
        dias[43] =  "Lara: I’m sure there’s a logical explanation.";
        dias[44] =  "Aral: The only thing I can think of is that I imagined it because I was half-asleep.";
        dias[45] =  "Lara: See? You already found a logical explanation.";
        dias[46] =  "Aral: Anyway, the center sent the code. It’s 1327.";
        dias[47] =  "Lara: I know. When I woke up, the code was already on the screen.";
        dias[48] =  "Aral: Then are you ready to enter the Nova Laboratory?";
        dias[49] =  "Lara: We’re not in a rush. I want to stay a little longer and watch the beach. The beach is beautiful at night, isn’t it?";
        dias[50] =  "Aral: Ah… Look, the beach really is beautiful, but I’m heading to the laboratory. You should come as soon as you can.";
        dias[51] =  "Lara: Don’t worry, I’m always punctual.";
        dias[52] =  "Aral: After all, laboratories are sterile environments.";
        dias[53] =  "Aral: I need to put on a lab coat. I wonder where the changing room is.";
        dias[54] =  "Aral: Hmm, this lab coat isn’t bad at all.";
        dias[55] =  "Lara: The lab coat suits you.";
        dias[56] =  "Aral: You… how… when did you get here?";
        dias[57] =  "Lara: Like I said, I’m always—";
        dias[58] =  "Aral: Punctual, yes, I got it.";
        dias[59] =  "Aral: So, can you briefly explain what we’re going to do now?";
        dias[60] =  "Lara: Sure. First, we’ll take the Aether Core energy capsules from the enviro room. There should be six of them.";
        dias[61] =  "Lara: Then, using these capsules, we need to activate the warp engine located in the experiment room on the second floor.";
        dias[62] =  "Lara: The warp engine is normally used for interstellar travel.";
        dias[63] =  "Lara: But today, we’re trying to combine the warp engine and the Aether Core energy capsules to create a Parallax engine.";
        dias[64] =  "Lara: In theory, this engine will be able to manipulate space and time not only forward like a warp engine, but also backward, in a more controlled way.";
        dias[65] =  "Lara: This way, we’re trying to make time travel possible.";
        dias[66] =  "Lara: What we’re doing here—and what we’re about to do—is very important for humanity."; // dont use
        dias[67] =  "Aral: Wow! That sounds like magic.";
        dias[68] =  "Lara: Any sufficiently advanced technology is indistinguishable from magic.";
        dias[69] =  "Aral: You’re right, Lara C.Clarke.";
        dias[70] =  "Lara: Haha! Oh, very funny.";
        dias[71] =  "Aral: The enviro room is locked. How are we going to get inside?";
        dias[72] =  "Lara: Prof.Arthur was responsible for this floor of the laboratory.Maybe you can find some kind of code among his belongings.";
        dias[73] =  "Lara: Check the men’s locker room.";
        dias[74] =  "Aral: These must be the login credentials for Prof. Arthur’s personal computer.";
        dias[75] =  "Aral: I should change my clothes first.";
        dias[76] =  "Lara: Did you find anything?";
        dias[77] =  "Aral: Yes. It seems Prof. Arthur also conducted experiments in this laboratory. I found notes related to his experiments. By the way, the access code is 1453.";
        dias[78] =  "Lara: You’re amazing.";
        dias[79] =  "Lara: Alright, now we need to take six Aether Core energy capsules.";
        dias[80] =  "Aral: There are five capsules on the shelf here, but two of them are empty.";
        dias[81] =  "Lara: Hmm, according to what’s written here, the machine in the corner can produce Aether Core energy capsules. I’ve activated the machine.";
        dias[82] =  "Aral: I found the machine, and there’s one more full capsule inside it. So I only need to fill the two empty ones.";
        dias[83] =  "Lara: That’s good news.";
        dias[84] =  "Aral: All six capsules are ready.";
        dias[85] =  "Lara: Look, there’s a list of experiments conducted here. This room was built for environmental protection purposes, but later it started being used for other experiments.";
        dias[86] =  "Aral: Yes, like producing these capsules. Come on, let’s go upstairs and start the procedure.";
        dias[87] =  "Lara: Okay, call the elevator. I’m coming.";
        dias[88] =  "Lara: I wonder what condition the upper floor of the laboratory is in.";
        dias[89] =  "Aral: The upper floor of the laboratory was built by a different company called Arc Industries.";
        dias[90] =  "Aral: They designed the laboratory to be self-sustaining, so I’m sure it’s in good condition.";
        dias[91] =  "Lara: Really? I thought the entire laboratory was built by Nova.";
        dias[92] =  "Aral: Nova only built the first floor. Their goal was to protect nature and the environment through the research conducted in the enviro room.";
        dias[93] =  "Aral: But since the experiments conducted here no longer served only that purpose, the laboratory was expanded by Arc Industries.";
        dias[94] =  "Lara: Do you think the Nova Center is hiding things from us?";
        dias[95] =  "Aral: Definitely. That’s why I don’t trust the Nova Center’s personnel… though you might be an exception.";
        dias[96] =  "Lara: Since you’re telling me all this, I trust you too.";
        dias[97] =  "Aral: Ah… my head.";
        dias[98] =  "Aral: What happened?";
        dias[99] =  "Aral: I need to find him.";
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
        dias[115] = "Aral: I’m going to stop the procedure.";   //çıkarıldı
        dias[116] = "Bilinmeyen: Come back alive.";
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
        dias[144] = "Lara: Aral, you’re trapped in purgatory. Look at your clothes!";
        dias[145] = "Lara: If you had really come here after the accident in the laboratory, you’d still be wearing your lab coat. But you’re wearing the jacket you had on the day we arrived on the island.";
        dias[146] = "Aral: I can’t believe it… How is this possible?";
        dias[147] = "Lara: The current time is the night of the day we arrived on the island. You’re actually asleep, and I came down to the beach.";
        dias[148] = "Lara: I tried to free you from the purgatory you’re trapped in—from this time loop. I did everything for you. I even—";
        dias[149] = "Aral: Even what? What did you do, Lara?";
        dias[150] = "Lara: When you learned the truth, you told me that I had to leave. That’s why I won’t explain it now. You’ll find out eventually.";
        dias[151] = "Lara: Just know that I love you enough to do this.";
        dias[152] = "Aral: Lara… I don’t want you to leave. I would never tell you to go—neither in the future nor in the past. Please don’t go, stay with me.";
        dias[153] = "Lara: Aral, you…";
        dias[154] = "Aral: Whatever the problem is, I’m sure we can overcome it. Until then—and even after that—just stay with me.";
        dias[155] = "Lara: You’re forcing me to make a difficult decision… again.";
        dias[156] = "Lara: To be honest, I never wanted to leave in the first place. I will save you from this purgatory.";
        dias[157] = "Aral: We can handle it together. If—";
        dias[158] = "Lara: Aral, hide—quickly. He mustn’t see you.";
        dias[159] = "Aral: Who mustn’t see me?";
        dias[160] = "Lara: There’s no time to explain. Hurry and hide behind that tree.";
        dias[161] = "Aral: Wait a second… is that me coming toward Lara?";
        dias[162] = "Aral: What’s happening? Is this a temporal fracture? I saw my past self, and I’m starting to lose my sense of reality.";
        dias[163] = "Aral: Is that my past self? And I’m standing in front of the light—how can I not see myself?";
        dias[164] = "Aral: Wait… that shadow I keep seeing… could it be…?";
        dias[165] = "Aral: I’m turning into that shadow.";
        dias[166] = "Aral: This is what Lara meant by being trapped in purgatory.";
        dias[167] = "Aral: It seems that every time I see my past self, reality fractures and I’m pushed a little further back in time.";
        dias[168] = "Aral: I’m literally becoming a shadow in time.";
        dias[169] = "Bilinmeyen: What is this? A shadow? But there’s no one in front of the light…";
        dias[170] = "Aral: Lara?";
        dias[171] = "Aral: Lara, no!";
        dias[172] = "Aral: I'd better find a weapon before I go down.";
        dias[173] = "Lara: An island in the middle of the Pacific, miles away from the mainland... You think twice before coming here.";
        dias[174] = "Aral: That was the point. An isolated laboratory. If the time experiment goes wrong, the effects must remain contained here.";
        dias[175] = "Lara: Official records show this place as an abandoned meteorological station. But the facility built beneath those cliffs will allow us to control time.";
        dias[176] = "Aral: I hope we leave this island with a successful result.";
        dias[177] = "Lara: We’re approaching the island. Prepare for landing.";
        dias[178] = "Aral: What did you do…";
        dias[179] = "Aral: Just now… did you shoot yourself?";
        dias[180] = "Lara: I…";
        dias[181] = "Lara: No… that wasn’t me…";
        dias[182] = "Lara: That was the one who failed.";
        dias[183] = "Aral: What does that mean?!";
        dias[184] = "Lara: ...";
        dias[185] = "Aral: How many times have you done this?";
        dias[186] = "Lara: I don’t remember.";
        dias[187] = "Aral: You don’t remember?!";
        dias[188] = "Lara: Because every time my memories get mixed. I keep leaving notes to myself so I won’t forget my purpose.";
        dias[189] = "Lara: That’s why this time will be different!";
        dias[190] = "Lara: This time I’ll get you out of here!";
        dias[191] = "Aral: Lara… You’re not trying to save me.";
        dias[192] = "Aral: You’re keeping me here. Now I understand.";
        dias[193] = "Lara: I only tried to save you… You keep turning into that shadow. I knew it from the beginning.";
        dias[194] = "Aral: The crash happens every time, doesn’t it?";
        dias[195] = "Aral: Every time the helicopter arrives.";
        dias[196] = "Aral: Every time we come and after the crash I get lost in purgatory.";
        dias[197] = "Aral: But you kill your past self and replace her to save the first me who got lost.";
        dias[198] = "Aral: This crash and this loop… You are the cause.";
        dias[199] = "Lara: No I... the first crash wasn’t because of me. The first one was really an accident.";
        dias[200] = "Aral: Lara let’s end this.";
        dias[201] = "Aral: I’m leaving. I won’t be part of this killing loop. You’re coming with me.";
        dias[202] = "Aral: Lara?";
        dias[203] = "Lara: I’m not coming.";
        dias[204] = "Aral: Don’t you understand? We can end the loop this way.";
        dias[205] = "Lara: It will end for you. When you turn into the shadow and nothing of you remains, my loop will begin again.";
        dias[206] = "Lara: Someone has to fix this and I’ll do whatever it takes.";
        dias[207] = "Aral: I really don’t want to leave you here.";
        dias[208] = "Lara: But I do. So go now.";
        dias[209] = "Aral: Take care of yourself.";
        dias[210] = "Lara: Aral no… You can’t do this… I only wanted to save you!";
        dias[211] = "Aral: Exactly. I’m ending everything.";
        dias[212] = "Lara: What will I do without you…";
        dias[213] = "Aral: You will live.";
        dias[214] = "Aral: I was your reason. Now I’ll be your freedom.";
        dias[215] = "Lara: I couldn’t save you but you saved me.";
        dias[216] = "Lara: Thank you.";
        dias[217] = "Aral: This doesn’t work.";
        dias[218] = "Lara: This time is different.";
        dias[219] = "Aral: No. You did the same.";
        dias[220] = "Lara: What?";
        dias[221] = "Aral: Countless times. Every time you killed yourself… Every time you took your place.";
        dias[222] = "Lara: How do you—";
        dias[223] = "Aral: I found them.";
        dias[224] = "Aral: The notes you hid.";
        dias[225] = "Aral: While trying to save me, you became the one who started the loop.";
        dias[226] = "Lara: I… don’t remember.";
        dias[227] = "Aral: Because if you remember, you can’t continue.";
        dias[228] = "Aral: The problem wasn’t trying. The problem was never stopping.";
        dias[229] = "Lara: What if I leave you here…";
        dias[230] = "Aral: Then for the first time you wouldn’t be abandoning me.";
        dias[231] = "Lara: What if you die…";
        dias[232] = "Aral: Then you’ll finally live.";
        dias[233] = "Lara: I won’t try anymore.";
        dias[234] = "Lara: Aral… that helicopter…";
        dias[235] = "Aral: Yes, it’s us.";
        dias[236] = "Aral: We broke our loop…";
        dias[237] = "Aral: Good luck to you";
        dias[238] = "Aral: Nice clock.";
        dias[239] = "Aral: I wonder whose it is...";
        dias[240] = "Lara: Where is that clock...";
        dias[241] = "Aral: I think I keep traveling back in time... The helicopter... Lara must be there.";


        menuUI[1] = "START NEW GAME";
        menuUI[2] = "CONTINUE";
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
        menuUI[30] = "LOAD GAME";
        menuUI[31] = "MAIN MANU";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";

        
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
        uıUI[31] = "Moment of decision, choose a response.";
        uıUI[32] = "Leave island and Lara to face what she has done.";
        uıUI[33] = "Kill yourself and put an end to Lara's painful loop.";
        uıUI[34] = "Convince Lara by telling her about her note.";


        
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
            mis.missions[18] = "—Return to the helicopter.";
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
I could not break this time loop, and I could not free Aral from the purgatory he is trapped in.

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
    void LoadDeutschDialogs()      /////////almanca dialoglar buraya eklenecek
    {
        dias[0] = "Lara: Bevor wir ins Labor gehen, müssen wir warten, bis das Nova-Zentrum uns den Zugangscode schickt.";
        dias[1] = "Aral: Einen Zugangscode?";
        dias[2] = "Lara: Ja, einen vierstelligen Code. Sie senden ihn an die Computer im Containergebäude auf der Insel.";
        dias[3] = "Lara: Prof. Arthur meinte, die Zugangskarte für den Container liegt im Hangar.";
        dias[4] = "Lara: Geh schon mal vor. Ich muss noch ein paar Sachen holen. Keine Sorge, ich komme gleich nach.";
        dias[5] = "Lara: Wie lange willst du mich eigentlich noch so anstarren?";
        dias[6] = "Aral: Hier ist sie.";
        dias[7] = "Lara: Sieht so aus, als hättest du die Karte gefunden und die Tür geöffnet.";
        dias[8] = "Aral: Ja, gerade eben. Perfektes Timing.";
        dias[9] = "Lara: Ich bin eben immer pünktlich.";
        dias[10] = "Lara: Moment mal… Was heißt hier kein Signal? Spinnt das System? Sind wir umsonst den ganzen Weg hierhergekommen?";
        dias[11] = "Aral: Vielleicht gibt es eine Störung am Funkturm.";
        dias[12] = "Lara: Wie kommst du darauf?";
        dias[13] = "Aral: Das System hier sieht völlig in Ordnung aus. Ich denke, das Problem liegt am Turm. Im Hangar habe ich Werkzeuge gesehen. Ich hole sie und sehe nach.";
        dias[14] = "Lara: Okay. Ich bleibe hier und schaue, was ich tun kann.";
        dias[15] = "Aral: Wow… Was für eine Aussicht.";
        dias[16] = "Aral: Was war das für ein Geräusch?";
        dias[17] = "Aral: Wahrscheinlich nur ein Tier.";
        dias[18] = "Aral: Gut, ich sollte jetzt zum Funkturm gehen.";
        dias[19] = "Aral: Das müsste reichen. Dann gehe ich besser zurück zu Lara.";
        dias[20] = "Aral: Hat Lara diese Taschenlampe hier liegen lassen?";
        dias[21] = "Aral: Die könnte nützlich sein, um verklemmte Türen aufzubrechen.";
        dias[22] = "Aral: Nur für den Fall, dass ich mich verteidigen muss.";
        dias[23] = "Aral: Alles klar, ich bin bereit.";
        dias[24] = "Lara: Du bist zurück. Nachdem du die Störung am Turm behoben hast, kam das Signal wieder durch und ich konnte die Verbindung herstellen. Aber das Zentrum hat den Code noch nicht geschickt.";
        dias[25] = "Aral: Die Schalttafel müsste oben sein.";
        dias[26] = "Aral: Sind wir also zu früh angekommen?";
        dias[27] = "Lara: Eigentlich nicht. Wären wir später gekommen, wäre es schon dunkel gewesen. Und ich bezweifle, dass du die Störung im Dunkeln hättest beheben können.";
        dias[28] = "Aral: Weißt du, wann sie den Code schicken?";
        dias[29] = "Lara: Vermutlich in zwei oder drei Stunden. Hier gibt es Betten, wenn du schlafen willst. Wir hatten beide eine lange Reise.";
        dias[30] = "Aral: Vielleicht erkunde ich die Insel noch ein bisschen, bevor ich schlafen gehe.";
        dias[31] = "Lara: Wie du meinst.";
        dias[32] = "Aral: Wie lange habe ich geschlafen? Das Zentrum muss den Code inzwischen geschickt haben.";
        dias[33] = "Aral: Wo ist Lara?";
        dias[34] = "Aral: Was ist das…? Mein Schatten? Aber vor der Lichtquelle steht doch niemand…";
        dias[35] = "Aral: Was war das gerade? Ich bin wohl noch halb im Schlaf. Ja… es gibt sicher eine ganz normale Erklärung.";
        dias[36] = "Aral: Lara?";
        dias[37] = "Lara: Du bist echt ein Langschläfer. Mir war langweilig, also bin ich runter zum Strand gegangen.";
        dias[38] = "Aral: Hast du gar nicht geschlafen?";
        dias[39] = "Lara: Doch, wie ein Baby. Aber ich war früher wach als du. Sag mal, hast du die Taschenlampe mitgenommen, die ich dagelassen habe?";
        dias[40] = "Aral: Ja. Und draußen vor der Tür war ein Schatten. Als ich näher kam, war er plötzlich weg.";
        dias[41] = "Lara: Ein Schatten? Vielleicht war es einfach dein eigener. Als sich die Tür hinter dir geschlossen hat, ist er verschwunden.";
        dias[42] = "Aral: Nein, es war nicht mein Schatten. Er stand vor der Lichtquelle.";
        dias[43] = "Lara: Dafür gibt es bestimmt eine logische Erklärung.";
        dias[44] = "Aral: Wahrscheinlich habe ich es mir nur eingebildet, weil ich noch halb geschlafen habe.";
        dias[45] = "Lara: Siehst du? Schon klingt es viel vernünftiger.";
        dias[46] = "Aral: Jedenfalls hat das Zentrum den Code geschickt. Er lautet 1327.";
        dias[47] = "Lara: Ich weiß. Als ich aufgewacht bin, stand er schon auf dem Bildschirm.";
        dias[48] = "Aral: Also, bist du bereit, ins Nova-Labor zu gehen?";
        dias[49] = "Lara: Wir haben es nicht eilig. Ich würde gern noch etwas hierbleiben und den Strand anschauen. Nachts ist er wunderschön, findest du nicht?";
        dias[50] = "Aral: Hm… Ja, der Strand ist wirklich schön. Aber ich gehe schon mal zum Labor. Komm bitte nach, sobald du kannst.";
        dias[51] = "Lara: Keine Sorge, ich bin immer pünktlich.";
        dias[52] = "Aral: Labore sind schließlich sterile Umgebungen.";
        dias[53] = "Aral: Ich sollte besser einen Laborkittel anziehen. Wo wohl die Umkleide ist?";
        dias[54] = "Aral: Hm, der Kittel steht mir gar nicht mal schlecht.";
        dias[55] = "Lara: Der Laborkittel steht dir wirklich gut.";
        dias[56] = "Aral: Du… wie… wann bist du hierhergekommen?";
        dias[57] = "Lara: Wie ich schon sagte, ich bin immer—";
        dias[58] = "Aral: Pünktlich. Ja, schon verstanden..";
        dias[59] = "Aral: Also, kannst du mir kurz erklären, was wir jetzt genau machen?";
        dias[60] = "Lara: Klar. Zuerst holen wir die Aether-Core-Energiekapseln aus dem Enviro-Raum. Es müssten sechs Stück sein.";
        dias[61] = "Lara: Danach müssen wir mit diesen Kapseln den Warpantrieb im Experimentierraum im zweiten Stock aktivieren.";
        dias[62] = "Lara: Normalerweise wird der Warpantrieb für interstellare Reisen genutzt.";
        dias[63] = "Lara: Aber heute versuchen wir, den Warpantrieb mit den Aether-Core-Energiekapseln zu kombinieren, um einen sogenannten Parallax-Antrieb zu erschaffen.";
        dias[64] = "Lara: Theoretisch kann dieser Antrieb Raum und Zeit nicht nur nach vorne – wie ein Warpantrieb – sondern auch rückwärts manipulieren. Und das auf kontrollierte Weise.";
        dias[65] = "Lara: Damit wollen wir Zeitreisen möglich machen.";
        dias[66] = "Lara: Was wir hier tun – und was wir gleich tun werden – ist von enormer Bedeutung für die Menschheit.";
        dias[67] = "Aral: Wow… Das klingt wie Magie.";
        dias[68] = "Lara: Jede hinreichend fortschrittliche Technologie ist von Magie nicht zu unterscheiden.";
        dias[69] = "Aral: Da hast du recht, Lara C. Clarke.";
        dias[70] = "Lara: Haha! Sehr witzig.";
        dias[71] = "Aral: Der Enviro-Raum ist verschlossen. Wie kommen wir da rein?";
        dias[72] = "Lara: Prof. Arthur war für diese Etage zuständig. Vielleicht findest du unter seinen Sachen einen Code oder etwas Ähnliches.";
        dias[73] = "Lara: Schau im Männerumkleideraum nach.";
        dias[74] = "Aral: Das hier müssten die Zugangsdaten für Prof. Arthurs persönlichen Computer sein.";
        dias[75] = "Aral: Ich sollte mich zuerst umziehen.";
        dias[76] = "Lara: Hast du etwas gefunden?";
        dias[77] = "Aral: Ja. Offenbar hat Prof. Arthur hier ebenfalls Experimente durchgeführt. Ich habe Notizen dazu gefunden. Übrigens, der Zugangscode lautet 1453.";
        dias[78] = "Lara: Du bist unglaublich.";
        dias[79] = "Lara: Gut, jetzt brauchen wir sechs Aether-Core-Energiekapseln.";
        dias[80] = "Aral: Hier im Regal stehen fünf Kapseln, aber zwei davon sind leer.";
        dias[81] = "Lara: Hm… Laut den Unterlagen hier kann die Maschine in der Ecke Aether-Core-Energiekapseln herstellen. Ich habe sie aktiviert.";
        dias[82] = "Aral: Ich habe die Maschine gefunden. Eine volle Kapsel ist noch drin. Ich muss also nur noch die zwei leeren auffüllen.";
        dias[83] = "Lara: Das sind gute Nachrichten.";
        dias[84] = "Aral: Alle sechs Kapseln sind einsatzbereit.";
        dias[85] = "Lara: Sieh mal, hier ist eine Liste der Experimente, die in diesem Raum durchgeführt wurden. Ursprünglich wurde er zum Schutz der Umwelt gebaut, aber später wurde er für andere Zwecke genutzt.";
        dias[86] = "Aral: Ja, zum Beispiel zur Herstellung dieser Kapseln. Komm, gehen wir nach oben und starten das Verfahren";
        dias[87] = "Lara: Okay, ruf den Aufzug. Ich komme nach";
        dias[88] = "Lara: Ich frage mich, in welchem Zustand die obere Etage ist.";
        dias[89] = "Aral: Die obere Etage wurde von einer anderen Firma namens Arc Industries gebaut.";
        dias[90] = "Aral: Sie haben das Labor als autarkes System konzipiert. Ich bin sicher, es ist in gutem Zustand.";
        dias[91] = "Lara: Wirklich? Ich dachte, das gesamte Labor wurde von Nova gebaut.";
        dias[92] = "Aral: Nova hat nur die erste Etage errichtet. Ihr Ziel war es, durch die Forschung im Enviro-Raum Natur und Umwelt zu schützen.";
        dias[93] = "Aral: Aber da die Experimente hier irgendwann nicht mehr nur diesem Zweck dienten, wurde das Labor von Arc Industries erweitert.";
        dias[94] = "Lara: Glaubst du, dass das Nova-Zentrum uns etwas verheimlicht?";
        dias[95] = "Aral: Auf jeden Fall. Deshalb vertraue ich dem Personal des Nova-Zentrums nicht… auch wenn du vielleicht eine Ausnahme bist.";
        dias[96] = "Lara: Wenn du mir das alles erzählst, dann vertraue ich dir auch.";
        dias[97] = "Aral: Ah… mein Kopf…";
        dias[98] = "Aral: Was ist passiert?";
        dias[99] = "Aral: Ich muss ihn finden.";
        dias[100] = "Lara: Ich glaube, das Stromkabel ist nicht angeschlossen.";
        dias[101] = "Aral: Lass mich die Kabel überprüfen.";
        dias[102] = "Aral: So, perfekt. Alle Systeme sind online.";
        dias[103] = "Lara: Gut. Als Nächstes müssen wir die Energiekapseln in den Warpantrieb einsetzen.";
        dias[104] = "Aral: Der Warpantrieb müsste im nächsten Raum sein.";
        dias[105] = "Aral: Alles klar… erledigt.";
        dias[106] = "Lara: Ich habe eine Unregelmäßigkeit in der Felddynamik festgestellt.";
        dias[107] = "Aral: Ist das etwas Ernstes?";
        dias[108] = "Lara: Ich denke, ich kann es beheben. Starte du schon mal die Prozedur. Rechts von der Doppeltür steht ein Tisch mit einem roten Knopf. Der startet alles.";
        dias[109] = "Aral: Der Aufzug… ich muss zum Aufzug.";
        dias[110] = "Lara: Wenn der Warpantrieb seine volle Leistung erreicht, sollte er die Raumzeit aufreißen und uns eine Stunde zurückschicken.";
        dias[111] = "Aral: Was war das für ein Geräusch?";
        dias[112] = "Aral: Lara, ist das normal?";
        dias[113] = "Lara: Es gibt eine Überlastung—brich die Prozedur ab!";
        dias[114] = "Aral: Lara, ich kann dich nicht hören!";
        dias[115] = "Aral: Ich stoppe die Prozedur!";
        dias[116] = "Unbekannt: Kehre ins Leben zurück.";
        dias[117] = "Aral: Nicht hier entlang… Vielleicht gibt es oben einen Ausgang.";
        dias[118] = "Aral: Das Labor liegt in Trümmern. Hoffentlich funktioniert der Aufzug noch.";
        dias[119] = "Aral: Hey! Wer ist da?";
        dias[120] = "Aral: Lara? Bist du das?";
        dias[121] = "Aral: Was zum Teufel geht hier vor sich? Und was war dieses Ding?";
        dias[122] = "Aral: Dieser Schatten schon wieder… Er spielt mit meinem Verstand.";
        dias[123] = "Aral: Hier ist der Generator.";
        dias[124] = "Aral: Geschafft. Der Aufzug sollte jetzt wieder funktionieren.";
        dias[125] = "Aral: Lara hat hier schon viel früher gearbeitet. Das muss eine Notiz von damals sein. Unglaublich, dass sie noch hier ist.";
        dias[126] = "Aral: Eine Zeitschleife? Ist das im Labor passiert? Mir schwirrt der Kopf… Hat Lara das geschrieben?";
        dias[127] = "Aral: Zeitschleife… Zeitschleife… Jetzt verstehe ich. Das Experiment ist nicht gescheitert – es war zu erfolgreich.";
        dias[128] = "Aral: Der Schatten, den ich gesehen habe, und die Stimmen, die ich gehört habe… Das hängt alles mit diesem Unfall zusammen.";
        dias[129] = "Aral: Komm schon! Komm schon! KOMM SCHON!";
        dias[130] = "Aral: Oh mein Gott!";
        dias[131] = "Aral: Dieses Ding verfolgt mich… wie ein Schatten.";
        dias[132] = "Aral: Wer bist du? Was willst du von mir?";
        dias[133] = "Entwickler: Ich hätte nicht erwartet, dass du es bis hierher schaffst. Deine Neugier hat dich an den richtigen Ort geführt. Du befindest dich in einem geheimen Bereich – und diese Notiz schaltet das dritte Ende des Spiels frei.";
        dias[134] = "Aral: Das kann nicht sein! Hat Lara ihr früheres Ich getötet und seinen Platz eingenommen? War es, um mich zu retten? Lebe ich ihretwegen?";
        dias[135] = "Aral: Ich habe so viele Fragen an sie… aber zuerst muss ich diesem Wahnsinn ein Ende setzen.";
        dias[136] = "Aral: Die Lara am Strand… Ich muss mit ihr reden.";
        dias[137] = "Aral: Lara! Gott sei Dank, dir ist nichts passiert. Was machst du hier?";
        dias[138] = "Lara: Aral? Bist du das wirklich? Warum bist du zurückgekommen?";
        dias[139] = "Aral: Ja, ich bin’s. Was meinst du mit „zurückgekommen“? Und was machst du hier?";
        dias[140] = "Lara: Wir haben gesprochen. Du hast mir gesagt, ich müsse gehen. Dann haben wir uns verabschiedet.";
        dias[141] = "Aral: Wann soll das gewesen sein? Nach dem Unfall im Labor bist du plötzlich verschwunden. Ich habe die Notiz gefunden, die du hinterlassen hast.";
        dias[142] = "Lara: Jetzt verstehe ich…";
        dias[143] = "Aral: Um Himmels willen! Sag mir endlich, was hier los ist!";
        dias[144] = "Lara: Aral… du steckst im Limbus fest. Schau dich an – deine Kleidung!";
        dias[145] = "Lara: Wenn du wirklich nach dem Laborunfall hierhergekommen wärst, würdest du noch deinen Laborkittel tragen. Aber du trägst die Jacke vom Tag unserer Ankunft auf der Insel.";
        dias[146] = "Aral: Das kann nicht sein… Wie ist das möglich?";
        dias[147] = "Lara: Es ist die Nacht des Tages, an dem wir auf der Insel angekommen sind. Du schläfst eigentlich noch – und ich bin zum Strand gegangen.";
        dias[148] = "Lara: Ich habe versucht, dich aus diesem Limbus zu befreien… aus dieser Zeitschleife. Ich habe alles für dich getan. Ich habe sogar—";
        dias[149] = "Aral: Sogar was? Was hast du getan, Lara?";
        dias[150] = "Lara: Als du die Wahrheit erfahren hast, hast du mir gesagt, dass ich gehen soll. Deshalb werde ich es dir jetzt nicht erklären. Du wirst es früher oder später selbst herausfinden.";
        dias[151] = "Lara: Du musst nur wissen, dass ich dich genug liebe, um das zu tun.";
        dias[152] = "Aral: Lara… ich will nicht, dass du gehst. Niemals würde ich dich wegschicken – weder in der Zukunft noch in der Vergangenheit. Bitte geh nicht. Bleib bei mir.";
        dias[153] = "Lara: Aral… du…";
        dias[154] = "Aral: Was auch immer das Problem ist, wir schaffen das zusammen. Bis dahin – und auch danach – bleib einfach bei mir.";
        dias[155] = "Lara: Du zwingst mich, wieder eine schwere Entscheidung zu treffen...";
        dias[156] = "Lara: Ehrlich gesagt wollte ich nie gehen. Ich werde dich aus diesem Limbus befreien.";
        dias[157] = "Aral: Wir können das gemeinsam durchstehen.Wenn—";
        dias[158] = "Lara: Aral, versteck dich – schnell! Er darf dich nicht sehen.";
        dias[159] = "Aral: Wer darf mich nicht sehen?";
        dias[160] = "Lara: Keine Zeit für Erklärungen. Schnell, versteck dich hinter diesem Baum!";
        dias[161] = "Aral: Warte… bin das etwa ich, der da auf Lara zukommt?";
        dias[162] = "Aral: Was passiert hier? Ist das ein Riss in der Zeit? Ich habe mein früheres Ich gesehen… und langsam verliere ich den Bezug zur Realität.";
        dias[163] = "Aral: Ist das wirklich mein früheres Ich? Und ich stehe direkt vor der Lichtquelle… warum sehe ich mich selbst nicht?";
        dias[164] = "Aral: Moment… dieser Schatten, den ich ständig sehe… könnte es sein, dass…?";
        dias[165] = "Aral: Ich werde zu diesem Schatten.";
        dias[166] = "Aral: Das meinte Lara also damit, im Limbus gefangen zu sein.";
        dias[167] = "Aral: Jedes Mal, wenn ich meinem früheren Ich begegne, zerbricht die Realität ein Stück mehr – und ich werde weiter in die Vergangenheit zurückgedrängt.";
        dias[168] = "Aral: Ich werde buchstäblich zu einem Schatten in der Zeit.";
        dias[169] = "Unbekannt: Was ist das? Mein Schatten? Aber vor der Lichtquelle steht doch niemand…";
        dias[170] = "Aral: Lara?";
        dias[171] = "Aral: Lara, nein!";
        dias[172] = "Aral: Ich sollte mir besser eine Waffe suchen, bevor ich nach unten gehe.";
        dias[173] = "Lara: Eine Insel mitten im Pazifik, kilometerweit vom Festland entfernt... Man überlegt es sich zweimal, bevor man hierherkommt.";
        dias[174] = "Aral: Genau das war der Plan. Ein isoliertes Labor. Wenn das Zeitexperiment schiefgeht, müssen die Auswirkungen hier bleiben.";
        dias[175] = "Lara: Offiziell gilt dieser Ort als verlassene Wetterstation. Doch die Anlage unter den Klippen wird es uns ermöglichen, die Zeit zu kontrollieren.";
        dias[176] = "Aral: Ich hoffe, wir verlassen diese Insel mit einem erfolgreichen Ergebnis.";
        dias[177] = "Lara: Wir nähern uns der Insel. Bereitmachen zur Landung.";
        dias[178] = "Aral: Was hast du getan…";
        dias[179] = "Aral: Gerade eben… hast du dich selbst erschossen?";
        dias[180] = "Lara: Ich…";
        dias[181] = "Lara: Nein… das war nicht ich…";
        dias[182] = "Lara: Das war die, die versagt hat.";
        dias[183] = "Aral: Was soll das heißen?!";
        dias[184] = "Lara: ...";
        dias[185] = "Aral: Wie oft hast du das getan?";
        dias[186] = "Lara: Ich erinnere mich nicht.";
        dias[187] = "Aral: Du erinnerst dich nicht?!";
        dias[188] = "Lara: Meine Erinnerungen vermischen sich jedes Mal. Ich hinterlasse mir Notizen, um mein Ziel nicht zu vergessen.";
        dias[189] = "Lara: Deshalb wird es diesmal anders!";
        dias[190] = "Lara: Dieses Mal hole ich dich hier raus!";
        dias[191] = "Aral: Lara… du versuchst mich nicht zu retten.";
        dias[192] = "Aral: Du hältst mich hier fest. Jetzt verstehe ich.";
        dias[193] = "Lara: Ich wollte dich nur retten… Du wirst immer mehr zu diesem Schatten.";
        dias[194] = "Aral: Der Absturz passiert jedes Mal, oder?";
        dias[195] = "Aral: Jedes Mal kommt der Helikopter.";
        dias[196] = "Aral: Jedes Mal kommen wir und nach dem Absturz verliere ich mich im Limbus.";
        dias[197] = "Aral: Und du tötest dein früheres Ich und ersetzt es.";
        dias[198] = "Aral: Dieser Unfall und diese Schleife… du bist der Grund.";
        dias[199] = "Lara: Nein… der erste Absturz war nicht meine Schuld. Es war wirklich ein Unfall.";
        dias[200] = "Aral: Lara, beenden wir das.";
        dias[201] = "Aral: Ich gehe. Ich werde nicht Teil dieser Schleife sein. Du kommst mit.";
        dias[202] = "Aral: Lara?";
        dias[203] = "Lara: Ich komme nicht.";
        dias[204] = "Aral: Verstehst du nicht? So können wir es beenden.";
        dias[205] = "Lara: Für dich vielleicht. Wenn du zum Schatten wirst, beginnt meine Schleife erneut.";
        dias[206] = "Lara: Jemand muss das in Ordnung bringen und ich werde alles tun.";
        dias[207] = "Aral: Ich will dich nicht hier lassen.";
        dias[208] = "Lara: Aber ich will es. Also geh.";
        dias[209] = "Aral: Pass auf dich auf.";
        dias[210] = "Lara: Aral nein… du kannst das nicht… ich wollte dich nur retten!";
        dias[211] = "Aral: Genau deshalb. Ich beende es.";
        dias[212] = "Lara: Was soll ich ohne dich tun…";
        dias[213] = "Aral: Du wirst leben.";
        dias[214] = "Aral: Ich war dein Grund. Jetzt bin ich deine Freiheit.";
        dias[215] = "Lara: Ich konnte dich nicht retten, aber du hast mich gerettet.";
        dias[216] = "Lara: Danke.";
        dias[217] = "Aral: Das funktioniert nicht.";
        dias[218] = "Lara: Diesmal ist es anders.";
        dias[219] = "Aral: Nein. Dasselbe wieder.";
        dias[220] = "Lara: Was?";
        dias[221] = "Aral: Unzählige Male…";
        dias[222] = "Lara: Woher weißt du—";
        dias[223] = "Aral: Ich habe sie gefunden.";
        dias[224] = "Aral: Deine Notizen.";
        dias[225] = "Aral: Beim Versuch mich zu retten hast du die Schleife erschaffen.";
        dias[226] = "Lara: Ich… erinnere mich nicht.";
        dias[227] = "Aral: Wenn du dich erinnerst, kannst du nicht weitermachen.";
        dias[228] = "Aral: Das Problem war nie der Versuch, sondern das Nicht-Aufhören.";
        dias[229] = "Lara: Wenn ich dich hier lasse…";
        dias[230] = "Aral: Dann würdest du mich zum ersten Mal nicht verlassen.";
        dias[231] = "Lara: Wenn du stirbst…";
        dias[232] = "Aral: Dann wirst du endlich leben.";
        dias[233] = "Lara: Ich werde es nicht mehr versuchen.";
        dias[234] = "Lara: Aral… der Helikopter…";
        dias[235] = "Aral: Ja, wir sind das.";
        dias[236] = "Aral: Wir haben unsere Schleife gebrochen…";
        dias[237] = "Aral: Viel Glück.";
        dias[238] = "Aral: Schöne Uhr.";
        dias[239] = "Aral: Ich frage mich, wem sie gehört...";
        dias[240] = "Lara: Wo ist diese Uhr...";
        dias[241] = "Aral: Ich glaube, ich reise weiter in die Vergangenheit... Der Hubschrauber... Lara muss dort sein.";


        menuUI[1] = "NEUES SPIEL STARTEN";
        menuUI[2] = "FORTSETZEN";
        menuUI[3] = "EINSTELLUNGEN";
        menuUI[4] = "CREDITS";
        menuUI[5] = "BEENDEN";
        menuUI[6] = "GRAFIK";
        menuUI[7] = "AUDIO";
        menuUI[8] = "KAMERA";
        menuUI[9] = "SPRACHE & BARRIEREFREIHEIT";
        menuUI[10] = "ZURÜCK";
        menuUI[11] = "AUFLÖSUNG";
        menuUI[12] = "BILDSCHIRMGRÖSSE";
        menuUI[13] = "GRAFIKOPTIONEN";
        menuUI[14] = "ANTI-ALIASING";
        menuUI[15] = "MENÜMUSIK";
        menuUI[16] = "MAUSEMPFINDLICHKEIT";
        menuUI[17] = "KOPFWIPPEN";
        menuUI[18] = "SPRACHE";
        menuUI[19] = "UNTERTITELGRÖSSE";
        menuUI[20] = "RANDLOSER VOLLBILDMODUS";
        menuUI[21] = "FENSTERMODUS";
        menuUI[22] = "HOCH";
        menuUI[23] = "MITTEL";
        menuUI[24] = "NIEDRIG";
        menuUI[25] = "SCHLIESSEN";
        menuUI[26] = "ÖFFNEN";
        menuUI[27] = "KLEIN";
        menuUI[28] = "MITTEL";
        menuUI[29] = "GROSS";
        menuUI[30] = "SPIEL LADEN";
        menuUI[31] = "HAUPTMENÜ";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";



        uıUI[0] = "Verschlossen";
        uıUI[1] = "Brecheisen benötigt";
        uıUI[2] = "Brecheisen benutzen";
        uıUI[3] = "Betreten";
        uıUI[4] = "Anmelden";
        uıUI[5] = "Umziehen";
        uıUI[6] = "Aufzug rufen";
        uıUI[7] = "Bitte warten...";
        uıUI[8] = "Zu Etage 2";
        uıUI[9] = "Aufnehmen";
        uıUI[10] = "Kapsel einsetzen";
        uıUI[11] = "Du hast keine leere Kapsel!";
        uıUI[12] = "ID-Karte benötigt";
        uıUI[13] = "Anstecklampe aufnehmen";
        uıUI[14] = "Schlafen";
        uıUI[15] = "Reparieren";
        uıUI[16] = "Reparaturset benötigt";
        uıUI[17] = "Zuerst musst du einen Laborkittel tragen.";
        uıUI[18] = "Durchsuchen";
        uıUI[19] = "Durchsuche...";
        uıUI[20] = "Energiekapsel einsetzen";
        uıUI[21] = "Kabel anschließen";
        uıUI[22] = "Knopf drücken";
        uıUI[23] = "Öffnen";
        uıUI[24] = "Zu Etage 1";
        uıUI[25] = "Mit Lara sprechen";
        uıUI[26] = "Generator starten";
        uıUI[27] = "Kein Strom";
        uıUI[28] = "Licht einschalten";
        uıUI[29] = "Ducken";
        uıUI[30] = "Verlassen";
        uıUI[31] = "Moment der Entscheidung, wähle eine Antwort.";
        uıUI[32] = "Lass Lara auf der Insel zurück, damit sie sich ihren Taten stellt, und verlasse die Insel.";
        uıUI[33] = "Töte dich selbst und beende Laras schmerzhaften Kreislauf.";
        uıUI[34] = "Überzeuge Lara, indem du ihr von ihrer Notiz erzählst.";




        if (mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Missionen";
            mis.missions[0] = "—Finde die ID-Karte im Hangar";
            mis.missions[1] = "—Geh zum Unterschlupf";
            mis.missions[2] = "—Finde das Reparaturset im Hangar";
            mis.missions[3] = "—Repariere den Stromkasten am Funkturm";
            mis.missions[4] = "—Sprich mit Lara";
            mis.missions[5] = "—Geh im Bett schlafen";
            mis.missions[6] = "—Nimm die Anstecklampe";
            mis.missions[7] = "—Triff Lara am Strand";
            mis.missions[8] = "—Öffne die Tür in der Höhle";
            mis.missions[9] = "—Zieh deinen Laborkittel an";
            mis.missions[10] = "—Geh ins Enviro-Labor";
            mis.missions[11] = "—Nimm 6 Energiekapseln";
            mis.missions[12] = "—Geh in den 2. Stock";
            mis.missions[13] = "—Schließe das Kabel an";
            mis.missions[14] = "—Setze 6 Kapseln ein";
            mis.missions[15] = "—Starte das Protokoll";
            mis.missions[16] = "—Verlasse das Labor";
            mis.missions[17] = "—Sprich mit Lara";
            mis.missions[18] = "—Kehre zum Hubschrauber zurück.";
            mis.missions[19] = "—Finde das Passwort für den Enviro-Raum";
            mis.missions[20] = "—Finde das Passwort für den Enviro-Raum";
        }

        if (sho != null)
        {
            sho.noteText1 =
        @"    Experiment 27 zeigte eine frühere Abweichung als erwartet. Das Chronometer funktioniert einwandfrei, doch der Beobachter kann nicht länger als verlässliche Referenz gelten. Die Zeit wird instabil.

Im zweiten Stock des Labors wurde eine magnetische Instabilität festgestellt. Der Aufenthalt in der Isolationskammer sollte vier Minuten nicht überschreiten. Längere Exposition führt zu Gedächtnislücken, die nicht wiederhergestellt werden können.

Falls ich erneut auf das System zugreifen muss:
Benutzername: NOVA
Passwort: 1441

– Prof. Arthur";
            sho.noteText2 =
        @"Sicherheitsprotokoll – Nur für den internen Gebrauch

Diese Waffen wurden für Notfälle im Sicherheitsraum bereitgestellt. Die Munition ist begrenzt. Eine Nachversorgung ist nicht möglich.

Anomalien, die während temporaler Experimente auftreten, verhalten sich nicht wie gewöhnliche Bedrohungen. Der Einsatz einer Waffe ist nicht immer eine Lösung; in manchen Fällen kann er die Situation sogar verschlimmern.

Wenn Sie einen Grund haben, eine dieser Waffen an sich zu nehmen, wurde das Protokoll bereits verletzt. Eine einzige Entscheidung kann mehrere Zeitlinien beeinflussen.

Warten Sie auf den richtigen Moment.
Eine falsche Entscheidung kann Jahre kosten.

Leitende Forscherin
Lara";
            sho.noteText3 =
        @"Professor Arthur,

Im Generatorraum gibt es etwas Ungewöhnliches. Das System läuft, aber es wirkt nicht stabil. Es treten kurze Aussetzer und unerwartete Schwankungen auf. Ich habe bisher nicht eingegriffen, da ein falscher Schritt ein größeres Problem verursachen könnte.

Ich denke, es wäre am besten, wenn Sie sich das persönlich ansehen.

— Techniker des Generatorraums
Bob";
            sho.noteText4 =
        @"Aral,

Die Dinge sind nicht so verlaufen, wie wir es geplant hatten. Ich habe versucht, das Experiment zu stoppen, doch für einen Moment habe ich die Kontrolle verloren. Das Geräusch, das Licht … und dann wurde plötzlich alles still. Ich habe nach dir gerufen, aber du hast nicht geantwortet.

Mir geht es gut … glaube ich. Aber es ist nicht sicher für mich, hier zu bleiben. Etwas folgt mir. Ich kann es nicht klar erkennen. Ich weiß nicht, was es ist – oder wer es ist. Alles, was ich weiß, ist, dass ich von hier wegmuss.

Das ist alles, was ich tun konnte. Ich wollte dich nicht noch tiefer hineinziehen. Ich weiß, dass du dir Sorgen um mich machen wirst, und ich weiß, dass du nach mir suchen wirst.

Bitte, sei vor…";
            sho.noteText5 =
        @"Während du das hier liest, bin ich vielleicht schon verschwunden. Was im Labor geschah, war das Ergebnis eines unkontrollierbaren Moments. Die letzten Dinge, an die ich mich aus diesem Augenblick erinnere, sind die Lichter, die Alarme und die seltsame Stille, die unmittelbar danach folgte … Dort begann alles.

Manche Schleifen haben keinen Ausgang, und ich bin in einer von ihnen gefangen. Ich höre Flüstern. Sie sagen: „Wegen dir.“ Ich kann nicht sagen, ob sie versuchen, mich abzulenken, oder ob sie mir etwas mitteilen wollen.

Die Zeit hier bewegt sich manchmal vorwärts, manchmal rückwärts, doch am Ende kehrt sie immer zu ihrem Anfang zurück. Dieselben Fehler, dieselben Ergebnisse. Ist es möglich, dass die Vergangenheit oder die Zukunft sich nicht wirklich verändern lassen? Wenn du dich nicht beeilst, wirst auch du Teil dieser Schleife werden.

Das Leben wird vorwärts gelebt, aber rückwärts verstanden.";
            sho.noteText6 =
        @"An mein zukünftiges Ich,

Lara, wenn du diesen Brief liest, musst du wissen, dass ich es nicht geschafft habe, Aral zu retten.
Ich musste mein vergangenes Ich töten und ihren Platz einnehmen, doch es war vergeblich.
Ich konnte diese Zeitschleife nicht durchbrechen, und ich konnte Aral nicht aus dem Zwischenzustand befreien, in dem er gefangen ist.

Du musst den Unfall verhindern, bevor er geschieht.
Selbst wenn es bedeutet, mich zu töten und meinen Platz einzunehmen, musst du es tun.
Bitte mache nicht dieselben Fehler wie ich. Egal, was geschieht, rette Aral – und sage ihm niemals, was du getan hast.

— Lara";
            sho.noteText7 = "Hinter dir";
        }


        if (inv != null)
        {
            inv.itemName[0] = "ID-Karte";
            inv.itemDesc[0] = "Eine Karte, mit der sich einige Türen im Nova-Labor öffnen lassen.";

            inv.itemName[1] = "Licht";
            inv.itemDesc[1] = "Ein am Revers getragenes Licht.";

            inv.itemName[2] = "Arthurs Notiz";

            if (sho != null)
                inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Leere Kapsel";
            inv.itemDesc[3] = "Eine leere Kapsel, die zu einer Energiekapsel wird, sobald sie gefüllt ist.";

            inv.itemName[4] = "Energiekapsel";
            inv.itemDesc[4] = "Eine Kapsel, die eine unvorstellbare Menge an Energie speichert – genug, um die Stadt Los Angeles 12 Jahre lang mit Strom zu versorgen.";

            inv.itemName[5] = "Brecheisen";
            inv.itemDesc[5] = "Ein Brecheisen, mit dem du verklemmte Türen öffnen kannst.";

            inv.itemName[6] = "Glock 17";
            inv.itemDesc[6] = "Eine Glock 17 aus dem Sicherheitsraum. Es bleibt nur eine Kugel. Es wird keine zweite Chance geben.";

            inv.itemName[7] = "Sicherheitsprotokoll";

            if (sho != null)
                inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Bobs Notiz";
            if (sho != null)
                inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Laras Notiz";
            if (sho != null)
                inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Arals Notiz?";
            if (sho != null)
                inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Laras Notiz?";
            if (sho != null)
                inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Unknown Notiz";
            if (sho != null)
                inv.itemDesc[12] = sho.noteText7;
        }
    }
    void LoadEspañolDialogs()      /////////ispanyolca dialoglar buraya eklenecek
    {
        dias[0] = "Lara: Antes de entrar al laboratorio, tenemos que esperar a que el Centro Nova nos envíe el código de acceso.";
        dias[1] = "Aral: ¿Un código de acceso?";
        dias[2] = "Lara: Sí, un código de cuatro dígitos. Lo envían a los ordenadores del edificio contenedor en la isla.";
        dias[3] = "Lara: El Prof. Arthur dijo que la tarjeta de acceso del contenedor está en el hangar.";
        dias[4] = "Lara: Adelántate. Tengo que recoger algunas cosas. No te preocupes, enseguida te alcanzo.";
        dias[5] = "Lara: ¿Cuánto tiempo más piensas quedarte mirándome así?";
        dias[6] = "Aral: Aquí está.";
        dias[7] = "Lara: Parece que encontraste la tarjeta y abriste la puerta.";
        dias[8] = "Aral: Sí, justo ahora. Momento perfecto.";
        dias[9] = "Lara: Siempre soy puntual.";
        dias[10] = "Lara: Un momento… ¿Qué significa sin señal? ¿Está fallando el sistema? ¿Vinimos hasta aquí para nada?";
        dias[11] = "Aral: Tal vez haya una interferencia en la torre de comunicación.";
        dias[12] = "Lara: ¿Por qué piensas eso?";
        dias[13] = "Aral: El sistema aquí parece estar completamente en orden. Creo que el problema está en la torre. Vi herramientas en el hangar. Las traeré y echaré un vistazo.";
        dias[14] = "Lara: De acuerdo. Me quedaré aquí y veré qué puedo hacer.";
        dias[15] = "Aral: Vaya… Qué vista tan impresionante.";
        dias[16] = "Aral: ¿Qué fue ese ruido?";
        dias[17] = "Aral: Probablemente solo fue un animal.";
        dias[18] = "Aral: Bien, debería ir ahora a la torre de comunicación.";
        dias[19] = "Aral: Esto debería ser suficiente. Mejor regreso con Lara.";
        dias[20] = "Aral: ¿Lara dejó esta linterna aquí?";
        dias[21] = "Aral: Podría ser útil para forzar puertas atascadas.";
        dias[22] = "Aral: Solo por si necesito defenderme.";
        dias[23] = "Aral: De acuerdo, estoy listo.";
        dias[24] = "Lara: Has vuelto. Después de que arreglaste la interferencia en la torre, la señal regresó y pude restablecer la conexión. Pero el centro aún no ha enviado el código.";
        dias[25] = "Aral: El panel de control debería estar arriba.";
        dias[26] = "Aral: Entonces, ¿llegamos demasiado pronto?";
        dias[27] = "Lara: En realidad no. Si hubiéramos llegado más tarde, ya habría oscurecido. Y dudo que hubieras podido arreglar la interferencia en la oscuridad.";
        dias[28] = "Aral: ¿Sabes cuándo enviarán el código?";
        dias[29] = "Lara: Probablemente en dos o tres horas. Hay camas aquí si quieres dormir. Ambos tuvimos un viaje largo.";
        dias[30] = "Aral: Tal vez explore un poco la isla antes de dormir.";
        dias[31] = "Lara: Como quieras.";
        dias[32] = "Aral: ¿Cuánto tiempo dormí? El centro ya debería haber enviado el código.";
        dias[33] = "Aral: ¿Dónde está Lara?";
        dias[34] = "Aral: ¿Qué es eso…? ¿Mi sombra? Pero no hay nadie delante de la fuente de luz…";
        dias[35] = "Aral: ¿Qué fue eso ahora? Debo de estar todavía medio dormido. Sí… seguro que hay una explicación perfectamente normal.";
        dias[36] = "Aral: ¿Lara?";
        dias[37] = "Lara: Eres todo un dormilón. Me aburría, así que bajé a la playa.";
        dias[38] = "Aral: ¿No dormiste nada?";
        dias[39] = "Lara: Claro que sí, como un bebé. Pero me desperté antes que tú. Oye, ¿tomaste la linterna que dejé?";
        dias[40] = "Aral: Sí. Y había una sombra afuera, frente a la puerta. Cuando me acerqué, desapareció de repente.";
        dias[41] = "Lara: ¿Una sombra? Tal vez era simplemente la tuya. Cuando la puerta se cerró detrás de ti, desapareció.";
        dias[42] = "Aral: No, no era mi sombra. Estaba delante de la fuente de luz.";
        dias[43] = "Lara: Seguro que hay una explicación lógica para eso.";
        dias[44] = "Aral: Probablemente solo lo imaginé porque todavía estaba medio dormido.";
        dias[45] = "Lara: ¿Ves? Ahora suena mucho más razonable.";
        dias[46] = "Aral: En cualquier caso, el centro envió el código. Es 1327.";
        dias[47] = "Lara: Lo sé. Cuando me desperté, ya estaba en la pantalla.";
        dias[48] = "Aral: Entonces, ¿estás lista para ir al laboratorio Nova?";
        dias[49] = "Lara: No tenemos prisa. Me gustaría quedarme un poco más y mirar la playa. Por la noche es hermosa, ¿no crees?";
        dias[50] = "Aral: Mmm… Sí, la playa es realmente hermosa. Pero iré al laboratorio. Ven en cuanto puedas.";
        dias[51] = "Lara: No te preocupes, siempre soy puntual.";
        dias[52] = "Aral: Después de todo, los laboratorios son entornos estériles.";
        dias[53] = "Aral: Será mejor que me ponga una bata de laboratorio. ¿Dónde estará el vestuario?";
        dias[54] = "Aral: Hmm, la bata no me queda nada mal.";
        dias[55] = "Lara: La bata realmente te queda muy bien.";
        dias[56] = "Aral: Tú… ¿cómo… cuándo llegaste aquí?";
        dias[57] = "Lara: Como ya dije, siempre soy—";
        dias[58] = "Aral: Puntual. Sí, ya lo entendí...";
        dias[59] = "Aral: Entonces, ¿puedes explicarme brevemente qué es exactamente lo que vamos a hacer ahora?";
        dias[60] = "Lara: Claro. Primero sacaremos las cápsulas de energía Aether-Core de la sala Enviro. Deberían ser seis.";
        dias[61] = "Lara: Después debemos activar el motor warp en la sala de experimentos del segundo piso usando esas cápsulas.";
        dias[62] = "Lara: Normalmente, el motor warp se utiliza para viajes interestelares.";
        dias[63] = "Lara: Pero hoy intentaremos combinar el motor warp con las cápsulas de energía Aether-Core para crear el llamado motor Parallax.";
        dias[64] = "Lara: Teóricamente, este motor puede manipular el espacio y el tiempo no solo hacia adelante —como un motor warp— sino también hacia atrás. Y de manera controlada.";
        dias[65] = "Lara: Con esto queremos hacer posibles los viajes en el tiempo.";
        dias[66] = "Lara: Lo que estamos haciendo aquí —y lo que estamos a punto de hacer— es de enorme importancia para la humanidad.";
        dias[67] = "Aral: Wow… Suena a magia.";
        dias[68] = "Lara: Cualquier tecnología suficientemente avanzada es indistinguible de la magia.";
        dias[69] = "Aral: Tienes razón, Lara C. Clarke.";
        dias[70] = "Lara: ¡Ja! Muy gracioso.";
        dias[71] = "Aral: La sala Enviro está cerrada. ¿Cómo entramos?";
        dias[72] = "Lara: El Prof. Arthur estaba a cargo de este piso. Tal vez encuentres entre sus cosas un código o algo parecido.";
        dias[73] = "Lara: Busca en el vestuario masculino.";
        dias[74] = "Aral: Estos deben de ser los datos de acceso al ordenador personal del Prof. Arthur.";
        dias[75] = "Aral: Primero debería cambiarme de ropa.";
        dias[76] = "Lara: ¿Encontraste algo?";
        dias[77] = "Aral: Sí. Al parecer, el Prof. Arthur también realizó experimentos aquí. Encontré notas al respecto. Por cierto, el código de acceso es 1453.";
        dias[78] = "Lara: Eres increíble.";
        dias[79] = "Lara: Bien, ahora necesitamos seis cápsulas de energía Aether-Core.";
        dias[80] = "Aral: Aquí en la estantería hay cinco cápsulas, pero dos de ellas están vacías.";
        dias[81] = "Lara: Hmm… Según los documentos, la máquina de la esquina puede fabricar cápsulas de energía Aether-Core. La he activado.";
        dias[82] = "Aral: Encontré la máquina. Aún queda una cápsula llena dentro. Solo tengo que rellenar las dos vacías.";
        dias[83] = "Lara: Esas son buenas noticias.";
        dias[84] = "Aral: Las seis cápsulas están listas para usarse.";
        dias[85] = "Lara: Mira, aquí hay una lista de los experimentos realizados en esta sala. Originalmente fue construida para proteger el medio ambiente, pero después se utilizó para otros fines.";
        dias[86] = "Aral: Sí, por ejemplo para fabricar estas cápsulas. Vamos, subamos y pongamos en marcha el procedimiento.";
        dias[87] = "Lara: De acuerdo, llama al ascensor. Voy detrás de ti.";
        dias[88] = "Lara: Me pregunto en qué estado estará el piso superior.";
        dias[89] = "Aral: El piso superior fue construido por otra empresa llamada Arc Industries.";
        dias[90] = "Aral: Diseñaron el laboratorio como un sistema autónomo. Estoy seguro de que está en buen estado.";
        dias[91] = "Lara: ¿De verdad? Pensé que todo el laboratorio había sido construido por Nova.";
        dias[92] = "Aral: Nova solo construyó el primer piso. Su objetivo era proteger la naturaleza y el medio ambiente mediante la investigación en la sala Enviro.";
        dias[93] = "Aral: Pero como los experimentos dejaron de servir únicamente a ese propósito, Arc Industries amplió el laboratorio.";
        dias[94] = "Lara: ¿Crees que el Centro Nova nos está ocultando algo?";
        dias[95] = "Aral: Sin duda. Por eso no confío en el personal del Centro Nova… aunque quizá tú seas una excepción.";
        dias[96] = "Lara: Si me cuentas todo esto, entonces yo también confío en ti.";
        dias[97] = "Aral: Ah… mi cabeza…";
        dias[98] = "Aral: ¿Qué ha pasado?";
        dias[99] = "Aral: Tengo que encontrarlo.";
        dias[100] = "Lara: Creo que el cable de corriente no está conectado.";
        dias[101] = "Aral: Déjame revisar los cables.";
        dias[102] = "Aral: Bien, perfecto. Todos los sistemas están en línea.";
        dias[103] = "Lara: Bien. Ahora debemos insertar las cápsulas de energía en el motor warp.";
        dias[104] = "Aral: El motor warp debe de estar en la siguiente sala.";
        dias[105] = "Aral: De acuerdo… hecho.";
        dias[106] = "Lara: He detectado una irregularidad en la dinámica del campo.";
        dias[107] = "Aral: ¿Es algo grave?";
        dias[108] = "Lara: Creo que puedo solucionarlo. Tú inicia el procedimiento. A la derecha de la puerta doble hay una mesa con un botón rojo. Eso lo pone todo en marcha.";
        dias[109] = "Aral: El ascensor… tengo que ir al ascensor.";
        dias[110] = "Lara: Cuando el motor warp alcance su potencia máxima, debería desgarrar el espacio-tiempo y enviarnos una hora atrás.";
        dias[111] = "Aral: ¿Qué fue ese ruido?";
        dias[112] = "Aral: Lara, ¿esto es normal?";
        dias[113] = "Lara: ¡Hay una sobrecarga—cancela el procedimiento!";
        dias[114] = "Aral: ¡Lara, no puedo oírte!";
        dias[115] = "Aral: ¡Detengo el procedimiento!";
        dias[116] = "Desconocido: Regresa a la vida.";
        dias[117] = "Aral: No por aquí… Tal vez haya una salida arriba.";
        dias[118] = "Aral: El laboratorio está en ruinas. Espero que el ascensor aún funcione.";
        dias[119] = "Aral: ¡Eh! ¿Quién está ahí?";
        dias[120] = "Aral: ¿Lara? ¿Eres tú?";
        dias[121] = "Aral: ¿Qué demonios está pasando aquí? ¿Y qué era esa cosa?";
        dias[122] = "Aral: Esa sombra otra vez… Está jugando con mi mente.";
        dias[123] = "Aral: Aquí está el generador.";
        dias[124] = "Aral: Listo. El ascensor debería funcionar otra vez.";
        dias[125] = "Aral: Lara trabajó aquí mucho antes. Esta debe de ser una nota de aquella época. Increíble que aún siga aquí.";
        dias[126] = "Aral: ¿Un bucle temporal? ¿Eso ocurrió en el laboratorio? Me da vueltas la cabeza… ¿Lara escribió esto?";
        dias[127] = "Aral: Bucle temporal… bucle temporal… Ahora lo entiendo. El experimento no fracasó — fue demasiado exitoso.";
        dias[128] = "Aral: La sombra que vi y las voces que escuché… Todo está relacionado con ese accidente.";
        dias[129] = "Aral: ¡Vamos! ¡Vamos! ¡VAMOS!";
        dias[130] = "Aral: ¡Oh, Dios mío!";
        dias[131] = "Aral: Esa cosa me está siguiendo… como una sombra.";
        dias[132] = "Aral: ¿Quién eres? ¿Qué quieres de mí?";
        dias[133] = "Desarrollador: No esperaba que llegaras hasta aquí. Tu curiosidad te ha llevado al lugar correcto. Estás en una zona secreta — y esta nota desbloquea el tercer final del juego.";
        dias[134] = "Aral: ¡No puede ser! ¿Lara mató a su yo del pasado y ocupó su lugar? ¿Fue para salvarme? ¿Estoy vivo gracias a ella?";
        dias[135] = "Aral: Tengo tantas preguntas para ella… pero primero debo poner fin a esta locura.";
        dias[136] = "Aral: La Lara de la playa… Tengo que hablar con ella.";
        dias[137] = "Aral: ¡Lara! Gracias a Dios, no te ha pasado nada. ¿Qué haces aquí?";
        dias[138] = "Lara: ¿Aral? ¿Eres realmente tú? ¿Por qué regresaste?";
        dias[139] = "Aral: Sí, soy yo. ¿Qué quieres decir con “regresaste”? ¿Y qué haces tú aquí?";
        dias[140] = "Lara: Hablamos. Me dijiste que tenía que irme. Luego nos despedimos.";
        dias[141] = "Aral: ¿Cuándo se supone que fue eso? Después del accidente en el laboratorio desapareciste de repente. Encontré la nota que dejaste.";
        dias[142] = "Lara: Ahora lo entiendo…";
        dias[143] = "Aral: ¡Por el amor de Dios! ¡Dime de una vez qué está pasando aquí!";
        dias[144] = "Lara: Aral… estás atrapado en el purgatory. Mírate — ¡tu ropa!";
        dias[145] = "Lara: Si realmente hubieras venido aquí después del accidente del laboratorio, todavía llevarías tu bata. Pero llevas la chaqueta del día en que llegamos a la isla.";
        dias[146] = "Aral: No puede ser… ¿Cómo es posible?";
        dias[147] = "Lara: Es la noche del día en que llegamos a la isla. En realidad aún estás durmiendo — y yo fui a la playa.";
        dias[148] = "Lara: He intentado liberarte de este purgatory… de este bucle temporal. He hecho todo por ti. Incluso he—";
        dias[149] = "Aral: ¿Incluso qué? ¿Qué hiciste, Lara?";
        dias[150] = "Lara: Cuando descubriste la verdad, me dijiste que me fuera. Por eso ahora no te lo explicaré. Tarde o temprano lo descubrirás por ti mismo.";
        dias[151] = "Lara: Solo debes saber que te amo lo suficiente como para hacer eso.";
        dias[152] = "Aral: Lara… no quiero que te vayas. Nunca te echaría — ni en el futuro ni en el pasado. Por favor, no te vayas. Quédate conmigo.";
        dias[153] = "Lara: Aral… tú…";
        dias[154] = "Aral: Sea cual sea el problema, lo superaremos juntos. Hasta entonces — y también después — simplemente quédate conmigo.";
        dias[155] = "Lara: Me estás obligando a tomar otra decisión difícil...";
        dias[156] = "Lara: Sinceramente, nunca quise irme. Te liberaré de este purgatory.";
        dias[157] = "Aral: Podemos superar esto juntos. Si—";
        dias[158] = "Lara: Aral, escóndete — ¡rápido! No puede verte.";
        dias[159] = "Aral: ¿Quién no puede verme?";
        dias[160] = "Lara: No hay tiempo para explicaciones. ¡Rápido, escóndete detrás de ese árbol!";
        dias[161] = "Aral: Espera… ¿ese que se acerca a Lara soy yo?";
        dias[162] = "Aral: ¿Qué está pasando aquí? ¿Es una grieta en el tiempo? Vi a mi yo del pasado… y poco a poco estoy perdiendo el contacto con la realidad.";
        dias[163] = "Aral: ¿Es realmente mi yo del pasado? Y estoy justo frente a la fuente de luz… ¿por qué no puedo verme a mí mismo?";
        dias[164] = "Aral: Espera… esa sombra que veo constantemente… ¿podría ser que…?";
        dias[165] = "Aral: Me estoy convirtiendo en esa sombra.";
        dias[166] = "Aral: Entonces eso era lo que Lara quería decir con estar atrapado en el purgatory.";
        dias[167] = "Aral: Cada vez que me encuentro con mi yo del pasado, la realidad se quiebra un poco más — y soy empujado más atrás en el tiempo.";
        dias[168] = "Aral: Literalmente me estoy convirtiendo en una sombra en el tiempo.";
        dias[169] = "Desconocido: ¿Qué es eso? ¿Mi sombra? Pero no hay nadie frente a la fuente de luz…";
        dias[170] = "Aral: ¿Lara?";
        dias[171] = "Aral: ¡Lara, no!";
        dias[172] = "Aral: Será mejor que busque un arma antes de bajar.";
        dias[173] = "Lara: Una isla en medio del Pacífico, a kilómetros del continente... Uno se lo piensa dos veces antes de venir aquí.";
        dias[174] = "Aral: Ese era el objetivo. Un laboratorio aislado. Si el experimento temporal sale mal, los efectos deben quedarse aquí.";
        dias[175] = "Lara: Oficialmente este lugar figura como una estación meteorológica abandonada. Pero la instalación bajo los acantilados nos permitirá controlar el tiempo.";
        dias[176] = "Aral: Espero que abandonemos esta isla con un resultado exitoso.";
        dias[177] = "Lara: Nos estamos acercando a la isla. Preparémonos para el aterrizaje.";
        dias[178] = "Aral: ¿Qué has hecho…";
        dias[179] = "Aral: Hace un momento… ¿te disparaste?";
        dias[180] = "Lara: Yo…";
        dias[181] = "Lara: No… no era yo…";
        dias[182] = "Lara: Era la que falló.";
        dias[183] = "Aral: ¿Qué significa eso?!";
        dias[184] = "Lara: ...";
        dias[185] = "Aral: ¿Cuántas veces hiciste esto?";
        dias[186] = "Lara: No lo recuerdo.";
        dias[187] = "Aral: ¿No lo recuerdas?!";
        dias[188] = "Lara: Porque cada vez mis recuerdos se mezclan. Me dejo notas para no olvidar mi propósito.";
        dias[189] = "Lara: ¡Por eso esta vez será diferente!";
        dias[190] = "Lara: ¡Esta vez te sacaré de aquí!";
        dias[191] = "Aral: Lara… no intentas salvarme.";
        dias[192] = "Aral: Me estás manteniendo aquí. Ahora lo entiendo.";
        dias[193] = "Lara: Solo intenté salvarte… sigues convirtiéndote en esa sombra.";
        dias[194] = "Aral: El accidente ocurre cada vez, ¿verdad?";
        dias[195] = "Aral: Cada vez llega el helicóptero.";
        dias[196] = "Aral: Cada vez venimos y después del accidente me pierdo en el purgatory.";
        dias[197] = "Aral: Y tú matas a tu yo pasado y tomas su lugar.";
        dias[198] = "Aral: Este accidente y este bucle… tú eres la causa.";
        dias[199] = "Lara: No… el primer accidente no fue por mí. Fue realmente un accidente.";
        dias[200] = "Aral: Lara, terminemos con esto.";
        dias[201] = "Aral: Me voy. No seré parte de este ciclo. Vienes conmigo.";
        dias[202] = "Aral: ¿Lara?";
        dias[203] = "Lara: No voy.";
        dias[204] = "Aral: ¿No lo entiendes? Podemos terminarlo así.";
        dias[205] = "Lara: Terminará para ti. Cuando te conviertas en sombra mi ciclo comenzará otra vez.";
        dias[206] = "Lara: Alguien debe arreglarlo y haré lo que sea.";
        dias[207] = "Aral: No quiero dejarte aquí.";
        dias[208] = "Lara: Pero yo sí. Así que vete.";
        dias[209] = "Aral: Cuídate.";
        dias[210] = "Lara: Aral no… no puedes… ¡solo quería salvarte!";
        dias[211] = "Aral: Exactamente por eso. Se acabó.";
        dias[212] = "Lara: ¿Qué haré sin ti…";
        dias[213] = "Aral: Vivirás.";
        dias[214] = "Aral: Fui tu razón. Ahora seré tu libertad.";
        dias[215] = "Lara: No pude salvarte pero tú me salvaste.";
        dias[216] = "Lara: Gracias.";
        dias[217] = "Aral: No funciona.";
        dias[218] = "Lara: Esta vez es diferente.";
        dias[219] = "Aral: No. Hiciste lo mismo.";
        dias[220] = "Lara: ¿Qué?";
        dias[221] = "Aral: Innumerables veces…";
        dias[222] = "Lara: Cómo sabes—";
        dias[223] = "Aral: Los encontré.";
        dias[224] = "Aral: Tus notas.";
        dias[225] = "Aral: Intentando salvarme iniciaste el bucle.";
        dias[226] = "Lara: Yo… no recuerdo.";
        dias[227] = "Aral: Si recuerdas no podrás continuar.";
        dias[228] = "Aral: El problema no era intentar sino no detenerse.";
        dias[229] = "Lara: Si te dejo aquí…";
        dias[230] = "Aral: Por primera vez no me abandonarías.";
        dias[231] = "Lara: Si mueres…";
        dias[232] = "Aral: Entonces vivirás de verdad.";
        dias[233] = "Lara: No lo intentaré más.";
        dias[234] = "Lara: Aral… ese helicóptero…";
        dias[235] = "Aral: Sí, somos nosotros.";
        dias[236] = "Aral: Rompimos nuestro bucle…";
        dias[237] = "Aral: Buena suerte.";
        dias[238] = "Aral: Bonito reloj.";
        dias[239] = "Aral: Me pregunto de quién será...";
        dias[240] = "Lara: ¿Dónde está ese reloj...?";
        dias[241] = "Aral: Creo que sigo viajando al pasado... El helicóptero... Lara debe estar allí.";



        menuUI[1] = "INICIAR NUEVA PARTIDA";
        menuUI[2] = "CONTINUAR";
        menuUI[3] = "AJUSTES";
        menuUI[4] = "CRÉDITOS";
        menuUI[5] = "SALIR";
        menuUI[6] = "GRÁFICOS";
        menuUI[7] = "AUDIO";
        menuUI[8] = "CÁMARA";
        menuUI[9] = "IDIOMA Y ACCESIBILIDAD";
        menuUI[10] = "ATRÁS";
        menuUI[11] = "RESOLUCIÓN";
        menuUI[12] = "TAMAÑO DE PANTALLA";
        menuUI[13] = "OPCIONES GRÁFICAS";
        menuUI[14] = "ANTIALIASING";
        menuUI[15] = "MÚSICA DEL MENÚ";
        menuUI[16] = "SENSIBILIDAD DEL RATÓN";
        menuUI[17] = "BALANCEO DE CABEZA";
        menuUI[18] = "IDIOMA";
        menuUI[19] = "TAMAÑO DE SUBTÍTULOS";
        menuUI[20] = "MODO PANTALLA COMPLETA SIN BORDES";
        menuUI[21] = "MODO VENTANA";
        menuUI[22] = "ALTO";
        menuUI[23] = "MEDIO";
        menuUI[24] = "BAJO";
        menuUI[25] = "CERRAR";
        menuUI[26] = "ABRIR";
        menuUI[27] = "PEQUEÑO";
        menuUI[28] = "MEDIO";
        menuUI[29] = "GRANDE";
        menuUI[30] = "CARGAR PARTIDA";
        menuUI[31] = "MENÚ PRINCIPAL";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";



        uıUI[0] = "CERRADO";
        uıUI[1] = "SE NECESITA UNA PALANCA";
        uıUI[2] = "USAR PALANCA";
        uıUI[3] = "ENTRAR";
        uıUI[4] = "INICIAR SESIÓN";
        uıUI[5] = "CAMBIARSE DE ROPA";
        uıUI[6] = "LLAMAR AL ASCENSOR";
        uıUI[7] = "POR FAVOR, ESPERA...";
        uıUI[8] = "IR AL PISO 2";
        uıUI[9] = "RECOGER";
        uıUI[10] = "COLOCAR CÁPSULA";
        uıUI[11] = "¡NO TIENES UNA CÁPSULA VACÍA!";
        uıUI[12] = "SE NECESITA TARJETA DE ID";
        uıUI[13] = "RECOGER LINTERNA DE SOLAPA";
        uıUI[14] = "DORMIR";
        uıUI[15] = "REPARAR";
        uıUI[16] = "SE NECESITA KIT DE REPARACIÓN";
        uıUI[17] = "PRIMERO, DEBES PONERTE LA BATA DE LABORATORIO.";
        uıUI[18] = "REGISTRAR";
        uıUI[19] = "REGISTRANDO...";
        uıUI[20] = "COLOCAR CÁPSULA DE ENERGÍA";
        uıUI[21] = "CONECTAR CABLE";
        uıUI[22] = "PULSAR BOTÓN";
        uıUI[23] = "ABRIR";
        uıUI[24] = "IR AL PISO 1";
        uıUI[25] = "HABLAR CON LARA";
        uıUI[26] = "INICIAR GENERADOR";
        uıUI[27] = "SIN ELECTRICIDAD";
        uıUI[28] = "ENCENDER LUZ";
        uıUI[29] = "AGACHARSE";
        uıUI[30] = "SALIR";
        uıUI[31] = "Momento de decisión, elige una respuesta.";
        uıUI[32] = "Deja a Lara en la isla para que enfrente sus actos y márchate.";
        uıUI[33] = "Suicídate y pon fin al doloroso bucle de Lara.";
        uıUI[34] = "Convence a Lara hablándole sobre su nota.";





        if (mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Misiones";
            mis.missions[0] = "—Encuentra la tarjeta de identificación en el hangar";
            mis.missions[1] = "—Ve al refugio";
            mis.missions[2] = "—Encuentra el kit de reparación en el hangar";
            mis.missions[3] = "—Repara la caja eléctrica en la torre de radio";
            mis.missions[4] = "—Habla con Lara";
            mis.missions[5] = "—Ve a dormir en la cama";
            mis.missions[6] = "—Recoge la linterna de solapa";
            mis.missions[7] = "—Reúnete con Lara en la playa";
            mis.missions[8] = "—Abre la puerta en la cueva";
            mis.missions[9] = "—Ponte la bata de laboratorio";
            mis.missions[10] = "—Ve al laboratorio Enviro";
            mis.missions[11] = "—Recoge 6 cápsulas de energía";
            mis.missions[12] = "—Ve al segundo piso";
            mis.missions[13] = "—Conecta el cable";
            mis.missions[14] = "—Coloca 6 cápsulas";
            mis.missions[15] = "—Inicia el protocolo";
            mis.missions[16] = "—Sal del laboratorio";
            mis.missions[17] = "—Habla con Lara";
            mis.missions[18] = "—Regresa al helicóptero.";
            mis.missions[19] = "—Encuentra la contraseña de la sala Enviro";
            mis.missions[20] = "—Encuentra la contraseña de la sala Enviro";
        }

        if (sho != null)
        {
            sho.noteText1 =
        @"    El Experimento 27 mostró una desviación anterior a la esperada.
El cronómetro funciona perfectamente, pero el observador ya no puede considerarse una referencia fiable. El tiempo se está volviendo inestable.

En el segundo piso del laboratorio se detectó una inestabilidad magnética. La permanencia en la cámara de aislamiento no debe superar los cuatro minutos. Una exposición prolongada provoca pérdidas de memoria irreversibles.

En caso de que necesite acceder nuevamente al sistema:
Usuario: NOVA
Contraseña: 1441

– Prof. Arthur";
            sho.noteText2 =
        @"Protocolo de Seguridad – Solo para uso interno

Estas armas han sido proporcionadas en la sala de seguridad para situaciones de emergencia. La munición es limitada. No es posible el reabastecimiento.

Las anomalías que surgen durante los experimentos temporales no se comportan como amenazas convencionales. El uso de un arma no siempre es la solución; en algunos casos, incluso puede empeorar la situación.

Si tiene un motivo para tomar una de estas armas, el protocolo ya ha sido violado. Una sola decisión puede afectar múltiples líneas temporales.

Espere el momento adecuado.
Una decisión equivocada puede costar años.

Investigadora Principal
Lara";
            sho.noteText3 =
        @"Profesor Arthur,

Hay algo inusual en la sala del generador. El sistema está funcionando, pero no parece estable. Se producen breves interrupciones y fluctuaciones inesperadas. Hasta ahora no he intervenido, ya que un paso en falso podría provocar un problema mayor.

Creo que sería mejor que usted lo revise personalmente.

— Técnico de la sala del generador
Bob";
            sho.noteText4 =
        @"Aral,

Las cosas no salieron como habíamos planeado. Intenté detener el experimento, pero por un momento perdí el control. El sonido, la luz… y luego, de repente, todo quedó en silencio. Te llamé, pero no respondiste.

Estoy bien… creo. Pero no es seguro para mí quedarme aquí. Algo me está siguiendo. No puedo verlo con claridad. No sé qué es… ni quién es. Lo único que sé es que tengo que irme de aquí.

Es todo lo que pude hacer. No quería arrastrarte más profundamente en esto. Sé que te preocuparás por mí, y sé que vendrás a buscarme.

Por favor, ten cui…";
            sho.noteText5 =
        @"Mientras lees esto, puede que yo ya haya desaparecido. Lo que ocurrió en el laboratorio fue el resultado de un momento incontrolable. Las últimas cosas que recuerdo de aquel instante son las luces, las alarmas y el extraño silencio que vino justo después… Allí fue donde comenzó todo.

Algunos bucles no tienen salida, y yo estoy atrapado en uno de ellos. Escucho susurros. Dicen: «Por tu culpa». No puedo saber si intentan distraerme o si quieren decirme algo.

El tiempo aquí a veces avanza, a veces retrocede, pero al final siempre regresa a su inicio. Los mismos errores, los mismos resultados. ¿Es posible que el pasado o el futuro no puedan cambiarse realmente? Si no te das prisa, tú también formarás parte de este bucle.

La vida se vive hacia adelante, pero se comprende hacia atrás.";
            sho.noteText6 =
        @"A mi yo del futuro,

Lara, si estás leyendo esta carta, debes saber que no logré salvar a Aral.
Tuve que matar a mi yo del pasado y ocupar su lugar, pero fue en vano.
No pude romper este bucle temporal, ni liberar a Aral del estado intermedio en el que está atrapado.

Debes impedir el accidente antes de que ocurra.
Incluso si eso significa matarme y ocupar mi lugar, debes hacerlo.
Por favor, no cometas los mismos errores que yo. Pase lo que pase, salva a Aral… y nunca le digas lo que hiciste.

— Lara";
            sho.noteText7 = "Detrás de ti";
        }


        if (inv != null)
        {
            inv.itemName[0] = "Tarjeta de identificación";
            inv.itemDesc[0] = "Una tarjeta que permite abrir algunas puertas del laboratorio Nova.";

            inv.itemName[1] = "Luz";
            inv.itemDesc[1] = "Una luz que se lleva en la solapa.";

            inv.itemName[2] = "Nota de Arthur";

            if (sho != null)
                inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Cápsula vacía";
            inv.itemDesc[3] = "Una cápsula vacía que se convierte en una cápsula de energía una vez que se llena.";

            inv.itemName[4] = "Cápsula de energía";
            inv.itemDesc[4] = "Una cápsula que almacena una cantidad inimaginable de energía, suficiente para abastecer de electricidad a la ciudad de Los Ángeles durante 12 años.";

            inv.itemName[5] = "Palanca";
            inv.itemDesc[5] = "Una palanca que puedes usar para abrir puertas atascadas.";

            inv.itemName[6] = "Glock 17";
            inv.itemDesc[6] = "Una Glock 17 tomada de la sala de seguridad. Solo queda una bala. No habrá una segunda oportunidad.";

            inv.itemName[7] = "Protocolo de seguridad";

            if (sho != null)
                inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Nota de Bob";
            if (sho != null)
                inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Nota de Lara";
            if (sho != null)
                inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Nota de Aral?";
            if (sho != null)
                inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Nota de Lara?";
            if (sho != null)
                inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Nota desconocida";
            if (sho != null)
                inv.itemDesc[12] = sho.noteText7;
        }
    }

    void LoadРусскийDialogs() /////////rusça dialoglar buraya eklenecek
    {
        dias[0] = "Лара: Прежде чем войти в лабораторию, нам нужно дождаться, пока центр Nova пришлёт код доступа.";
        dias[1] = "Арал: Код доступа?";
        dias[2] = "Лара: Да, четырёхзначный код. Его отправят на компьютеры в контейнерном здании на острове.";
        dias[3] = "Лара: Профессор Артур говорил, что карта доступа к контейнеру находится в ангаре.";
        dias[4] = "Лара: Ты иди вперёд, мне нужно взять ещё пару вещей. Не переживай, я тебя догоню.";
        dias[5] = "Лара: И сколько ты ещё собираешься так на меня смотреть?";
        dias[6] = "Арал: Вот он.";
        dias[7] = "Лара: Похоже, ты нашёл карту и открыл дверь.";
        dias[8] = "Арал: Да, только что открыл. Время у тебя идеальное.";
        dias[9] = "Лара: Я всегда пунктуальна.";
        dias[10] = "Лара: Подожди минуту, что значит «нет сигнала»? Система неисправна? Мы зря проделали весь этот путь?";
        dias[11] = "Арал: Может, проблема в радиовышке.";
        dias[12] = "Лара: Почему ты так думаешь?";
        dias[13] = "Арал: Потому что система здесь выглядит исправной. Думаю, проблема в радиовышке. В ангаре я видел несколько инструментов. Возьму их и проверю.";
        dias[14] = "Лара: Хорошо, тогда я останусь здесь и посмотрю, что могу сделать.";
        dias[15] = "Арал: Вау! Какой красивый вид.";
        dias[16] = "Арал: Что это был за звук?";
        dias[17] = "Арал: Наверное, просто животное.";
        dias[18] = "Арал: Ладно, мне нужно идти к радиовышке.";
        dias[19] = "Арал: Отлично, это сработает. Теперь нужно вернуться к Ларе.";
        dias[20] = "Арал: Это фонарик Лара оставила?";
        dias[21] = "Арал: Подойдёт, чтобы открывать заклинившие двери.";
        dias[22] = "Арал: На случай, если придётся защищаться.";
        dias[23] = "Арал: Всё готово.";
        dias[24] = "Лара: Ты вернулся. После того как ты починил вышку, появился сигнал, и я установила соединение, но центр ещё не прислал код.";
        dias[25] = "Арал: Электрический щиток должен быть наверху.";
        dias[26] = "Арал: Значит, мы приехали слишком рано?";
        dias[27] = "Лара: Вообще-то нет. Если бы мы приехали позже, уже стемнело бы, и я сомневаюсь, что ты смог бы починить вышку в темноте.";
        dias[28] = "Арал: Известно, когда они пришлют код?";
        dias[29] = "Лара: Через два-три часа. Здесь есть кровати, можешь поспать. Мы оба устали после долгой дороги.";
        dias[30] = "Арал: Может, перед сном немного осмотрю остров.";
        dias[31] = "Лара: Как хочешь.";
        dias[32] = "Арал: Сколько я спал? Центр уже должен был прислать код.";
        dias[33] = "Арал: Где Лара?";
        dias[34] = "Арал: Что это? Тень? Но перед светом никого нет...";
        dias[35] = "Арал: Что это сейчас было? Наверное, я ещё не до конца проснулся. Да, другого объяснения быть не может.";
        dias[36] = "Арал: Лара.";
        dias[37] = "Лара: Ну и соня ты. Пока ждала тебя, мне стало скучно, и я спустилась к пляжу.";
        dias[38] = "Арал: Ты вообще не спала?";
        dias[39] = "Лара: Спала как младенец, но проснулась раньше тебя. Кстати, ты взял фонарик, который я оставила?";
        dias[40] = "Арал: Да, взял. И когда вышел наружу, перед дверью была тень. Когда я подошёл, она исчезла.";
        dias[41] = "Лара: Тень? Может, это была твоя тень, и когда дверь закрылась за тобой, она исчезла.";
        dias[42] = "Арал: Нет, это была не моя тень. Она была перед светом снаружи.";
        dias[43] = "Лара: Уверена, этому есть логичное объяснение.";
        dias[44] = "Арал: Единственное, что приходит в голову — я был сонным и мне показалось.";
        dias[45] = "Лара: Вот видишь, ты уже нашёл логичное объяснение.";
        dias[46] = "Арал: В любом случае, центр прислал код. Код 1327.";
        dias[47] = "Лара: Я знаю, когда я проснулась, код уже был на экране.";
        dias[48] = "Арал: Тогда ты готова войти в лабораторию Nova?";
        dias[49] = "Лара: Нам некуда спешить. Хочу ещё немного посидеть и посмотреть на пляж. Ночью он особенно красив, правда?";
        dias[50] = "Арал: Ах... Да, пляж действительно красив, но я иду в лабораторию. Тебе тоже лучше не задерживаться.";
        dias[51] = "Лара: Не переживай, я всегда пунктуальна.";
        dias[52] = "Арал: В конце концов, лаборатории — это стерильная среда.";
        dias[53] = "Арал: Мне нужно надеть лабораторный халат. Интересно, где раздевалка?";
        dias[54] = "Арал: Хм, этот халат совсем неплох.";
        dias[55] = "Лара: Тебе идёт халат.";
        dias[56] = "Арал: Ты... как... когда ты успела прийти?";
        dias[57] = "Лара: Как я уже говорила, я всегда-";
        dias[58] = "Арал: Пунктуальна, понял.";
        dias[59] = "Арал: Итак, можешь кратко рассказать, что мы будем делать?";
        dias[60] = "Лара: Конечно. Сначала мы возьмём энергетические капсулы Aether Core из комнаты Enviro. Их должно быть шесть.";
        dias[61] = "Лара: Затем, используя эти капсулы, мы должны запустить варп-двигатель в экспериментальной комнате на втором этаже.";
        dias[62] = "Лара: Варп-двигатель обычно предназначен для межзвёздных путешествий.";
        dias[63] = "Лара: Но сегодня мы попытаемся объединить варп-двигатель и энергетические капсулы Aether Core, чтобы создать параллакс-двигатель.";
        dias[64] = "Лара: Теоретически этот двигатель сможет изменять пространство и время не только вперёд, как варп-двигатель, но и назад — более контролируемым способом.";
        dias[65] = "Лара: Таким образом мы пытаемся сделать путешествия во времени возможными.";
        dias[66] = "Лара: То, что мы делаем здесь, очень важно для человечества.";
        dias[67] = "Арал: Вау! Звучит как магия.";
        dias[68] = "Лара: Любая достаточно развитая технология неотличима от магии.";
        dias[69] = "Арал: Ты права, Лара К. Кларк.";
        dias[70] = "Лара: Ха-ха! Очень смешно.";
        dias[71] = "Арал: Комната Enviro заперта. Как мы попадём внутрь?";
        dias[72] = "Лара: За этот этаж лаборатории отвечал профессор Артур. Возможно, среди его вещей ты найдёшь какой-нибудь пароль.";
        dias[73] = "Лара: Посмотри в мужской раздевалке.";
        dias[74] = "Арал: Похоже, это данные для входа в личный компьютер профессора Артура.";
        dias[75] = "Арал: Сначала мне нужно переодеться.";
        dias[76] = "Лара: Ты что-нибудь нашёл?";
        dias[77] = "Арал: Да. Похоже, профессор Артур тоже проводил здесь эксперименты. Я нашёл его записи. Кстати, код доступа — 1453.";
        dias[78] = "Лара: Ты молодец.";
        dias[79] = "Лара: Хорошо, теперь нам нужно взять шесть энергетических капсул Aether Core.";
        dias[80] = "Арал: На полке пять капсул, но две из них пустые.";
        dias[81] = "Лара: Хм, здесь написано, что машина в углу может производить капсулы Aether Core. Я активировала её.";
        dias[82] = "Арал: Я нашёл машину, и внутри есть ещё одна заполненная капсула. Значит, нужно заполнить только две пустые.";
        dias[83] = "Лара: Вот это хорошие новости.";
        dias[84] = "Арал: Все шесть капсул готовы.";
        dias[85] = "Лара: Смотри, здесь есть список проведённых экспериментов. Изначально эта комната была создана для защиты природы, но позже её начали использовать для других экспериментов.";
        dias[86] = "Арал: Да, например, для производства этих капсул. Ладно, пора подниматься наверх и запускать процедуру.";
        dias[87] = "Лара: Хорошо, вызови лифт, я сейчас подойду.";
        dias[88] = "Лара: Интересно, в каком состоянии верхний этаж лаборатории.";
        dias[89] = "Арал: Верхний этаж построила другая компания — Arc Industries.";
        dias[90] = "Арал: Они сделали лабораторию полностью автономной. Так что уверен, она в хорошем состоянии.";
        dias[91] = "Лара: Правда? Я думала, всю лабораторию построила компания Nova.";
        dias[92] = "Арал: Nova построила только первый этаж. Их целью было создание комнаты Enviro для исследований по защите природы и окружающей среды.";
        dias[93] = "Арал: Но поскольку эксперименты больше не служили только этой цели, лабораторию расширила Arc Industries.";
        dias[94] = "Лара: Как думаешь, центр Nova что-то от нас скрывает?";
        dias[95] = "Арал: Определённо. Поэтому я не доверяю сотрудникам центра Nova... Хотя ты можешь быть исключением.";
        dias[96] = "Лара: Раз ты рассказал это мне, значит, я тоже тебе доверяю.";
        dias[97] = "Арал: Ах... моя голова.";
        dias[98] = "Арал: Что случилось?";
        dias[99] = "Арал: Я должен его найти.";
        dias[100] = "Лара: Кажется, силовой кабель не подключён.";
        dias[101] = "Арал: Я проверю кабели.";
        dias[102] = "Арал: Готово, все системы запущены.";
        dias[103] = "Лара: Хорошо, следующий шаг — установить энергетические капсулы в варп-двигатель.";
        dias[104] = "Арал: Варп-двигатель должен быть в соседней комнате.";
        dias[105] = "Арал: Всё, я справился.";
        dias[106] = "Лара: Я заметила нестабильность в динамике поля.";
        dias[107] = "Арал: Это что-то серьёзное?";
        dias[108] = "Лара: Скорее всего, я исправлю это. Ты запускай процедуру. На столе справа от двойной двери есть красная кнопка. Она запускает процедуру.";
        dias[109] = "Арал: Лифт... Мне нужно к лифту.";
        dias[110] = "Лара: Когда варп-двигатель выйдет на полную мощность, он должен открыть разрыв в пространстве-времени и отправить нас на 1 час назад.";
        dias[111] = "Арал: Что это за звук?";
        dias[112] = "Арал: Лара, это нормально?";
        dias[113] = "Лара: Произошла перегрузка, останови процедуру!";
        dias[114] = "Арал: Лара, я тебя не слышу.";
        dias[115] = "Арал: Я остановлю процедуру.";
        dias[116] = "Неизвестный: Вернись к жизни.";
        dias[117] = "Арал: Отсюда не получится. Может быть, наверху есть выход.";
        dias[118] = "Арал: Лаборатория разрушена. Надеюсь, лифт работает.";
        dias[119] = "Арал: Эй, кто там?";
        dias[120] = "Арал: Лара? Это ты?";
        dias[121] = "Арал: Что за чёрт здесь происходит, и что это было?";
        dias[122] = "Арал: Опять эта тень... Она играет с моим разумом.";
        dias[123] = "Арал: Генератор здесь.";
        dias[124] = "Арал: Получилось, скорее всего лифт теперь работает.";
        dias[125] = "Арал: Лара работала здесь много лет назад. Должна быть записка с тех времён. Удивительно, что она всё ещё здесь.";
        dias[126] = "Арал: Временная петля? То, что произошло в лаборатории? У меня голова идёт кругом. Это Лара написала?";
        dias[127] = "Арал: Временная петля, временная петля, временная петля... Теперь понимаю — эксперимент не провалился, он оказался слишком успешным.";
        dias[128] = "Арал: Та тень, которую я видел, и голоса, которые слышал, должны быть связаны с этой аварией.";
        dias[129] = "Арал: Давай! Давай! ДАВАЙ!";
        dias[130] = "Арал: Боже мой!";
        dias[131] = "Арал: Эта штука постоянно меня преследует. Прямо как тень.";
        dias[132] = "Арал: Кто ты? Чего ты от меня хочешь?";
        dias[133] = "Разработчик: Я не ожидал, что ты зайдёшь так далеко. Твоё любопытство привело тебя в нужное место. Ты в скрытой области, и записка здесь открывает третий финал игры.";
        dias[134] = "Арал: Не могу поверить! Лара убила свою прошлую версию и заняла её место? Ради того, чтобы спасти меня? Я жив благодаря ей?";
        dias[135] = "Арал: У меня к ней так много вопросов, но прежде всего я должен положить конец этому безумию.";
        dias[136] = "Арал: Лара на пляже? Мне нужно поговорить с ней.";
        dias[137] = "Арал: Лара, слава богу, ты в порядке. Что ты здесь делаешь?";
        dias[138] = "Лара: Арал? Это ты? Почему ты вернулся?";
        dias[139] = "Арал: Да, это я. Что значит вернулся? И что ты здесь делаешь?";
        dias[140] = "Лара: Мы поговорили, и ты сказал, что мне нужно уйти, а потом мы попрощались.";
        dias[141] = "Арал: Когда всё это произошло? После аварии в лаборатории ты внезапно исчезла. Я нашёл твою записку.";
        dias[142] = "Лара: Теперь я понимаю...";
        dias[143] = "Арал: Ради бога! Ты наконец объяснишь, что происходит?";
        dias[144] = "Лара: Арал, ты застрял в лимбе. Посмотри на свою одежду!";
        dias[145] = "Лара: Если бы ты оказался здесь сразу после аварии в лаборатории, ты всё ещё был бы в лабораторном халате. Но на тебе куртка, в которой ты был в день нашего прибытия на остров.";
        dias[146] = "Арал: Не могу поверить... Как такое возможно?";
        dias[147] = "Лара: Сейчас ночь того дня, когда мы прибыли на остров. Ты на самом деле спишь, а я пришла на пляж.";
        dias[148] = "Лара: Я пыталась вытащить тебя из этого лимба, из этой временной петли. Я всё сделала ради тебя. Даже...";
        dias[149] = "Арал: Даже что? Что ты сделала, Лара?";
        dias[150] = "Лара: Когда ты это узнаешь, ты сказал, что мне придётся уйти. Поэтому сейчас я не буду это объяснять. Всё равно ты узнаешь.";
        dias[151] = "Лара: Ты только знай, что я люблю тебя настолько, чтобы сделать это.";
        dias[152] = "Арал: Лара... Я не хочу, чтобы ты уходила. Я никогда не скажу тебе уйти — ни в будущем, ни в прошлом. Пожалуйста, не уходи. Останься со мной.";
        dias[153] = "Лара: Арал, ты...";
        dias[154] = "Арал: Какова бы ни была проблема, мы справимся вместе. До того времени — и даже после — просто оставайся со мной.";
        dias[155] = "Лара: Ты заставляешь меня снова принимать трудное решение...";
        dias[156] = "Лара: Честно говоря, я никогда не хотела уходить. Я выведу тебя из этого лимба.";
        dias[157] = "Арал: Мы можем справиться вместе. Если—";
        dias[158] = "Лара: Арал, быстро, спрячься — он не должен тебя видеть.";
        dias[159] = "Арал: Кто не должен меня видеть?";
        dias[160] = "Лара: Нет времени объяснять. Быстро, спрячься за этим деревом!";
        dias[161] = "Арал: Погоди... это я иду к Ларе?";
        dias[162] = "Арал: Что здесь происходит? Это разрыв во времени? Я видел своё прошлое «я» и начинаю терять связь с реальностью.";
        dias[163] = "Арал: Это действительно моё прошлое «я»? И я стою прямо перед источником света... почему я себя не вижу?";
        dias[164] = "Арал: Подожди... эта тень, которую я всё время вижу... может быть, что...";
        dias[165] = "Арал: Я превращаюсь в эту тень.";
        dias[166] = "Арал: Вот что Лара имела в виду, говоря о том, чтобы застрять в лимбе.";
        dias[167] = "Арал: Каждый раз, когда я вижу своё прошлое «я», реальность разрушается чуть-чуть — и я отодвигаюсь всё дальше в прошлое.";
        dias[168] = "Арал: Я буквально становлюсь тенью во времени.";
        dias[169] = "Неизвестный: Что это? Моя тень? Но перед светом никого нет...";
        dias[170] = "Арал: Лара?";
        dias[171] = "Арал: Лара, нет!";
        dias[172] = "Арал: Лучше найти оружие, прежде чем спускаться вниз.";
        dias[173] = "Лара: Остров посреди Тихого океана, в тысячах километров от материка... Прежде чем прилететь сюда, дважды подумаешь.";
        dias[174] = "Арал: В этом и был смысл. Изолированная лаборатория. Если эксперимент со временем пойдет не так, последствия должны остаться здесь.";
        dias[175] = "Лара: По официальным данным это заброшенная метеостанция. Но комплекс под скалами позволит нам управлять временем.";
        dias[176] = "Арал: Надеюсь, мы покинем этот остров с успешным результатом.";
        dias[177] = "Лара: Мы приближаемся к острову. Готовьтесь к посадке.";
        dias[178] = "Арал: Что ты сделала…";
        dias[179] = "Арал: Только что… ты выстрелила в себя?";
        dias[180] = "Лара: Я…";
        dias[181] = "Лара: Нет… это была не я…";
        dias[182] = "Лара: Это была та, что потерпела неудачу.";
        dias[183] = "Арал: Что это значит?!";
        dias[184] = "Лара: ...";
        dias[185] = "Арал: Сколько раз ты это делала?";
        dias[186] = "Лара: Не помню.";
        dias[187] = "Арал: Не помнишь?!";
        dias[188] = "Лара: Каждый раз воспоминания путаются. Я оставляю себе записи, чтобы не забыть цель.";
        dias[189] = "Лара: Поэтому в этот раз всё будет иначе!";
        dias[190] = "Лара: В этот раз я вытащу тебя отсюда!";
        dias[191] = "Арал: Лара… ты не пытаешься спасти меня.";
        dias[192] = "Арал: Ты держишь меня здесь. Теперь я понимаю.";
        dias[193] = "Лара: Я лишь пыталась спасти тебя… ты превращаешься в ту тень.";
        dias[194] = "Арал: Катастрофа происходит каждый раз, да?";
        dias[195] = "Арал: Каждый раз прилетает вертолёт.";
        dias[196] = "Арал: Каждый раз мы приходим и после аварии я теряюсь в лимбе.";
        dias[197] = "Арал: А ты убиваешь себя в прошлом и заменяешь её.";
        dias[198] = "Арал: Эта авария и этот цикл… причина ты.";
        dias[199] = "Лара: Нет… первая авария была не из-за меня. Это действительно был несчастный случай.";
        dias[200] = "Арал: Лара, давай покончим с этим.";
        dias[201] = "Арал: Я ухожу. Я не буду частью этого цикла. Ты идёшь со мной.";
        dias[202] = "Арал: Лара?";
        dias[203] = "Лара: Я не пойду.";
        dias[204] = "Арал: Ты не понимаешь? Мы можем закончить это.";
        dias[205] = "Лара: Для тебя да. Когда ты станешь тенью, мой цикл начнётся снова.";
        dias[206] = "Лара: Кто-то должен всё исправить, и я сделаю всё.";
        dias[207] = "Арал: Я не хочу оставлять тебя здесь.";
        dias[208] = "Лара: Но я хочу. Уходи.";
        dias[209] = "Арал: Береги себя.";
        dias[210] = "Лара: Арал нет… ты не можешь… я просто хотела спасти тебя!";
        dias[211] = "Арал: Именно поэтому. Я всё закончу.";
        dias[212] = "Лара: Что я буду делать без тебя…";
        dias[213] = "Арал: Жить.";
        dias[214] = "Арал: Я был твоей причиной. Теперь буду твоей свободой.";
        dias[215] = "Лара: Я не смогла спасти тебя, но ты спас меня.";
        dias[216] = "Лара: Спасибо.";
        dias[217] = "Арал: Это не работает.";
        dias[218] = "Лара: В этот раз всё иначе.";
        dias[219] = "Арал: Нет. Ты сделала то же самое.";
        dias[220] = "Лара: Что?";
        dias[221] = "Арал: Бесчисленное количество раз…";
        dias[222] = "Лара: Откуда ты—";
        dias[223] = "Арал: Я нашёл их.";
        dias[224] = "Арал: Твои записи.";
        dias[225] = "Арал: Пытаясь спасти меня, ты запустила цикл.";
        dias[226] = "Лара: Я… не помню.";
        dias[227] = "Арал: Если вспомнишь — не сможешь продолжать.";
        dias[228] = "Арал: Проблема была не в попытках, а в том что ты не останавливалась.";
        dias[229] = "Лара: Если я оставлю тебя здесь…";
        dias[230] = "Арал: Тогда впервые ты не бросишь меня.";
        dias[231] = "Лара: Если ты умрёшь…";
        dias[232] = "Арал: Тогда ты по-настоящему начнёшь жить.";
        dias[233] = "Лара: Я больше не буду пытаться.";
        dias[234] = "Лара: Арал… тот вертолёт…";
        dias[235] = "Арал: Да, это мы.";
        dias[236] = "Арал: Мы разорвали свой цикл…";
        dias[237] = "Арал: Удачи.";
        dias[238] = "Арал: Красивые часы.";
        dias[239] = "Арал: Интересно, чьи они...";
        dias[240] = "Лара: Где эти часы...";
        dias[241] = "Арал: Похоже, я продолжаю возвращаться в прошлое... Вертолёт... Лара должна быть там.";



        menuUI[1] = "НАЧАТЬ НОВУЮ ИГРУ";
        menuUI[2] = "ПРОДОЛЖИТЬ";
        menuUI[3] = "НАСТРОЙКИ";
        menuUI[4] = "КРЕДИТЫ";
        menuUI[5] = "ВЫХОД";
        menuUI[6] = "ГРАФИКА";
        menuUI[7] = "ЗВУК";
        menuUI[8] = "КАМЕРА";
        menuUI[9] = "ЯЗЫК И ДОСТУПНОСТЬ";
        menuUI[10] = "НАЗАД";
        menuUI[11] = "РАЗРЕШЕНИЕ";
        menuUI[12] = "РАЗМЕР ЭКРАНА";
        menuUI[13] = "НАСТРОЙКИ ГРАФИКИ";
        menuUI[14] = "СГЛАЖИВАНИЕ КРАЕВ";
        menuUI[15] = "МУЗЫКА МЕНЮ";
        menuUI[16] = "ЧУВСТВИТЕЛЬНОСТЬ МЫШИ";
        menuUI[17] = "ПОКИВЫВАНИЕ ГОЛОВОЙ";
        menuUI[18] = "ЯЗЫК";
        menuUI[19] = "РАЗМЕР СУБТИТРОВ";
        menuUI[20] = "БЕЗРАМOЧНЫЙ РЕЖИМ";
        menuUI[21] = "ОКОННЫЙ РЕЖИМ";
        menuUI[22] = "ВЫСОКИЙ";
        menuUI[23] = "СРЕДНИЙ";
        menuUI[24] = "НИЗКИЙ";
        menuUI[25] = "ЗАКРЫТЬ";
        menuUI[26] = "ОТКРЫТЬ";
        menuUI[27] = "МАЛЫЙ";
        menuUI[28] = "СРЕДНИЙ";
        menuUI[29] = "БОЛЬШОЙ";
        menuUI[30] = "ЗАГРУЗИТЬ ИГРУ";
        menuUI[31] = "ГЛАВНОЕ МЕНЮ";
        menuUI[32] = "АРАЛ";
        menuUI[33] = "ЛАРА";


        uıUI[0] = "ЗАКРЫТО";
        uıUI[1] = "ТРЕБУЕТСЯ ЛОМ";
        uıUI[2] = "ИСПОЛЬЗОВАТЬ ЛОМ";
        uıUI[3] = "ВВЕСТИ ПАРОЛЬ";
        uıUI[4] = "ВХОД";
        uıUI[5] = "ПЕРЕОДЕТЬСЯ";
        uıUI[6] = "ВЫЗВАТЬ ЛИФТ";
        uıUI[7] = "ПОЖАЛУЙСТА, ПОДОЖДИТЕ";
        uıUI[8] = "2-Й ЭТАЖ";
        uıUI[9] = "ВЗЯТЬ";
        uıUI[10] = "РАЗМЕСТИТЬ КАПСУЛУ";
        uıUI[11] = "У ВАС НЕТ ПУСТОЙ КАПСУЛЫ";
        uıUI[12] = "ТРЕБУЕТСЯ ID-КАРТА";
        uıUI[13] = "СНАЧАЛА ВОЗЬМИ НАЛОЧНЫЙ ФОНАРЬ";
        uıUI[14] = "СПАТЬ";
        uıUI[15] = "ПОЧИНИТЬ";
        uıUI[16] = "ТРЕБУЕТСЯ РЕМОНТНЫЙ НАБОР";
        uıUI[17] = "ПЕРЕД ПРОДОЛЖЕНИЕМ СМЕНИ ОДЕЖДУ";
        uıUI[18] = "ИССЛЕДОВАТЬ";
        uıUI[19] = "ИССЛЕДОВАНИЕ...";
        uıUI[20] = "РАЗМЕСТИТЬ ЭНЕРГЕТИЧЕСКУЮ КАПСУЛУ";
        uıUI[21] = "ПОДКЛЮЧИТЬ КАБЕЛЬ";
        uıUI[22] = "НАЖАТЬ КНОПКУ";
        uıUI[23] = "ОТКРЫТЬ";
        uıUI[24] = "1-Й ЭТАЖ";
        uıUI[25] = "ПОГОВОРИТЬ С ЛАРОЙ";
        uıUI[26] = "ЗАПУСТИТЬ ГЕНЕРАТОР";
        uıUI[27] = "ЭЛЕКТРИЧЕСТВА НЕТ";
        uıUI[28] = "ВКЛЮЧИТЬ ФОНАРЬ";
        uıUI[29] = "ПРИСЕСТЬ";
        uıUI[30] = "ВЫХОД";
        uıUI[31] = "Момент решения, выберите ответ.";
        uıUI[32] = "Оставьте Лару на острове, чтобы она столкнулась со своими поступками, и покиньте его.";
        uıUI[33] = "Покончите с собой и завершите болезненный цикл Лары.";
        uıUI[34] = "Убедите Лару, рассказав ей о её записи.";



        if (mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "ЗАДАНИЯ";
            mis.missions[0] = "—НАЙДИТЕ ID-КАРТУ В АНГАРЕ";
            mis.missions[1] = "—ВЙДИТЕ В КОНТЕЙНЕРНОЕ ЗДАНИЕ";
            mis.missions[2] = "—НАЙДИТЕ РЕМОНТНЫЙ НАБОР В АНГАРЕ";
            mis.missions[3] = "—ПОЧИНИТЕ НЕИСПРАВНОСТЬ НА РАДИОКУЛЕ";
            mis.missions[4] = "—ВЕРНИТЕСЬ К ЛАРЕ";
            mis.missions[5] = "—НЕМНОГО ПОСПИТЕ";
            mis.missions[6] = "—ВОЗЬМИТЕ НАЛОЧНЫЙ ФОНАРЬ";
            mis.missions[7] = "—ВСТРЕТЬТЕСЬ С ЛАРОЙ НА ПЛЯЖЕ";
            mis.missions[8] = "—ВЙДИТЕ В ЛАБОРАТОРИЮ В ПЕЩЕРЕ";
            mis.missions[9] = "—НАДЕНЬТЕ ЛАБОРАТОРНЫЙ ХАЛАТ";
            mis.missions[10] = "—ИДИТЕ В КОМНАТУ ЭНВИРО";
            mis.missions[11] = "—ВОЗЬМИТЕ 6 ЭНЕРГЕТИЧЕСКИХ КАПСУЛ";
            mis.missions[12] = "—ПОДНИМИТЕСЬ НА 2-Й ЭТАЖ ЛАБОРАТОРИИ";
            mis.missions[13] = "—ПОДКЛЮЧИТЕ КАБЕЛЬ";
            mis.missions[14] = "—РАЗМЕСТИТЕ 6 КАПСУЛ";
            mis.missions[15] = "—ЗАПУСТИТЕ ПРОТОКОЛ";
            mis.missions[16] = "—ВЫЙДИТЕ ИЗ ЛАБОРАТОРИИ";
            mis.missions[17] = "—ПОГОВОРИТЕ С ЛАРОЙ";
            mis.missions[18] = "—Вернись к вертолёту.";
            mis.missions[19] = "—НАЙДИТЕ ПАРОЛЬ ДЛЯ КОМНАТЫ ЭНВИРО";
            mis.missions[20] = "—НАЙДИТЕ ПАРОЛЬ ДЛЯ КОМНАТЫ ЭНВИРО";
        }


        if (sho != null)
        {
            sho.noteText1 =
        @"Эксперимент 27 показал отклонение раньше, чем ожидалось. Хронометр работает правильно, но наблюдатель больше не может считаться надежной ссылкой. Время становится нестабильным.

На втором этаже лаборатории обнаружена магнитная нестабильность. Пребывание в изоляционной камере не должно превышать 4 минут. Более длительное воздействие вызывает провалы в памяти, которые невозможно восстановить.

Если мне снова понадобится доступ к системе:
Имя пользователя: NOVA
Пароль: 1441

— Проф. Артур";
            sho.noteText2 =
        @"Протокол безопасности – Только для внутреннего использования

Эти оружия оставлены в охранной комнате на случай чрезвычайных ситуаций.
Боеприпасы ограничены. Пополнения нет.

Аномалии, возникающие во время экспериментов со временем, не ведут себя как обычные угрозы. Стрельба не всегда является решением; иногда это может усугубить ситуацию.

Если у вас есть причина взять любое из этих оружий, протокол уже был нарушен. Одно единственное решение может повлиять на несколько временных линий.

Ждите подходящего момента.
Неправильное решение может стоить лет.

Главный исследователь
Лара
";
            sho.noteText3 =
        @"Профессор Артур,

В комнате генератора наблюдается странная ситуация. Система работает, но ведет себя нестабильно. Происходят кратковременные сбои и неожиданные колебания. Пока я не вмешивался; опасаюсь, что неверный шаг может привести к более серьёзной проблеме.

Думаю, лучше, если вы лично это проверите.

— Техник комнаты генератора
Боб";
            sho.noteText4 =
        @"Арал,

Дела пошли не так, как мы планировали. Я пыталась остановить эксперимент, но на мгновение контроль вышел из-под меня. Шум, взрыв… потом внезапно наступила тишина. Я звала тебя, но ты не ответил.

Со мной всё в порядке… наверное. Но оставаться здесь небезопасно. Что-то идёт за мной. Я не могу его полностью разглядеть. Я не знаю, что это или кто это. Всё, что я знаю — мне нужно уйти отсюда.

Я не хотела втягивать тебя в это ещё глубже. Я знаю, что ты будешь переживать за меня, и что ты пойдёшь за мной.

Пожалуйста, будь осторожен.";
            sho.noteText5 =
        @"Пока ты это читаешь, меня может уже не быть. То, что произошло в лаборатории, стало результатом неконтролируемого момента. Последние вещи, которые я помню из того мгновения — это огни, тревоги и странная тишина, которая последовала сразу после… Именно там всё и началось.

Некоторые петли не имеют выхода, и я оказалась в одной из них. Я слышу шёпот. Они говорят: «Из-за тебя!» Не могу понять, отвлекают ли они меня или пытаются что-то сообщить.

Время здесь иногда идёт вперёд, иногда назад, но в конце концов всегда возвращается к своей начальной точке. Те же ошибки, те же результаты. Возможно ли, что прошлое или будущее действительно нельзя изменить? Если не поторопишься, ты тоже станешь частью этой петли.

Жизнь проживается вперёд, но понимается задним числом.";
            sho.noteText6 =
        @"Моему будущему «я»,

Лара, если ты читаешь это письмо, ты должна знать, что мне не удалось спасти Арала. Я должна была убить своё прошлое «я» и занять его место, но это оказалось тщетным. Я не смогла разорвать этот временной цикл и не смогла освободить Арала из того состояния, в котором он оказался.

Ты должна предотвратить несчастный случай до того, как он произойдёт. Даже если это означает убить меня и занять моё место, ты должна это сделать. Пожалуйста, не повторяй моих ошибок. Что бы ни произошло, спаси Арала — и никогда не рассказывай ему, что ты сделала.

— Лара";
            sho.noteText7 = "Позади тебя!";
        }


        if (inv != null)
        {
            inv.itemName[0] = "ID-Карта";
            inv.itemDesc[0] = "Эта карта открывает некоторые двери в лаборатории Нова.";
            inv.itemName[1] = "Фонарик на лацкане";
            inv.itemDesc[1] = "Фонарик, который крепится на лацкан.";
            inv.itemName[2] = "Записка Артура";
            if (sho != null)
                inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Пустая капсула";
            inv.itemDesc[3] = "Пустая капсула, которая становится энергетической капсулой, когда её заполняют.";
            inv.itemName[4] = "Энергетическая капсула";
            inv.itemDesc[4] = "Капсула, содержащая невообразимое количество энергии — достаточно, чтобы снабжать город Лос-Анджелес электричеством в течение 12 лет.";
            inv.itemName[5] = "Лом";
            inv.itemDesc[5] = "Этот лом используется для открытия некоторых застрявших дверей.";
            inv.itemName[6] = "Glock 17";
            inv.itemDesc[6] = "Glock 17 из комнаты безопасности. Осталась только одна пуля. Второго шанса не будет.";
            inv.itemName[7] = "Протокол безопасности";
            if (sho != null)
                inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Записка персонала";
            if (sho != null)
                inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Записка Лары";
            if (sho != null)
                inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Записка Арала";
            if (sho != null)
                inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Записка Лары";
            if (sho != null)
                inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Неизвестная записка";
            if (sho != null)
                inv.itemDesc[12] = sho.noteText7;
        }
    }

    void LoadFrançaisDialogs()      /////////fransızca dialoglar buraya eklenecek
    {
        dias[0] = "Lara : Avant d'entrer dans le laboratoire, nous devons attendre que le Centre Nova envoie le code d'accès.";
        dias[1] = "Aral : Un code d'accès ?";
        dias[2] = "Lara : Oui, un code à 4 chiffres. Ils enverront ce code aux ordinateurs situés dans le bâtiment des conteneurs sur l'île.";
        dias[3] = "Lara : Le professeur Arthur a mentionné que la carte d'accès au conteneur se trouvait dans le hangar.";
        dias[4] = "Lara : Tu y vas en premier, j'ai quelques affaires à prendre. Ne t'inquiète pas, je te rattraperai.";
        dias[5] = "Lara : Combien de temps vas-tu encore me regarder comme ça ?";
        dias[6] = "Aral : C'est juste ici.";
        dias[7] = "Lara : On dirait que tu as trouvé la carte et ouvert la porte.";
        dias[8] = "Aral : Oui, je viens de l'ouvrir — ton timing est parfait.";
        dias[9] = "Lara : Je suis toujours ponctuelle.";
        dias[10] = "Lara : Attends une seconde, que veux-tu dire par 'pas de signal' ? Le système est en panne ? Avons-nous fait tout ce chemin pour rien ?";
        dias[11] = "Aral : Peut-être qu'il y a une panne à la tour radio.";
        dias[12] = "Lara : Pourquoi penses-tu ça ?";
        dias[13] = "Aral : Parce que le système ici semble assez propre et opérationnel. Je pense que le problème se trouve à la tour radio. J'ai vu quelques outils dans le hangar. Je vais les prendre et vérifier.";
        dias[14] = "Lara : Très bien alors, je reste ici et je verrai ce que je peux faire.";
        dias[15] = "Aral : Wow ! Quelle belle vue.";
        dias[16] = "Aral : Quel était ce bruit ?";
        dias[17] = "Aral : C'était probablement juste un animal.";
        dias[18] = "Aral : Bon, je devrais me diriger vers la tour radio maintenant.";
        dias[19] = "Aral : D'accord, cela devrait faire l'affaire. Maintenant, je devrais retourner auprès de Lara.";
        dias[20] = "Aral : Lara a-t-elle laissé cette lampe de poche ?";
        dias[21] = "Aral : Elle sera utile pour ouvrir les portes coincées.";
        dias[22] = "Aral : Juste au cas où je devrais me protéger.";
        dias[23] = "Aral : Tout est prêt.";
        dias[24] = "Lara : Tu es de retour. Après que tu aies réparé la panne à la tour, le signal est passé et j'ai établi la connexion, mais le centre n'a pas encore envoyé le code.";
        dias[25] = "Aral : Le panneau électrique devrait être à l'étage.";
        dias[26] = "Aral : Donc, sommes-nous arrivés trop tôt ?";
        dias[27] = "Lara : En fait, non. Si nous étions arrivés plus tard, il aurait été soir, et je doute que tu puisses réparer la tour dans l'obscurité.";
        dias[28] = "Aral : Savez-vous quand ils enverront le code ?";
        dias[29] = "Lara : Ils l'enverront probablement dans deux ou trois heures. Il y a des lits ici si tu veux dormir. Nous avons tous les deux fait un long voyage et nous sommes fatigués.";
        dias[30] = "Aral : Peut-être que je peux explorer un peu l'île avant de dormir.";
        dias[31] = "Lara : Comme tu veux.";
        dias[32] = "Aral : Depuis combien d'heures ai-je dormi ? Le centre a dû envoyer le code.";
        dias[33] = "Aral : Où est Lara ?";
        dias[34] = "Aral : Qu'est-ce que c'est ? Mon ombre ? Mais il n'y a personne devant la lumière...";
        dias[35] = "Aral : Que vient-il de se passer ? Je dois être encore groggy puisque je viens de me réveiller. Oui, il ne peut pas y avoir d'autre explication.";
        dias[36] = "Aral : Lara.";
        dias[37] = "Lara : Quel dormeur tu fais. Je me suis ennuyée en t'attendant et je suis descendue à la plage.";
        dias[38] = "Aral : Tu n'as pas du tout dormi ?";
        dias[39] = "Lara : J'ai dormi comme un bébé, mais je me suis réveillée avant toi. Au fait, as-tu pris la lampe de poche que j'ai laissée ?";
        dias[40] = "Aral : Oui, je l'ai prise. Et quand je suis sorti, il y avait une ombre devant la porte. Elle a disparu quand je me suis approché.";
        dias[41] = "Lara : Une ombre ? Peut-être que c'était ta propre ombre, et quand la porte s'est refermée derrière toi, elle a disparu.";
        dias[42] = "Aral : Non, ce n'était pas mon ombre. Elle était devant la source de lumière.";
        dias[43] = "Lara : Je suis sûre qu'il y a une explication logique.";
        dias[44] = "Aral : La seule chose à laquelle je peux penser est que je l'ai imaginée parce que j'étais à moitié endormi.";
        dias[45] = "Lara : Tu vois ? Tu as déjà trouvé une explication logique.";
        dias[46] = "Aral : Quoi qu'il en soit, le centre a envoyé le code. C'est 1327.";
        dias[47] = "Lara : Je sais. Quand je me suis réveillée, le code était déjà sur l'écran.";
        dias[48] = "Aral : Alors, es-tu prêt à entrer dans le laboratoire Nova ?";
        dias[49] = "Lara : Nous ne sommes pas pressés. Je veux rester un peu plus longtemps et regarder la plage. La plage est belle la nuit, n'est-ce pas ?";
        dias[50] = "Aral : Ah… Regarde, la plage est vraiment belle, mais je me dirige vers le laboratoire. Tu devrais venir dès que possible.";
        dias[51] = "Lara : Ne t’inquiète pas, je suis toujours ponctuelle.";
        dias[52] = "Aral : Après tout, les laboratoires sont des environnements stériles.";
        dias[53] = "Aral : Je dois mettre une blouse de laboratoire. Je me demande où se trouve le vestiaire.";
        dias[54] = "Aral : Hmm, cette blouse de laboratoire n’est pas mal du tout.";
        dias[55] = "Lara : La blouse te va très bien.";
        dias[56] = "Aral : Toi… comment… quand es-tu arrivée ?";
        dias[57] = "Lara : Comme je l'ai dit, je suis toujours—";
        dias[58] = "Aral : Ponctuelle, oui, j’ai compris.";
        dias[59] = "Aral : Alors, peux-tu m’expliquer brièvement ce que nous allons faire maintenant ?";
        dias[60] = "Lara : Bien sûr. D’abord, nous prendrons les capsules d’énergie Aether Core de la salle enviro. Il devrait y en avoir six.";
        dias[61] = "Lara : Ensuite, en utilisant ces capsules, nous devons activer le moteur de distorsion situé dans la salle d’expérimentation au deuxième étage.";
        dias[62] = "Lara : Le moteur de distorsion est normalement utilisé pour les voyages interstellaires.";
        dias[63] = "Lara : Mais aujourd’hui, nous essayons de combiner le moteur de distorsion et les capsules d’énergie Aether Core pour créer un moteur Parallax.";
        dias[64] = "Lara : En théorie, ce moteur pourra manipuler l’espace et le temps non seulement vers l’avant comme un moteur de distorsion, mais aussi vers l’arrière, de manière plus contrôlée.";
        dias[65] = "Lara : De cette façon, nous essayons de rendre le voyage dans le temps possible.";
        dias[66] = "Lara : Ce que nous faisons ici — et ce que nous allons faire — est très important pour l’humanité.";
        dias[67] = "Aral : Wow ! Ça ressemble à de la magie.";
        dias[68] = "Lara : Toute technologie suffisamment avancée est indiscernable de la magie.";
        dias[69] = "Aral : Tu as raison, Lara C.Clarke.";
        dias[70] = "Lara : Haha ! Oh, très drôle.";
        dias[71] = "Aral : La salle enviro est verrouillée. Comment allons-nous y entrer ?";
        dias[72] = "Lara : Le Prof. Arthur était responsable de cet étage du laboratoire. Peut-être peux-tu trouver un code parmi ses affaires.";
        dias[73] = "Lara : Vérifie le vestiaire des hommes.";
        dias[74] = "Aral : Ce doivent être les identifiants pour l’ordinateur personnel du Prof. Arthur.";
        dias[75] = "Aral : Je devrais changer mes vêtements d’abord.";
        dias[76] = "Lara : As-tu trouvé quelque chose ?";
        dias[77] = "Aral : Oui. Il semble que le Prof. Arthur ait également réalisé des expériences dans ce laboratoire. J’ai trouvé des notes liées à ses expériences. Au fait, le code d’accès est 1453.";
        dias[78] = "Lara : Tu es incroyable.";
        dias[79] = "Lara : Très bien, maintenant nous devons prendre six capsules d’énergie Aether Core.";
        dias[80] = "Aral : Il y a cinq capsules sur l’étagère ici, mais deux sont vides.";
        dias[81] = "Lara : Hmm, selon ce qui est écrit ici, la machine dans le coin peut produire des capsules d’énergie Aether Core. J’ai activé la machine.";
        dias[82] = "Aral : J’ai trouvé la machine, et il y a une capsule pleine à l’intérieur. Je dois donc seulement remplir les deux vides.";
        dias[83] = "Lara : C’est une bonne nouvelle.";
        dias[84] = "Aral : Les six capsules sont prêtes.";
        dias[85] = "Lara : Regarde, il y a une liste des expériences réalisées ici. Cette salle a été construite pour la protection de l’environnement, mais elle a ensuite été utilisée pour d’autres expériences.";
        dias[86] = "Aral : Oui, comme pour produire ces capsules. Allons à l’étage et commençons la procédure.";
        dias[87] = "Lara : D’accord, appelle l’ascenseur. J’arrive.";
        dias[88] = "Lara : Je me demande dans quel état se trouve l’étage supérieur du laboratoire.";
        dias[89] = "Aral : L’étage supérieur du laboratoire a été construit par une entreprise différente appelée Arc Industries.";
        dias[90] = "Aral : Ils ont conçu le laboratoire pour qu’il soit autonome, donc je suis sûr qu’il est en bon état.";
        dias[91] = "Lara : Vraiment ? Je pensais que tout le laboratoire avait été construit par Nova.";
        dias[92] = "Aral : Nova n’a construit que le premier étage. Leur objectif était de protéger la nature et l’environnement grâce aux recherches menées dans la salle enviro.";
        dias[93] = "Aral : Mais comme les expériences menées ici ne servaient plus uniquement à ce but, le laboratoire a été agrandi par Arc Industries.";
        dias[94] = "Lara : Penses-tu que le Centre Nova nous cache des choses ?";
        dias[95] = "Aral : Définitivement. C’est pourquoi je ne fais pas confiance au personnel du Centre Nova… bien que tu puisses être une exception.";
        dias[96] = "Lara : Puisque tu me dis tout cela, je te fais confiance aussi.";
        dias[97] = "Aral : Ah… ma tête.";
        dias[98] = "Aral : Que s’est-il passé ?";
        dias[99] = "Aral : Je dois le trouver.";
        dias[100] = "Lara : Je pense que le câble d’alimentation n’est pas branché.";
        dias[101] = "Aral : Laisse-moi vérifier les câbles.";
        dias[102] = "Aral : Voilà, tous les systèmes sont en ligne.";
        dias[103] = "Lara : D’accord, la prochaine étape est d’insérer les capsules d’énergie dans le moteur de distorsion.";
        dias[104] = "Aral : Le moteur de distorsion doit être dans la pièce suivante.";
        dias[105] = "Aral : Très bien, c’est fait.";
        dias[106] = "Lara : J’ai détecté une irrégularité dans la dynamique du champ.";
        dias[107] = "Aral : Est-ce sérieux ?";
        dias[108] = "Lara : Je peux probablement le réparer. Commence la procédure. Il y a un bouton rouge sur la table à droite des portes doubles. Ce bouton lance la procédure.";
        dias[109] = "Aral : L’ascenseur… je dois aller à l’ascenseur.";
        dias[110] = "Lara : Quand le moteur de distorsion atteindra sa pleine puissance, il devrait déchirer l’espace-temps et nous renvoyer d’une heure en arrière.";
        dias[111] = "Aral : Quel était ce bruit ?";
        dias[112] = "Aral : Lara, est-ce normal ?";
        dias[113] = "Lara : Il y a une surcharge—arrête la procédure !";
        dias[114] = "Aral : Lara, je ne t’entends pas.";
        dias[115] = "Aral : Je vais arrêter la procédure.";
        dias[116] = "Inconnu : Retourne à la vie.";
        dias[117] = "Aral : Pas par ici. Peut-être qu’il y a une sortie à l’étage supérieur.";
        dias[118] = "Aral : Le laboratoire est en ruines. J’espère que l’ascenseur fonctionne encore.";
        dias[119] = "Aral : Hé, qui est là ?";
        dias[120] = "Aral : Lara ? C’est toi ?";
        dias[121] = "Aral : Qu’est-ce qui se passe ici ? Et c’était quoi ce truc ?";
        dias[122] = "Aral : Cette ombre encore… elle joue avec mon esprit.";
        dias[123] = "Aral : Le générateur est là.";
        dias[124] = "Aral : Je l’ai fait. L’ascenseur fonctionne probablement maintenant.";
        dias[125] = "Aral : Lara travaillait ici il y a longtemps. Ceci doit être une note de cette époque. Je suis surpris qu’elle soit encore là.";
        dias[126] = "Aral : Une boucle temporelle ? Est-ce ce qui s’est passé dans le laboratoire ? Ma tête tourne. Lara a-t-elle écrit ça ?";
        dias[127] = "Aral : Boucle temporelle, boucle temporelle, boucle temporelle… Maintenant je comprends. L’expérience n’a pas échoué—elle a été trop réussie.";
        dias[128] = "Aral : L’ombre que j’ai vue et les voix que j’ai entendues doivent être liées à cet accident.";
        dias[129] = "Aral : Allez ! Allez ! ALLEZ !";
        dias[130] = "Aral : Oh mon Dieu !";
        dias[131] = "Aral : Cette chose continue de me suivre—comme une ombre.";
        dias[132] = "Aral : Qui es-tu ? Que veux-tu de moi ?";
        dias[133] = "Développeur : Je ne m’attendais pas à ce que tu arrives aussi loin. Ta curiosité t’a conduit au bon endroit. Tu es dans une zone secrète, et cette note débloque la troisième fin du jeu.";
        dias[134] = "Aral : Je n’y crois pas ! Lara a-t-elle tué son moi du passé et pris sa place ? Était-ce pour me sauver ? Suis-je vivant grâce à elle ?";
        dias[135] = "Aral : J’ai tellement de questions pour elle, mais avant tout, je dois m’assurer que cette folie s’arrête.";
        dias[136] = "Aral : La Lara sur la plage ? Je dois lui parler.";
        dias[137] = "Aral : Lara, Dieu merci tu vas bien. Que fais-tu ici ?";
        dias[138] = "Lara : Aral ? C’est toi ? Pourquoi es-tu revenu ?";
        dias[139] = "Aral : Oui, c’est moi. Que veux-tu dire par « revenu » ? Et que fais-tu ici ?";
        dias[140] = "Lara : Nous avons parlé, et tu m’as dit que je devais partir. Puis nous nous sommes dit au revoir.";
        dias[141] = "Aral : Quand tout cela est-il arrivé ? Après l’accident au laboratoire, tu as soudainement disparu. J’ai trouvé la note que tu as laissée.";
        dias[142] = "Lara : Maintenant je comprends…";
        dias[143] = "Aral : Bon sang ! Vas-tu enfin me dire ce qui se passe ?";
        dias[144] = "Lara : Aral, tu es coincé dans le limbe. Regarde tes vêtements !";
        dias[145] = "Lara : Si tu étais vraiment venu ici après l’accident au laboratoire, tu porterais encore ta blouse de labo. Mais tu portes la veste que tu avais le jour où nous sommes arrivés sur l’île.";
        dias[146] = "Aral : Je n’arrive pas à y croire… Comment est-ce possible ?";
        dias[147] = "Lara : Le temps actuel est la nuit du jour où nous sommes arrivés sur l’île. Tu es en fait endormi, et je suis descendue à la plage.";
        dias[148] = "Lara : J’ai essayé de te libérer du limbe dans lequel tu es coincé—de cette boucle temporelle. J’ai tout fait pour toi. J’ai même—";
        dias[149] = "Aral : Même quoi ? Qu’as-tu fait, Lara ?";
        dias[150] = "Lara : Quand tu as découvert la vérité, tu m’as dit que je devais partir. C’est pourquoi je ne vais pas l’expliquer maintenant. Tu finiras par le découvrir.";
        dias[151] = "Lara : Sache juste que je t’aime assez pour faire ça.";
        dias[152] = "Aral : Lara… Je ne veux pas que tu partes. Je ne te dirais jamais de partir—ni dans le futur ni dans le passé. S’il te plaît, ne pars pas, reste avec moi.";
        dias[153] = "Lara : Aral, tu…";
        dias[154] = "Aral : Peu importe le problème, je suis sûr que nous pouvons le surmonter. Jusque-là—et même après—reste simplement avec moi.";
        dias[155] = "Lara : Tu me forces à prendre une décision difficile… encore une fois.";
        dias[156] = "Lara : Pour être honnête, je n’ai jamais voulu partir dès le départ. Je vais te sauver de ce limbe.";
        dias[157] = "Aral : Nous pouvons le gérer ensemble. Si—";
        dias[158] = "Lara : Aral, cache-toi—vite. Il ne doit pas te voir.";
        dias[159] = "Aral : Qui ne doit pas me voir ?";
        dias[160] = "Lara : Il n’y a pas le temps d’expliquer. Dépêche-toi et cache-toi derrière cet arbre.";
        dias[161] = "Aral : Attends une seconde… est-ce moi qui vais vers Lara ?";
        dias[162] = "Aral : Que se passe-t-il ? Est-ce une fracture temporelle ? J’ai vu mon moi du passé, et je commence à perdre mon sens de la réalité.";
        dias[163] = "Aral : Est-ce mon moi du passé ? Et je suis devant la lumière—comment ne puis-je pas me voir ?";
        dias[164] = "Aral : Attends… cette ombre que je vois tout le temps… et si c’était… ?";
        dias[165] = "Aral : Je deviens cette ombre.";
        dias[166] = "Aral : C’est ce que Lara voulait dire par être coincé dans le limbe.";
        dias[167] = "Aral : Il semble qu’à chaque fois que je vois mon moi du passé, la réalité se fracture et je suis repoussé un peu plus loin dans le temps.";
        dias[168] = "Aral : Je deviens littéralement une ombre dans le temps.";
        dias[169] = "Inconnu : Qu’est-ce que c’est ? Une ombre de moi-même ? Mais il n’y a personne devant la lumière…";
        dias[170] = "Aral : Lara ?";
        dias[171] = "Aral : Lara, non !";
        dias[172] = "Aral : Je ferais mieux de trouver une arme avant de descendre.";
        dias[173] = "Lara: Une île au milieu du Pacifique, à des kilomètres du continent... On y réfléchit à deux fois avant de venir ici.";
        dias[174] = "Aral: C’était le but. Un laboratoire isolé. Si l’expérience temporelle tourne mal, les effets doivent rester confinés ici.";
        dias[175] = "Lara: Officiellement, cet endroit est une station météorologique abandonnée. Mais l’installation sous les falaises nous permettra de contrôler le temps.";
        dias[176] = "Aral: J’espère que nous quitterons cette île avec un résultat concluant.";
        dias[177] = "Lara: Nous approchons de l’île. Préparez-vous à l’atterrissage.";
        dias[178] = "Aral : Qu’est-ce que tu as fait…";
        dias[179] = "Aral : À l’instant… tu t’es tiré dessus ?";
        dias[180] = "Lara : Je…";
        dias[181] = "Lara : Non… ce n’était pas moi…";
        dias[182] = "Lara : C’était celle qui a échoué.";
        dias[183] = "Aral : Qu’est-ce que ça veut dire ?!";
        dias[184] = "Lara : ...";
        dias[185] = "Aral : Combien de fois as-tu fait ça ?";
        dias[186] = "Lara : Je ne me souviens pas.";
        dias[187] = "Aral : Tu ne te souviens pas ?!";
        dias[188] = "Lara : Parce que mes souvenirs se mélangent à chaque fois. Je me laisse des notes pour ne pas oublier mon objectif.";
        dias[189] = "Lara : C’est pour ça que cette fois sera différente !";
        dias[190] = "Lara : Cette fois je te sortirai d’ici !";
        dias[191] = "Aral : Lara… tu n’essaies pas de me sauver.";
        dias[192] = "Aral : Tu me gardes ici. Maintenant je comprends.";
        dias[193] = "Lara : J’ai seulement essayé de te sauver… Tu te transformes peu à peu en cette ombre. Je l’ai toujours su.";
        dias[194] = "Aral : L’accident arrive à chaque fois, n’est-ce pas ?";
        dias[195] = "Aral : Chaque fois l’hélicoptère arrive.";
        dias[196] = "Aral : Chaque fois nous venons et après l’accident je me perds dans le limbe.";
        dias[197] = "Aral : Mais toi tu tues ton ancien toi et prends sa place pour sauver le premier moi perdu.";
        dias[198] = "Aral : Cet accident et cette boucle… tu en es la cause.";
        dias[199] = "Lara : Non… le premier accident n’était pas à cause de moi. C’était vraiment un accident.";
        dias[200] = "Aral : Lara, mettons fin à ça.";
        dias[201] = "Aral : Je pars. Je ne ferai plus partie de cette boucle meurtrière. Tu viens avec moi.";
        dias[202] = "Aral : Lara ?";
        dias[203] = "Lara : Je ne viens pas.";
        dias[204] = "Aral : Tu ne comprends pas ? On peut arrêter la boucle ainsi.";
        dias[205] = "Lara : Pour toi oui. Quand tu deviendras l’ombre, ma boucle recommencera.";
        dias[206] = "Lara : Quelqu’un doit réparer tout ça et je ferai tout ce qu’il faut.";
        dias[207] = "Aral : Je ne veux vraiment pas te laisser ici.";
        dias[208] = "Lara : Mais moi oui. Alors pars.";
        dias[209] = "Aral : Prends soin de toi.";
        dias[210] = "Lara : Aral non… tu ne peux pas… je voulais seulement te sauver !";
        dias[211] = "Aral : Justement. Je vais tout arrêter.";
        dias[212] = "Lara : Que vais-je faire sans toi…";
        dias[213] = "Aral : Tu vas vivre.";
        dias[214] = "Aral : J’étais ta raison. Maintenant je serai ta liberté.";
        dias[215] = "Lara : Je n’ai pas pu te sauver mais tu m’as sauvée.";
        dias[216] = "Lara : Merci.";
        dias[217] = "Aral : Ça ne marche pas.";
        dias[218] = "Lara : Cette fois c’est différent.";
        dias[219] = "Aral : Non. Tu as fait pareil.";
        dias[220] = "Lara : Quoi ?";
        dias[221] = "Aral : D’innombrables fois. Chaque fois tu t’es tuée… chaque fois tu as pris ta place.";
        dias[222] = "Lara : Comment sais-tu—";
        dias[223] = "Aral : Je les ai trouvées.";
        dias[224] = "Aral : Les notes que tu as cachées.";
        dias[225] = "Aral : En voulant me sauver, tu as créé la boucle.";
        dias[226] = "Lara : Je… ne me souviens pas.";
        dias[227] = "Aral : Parce que si tu te souviens, tu ne peux pas continuer.";
        dias[228] = "Aral : Le problème n’était pas d’essayer mais de ne jamais arrêter.";
        dias[229] = "Lara : Et si je te laisse ici…";
        dias[230] = "Aral : Pour la première fois tu ne m’abandonnerais pas.";
        dias[231] = "Lara : Et si tu meurs…";
        dias[232] = "Aral : Alors tu vivras enfin.";
        dias[233] = "Lara : Je n’essaierai plus.";
        dias[234] = "Lara : Aral… cet hélicoptère…";
        dias[235] = "Aral : Oui, c’est nous.";
        dias[236] = "Aral : Nous avons brisé notre boucle…";
        dias[237] = "Aral : Bonne chance.";
        dias[238] = "Aral : Belle horloge.";
        dias[239] = "Aral : Je me demande à qui elle appartient...";
        dias[240] = "Lara : Où est cette horloge...";
        dias[241] = "Aral: Je crois que je continue à voyager dans le passé... L'hélicoptère... Lara doit être là-bas.";



        menuUI[1] = "COMMENCER UNE NOUVELLE PARTIE";
        menuUI[2] = "CONTINUER";
        menuUI[3] = "PARAMÈTRES";
        menuUI[4] = "CRÉDITS";
        menuUI[5] = "QUITTER";
        menuUI[6] = "GRAPHISMES";
        menuUI[7] = "AUDIO";
        menuUI[8] = "CAMÉRA";
        menuUI[9] = "LANGUE & ACCESSIBILITÉ";
        menuUI[10] = "RETOUR";
        menuUI[11] = "RÉSOLUTION";
        menuUI[12] = "TAILLE DE L'ÉCRAN";
        menuUI[13] = "PARAMÈTRES GRAPHIQUES";
        menuUI[14] = "ANTI-ALIASING";
        menuUI[15] = "MUSIQUE DU MENU";
        menuUI[16] = "SENSIBILITÉ DE LA SOURIS";
        menuUI[17] = "BALANCEMENT DE LA TÊTE";
        menuUI[18] = "LANGUE";
        menuUI[19] = "TAILLE DES SOUS-TITRES";
        menuUI[20] = "PLEIN ÉCRAN SANS BORDURES";
        menuUI[21] = "MODE FENÊTRE";
        menuUI[22] = "ÉLEVÉE";
        menuUI[23] = "MOYENNE";
        menuUI[24] = "FAIBLE";
        menuUI[25] = "FERMER";
        menuUI[26] = "OUVRIR";
        menuUI[27] = "PETIT";
        menuUI[28] = "MOYEN";
        menuUI[29] = "GRAND";
        menuUI[30] = "CHARGER LA PARTIE";
        menuUI[31] = "MENU PRINCIPAL";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";


        uıUI[0] = "Verrouillé";
        uıUI[1] = "besoin d'un pied-de-biche";
        uıUI[2] = "pour utiliser le pied-de-biche";
        uıUI[3] = "pour entrer";
        uıUI[4] = "pour se connecter";
        uıUI[5] = "pour changer de vêtements";
        uıUI[6] = "pour appeler l'ascenseur";
        uıUI[7] = "Veuillez patienter...";
        uıUI[8] = "vers l'étage 2";
        uıUI[9] = "pour prendre";
        uıUI[10] = "pour placer la capsule";
        uıUI[11] = "Vous n'avez pas de capsule vide !";
        uıUI[12] = "ID Carte nécessaire";
        uıUI[13] = "Il faut prendre la lampe de col";
        uıUI[14] = "pour dormir";
        uıUI[15] = "pour réparer";
        uıUI[16] = "kit de réparation nécessaire";
        uıUI[17] = "Tout d'abord, vous devez porter la blouse de laboratoire.";
        uıUI[18] = "pour chercher";
        uıUI[19] = "recherche en cours...";
        uıUI[20] = "pour placer la capsule d'énergie";
        uıUI[21] = "pour connecter le câble";
        uıUI[22] = "pour appuyer sur le bouton";
        uıUI[23] = "pour ouvrir";
        uıUI[24] = "vers l'étage 1";
        uıUI[25] = "pour parler à Lara";
        uıUI[26] = "pour démarrer le générateur";
        uıUI[27] = "pas d'électricité";
        uıUI[28] = "pour allumer la lumière";
        uıUI[29] = "pour s'accroupir";
        uıUI[30] = "pour sortir";
        uıUI[31] = "Moment de décision, choisissez une réponse.";
        uıUI[32] = "Laissez Lara sur l’île pour qu’elle affronte ses actes et partez.";
        uıUI[33] = "Tuez-vous et mettez fin à la boucle douloureuse de Lara.";
        uıUI[34] = "Convainquez Lara en lui parlant de sa note.";



        if (mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Missions";
            mis.missions[0] = "—Trouver la carte d'identité dans le hangar";
            mis.missions[1] = "—Aller à l'abri";
            mis.missions[2] = "—Trouver le kit de réparation dans le hangar";
            mis.missions[3] = "—Réparer le tableau électrique sur la tour radio";
            mis.missions[4] = "—Parler avec Lara";
            mis.missions[5] = "—Aller dormir dans le lit";
            mis.missions[6] = "—Prendre la lampe de col";
            mis.missions[7] = "—Rencontrer Lara sur la plage";
            mis.missions[8] = "—Ouvrir la porte dans la grotte";
            mis.missions[9] = "—Mettre ta blouse de laboratoire";
            mis.missions[10] = "—Aller au laboratoire environnemental";
            mis.missions[11] = "—Prendre 6 capsules d'énergie";
            mis.missions[12] = "—Monter au 2ᵉ étage";
            mis.missions[13] = "—Connecter le câble";
            mis.missions[14] = "—Placer 6 capsules";
            mis.missions[15] = "—Initier le protocole";
            mis.missions[16] = "—Quitter le laboratoire";
            mis.missions[17] = "—Parler avec Lara";
            mis.missions[18] = "—Retourne à l’hélicoptère.";
            mis.missions[19] = "—Trouver le mot de passe de la salle environnementale";
            mis.missions[20] = "—Trouver le mot de passe de la salle environnementale";
        }

        if (sho != null)
        {
            sho.noteText1 =
        @"Expérience 27 a montré une déviation plus précoce que prévu. Le chronomètre fonctionne correctement, mais l’observateur ne peut plus être considéré comme une référence fiable. Le temps devient instable.

Une instabilité magnétique a été détectée au deuxième niveau du laboratoire. La durée passée dans la chambre d’isolement ne doit pas dépasser quatre minutes. Une exposition prolongée entraîne des trous de mémoire irrécupérables.

Si j’ai besoin d’accéder au système à nouveau :
Nom d’utilisateur : NOVA
Mot de passe : 1441

— Prof. Arthur";
            sho.noteText2 =
        @"Protocole de sécurité – Usage interne uniquement

Ces armes ont été placées dans la salle de sécurité pour les situations d’urgence. Les munitions sont limitées. Aucun réapprovisionnement n’est disponible.

Les anomalies qui apparaissent lors des expériences temporelles ne se comportent pas comme des menaces classiques. Tirer avec une arme n’est pas toujours une solution ; dans certains cas, cela peut aggraver la situation.

Si vous avez une raison de prendre l’une de ces armes, le protocole a déjà été enfreint. Une seule décision peut affecter plusieurs lignes temporelles.

Attendez le bon moment.
Une mauvaise décision peut coûter des années.

— Chercheuse en chef
Lara";
            sho.noteText3 =
        @"Professeur Arthur,

Il y a quelque chose d’inhabituel dans la salle des générateurs. Le système fonctionne, mais il ne semble pas stable. Il y a de brèves pauses et des fluctuations inattendues. Je n’ai pas encore intervenu, car un mauvais geste pourrait provoquer un problème plus important.

Je pense qu’il serait préférable que vous y jetiez un œil.

— Technicien de la salle des générateurs
Bob";
            sho.noteText4 =
        @"Aral,

Les choses ne se sont pas passées comme prévu. J’ai essayé d’arrêter l’expérience, mais pendant un instant, j’ai perdu le contrôle. Le bruit, la lumière… puis tout est devenu silencieux. Je t’ai appelé, mais tu n’as pas répondu.

Je vais bien… je crois. Mais il n’est pas sûr que je reste ici. Quelque chose me suit. Je ne peux pas le voir clairement. Je ne sais pas ce que c’est, ni qui c’est. Tout ce que je sais, c’est que je dois m’éloigner d’ici.

C’est tout ce que je pouvais faire. Je ne voulais pas t’entraîner davantage dans cette situation. Je sais que tu vas t’inquiéter pour moi, et je sais que tu viendras me chercher.

S’il te plaît, fais attention.";
            sho.noteText5 =
        @"Pendant que tu lis ceci, il se peut que je sois déjà partie. Ce qui s’est passé dans le laboratoire est le résultat d’un moment incontrôlable. Les dernières choses dont je me souviens à ce moment-là sont les lumières, les alarmes, et le silence étrange qui a suivi immédiatement… C’est là que tout a commencé.

Certaines boucles n’ont pas de sortie, et je suis piégée dans l’une d’elles. J’entends des chuchotements. Ils disent : « À cause de toi. » Je ne peux pas dire s’ils essaient de me distraire ou s’ils essaient de me communiquer quelque chose.

Le temps ici avance parfois, recule parfois, mais il revient toujours à son point de départ. Les mêmes erreurs, les mêmes résultats. Est-il possible que le passé ou le futur ne puisse vraiment être changé ? Si tu ne te dépêches pas, toi aussi tu deviendras une partie de cette boucle.

La vie se vit en avant, mais se comprend en arrière.";
            sho.noteText6 =
        @"À mon moi futur,

Lara, si tu lis cette lettre, tu dois savoir que je n’ai pas réussi à sauver Aral.
J’ai dû tuer mon moi passé et prendre sa place, mais tout cela était vain.
Je n’ai pas pu briser cette boucle temporelle, et je n’ai pas pu libérer Aral du limbe dans lequel il est prisonnier.

Tu dois empêcher l’accident avant qu’il n’arrive.
Même si cela signifie me tuer et prendre ma place, tu dois le faire.
S’il te plaît, ne reproduis pas les mêmes erreurs que moi. Quoi qu’il arrive, sauve Aral et ne lui raconte jamais ce que tu as fait.

— Lara";
            sho.noteText7 = "Derrière toi! ";
        }


        if (inv != null)
        {
            inv.itemName[0] = "Carte d'ID";
            inv.itemDesc[0] = "Une carte qui peut ouvrir certaines portes du laboratoire Nova.";
            inv.itemName[1] = "Lampe";
            inv.itemDesc[1] = "Une lampe portée sur le revers.";
            inv.itemName[2] = "Note d'Arthur";
            if (sho != null)
                inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Capsule Vide";
            inv.itemDesc[3] = "Une capsule vide qui devient une capsule d'énergie une fois remplie.";
            inv.itemName[4] = "Capsule d'Énergie";
            inv.itemDesc[4] = "Une capsule contenant une quantité d'énergie inimaginable, suffisante pour alimenter la ville de Los Angeles pendant 12 ans.";
            inv.itemName[5] = "Pied-de-biche";
            inv.itemDesc[5] = "Un pied-de-biche que vous pouvez utiliser pour ouvrir des portes bloquées.";
            inv.itemName[6] = "Glock 17";
            inv.itemDesc[6] = "Un Glock 17 pris dans la salle de sécurité. Il ne reste qu'une seule balle. Il n'y aura pas de seconde chance.";
            inv.itemName[7] = "Protocole de Sécurité";
            if (sho != null)
                inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Note de Bob";
            if (sho != null)
                inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Note de Lara";
            if (sho != null)
                inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Note de Aral?";
            if (sho != null)
                inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Note de Lara?";
            if (sho != null)
                inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Note inconnue";
            if (sho != null)
                inv.itemDesc[12] = sho.noteText7;
        }
    }
    void LoadItalianoDialogs()      /////////İtalyanca dialoglar buraya eklenecek
    {
        dias[0] = "Lara: Prima di entrare nel laboratorio, dobbiamo aspettare che il Centro Nova invii il codice di accesso.";
        dias[1] = "Aral: Un codice di accesso?";
        dias[2] = "Lara: Sì, un codice a 4 cifre. Lo invieranno ai computer situati nell'edificio container sull'isola.";
        dias[3] = "Lara: Il Prof. Arthur ha detto che la scheda di accesso al container era nell'hangar.";
        dias[4] = "Lara: Vai avanti tu, ho alcune cose da prendere. Non preoccuparti, ti raggiungerò.";
        dias[5] = "Lara: Quanto ancora mi guarderai così?";
        dias[6] = "Aral: È proprio qui.";
        dias[7] = "Lara: Sembra che tu abbia trovato la scheda e aperto la porta.";
        dias[8] = "Aral: Sì, l'ho appena aperta—il tempismo è perfetto.";
        dias[9] = "Lara: Sono sempre puntuale.";
        dias[10] = "Lara: Aspetta un attimo, cosa intendi per nessun segnale? Il sistema non funziona? Siamo venuti fin qui per niente?";
        dias[11] = "Aral: Forse c'è un malfunzionamento alla torre radio.";
        dias[12] = "Lara: Perché lo pensi?";
        dias[13] = "Aral: Perché il sistema qui sembra pulito e operativo. Penso che il problema sia alla torre radio. Ho visto alcuni strumenti nell'hangar. Li prenderò e controllerò.";
        dias[14] = "Lara: Va bene allora, rimarrò qui e vedrò cosa posso fare.";
        dias[15] = "Aral: Wow! Che vista bellissima.";
        dias[16] = "Aral: Cos'era quel rumore?";
        dias[17] = "Aral: Probabilmente solo un animale.";
        dias[18] = "Aral: Bene, dovrei andare alla torre radio ora.";
        dias[19] = "Aral: Ok, questo dovrebbe funzionare. Ora dovrei tornare da Lara.";
        dias[20] = "Aral: Lara ha lasciato questa torcia?";
        dias[21] = "Aral: Dovrebbe essere utile per aprire porte bloccate.";
        dias[22] = "Aral: Nel caso dovessi difendermi.";
        dias[23] = "Aral: Tutto è pronto.";
        dias[24] = "Lara: Sei tornato. Dopo che hai sistemato il malfunzionamento alla torre, il segnale è arrivato e ho stabilito la connessione, ma il centro non ha ancora inviato il codice.";
        dias[25] = "Aral: Il quadro elettrico dovrebbe essere al piano di sopra.";
        dias[26] = "Aral: Quindi siamo arrivati troppo presto?";
        dias[27] = "Lara: In realtà, no. Se fossimo arrivati più tardi, sarebbe stato sera e dubito che avresti potuto riparare il malfunzionamento della torre al buio.";
        dias[28] = "Aral: Sappiamo quando invieranno il codice?";
        dias[29] = "Lara: Probabilmente lo invieranno tra due o tre ore. Ci sono dei letti qui se vuoi dormire. Siamo venuti entrambi da lontano e siamo stanchi.";
        dias[30] = "Aral: Forse posso esplorare un po' l'isola prima di dormire.";
        dias[31] = "Lara: Come preferisci.";
        dias[32] = "Aral: Quante ore ho dormito? Il centro deve aver inviato il codice.";
        dias[33] = "Aral: Dove è Lara?";
        dias[34] = "Aral: Cos'è questo? Una mia ombra? Ma non c'è nessuno davanti alla luce...";
        dias[35] = "Aral: Cosa è successo? Devo ancora essere assonnato visto che mi sono appena svegliato. Sì, non può esserci altra spiegazione.";
        dias[36] = "Aral: Lara.";
        dias[37] = "Lara: Sei proprio un dormiglione. Mi sono annoiata ad aspettarti e sono scesa in spiaggia.";
        dias[38] = "Aral: Non hai dormito affatto?";
        dias[39] = "Lara: Ho dormito come un bambino, ma mi sono svegliata prima di te. A proposito, hai preso la torcia che ho lasciato?";
        dias[40] = "Aral: Sì, l'ho presa. E quando sono uscito, c'era un'ombra davanti alla porta. È scomparsa quando mi sono avvicinato.";
        dias[41] = "Lara: Un'ombra? Forse era la tua stessa ombra e, quando la porta si è chiusa dietro di te, è scomparsa.";
        dias[42] = "Aral: No, non era la mia ombra. Era davanti alla fonte di luce.";
        dias[43] = "Lara: Sono sicura che ci sia una spiegazione logica.";
        dias[44] = "Aral: L'unica cosa a cui posso pensare è che l'ho immaginata perché ero mezzo addormentato.";
        dias[45] = "Lara: Vedi? Hai già trovato una spiegazione logica.";
        dias[46] = "Aral: Comunque, il centro ha inviato il codice. È 1327.";
        dias[47] = "Lara: Lo so. Quando mi sono svegliata, il codice era già sullo schermo.";
        dias[48] = "Aral: Allora sei pronta per entrare nel Laboratorio Nova?";
        dias[49] = "Lara: Non abbiamo fretta. Voglio restare un po' di più e guardare la spiaggia. La spiaggia è bellissima di notte, vero?";
        dias[50] = "Aral: Ah… Guarda, la spiaggia è davvero bellissima, ma io vado al laboratorio. Dovresti venire il prima possibile.";
        dias[51] = "Lara: Non preoccuparti, sono sempre puntuale.";
        dias[52] = "Aral: Dopotutto, i laboratori sono ambienti sterili.";
        dias[53] = "Aral: Devo indossare un camice. Mi chiedo dove sia lo spogliatoio.";
        dias[54] = "Aral: Hmm, questo camice non è affatto male.";
        dias[55] = "Lara: Il camice ti sta bene.";
        dias[56] = "Aral: Tu… come… quando sei arrivata qui?";
        dias[57] = "Lara: Come ho detto, sono sempre—";
        dias[58] = "Aral: Puntuale, sì, ho capito.";
        dias[59] = "Aral: Quindi, puoi spiegarmi brevemente cosa faremo adesso?";
        dias[60] = "Lara: Certo. Prima prenderemo le capsule energetiche Aether Core dalla stanza ambientale. Dovrebbero essere sei.";
        dias[61] = "Lara: Poi, usando queste capsule, dobbiamo attivare il motore warp situato nella stanza degli esperimenti al secondo piano.";
        dias[62] = "Lara: Il motore warp è normalmente usato per viaggi interstellari.";
        dias[63] = "Lara: Ma oggi stiamo cercando di combinare il motore warp con le capsule energetiche Aether Core per creare un motore Parallax.";
        dias[64] = "Lara: In teoria, questo motore sarà in grado di manipolare spazio e tempo non solo in avanti come un motore warp, ma anche all'indietro, in modo più controllato.";
        dias[65] = "Lara: In questo modo, stiamo cercando di rendere possibile il viaggio nel tempo.";
        dias[66] = "Lara: Ciò che stiamo facendo qui—e ciò che stiamo per fare—è molto importante per l'umanità.";
        dias[67] = "Aral: Wow! Sembra magia.";
        dias[68] = "Lara: Qualsiasi tecnologia sufficientemente avanzata è indistinguibile dalla magia.";
        dias[69] = "Aral: Hai ragione, Lara C. Clarke.";
        dias[70] = "Lara: Ahah! Molto divertente.";
        dias[71] = "Aral: La stanza ambientale è chiusa a chiave. Come faremo ad entrare?";
        dias[72] = "Lara: Il Prof. Arthur era responsabile di questo piano del laboratorio. Forse puoi trovare qualche codice tra i suoi effetti personali.";
        dias[73] = "Lara: Controlla gli spogliatoi maschili.";
        dias[74] = "Aral: Queste devono essere le credenziali di accesso per il computer personale del Prof. Arthur.";
        dias[75] = "Aral: Dovrei cambiarmi prima.";
        dias[76] = "Lara: Hai trovato qualcosa?";
        dias[77] = "Aral: Sì. Sembra che anche il Prof. Arthur abbia condotto esperimenti in questo laboratorio. Ho trovato appunti relativi ai suoi esperimenti. A proposito, il codice di accesso è 1453.";
        dias[78] = "Lara: Sei incredibile.";
        dias[79] = "Lara: Bene, ora dobbiamo prendere sei capsule energetiche Aether Core.";
        dias[80] = "Aral: Ci sono cinque capsule sullo scaffale qui, ma due di esse sono vuote.";
        dias[81] = "Lara: Hmm, secondo quanto scritto qui, la macchina nell'angolo può produrre capsule energetiche Aether Core. Ho attivato la macchina.";
        dias[82] = "Aral: Ho trovato la macchina, e c'è un'altra capsula piena all'interno. Quindi devo solo riempire le due vuote.";
        dias[83] = "Lara: È una buona notizia.";
        dias[84] = "Aral: Tutte e sei le capsule sono pronte.";
        dias[85] = "Lara: Guarda, c'è una lista degli esperimenti condotti qui. Questa stanza è stata costruita per la protezione ambientale, ma in seguito è stata usata per altri esperimenti.";
        dias[86] = "Aral: Sì, come la produzione di queste capsule. Dai, saliamo e iniziamo la procedura.";
        dias[87] = "Lara: Ok, chiama l'ascensore. Arrivo.";
        dias[88] = "Lara: Mi chiedo in che condizioni sia il piano superiore del laboratorio.";
        dias[89] = "Aral: Il piano superiore del laboratorio è stato costruito da un'azienda diversa chiamata Arc Industries.";
        dias[90] = "Aral: Hanno progettato il laboratorio per essere autosufficiente, quindi sono sicuro che sia in buone condizioni.";
        dias[91] = "Lara: Davvero? Pensavo che l'intero laboratorio fosse stato costruito da Nova.";
        dias[92] = "Aral: Nova ha costruito solo il primo piano. Il loro obiettivo era proteggere la natura e l'ambiente attraverso la ricerca condotta nella stanza ambientale.";
        dias[93] = "Aral: Ma poiché gli esperimenti qui condotti non servivano più solo a quello scopo, il laboratorio è stato ampliato da Arc Industries.";
        dias[94] = "Lara: Pensi che il Centro Nova ci stia nascondendo qualcosa?";
        dias[95] = "Aral: Assolutamente. Ecco perché non mi fido del personale del Centro Nova… anche se tu potresti essere un'eccezione.";
        dias[96] = "Lara: Dal momento che mi stai raccontando tutto questo, anche io mi fido di te.";
        dias[97] = "Aral: Ah… la mia testa.";
        dias[98] = "Aral: Cosa è successo?";
        dias[99] = "Aral: Devo trovarlo.";
        dias[100] = "Lara: Penso che il cavo di alimentazione non sia collegato.";
        dias[101] = "Aral: Fammi controllare i cavi.";
        dias[102] = "Aral: Ecco fatto, tutti i sistemi sono online.";
        dias[103] = "Lara: Bene, il passo successivo è inserire le capsule energetiche nel motore warp.";
        dias[104] = "Aral: Il motore warp dovrebbe essere nella stanza accanto.";
        dias[105] = "Aral: Perfetto, è fatto.";
        dias[106] = "Lara: Ho rilevato un'anomalia nella dinamica del campo.";
        dias[107] = "Aral: È qualcosa di grave?";
        dias[108] = "Lara: Probabilmente posso sistemarlo. Tu inizia la procedura. C'è un pulsante rosso sul tavolo a destra delle porte doppie. Quel pulsante avvia la procedura.";
        dias[109] = "Aral: L'ascensore… devo raggiungere l'ascensore.";
        dias[110] = "Lara: Quando il motore warp raggiungerà la piena potenza, dovrebbe lacerare lo spazio-tempo e portarci un'ora indietro.";
        dias[111] = "Aral: Cos'era quel rumore?";
        dias[112] = "Aral: Lara, è normale tutto questo?";
        dias[113] = "Lara: C'è un sovraccarico—ferma la procedura!";
        dias[114] = "Aral: Lara, non riesco a sentirti.";
        dias[115] = "Aral: Interromperò la procedura.";
        dias[116] = "Sconosciuto: Torna in vita.";
        dias[117] = "Aral: Non da questa parte. Forse c'è un'uscita al piano superiore.";
        dias[118] = "Aral: Il laboratorio è in rovina. Spero che l'ascensore funzioni ancora.";
        dias[119] = "Aral: Ehi, chi c'è?";
        dias[120] = "Aral: Lara? Sei tu?";
        dias[121] = "Aral: Che diavolo sta succedendo qui? E cos'era quella cosa?";
        dias[122] = "Aral: Quell'ombra di nuovo… sta giocando con la mia mente.";
        dias[123] = "Aral: Il generatore è qui.";
        dias[124] = "Aral: Ce l'ho fatta. Probabilmente ora l'ascensore funziona.";
        dias[125] = "Aral: Lara ha lavorato qui molto tempo fa. Questo deve essere un appunto di allora. Sono sorpreso che sia ancora qui.";
        dias[126] = "Aral: Un loop temporale? È quello che è successo nel laboratorio? La mia testa gira. Lara ha scritto questo?";
        dias[127] = "Aral: Loop temporale, loop temporale, loop temporale… Ora capisco. L'esperimento non è fallito—è stato troppo efficace.";
        dias[128] = "Aral: L'ombra che ho visto e le voci che ho sentito devono essere collegate a questo incidente.";
        dias[129] = "Aral: Dai! Dai! DAI!";
        dias[130] = "Aral: Oh mio Dio!";
        dias[131] = "Aral: Quella cosa continua a seguirmi—proprio come un'ombra.";
        dias[132] = "Aral: Chi sei? Cosa vuoi da me?";
        dias[133] = "Sviluppatore: Non mi aspettavo che arrivassi fin qui. La tua curiosità ti ha portato nel posto giusto. Sei in un'area segreta e questo appunto sblocca il terzo finale del gioco.";
        dias[134] = "Aral: Non ci posso credere! Lara ha ucciso il suo sé passato e ha preso il suo posto? Era per salvarmi? Sono vivo grazie a lei?";
        dias[135] = "Aral: Ho così tante domande per lei, ma prima di tutto, devo assicurarmi che questa follia finisca.";
        dias[136] = "Aral: La Lara sulla spiaggia? Devo parlare con lei.";
        dias[137] = "Aral: Lara, grazie a Dio stai bene. Cosa stai facendo qui?";
        dias[138] = "Lara: Aral? Sei tu? Perché sei tornato indietro?";
        dias[139] = "Aral: Sì, sono io. Cosa intendi con 'tornato indietro'? E cosa stai facendo qui?";
        dias[140] = "Lara: Abbiamo parlato, e mi hai detto che dovevo andarmene. Poi ci siamo detti addio.";
        dias[141] = "Aral: Quando è successo tutto questo? Dopo l'incidente nel laboratorio, sei scomparsa all'improvviso. Ho trovato il biglietto che hai lasciato.";
        dias[142] = "Lara: Ora capisco…";
        dias[143] = "Aral: Per l'amor di Dio! Finalmente mi dirai cosa sta succedendo?";
        dias[144] = "Lara: Aral, sei intrappolato nel purgatory. Guarda i tuoi vestiti!";
        dias[145] = "Lara: Se fossi davvero venuto qui dopo l'incidente nel laboratorio, indosseresti ancora il camice. Ma stai indossando la giacca che avevi il giorno in cui siamo arrivati sull'isola.";
        dias[146] = "Aral: Non ci posso credere… Com'è possibile?";
        dias[147] = "Lara: L'orario attuale è la notte del giorno in cui siamo arrivati sull'isola. In realtà stai dormendo, e io sono scesa sulla spiaggia.";
        dias[148] = "Lara: Ho cercato di liberarti dal purgatory in cui sei intrappolato—da questo loop temporale. Ho fatto tutto per te. Ho perfino—";
        dias[149] = "Aral: Perfino cosa? Cosa hai fatto, Lara?";
        dias[150] = "Lara: Quando hai scoperto la verità, mi hai detto che dovevo andarmene. Ecco perché non lo spiegherò ora. Lo scoprirai col tempo.";
        dias[151] = "Lara: Sappi solo che ti amo abbastanza da fare questo.";
        dias[152] = "Aral: Lara… non voglio che te ne vada. Non ti direi mai di andare—né nel futuro né nel passato. Per favore, non andare, resta con me.";
        dias[153] = "Lara: Aral, tu…";
        dias[154] = "Aral: Qualunque sia il problema, sono sicuro che possiamo superarlo. Fino ad allora—e anche dopo—resta con me.";
        dias[155] = "Lara: Mi stai costringendo a prendere una decisione difficile… di nuovo.";
        dias[156] = "Lara: A dire il vero, non ho mai voluto andarmene. Ti salverò da questo purgatory.";
        dias[157] = "Aral: Possiamo farcela insieme. Se—";
        dias[158] = "Lara: Aral, nasconditi—velocemente. Non deve vederti.";
        dias[159] = "Aral: Chi non deve vedermi?";
        dias[160] = "Lara: Non c'è tempo per spiegazioni. Corri e nasconditi dietro quell'albero.";
        dias[161] = "Aral: Aspetta un attimo… sono io che vado verso Lara?";
        dias[162] = "Aral: Cosa sta succedendo? È una frattura temporale? Ho visto il mio sé passato e sto iniziando a perdere il senso della realtà.";
        dias[163] = "Aral: È il mio sé passato? E io sto davanti alla luce—come è possibile che non mi veda?";
        dias[164] = "Aral: Aspetta… quell'ombra che continuo a vedere… potrebbe essere…?";
        dias[165] = "Aral: Sto diventando quell'ombra.";
        dias[166] = "Aral: Questo è ciò che Lara intendeva con essere intrappolati nel purgatory.";
        dias[167] = "Aral: Sembra che ogni volta che vedo il mio sé passato, la realtà si frantuma e vengo spinto un po' più indietro nel tempo.";
        dias[168] = "Aral: Sto letteralmente diventando un'ombra nel tempo.";
        dias[169] = "Sconosciuto: Cos'è questo? Un'ombra mia? Ma non c'è nessuno davanti alla luce…";
        dias[170] = "Aral: Lara?";
        dias[171] = "Aral: Lara, no!";
        dias[172] = "Aral: È meglio che trovi un'arma prima di scendere.";
        dias[173] = "Lara: Un’isola nel mezzo del Pacifico, a chilometri dalla terraferma... Ci si pensa due volte prima di venire qui.";
        dias[174] = "Aral: Era proprio questo l’obiettivo. Un laboratorio isolato. Se l’esperimento sul tempo dovesse fallire, gli effetti devono restare qui.";
        dias[175] = "Lara: Ufficialmente questo posto è una stazione meteorologica abbandonata. Ma la struttura sotto le scogliere ci permetterà di controllare il tempo.";
        dias[176] = "Aral: Spero che lasceremo quest’isola con un risultato positivo.";
        dias[177] = "Lara: Ci stiamo avvicinando all’isola. Prepariamoci all’atterraggio.";
        dias[178] = "Aral: Che cosa hai fatto…";
        dias[179] = "Aral: Poco fa… ti sei sparata?";
        dias[180] = "Lara: Io…";
        dias[181] = "Lara: No… non ero io…";
        dias[182] = "Lara: Era quella che ha fallito.";
        dias[183] = "Aral: Cosa significa?!";
        dias[184] = "Lara: ...";
        dias[185] = "Aral: Quante volte l’hai fatto?";
        dias[186] = "Lara: Non ricordo.";
        dias[187] = "Aral: Non ricordi?!";
        dias[188] = "Lara: Perché ogni volta i miei ricordi si confondono. Continuo a lasciarmi appunti per non dimenticare il mio scopo.";
        dias[189] = "Lara: Per questo stavolta sarà diverso!";
        dias[190] = "Lara: Stavolta ti porterò fuori di qui!";
        dias[191] = "Aral: Lara… non stai cercando di salvarmi.";
        dias[192] = "Aral: Mi stai tenendo qui. Ora capisco.";
        dias[193] = "Lara: Ho solo cercato di salvarti… continui a trasformarti in quell’ombra.";
        dias[194] = "Aral: L’incidente succede ogni volta, vero?";
        dias[195] = "Aral: Ogni volta arriva l’elicottero.";
        dias[196] = "Aral: Ogni volta arriviamo e dopo l’incidente mi perdo nel purgatory.";
        dias[197] = "Aral: E tu uccidi il tuo passato e prendi il suo posto.";
        dias[198] = "Aral: Questo incidente e questo ciclo… la causa sei tu.";
        dias[199] = "Lara: No… il primo incidente non è stato per colpa mia. È stato davvero un incidente.";
        dias[200] = "Aral: Lara, mettiamo fine a tutto.";
        dias[201] = "Aral: Me ne vado. Non farò parte di questo ciclo. Vieni con me.";
        dias[202] = "Aral: Lara?";
        dias[203] = "Lara: Non vengo.";
        dias[204] = "Aral: Non capisci? Possiamo finirla così.";
        dias[205] = "Lara: Finirà per te. Quando diventerai ombra, il mio ciclo ricomincerà.";
        dias[206] = "Lara: Qualcuno deve sistemare tutto e farò qualsiasi cosa.";
        dias[207] = "Aral: Non voglio lasciarti qui.";
        dias[208] = "Lara: Ma io sì. Quindi vai.";
        dias[209] = "Aral: Stammi bene.";
        dias[210] = "Lara: Aral no… non puoi… volevo solo salvarti!";
        dias[211] = "Aral: Proprio per questo. Finisce qui.";
        dias[212] = "Lara: Cosa farò senza di te…";
        dias[213] = "Aral: Vivrai.";
        dias[214] = "Aral: Ero la tua ragione. Ora sarò la tua libertà.";
        dias[215] = "Lara: Non sono riuscita a salvarti ma tu hai salvato me.";
        dias[216] = "Lara: Grazie.";
        dias[217] = "Aral: Non funziona.";
        dias[218] = "Lara: Stavolta è diverso.";
        dias[219] = "Aral: No. Hai fatto lo stesso.";
        dias[220] = "Lara: Cosa?";
        dias[221] = "Aral: Innumerevoli volte…";
        dias[222] = "Lara: Come fai a—";
        dias[223] = "Aral: Li ho trovati.";
        dias[224] = "Aral: I tuoi appunti.";
        dias[225] = "Aral: Cercando di salvarmi hai iniziato il ciclo.";
        dias[226] = "Lara: Io… non ricordo.";
        dias[227] = "Aral: Se ricordi non puoi continuare.";
        dias[228] = "Aral: Il problema non era provarci ma non fermarsi mai.";
        dias[229] = "Lara: Se ti lasciassi qui…";
        dias[230] = "Aral: Per la prima volta non mi abbandoneresti.";
        dias[231] = "Lara: Se morissi…";
        dias[232] = "Aral: Allora vivresti davvero.";
        dias[233] = "Lara: Non ci proverò più.";
        dias[234] = "Lara: Aral… quell’elicottero…";
        dias[235] = "Aral: Sì, siamo noi.";
        dias[236] = "Aral: Abbiamo spezzato il nostro ciclo…";
        dias[237] = "Aral: Buona fortuna.";
        dias[238] = "Aral: Bel orologio.";
        dias[239] = "Aral: Mi chiedo di chi sia...";
        dias[240] = "Lara: Dov'è quell'orologio...";
        dias[241] = "Aral: Credo di continuare a viaggiare nel passato... L'elicottero... Lara deve essere lì.";



        menuUI[1] = "NUOVA PARTITA";
        menuUI[2] = "CONTINUA";
        menuUI[3] = "IMPOSTAZIONI";
        menuUI[4] = "CREDITI";
        menuUI[5] = "ESCI";
        menuUI[6] = "GRAFICA";
        menuUI[7] = "AUDIO";
        menuUI[8] = "TELECAMERA";
        menuUI[9] = "LINGUA E ACCESSIBILITÀ";
        menuUI[10] = "INDIETRO";
        menuUI[11] = "RISOLUZIONE";
        menuUI[12] = "DIMENSIONE SCHERMO";
        menuUI[13] = "IMPOSTAZIONI GRAFICHE";
        menuUI[14] = "ANTI-ALIASING";
        menuUI[15] = "MUSICA DEL MENU";
        menuUI[16] = "SENSIBILITÀ MOUSE";
        menuUI[17] = "MOVIMENTO TESTA";
        menuUI[18] = "LINGUA";
        menuUI[19] = "DIMENSIONE SOTTOTITOLI";
        menuUI[20] = "SCHERMO INTERO SENZA BORDI";
        menuUI[21] = "MODALITÀ FINESTRA";
        menuUI[22] = "ALTO";
        menuUI[23] = "MEDIO";
        menuUI[24] = "BASSO";
        menuUI[25] = "CHIUDI";
        menuUI[26] = "APRI";
        menuUI[27] = "PICCOLO";
        menuUI[28] = "MEDIO";
        menuUI[29] = "GRANDE";
        menuUI[30] = "CARICA PARTITA";
        menuUI[31] = "MENÙ PRINCIPALE";
        menuUI[32] = "ARAL";
        menuUI[33] = "LARA";


        uıUI[0] = "Bloccato";
        uıUI[1] = "serve un piede di porco";
        uıUI[2] = "per usare il piede di porco";
        uıUI[3] = "per entrare";
        uıUI[4] = "per accedere";
        uıUI[5] = "per cambiarsi";
        uıUI[6] = "per chiamare l’ascensore";
        uıUI[7] = "Attendere prego...";
        uıUI[8] = "per il piano 2";
        uıUI[9] = "per prendere";
        uıUI[10] = "per posizionare la capsula";
        uıUI[11] = "Non hai capsule vuote!";
        uıUI[12] = "Serve la tessera ID";
        uıUI[13] = "Serve prendere la luce da bavero";
        uıUI[14] = "per dormire";
        uıUI[15] = "per riparare";
        uıUI[16] = "serve il kit di riparazione";
        uıUI[17] = "Prima di tutto, devi indossare il camice da laboratorio.";
        uıUI[18] = "per cercare";
        uıUI[19] = "cercando...";
        uıUI[20] = "per posizionare la capsula di energia";
        uıUI[21] = "per collegare il cavo";
        uıUI[22] = "per premere il pulsante";
        uıUI[23] = "per aprire";
        uıUI[24] = "per il piano 1";
        uıUI[25] = "per parlare con Lara";
        uıUI[26] = "per avviare il generatore";
        uıUI[27] = "nessuna elettricità";
        uıUI[28] = "per accendere la luce";
        uıUI[29] = "per accovacciarsi";
        uıUI[30] = "per uscire";
        uıUI[31] = "Momento della decisione, scegli una risposta.";
        uıUI[32] = "Lascia Lara sull’isola ad affrontare le sue azioni e vai via.";
        uıUI[33] = "Ucciditi e metti fine al doloroso ciclo di Lara.";
        uıUI[34] = "Convincila parlando a Lara del suo appunto.";



        if (mis != null)
        {
            mis.gameObject.GetComponent<Transform>().Find("Missions").Find("Missions header").gameObject.GetComponent<TextMeshProUGUI>().text = "Missioni";
            mis.missions[0] = "—Trova la tessera ID nell'hangar";
            mis.missions[1] = "—Vai al rifugio";
            mis.missions[2] = "—Trova il kit di riparazione nell'hangar";
            mis.missions[3] = "—Ripara il quadro elettrico sulla torre radio";
            mis.missions[4] = "—Parla con Lara";
            mis.missions[5] = "—Vai a dormire a letto";
            mis.missions[6] = "—Prendi la luce da bavero";
            mis.missions[7] = "—Incontra Lara sulla spiaggia";
            mis.missions[8] = "—Apri la porta nella caverna";
            mis.missions[9] = "—Indossa il camice da laboratorio";
            mis.missions[10] = "—Vai al laboratorio ambientale";
            mis.missions[11] = "—Prendi 6 capsule di energia";
            mis.missions[12] = "—Sali al secondo piano";
            mis.missions[13] = "—Collega il cavo";
            mis.missions[14] = "—Posiziona 6 capsule";
            mis.missions[15] = "—Avvia il protocollo";
            mis.missions[16] = "—Esci dal laboratorio";
            mis.missions[17] = "—Parla con Lara";
            mis.missions[18] = "—Torna all’elicottero.";
            mis.missions[19] = "—Trova la password per la stanza ambientale";
            mis.missions[20] = "—Trova la password per la stanza ambientale";
        }

        if (sho != null)
        {
            sho.noteText1 =
        @"Esperimento 27 ha mostrato una deviazione anticipata rispetto al previsto. Il cronometro funziona correttamente, ma l’osservatore non può più essere considerato un riferimento affidabile. Il tempo sta diventando instabile.

È stata rilevata un’instabilità magnetica al secondo livello del laboratorio. Il tempo trascorso nella camera di isolamento non dovrebbe superare i quattro minuti. L’esposizione prolungata provoca vuoti di memoria che non possono essere recuperati.

Se dovessi accedere nuovamente al sistema:
Username: NOVA
Password: 1441

— Prof. Arthur";
            sho.noteText2 =
        @"Protocollo di Sicurezza – Uso Interno

Queste armi sono state collocate nella sala di sicurezza per situazioni di emergenza. Le munizioni sono limitate. Non è previsto alcun rifornimento.

Le anomalie che emergono durante gli esperimenti temporali non si comportano come minacce standard. Usare un’arma non è sempre una soluzione; in alcuni casi può peggiorare la situazione.

Se hai un motivo per prendere una di queste armi, il protocollo è già stato violato. Una singola decisione può influenzare più linee temporali.

Aspetta il momento giusto.
Una decisione sbagliata può costare anni.

Responsabile della Ricerca
Lara";
            sho.noteText3 =
        @"Professore Arthur,

C’è qualcosa di insolito nella sala del generatore. Il sistema è in funzione, ma non sembra stabile. Ci sono brevi pause e fluttuazioni inaspettate. Non sono ancora intervenuto, poiché un errore potrebbe causare un problema più grave.

Credo sia meglio se dia un’occhiata personalmente.

— Tecnico della Sala Generatori
Bob";
            sho.noteText4 =
        @"Aral,

Le cose non sono andate come avevamo pianificato. Ho cercato di fermare l’esperimento, ma per un momento ho perso il controllo. Il rumore, la luce… e poi tutto è diventato silenzioso. Ti ho chiamato, ma non hai risposto.

Sto bene… credo. Ma non è sicuro per me restare qui. Qualcosa mi sta seguendo. Non riesco a vederlo chiaramente. Non so cosa sia, né chi sia. Tutto quello che so è che devo allontanarmi da qui.

È tutto ciò che potevo fare. Non volevo trascinarti più a fondo in questa situazione. So che ti preoccuperai per me, e so che verrai a cercarmi.

Per favore, fai attenzione…";
            sho.noteText5 =
        @"Mentre stai leggendo questo, potrei essere già andata via. Ciò che è successo nel laboratorio è stato il risultato di un momento incontrollabile. Le ultime cose che ricordo di quel momento sono le luci, gli allarmi e il silenzio strano che è seguito immediatamente dopo… È lì che tutto ha avuto inizio.

Alcuni loop non hanno uscita, e io sono intrappolata in uno di essi. Sento dei sussurri. Dicono: “Per colpa tua.” Non riesco a capire se stanno cercando di distrarmi o se stanno cercando di dirmi qualcosa.

Il tempo qui a volte scorre in avanti, a volte indietro, ma alla fine torna sempre al punto di partenza. Gli stessi errori, gli stessi risultati. È possibile che il passato o il futuro non possano essere veramente cambiati? Se non ti affretti, anche tu diventerai parte di questo loop.

La vita si vive in avanti, ma si comprende all’indietro.";
            sho.noteText6 =
        @"Al mio io futuro,

Lara, se stai leggendo questa lettera, devi sapere che non sono riuscita a salvare Aral.
Ho dovuto uccidere il mio io passato e prendere il suo posto, ma è stato inutile.
Non sono riuscita a rompere questo loop temporale, e non sono riuscita a liberare Aral dal purgatory in cui è intrappolato.

Devi prevenire l’incidente prima che accada.
Anche se significa uccidermi e prendere il mio posto, devi farlo.
Per favore, non commettere gli stessi errori che ho fatto io. A qualunque costo, salva Aral e non dirgli mai cosa hai fatto.

— Lara";
            sho.noteText7 = "Dietro di te!";
        }


        if (inv != null)
        {
            inv.itemName[0] = "Tessera ID";
            inv.itemDesc[0] = "Una tessera che può aprire alcune porte del Nova Lab.";
            inv.itemName[1] = "Luce";
            inv.itemDesc[1] = "Una luce da indossare sulla spilla.";
            inv.itemName[2] = "Nota di Arthur";
            if (sho != null)
                inv.itemDesc[2] = sho.noteText1;
            inv.itemName[3] = "Capsula Vuota";
            inv.itemDesc[3] = "Una capsula vuota che diventa una capsula energetica quando viene riempita.";
            inv.itemName[4] = "Capsula Energetica";
            inv.itemDesc[4] = "Una capsula che contiene una quantità di energia inimmaginabile, sufficiente a alimentare la città di Los Angeles per 12 anni.";
            inv.itemName[5] = "Piede di Porco";
            inv.itemDesc[5] = "Un piede di porco che puoi usare per aprire porte bloccate.";
            inv.itemName[6] = "Glock 17";
            inv.itemDesc[6] = "Una Glock 17 presa dalla stanza di sicurezza. Rimane solo un proiettile. Non ci sarà una seconda possibilità.";
            inv.itemName[7] = "Protocollo di Sicurezza";
            if (sho != null)
                inv.itemDesc[7] = sho.noteText2;
            inv.itemName[8] = "Nota di Bob";
            if (sho != null)
                inv.itemDesc[8] = sho.noteText3;
            inv.itemName[9] = "Nota di Lara";
            if (sho != null)
                inv.itemDesc[9] = sho.noteText4;
            inv.itemName[10] = "Nota di Aral?";
            if (sho != null)
                inv.itemDesc[10] = sho.noteText5;
            inv.itemName[11] = "Nota di Lara?";
            if (sho != null)
                inv.itemDesc[11] = sho.noteText6;
            inv.itemName[12] = "Nota Sconosciuta";
            if (sho != null)
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
        yield return StartCoroutine(PDL.PlayVoice(0));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[1];
        yield return StartCoroutine(PDL.PlayVoice(1));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[2];
        yield return StartCoroutine(PDL.PlayVoice(2));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[3];
        yield return StartCoroutine(PDL.PlayVoice(3));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[4];
        yield return StartCoroutine(PDL.PlayVoice(4));
        dialog.text = "";
        mis.StartMis(mis.missionCount);
        Laradia = true;
        yield return new WaitForSeconds(2f);
        dialog.text = dias[240];
        yield return StartCoroutine(PDL.PlayVoice(240));
        dialog.text = "";
    }

    public void EventDia(int s, float delaybefore=0f)
    {
        PlayDialog(EventDialog(s, delaybefore));
    }
    public IEnumerator EventDialog(int s, float delaybefore=0f)
    {
        if(delaybefore != 0f)
            yield return new WaitForSeconds(delaybefore);
        dialog.text = dias[s];
        yield return StartCoroutine(PDL.PlayVoice(s));
        dialog.text = "";
    }

    public void SleepDoor()
    {
        PlayDialog(SleepDoorOpen());
    }
    IEnumerator SleepDoorOpen()
    {
        dialog.text = dias[7];
        yield return StartCoroutine(PDL.PlayVoice(7));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[8];
        yield return StartCoroutine(PDL.PlayVoice(8));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[9];
        yield return StartCoroutine(PDL.PlayVoice(9));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[10];
        yield return StartCoroutine(PDL.PlayVoice(10));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[11];
        yield return StartCoroutine(PDL.PlayVoice(11));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[12];
        yield return StartCoroutine(PDL.PlayVoice(12));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[13];
        yield return StartCoroutine(PDL.PlayVoice(13));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[14];
        yield return StartCoroutine(PDL.PlayVoice(14));
        dialog.text = "";
        mis.DisMis(2);
    }
    
    public void WakeUp()
    {
        PlayDialog(WakeUpStart());
    }
    IEnumerator WakeUpStart()
    {
        dialog.text = dias[32];
        yield return StartCoroutine(PDL.PlayVoice(32));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[33];
        yield return StartCoroutine(PDL.PlayVoice(33));
        dialog.text = "";
    }
    
    
    public void BeachSpeak()
    {
        PlayDialog(BeachSpeakStart());
    }
    IEnumerator BeachSpeakStart()
    {
        dialog.text = dias[36];
        yield return StartCoroutine(PDL.PlayVoice(36));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[37];
        yield return StartCoroutine(PDL.PlayVoice(37));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[38];
        yield return StartCoroutine(PDL.PlayVoice(38));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[39];
        yield return StartCoroutine(PDL.PlayVoice(39));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[40];
        yield return StartCoroutine(PDL.PlayVoice(40));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[41];
        yield return StartCoroutine(PDL.PlayVoice(41));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[42];
        yield return StartCoroutine(PDL.PlayVoice(42));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[43];
        yield return StartCoroutine(PDL.PlayVoice(43));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[44];
        yield return StartCoroutine(PDL.PlayVoice(44));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[45];
        yield return StartCoroutine(PDL.PlayVoice(45));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[46];
        yield return StartCoroutine(PDL.PlayVoice(46));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[47];
        yield return StartCoroutine(PDL.PlayVoice(47));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[48];
        yield return StartCoroutine(PDL.PlayVoice(48));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[49];
        yield return StartCoroutine(PDL.PlayVoice(49));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[50];
        yield return StartCoroutine(PDL.PlayVoice(50));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[51];
        yield return StartCoroutine(PDL.PlayVoice(51));
        dialog.text = "";
        mis.DisMis(8);
    }

    
    public void Steam()
    {
        PlayDialog(SteamStart());
    }
    IEnumerator SteamStart()
    {
        dialog.text = dias[32];
        yield return StartCoroutine(PDL.PlayVoice(32));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[33];
        yield return StartCoroutine(PDL.PlayVoice(33));
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
        yield return StartCoroutine(PDL.PlayVoice(55));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[56];
        yield return StartCoroutine(PDL.PlayVoice(56));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[57];
        yield return StartCoroutine(PDL.PlayVoice(57));
        dialog.text = dias[58];
        yield return StartCoroutine(PDL.PlayVoice(58));
        dialog.text = "";
        ABS.ActivePlayer();
        Lara.LaraXray();
        yield return new WaitForSeconds(2.5f);
        dialog.text = dias[59];
        yield return StartCoroutine(PDL.PlayVoice(59));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[60];
        yield return StartCoroutine(PDL.PlayVoice(60));
        dialog.text = dias[61];
        yield return StartCoroutine(PDL.PlayVoice(61));
        dialog.text = dias[62];
        yield return StartCoroutine(PDL.PlayVoice(62));
        dialog.text = dias[63];
        yield return StartCoroutine(PDL.PlayVoice(63));
        dialog.text = dias[64];
        yield return StartCoroutine(PDL.PlayVoice(64));
        dialog.text = dias[65];
        yield return StartCoroutine(PDL.PlayVoice(65));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[67];
        yield return StartCoroutine(PDL.PlayVoice(67));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[68];
        yield return StartCoroutine(PDL.PlayVoice(68));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[69];
        yield return StartCoroutine(PDL.PlayVoice(69));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[70];
        yield return StartCoroutine(PDL.PlayVoice(70));
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
        yield return StartCoroutine(PDL.PlayVoice(76));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[77];
        yield return StartCoroutine(PDL.PlayVoice(77));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[78];
        yield return StartCoroutine(PDL.PlayVoice(78));
        dialog.text = "";
    }
    
    public void CapsuleDia()
    {
        PlayDialog(CapsuleDialog());
    }
    IEnumerator CapsuleDialog()
    {
        dialog.text = dias[79];
        yield return StartCoroutine(PDL.PlayVoice(79));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[80];
        yield return StartCoroutine(PDL.PlayVoice(80));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[81];
        yield return StartCoroutine(PDL.PlayVoice(81));
        dialog.text = "";
    }
    
    public void FindMacDia()
    {
        PlayDialog(FindMacDialog());
    }
    IEnumerator FindMacDialog()
    {
        dialog.text = dias[82];
        yield return StartCoroutine(PDL.PlayVoice(82));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[83];
        yield return StartCoroutine(PDL.PlayVoice(83));
        dialog.text = "";
    }
    
    public void ComCapDia()
    {
        PlayDialog(ComCapDialog());
    }
    IEnumerator ComCapDialog()
    {
        dialog.text = dias[23];
        yield return StartCoroutine(PDL.PlayVoice(23));
        dialog.text = dias[84];
        yield return StartCoroutine(PDL.PlayVoice(84));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[85];
        yield return StartCoroutine(PDL.PlayVoice(85));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[86];
        yield return StartCoroutine(PDL.PlayVoice(86));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[87];
        yield return StartCoroutine(PDL.PlayVoice(87));
        dialog.text = "";
        mis.DisMis(12);
        SES.OnElevatorButton();
    }

    
    public void ArcDia()
    {
        PlayDialog(ArcDialog());
    }
    IEnumerator ArcDialog()
    {
        dialog.text = dias[88];
        yield return StartCoroutine(PDL.PlayVoice(88));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[89];
        yield return StartCoroutine(PDL.PlayVoice(89));
        dialog.text = dias[90];
        yield return StartCoroutine(PDL.PlayVoice(90));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[91];
        yield return StartCoroutine(PDL.PlayVoice(91));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[92];
        yield return StartCoroutine(PDL.PlayVoice(92));
        dialog.text = dias[93];
        yield return StartCoroutine(PDL.PlayVoice(93));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[94];
        yield return StartCoroutine(PDL.PlayVoice(94));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[95];
        yield return StartCoroutine(PDL.PlayVoice(95));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[96];
        yield return StartCoroutine(PDL.PlayVoice(96));
        dialog.text = "";
        yield return new WaitForSeconds(4f);
        dialog.text = dias[100];
        yield return StartCoroutine(PDL.PlayVoice(100));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[101];
        yield return StartCoroutine(PDL.PlayVoice(101));
        dialog.text = "";
    }

    
    public void SeaDia()
    {
        PlayDialog(SeaDialog());
    }
    IEnumerator SeaDialog()
    {
        dialog.text = dias[71];
        yield return StartCoroutine(PDL.PlayVoice(71));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[72];
        yield return StartCoroutine(PDL.PlayVoice(72));
        dialog.text = dias[73];
        yield return StartCoroutine(PDL.PlayVoice(73));
        dialog.text = "";
    }

    
    public void WarpDia()
    {
        PlayDialog(WarpDialog());
    }
    IEnumerator WarpDialog()
    {
        dialog.text = dias[102];
        yield return StartCoroutine(PDL.PlayVoice(102));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[103];
        yield return StartCoroutine(PDL.PlayVoice(103));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[104];
        yield return StartCoroutine(PDL.PlayVoice(104));
        dialog.text = "";
    }
    
    public void Warp2Dia()
    {
        PlayDialog(Warp2Dialog());
    }
    IEnumerator Warp2Dialog()
    {
        dialog.text = dias[105];
        yield return StartCoroutine(PDL.PlayVoice(105));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[106];
        yield return StartCoroutine(PDL.PlayVoice(106));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[107];
        yield return StartCoroutine(PDL.PlayVoice(107));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[108];
        yield return StartCoroutine(PDL.PlayVoice(108));
        dialog.text = "";
        mis.DisMis(15);
    }

    public void RunSoundDia()
    {
        PlayDialog(RunSoundDialog());
    }
    IEnumerator RunSoundDialog()
    {
        dialog.text = dias[119];
        yield return StartCoroutine(PDL.PlayVoice(119));
        dialog.text = dias[120];
        yield return StartCoroutine(PDL.PlayVoice(120));
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
        yield return StartCoroutine(PDL.PlayVoice(126));
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[127];
        yield return StartCoroutine(PDL.PlayVoice(127));
        dialog.text = dias[128];
        yield return StartCoroutine(PDL.PlayVoice(128));
        dialog.text = "";
    }

    public void EasterEggDia()
    {
        PlayDialog(EasterEggDialog());
    }
    IEnumerator EasterEggDialog()
    {
        dialog.text = dias[134];
        yield return StartCoroutine(PDL.PlayVoice(134));
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[135];
        yield return StartCoroutine(PDL.PlayVoice(135));
        dialog.text = "";
    }
    
    public void BoatDia()
    {
        PlayDialog(BoatDialog());
    }
    public IEnumerator BoatDialog()
    {
        dialog.text = dias[137];
        yield return StartCoroutine(PDL.PlayVoice(137));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[138];
        yield return StartCoroutine(PDL.PlayVoice(138));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[139];
        yield return StartCoroutine(PDL.PlayVoice(139));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[140];
        yield return StartCoroutine(PDL.PlayVoice(140));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[141];
        yield return StartCoroutine(PDL.PlayVoice(141));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[142];
        yield return StartCoroutine(PDL.PlayVoice(142));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[143];
        yield return StartCoroutine(PDL.PlayVoice(143));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[144];
        yield return StartCoroutine(PDL.PlayVoice(144));
        yield return new WaitForSeconds(0.5f);

        Transform Aral = transform.parent.parent.parent;
        float duration = 0.5f;
        float t = 0f;

        Quaternion startRot = Quaternion.Euler(0f, 0f, 0f);
        Quaternion targetRot = Quaternion.Euler(80f, 0f, 0f);

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            Aral.localRotation = Quaternion.Lerp(startRot, targetRot, t);
            yield return null;
        }

        yield return new WaitForSeconds(1f);
        dialog.text = dias[146];
        StartCoroutine(PDL.PlayVoice(146));
        yield return new WaitForSeconds(1f);

        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            Aral.localRotation = Quaternion.Lerp(targetRot, startRot, t);
            yield return null;
        }
        Aral.localRotation = startRot;

        yield return new WaitForSeconds(1.5f);
        dialog.text = dias[145];
        yield return StartCoroutine(PDL.PlayVoice(145));
        dialog.text = dias[147];
        yield return StartCoroutine(PDL.PlayVoice(147));
        dialog.text = dias[148];
        yield return StartCoroutine(PDL.PlayVoice(148));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[149];
        yield return StartCoroutine(PDL.PlayVoice(149));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[150];
        yield return StartCoroutine(PDL.PlayVoice(150));
        dialog.text = dias[151];
        yield return StartCoroutine(PDL.PlayVoice(151));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[152];
        yield return StartCoroutine(PDL.PlayVoice(152));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[153];
        yield return StartCoroutine(PDL.PlayVoice(153));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[154];
        yield return StartCoroutine(PDL.PlayVoice(154));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[155];
        yield return StartCoroutine(PDL.PlayVoice(155));
        yield return new WaitForSeconds(1f);
        dialog.text = dias[156];
        yield return StartCoroutine(PDL.PlayVoice(156));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[157];
        yield return StartCoroutine(PDL.PlayVoice(157));
        dialog.text = dias[158];
        yield return StartCoroutine(PDL.PlayVoice(158));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[159];
        yield return StartCoroutine(PDL.PlayVoice(159));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[160];
        yield return StartCoroutine(PDL.PlayVoice(160));
        dialog.text = "";
    }

    IEnumerator StartSinematicDialog()
    {
        yield return new WaitForSeconds(2f);
        dialog.text = dias[173];
        yield return StartCoroutine(PDL.PlayVoice(173));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[174];
        yield return StartCoroutine(PDL.PlayVoice(174));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[175];
        yield return StartCoroutine(PDL.PlayVoice(175));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[176];
        yield return StartCoroutine(PDL.PlayVoice(176));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[177];
        yield return StartCoroutine(PDL.PlayVoice(177));
        dialog.text = "";
    }

    public IEnumerator FinalDialog()
    {
        yield return new WaitForSeconds(3f);
        dialog.text = dias[178];
        yield return StartCoroutine(PDL.PlayVoice(178));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[179];
        yield return StartCoroutine(PDL.PlayVoice(179));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[180];
        yield return StartCoroutine(PDL.PlayVoice(180));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[181];
        yield return StartCoroutine(PDL.PlayVoice(181));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[182];
        yield return StartCoroutine(PDL.PlayVoice(182));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[183];
        yield return StartCoroutine(PDL.PlayVoice(183));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[184];
        yield return new WaitForSeconds(2f);
        dialog.text = dias[185];
        yield return StartCoroutine(PDL.PlayVoice(185));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[186];
        yield return StartCoroutine(PDL.PlayVoice(186));
        dialog.text = dias[187];
        yield return StartCoroutine(PDL.PlayVoice(187));
        dialog.text = dias[188];
        yield return StartCoroutine(PDL.PlayVoice(188));
        dialog.text = dias[189];
        yield return StartCoroutine(PDL.PlayVoice(189));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[190];
        yield return StartCoroutine(PDL.PlayVoice(190));
        dialog.text = "";
        yield return new WaitForSeconds(0.7f);
        dialog.text = dias[191];
        yield return StartCoroutine(PDL.PlayVoice(191));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[192];
        yield return StartCoroutine(PDL.PlayVoice(192));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[193];
        yield return StartCoroutine(PDL.PlayVoice(193));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[194];
        yield return StartCoroutine(PDL.PlayVoice(194));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[195];
        yield return StartCoroutine(PDL.PlayVoice(195));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[196];
        yield return StartCoroutine(PDL.PlayVoice(196));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[197];
        yield return StartCoroutine(PDL.PlayVoice(197));
        dialog.text = "";
        yield return new WaitForSeconds(0.7f);
        dialog.text = dias[198];
        yield return StartCoroutine(PDL.PlayVoice(198));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[199];
        yield return StartCoroutine(PDL.PlayVoice(199));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[200];
        yield return StartCoroutine(PDL.PlayVoice(200));
        dialog.text = "";
    }

    public IEnumerator FirstEndDialog()
    {
        yield return new WaitForSeconds(1f);
        dialog.text = dias[201];
        yield return StartCoroutine(PDL.PlayVoice(201));
        dialog.text = "";
        yield return new WaitForSeconds(4f);
        dialog.text = dias[202];
        yield return StartCoroutine(PDL.PlayVoice(202));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[203];
        yield return StartCoroutine(PDL.PlayVoice(203));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[204];
        yield return StartCoroutine(PDL.PlayVoice(204));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[205];
        yield return StartCoroutine(PDL.PlayVoice(205));
        dialog.text = "";
        yield return new WaitForSeconds(0.6f);
        dialog.text = dias[206];
        yield return StartCoroutine(PDL.PlayVoice(206));
        dialog.text = "";
        yield return new WaitForSeconds(0.1f);
        dialog.text = dias[207];
        yield return StartCoroutine(PDL.PlayVoice(207));
        dialog.text = "";
        yield return new WaitForSeconds(0.1f);
        dialog.text = dias[208];
        yield return StartCoroutine(PDL.PlayVoice(208));
        dialog.text = "";
        yield return new WaitForSeconds(2f);
        dialog.text = dias[209];
        yield return StartCoroutine(PDL.PlayVoice(209));
        dialog.text = "";
    }
    public IEnumerator SecondEndDialog()
    {
        dialog.text = dias[210];
        yield return StartCoroutine(PDL.PlayVoice(210));
        dialog.text = dias[211];
        yield return StartCoroutine(PDL.PlayVoice(211));
        dialog.text = dias[212];
        yield return StartCoroutine(PDL.PlayVoice(212));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[213];
        yield return StartCoroutine(PDL.PlayVoice(213));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[214];
        yield return StartCoroutine(PDL.PlayVoice(214));
        dialog.text = "";
    }
    public IEnumerator SecondEndDialogPart2()
    {
        yield return new WaitForSeconds(4f);
        dialog.text = dias[215];
        yield return StartCoroutine(PDL.PlayVoice(215));
        dialog.text = "";
        yield return new WaitForSeconds(2f);
        dialog.text = dias[216];
        yield return StartCoroutine(PDL.PlayVoice(216));
        dialog.text = "";
    }
    
    public IEnumerator ThirdEndDialog()
    {
        yield return new WaitForSeconds(1f);
        dialog.text = dias[217];
        yield return StartCoroutine(PDL.PlayVoice(217));
        dialog.text = dias[218];
        yield return StartCoroutine(PDL.PlayVoice(218));
        dialog.text = dias[219];
        yield return StartCoroutine(PDL.PlayVoice(219));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[220];
        yield return StartCoroutine(PDL.PlayVoice(220));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[221];
        yield return StartCoroutine(PDL.PlayVoice(221));
        dialog.text = dias[222];
        yield return StartCoroutine(PDL.PlayVoice(222));
        dialog.text = dias[223];
        yield return StartCoroutine(PDL.PlayVoice(223));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[224];
        yield return StartCoroutine(PDL.PlayVoice(224));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[225];
        yield return StartCoroutine(PDL.PlayVoice(225));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[226];
        yield return StartCoroutine(PDL.PlayVoice(226));
        dialog.text = "";
        yield return new WaitForSeconds(0.2f);
        dialog.text = dias[227];
        yield return StartCoroutine(PDL.PlayVoice(227));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[228];
        yield return StartCoroutine(PDL.PlayVoice(228));
        dialog.text = "";
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[231];
        yield return StartCoroutine(PDL.PlayVoice(231));
        yield return new WaitForSeconds(1f);
        dialog.text = dias[232];
        yield return StartCoroutine(PDL.PlayVoice(232));
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[233];
        yield return StartCoroutine(PDL.PlayVoice(233));
        dialog.text = "";
    }
    public IEnumerator ThirdEndDialogPart2()
    {
        yield return new WaitForSeconds(5f);
        dialog.text = dias[234];
        yield return StartCoroutine(PDL.PlayVoice(234));
        dialog.text = dias[235];
        yield return StartCoroutine(PDL.PlayVoice(235));
        dialog.text = "";
        yield return new WaitForSeconds(3f);
        dialog.text = dias[236];
        yield return StartCoroutine(PDL.PlayVoice(236));
        dialog.text = "";
        yield return new WaitForSeconds(1f);
        dialog.text = dias[237];
        yield return StartCoroutine(PDL.PlayVoice(237));
        dialog.text = "";
    }

    public void WatchDia()
    {
        StartCoroutine(WatchDialog());
    }    

    public IEnumerator WatchDialog()
    {
        yield return new WaitForSeconds(0.5f);
        dialog.text = dias[238];
        yield return StartCoroutine(PDL.PlayVoice(238));
        yield return new WaitForSeconds(1f);
        dialog.text = dias[239];
        yield return StartCoroutine(PDL.PlayVoice(239));
        dialog.text = "";
    }
}
