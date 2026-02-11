using UnityEngine;
using System.Collections;

public class LoadScript : MonoBehaviour
{
    public GameObject repairkit;
    public GameObject checkpoint1;
    public GameObject checkpoint2;
    public GameObject checkpoint4;
    public GameObject checkpoint5;
    public GameObject checkpoint6;
    public GameObject checkpoint7;
    public GameObject checkpoint8;
    public GameObject checkpoint9;
    public GameObject checkpoint10;
    public GameObject checkpoint11;
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
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.StartMis(0);
                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 2) //radyo kulesi
            {
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.missionCount = 2;
                mis.StartMis(++mis.missionCount);
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
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 3) //sahil gece
            {
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                mis.missionCount = 6;
                mis.StartMis(++mis.missionCount);
                ra.haveRepairKit = true;
                ra.HaveCard = true;
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
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 4) //lab girişi
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 5) //enviro içi
            {
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 
                checkpoint4.SetActive(false);
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                mis.missionCount = 10;
                mis.StartMis(++mis.missionCount);
                envirokeypad.tag = "Untagged";
                envirokeypad.GetComponent<Transform>().parent.Find("TrigSearchDia").gameObject.SetActive(false);
                envirokeypad.GetComponent<Transform>().parent.Find("Up").GetComponent<Animator>().SetBool("Open", true);
                envirokeypad.GetComponent<Transform>().parent.Find("Down").GetComponent<Animator>().SetBool("Open", true);
                envirokeypad.GetComponent<Transform>().parent.Find("Down/Middle").GetComponent<Animator>().SetBool("Open", true);
                GameObject.FindGameObjectWithTag("Security").GetComponent<BoxCollider>().enabled = false;
                locker.GetComponent<Transform>().Find("Plane (3)").gameObject.tag = "Untagged";
                locker.GetComponent<Transform>().Find("Plane (5)").gameObject.tag = "Untagged";
                locker.GetComponent<Transform>().Find("Plane (6)").gameObject.tag = "Untagged";
                locker.GetComponent<Transform>().Find("Plane (8)").gameObject.tag = "Untagged";
                locker.GetComponent<Transform>().parent.Find("hooker/clothes/Clothes").gameObject.tag = "Untagged";
                GameObject.FindGameObjectWithTag("Lara").GetComponent<Transform>().position = new Vector3(1341.33f,4.736f,1543.33f);
                GameObject.FindGameObjectWithTag("Lara").GetComponent<Transform>().rotation = Quaternion.Euler(0f, -136.041f, 0f);
                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 6) //2.kat
            {
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 
                GameObject.FindGameObjectWithTag("Lara").GetComponent<LaraMovement>().elevator = false;
                floor1.SetActive(false);
                floor2.SetActive(true);
                transform.Find("CameraParent").GetComponent<AudioSource>().Play();
                transform.position = new Vector3(1344.84f,4.73f,1533.06f);
                transform.rotation = Quaternion.Euler(0f, 45f, 0f);
                dia.scene = 0;
                dia.EventDia(0.1f,"");
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                mis.missionCount = 11;
                mis.StartMis(++mis.missionCount);

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 7) //kaza sonrası
            {
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
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
                mis.missionCount = 15;
                mis.StartMis(++mis.missionCount);
                GetComponent<LabMovement>().ExplosionAfter();
                GameObject.FindGameObjectWithTag("Lara").SetActive(false);

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 8) //levye odası
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
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
                floor2.GetComponent<Transform>().Find("effects/crash test").gameObject.GetComponent<ExplosionTest>().triangle.DisableScreen();
                floor2.GetComponent<Transform>().Find("effects/crash test").gameObject.GetComponent<ExplosionTest>().door.SetBool("Open",false);
                elevator.SetActive(false);
                elevatorcrash.SetActive(true);
                ra.levye = true;

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 9) //siah odası
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 10) // 1. kat kaza
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            else if(SaveManager.Instance.CurrentSaveData.checkpointID == 11) // final
            {
                inv.gameObject.SetActive(false);
                inv.gameObject.SetActive(true);
                transform.Find("aral_lab").gameObject.SetActive(true);
                transform.Find("aral.v1").gameObject.SetActive(false);
                GetComponent<PlayerAnimationController>().ChangeOutfit(); 

                SaveManager.Instance.IsLoadingFromSave = false;
            }
            ABS.DisBlack();
        }
    }
}
