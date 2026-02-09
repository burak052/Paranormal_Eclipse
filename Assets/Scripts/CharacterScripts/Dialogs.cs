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
    //public string Language = "turkce";
    public string[] dias = new string[300];
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
        }

        /*dialog.text = "";
        if (scene == 1)
            PlayDialog(OutdoorDialog());
        if (scene == 2)
            EventDia(5f,dias[53],4f);
        if (scene == 3)
            EventDia(3f,dias[136],6f);*/

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
