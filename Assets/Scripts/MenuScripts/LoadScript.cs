using UnityEngine;
using System.Collections;

public class LoadScript : MonoBehaviour
{
    public GameObject repairkit;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint4;
    public GameObject envirokeypad;
    public GameObject locker;
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor1crash;
    public GameObject elevator;
    public GameObject elevatorcrash;
    void Start()
    {
        Dialogs dia = transform.Find("CameraParent/Camera/Canvas/Dialogs").gameObject.GetComponent<Dialogs>();
        Missions mis = transform.Find("CameraParent/Camera/Canvas/Menu").gameObject.GetComponent<Missions>();
        Raycast ra = transform.Find("CameraParent/Camera").gameObject.GetComponent<Raycast>();
        inventory inv = transform.Find("CameraParent/Camera").gameObject.GetComponent<inventory>();
        ActiveBlackScreen ABS = transform.Find("CameraParent/Camera").gameObject.GetComponent<ActiveBlackScreen>();

        if(SaveManager.Instance.IsLoadingFromSave)
        {
            inv.inventoryData.ownedItemIDs = SaveManager.Instance.CurrentSaveData.ownedItemIDs;
            if(inv.inventoryData.ownedItemIDs.Contains(2) && locker != null)
                locker.GetComponent<Transform>().parent.Find("hooker/clothes/Clothes").gameObject.tag = "Untagged";
            if (inv.inventoryData.ownedItemIDs.Contains(5) && GameObject.FindGameObjectWithTag("Levye") != null)
                GameObject.FindGameObjectWithTag("Levye").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(7) && GameObject.FindGameObjectWithTag("SecurityNote") != null)
                GameObject.FindGameObjectWithTag("SecurityNote").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(8) && GameObject.FindGameObjectWithTag("GeneratorNote") != null)
                GameObject.FindGameObjectWithTag("GeneratorNote").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(9) && GameObject.FindGameObjectWithTag("LaraNote") != null)
                GameObject.FindGameObjectWithTag("LaraNote").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(10) && GameObject.FindGameObjectWithTag("MaterialNote") != null)
                GameObject.FindGameObjectWithTag("MaterialNote").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(11) && GameObject.FindGameObjectWithTag("EasterEggNote") != null)
                GameObject.FindGameObjectWithTag("EasterEggNote").SetActive(false);
            if (inv.inventoryData.ownedItemIDs.Contains(12) && GameObject.FindGameObjectWithTag("BoilerNote") != null)
                GameObject.FindGameObjectWithTag("BoilerNote").SetActive(false);

            OpenGenerator generator = FindObjectOfType<OpenGenerator>();
            if(generator != null && SaveManager.Instance.CurrentSaveData.generator)
            {
                generator.PowerOn();
            }

            transform.position = new Vector3(
                SaveManager.Instance.CurrentSaveData.posX,
                SaveManager.Instance.CurrentSaveData.posY,
                SaveManager.Instance.CurrentSaveData.posZ
            );
            if(SaveManager.Instance.CurrentSaveData.checkpointID == 1)  //id cart
            {
                dia.LoadDias();
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.missionCount = 0;
                mis.StartMis(0);
                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 2) //radyo kulesi
            {
                dia.LoadDias();
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.missionCount = 3;
                StartCoroutine(StartMissions(mis.missions[3],mis));
                ra.haveRepairKit = true;
                ra.HaveCard = true;
                ra.firsttimeopen = false;
                GameObject.FindGameObjectWithTag("IDCard").SetActive(false);
                repairkit.SetActive(false);
                checkpoint1.SetActive(false);
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Lara").GetComponent<LaraMovement>().LaraIdle();
                GameObject.FindGameObjectWithTag("Lara").GetComponent<Transform>().position = new Vector3(1405.61f,5.15f,1666.51f);
                GameObject.FindGameObjectWithTag("Lara").GetComponent<Transform>().rotation = Quaternion.Euler(0f, 182f, 0f);
                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 3) //sahil gece
            {
                dia.LoadDias();
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.missionCount = 7;
                StartCoroutine(StartMissions(mis.missions[7],mis));
                ra.haveRepairKit = true;
                ra.HaveCard = true;
                ra.haveheadlight = true;
                ra.havesleep = true;
                ra.isload = true;
                ra.firsttimeopen = false;
                ra.sig.SignalOn();
                ra.sig.transform.parent.Find("DialogTriggerCube").gameObject.SetActive(false);
                ra.sig.PasswordActive();
                ra.spotlight.SetActive(true);
                GameObject.FindGameObjectWithTag("IDCard").SetActive(false);
                repairkit.SetActive(false);
                checkpoint1.SetActive(false);
                checkpoint2.SetActive(false);
                GameObject.FindGameObjectWithTag("ElectricBox").tag = "Untagged";
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Lara").GetComponent<LaraMovement>().LaraSitting();
                GameObject.FindGameObjectWithTag("Lara").GetComponent<LaraMovement>().LaraBeach();
                ABS.day.SetActive(false);
                ABS.sunLight.SetActive(false);
                ABS.night.SetActive(true);
                ABS.moonLight.SetActive(true);
                ABS.forestSound.PlayOneShot(ABS.nightSound);
                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 4) //lab girişi
            {
                mis.missionCount = 9;
                StartCoroutine(StartMissions(mis.missions[9],mis));
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 5) //kaza sonrası
            {
                dia.LoadDias();
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 
                floor1.SetActive(false);
                floor1crash.SetActive(false);
                floor2.SetActive(true);
                floor2.GetComponent<Transform>().Find("before crash").gameObject.SetActive(false);
                floor2.GetComponent<Transform>().Find("after crash").gameObject.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test/vfx_Flames_01").gameObject.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test/flame_box").gameObject.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test/Flamethrower").gameObject.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test/Flamethrower (1)").gameObject.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test").gameObject.GetComponent<ExplosionTest>().laranote.SetActive(true);
                floor2.GetComponent<Transform>().Find("effects/crash test").gameObject.GetComponent<ExplosionTest>().triangle.DisableScreen();
                floor2.GetComponent<Transform>().Find("effects/crash test").gameObject.GetComponent<ExplosionTest>().door.SetBool("Open",false);
                elevator.SetActive(false);
                elevatorcrash.SetActive(true);
                ra.accident = true;
                dia.scene = 0;
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                mis.missionCount = 16;
                StartCoroutine(StartMissions(mis.missions[16],mis));
                GetComponent<LabMovement>().ExplosionAfter();
                GameObject.FindGameObjectWithTag("Lara").SetActive(false);

                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 6) // 1. kat kaza
            {
                dia.LoadDias();
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 
                floor1.SetActive(false);
                floor1crash.SetActive(true);
                floor2.SetActive(false);
                mis.missionCount = 16;
                StartCoroutine(StartMissions(mis.missions[16],mis));

                GameObject.FindGameObjectWithTag("Lara").SetActive(false);
                SaveManager.Instance.IsLoadingFromSave = false;
                ABS.DisBlack();
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 7) // final
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                dia.EventDia(3f, dia.dias[136], 6f);

                SaveManager.Instance.IsLoadingFromSave = false;
            }
        }
    }    
    IEnumerator StartMissions(string s, Missions mis)
    {
        yield return new WaitForSeconds(3f);
        mis.missionText.text = s;
        mis.gameObject.GetComponents<AudioSource>()[1].Play();
        mis.gameObject.transform.Find("Missions").gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        mis.gameObject.transform.Find("Missions").gameObject.SetActive(false);
    }
}
