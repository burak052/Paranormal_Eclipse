using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Ayarları")]
    public float interactDistance = 1.5f;  
    public LayerMask layerMask;          

    [Header("UI")]
    public AudioSource pickupSound;
    public AudioSource horrorSoundOutdoor;
    public AudioSource searchSound;
    public AudioSource paperSound;
    public GameObject disableFloor1;
    public GameObject pressEUI;
    public GameObject spotlight;
    public GameObject checkpoint2;
    private Animator currentDoorAnimator;
    private Animator currentDoorAnimator2;
    public MonoBehaviour playerMovement;
    public PlayerAnimationController playeranim;
    public ElevatorFloor Callfloor;
    public TextMeshProUGUI passwordText;
    public TextMeshProUGUI pressEUIText;
    public string password;
    public bool pressenter;
    private ActiveBlackScreen ABS;
    public SmoothCameraMove cameraMove;
    public repairtool repairt;
    public keypadmat keymat;
    public signal sig;
    public LaraMovement Lara;
    public ItemInspectSystem inspectSystem;
    public inventory inventor;
    public ShowNotes paper;
    public StartEnergyCapsule SEC;
    public StartEnergySmoke SES;
    public Missions missions;
    public ESCMenu Menu;
    public Dialogs dialog;
    public bool isbusy = false;
    public bool HaveCard = false;
    public bool inkeypad = false;
    public bool haveRepairKit = false;
    public bool haveheadlight = false;
    public bool havesleep = false;
    public bool firsttimeopen = true;
    public bool takelight = false;
    public bool issearching = false;
    public bool capsuleAnim = true;
    public bool callElevator = true;
    public bool inFloor2 = false;
    public bool levye = false;
    public bool ispressE = false;
    public bool accident = false;
    public bool ctrlshow = false;
    public bool havegun = false;
    public bool isload = false;
    public int capsuleCount = 0;
    public int EnergyCapsuleCount = 0;
    public Sprite LSprite;
    public Sprite ESprite;
    public Sprite redxSprite;
    public Sprite CTRLSprite;
    

    void Start()
    {
        if (pressEUI != null)
        {
            pressEUI.SetActive(false);
            pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
        }
        pressenter = false;
        passwordText.text = "";
        if(disableFloor1 != null)
            disableFloor1.SetActive(true);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, layerMask.value == 0 ? ~0 : layerMask))
        {
            if (hit.collider.CompareTag("BoilerDoor"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                currentDoorAnimator = hit.collider.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            if (hit.collider.CompareTag("AirLockDoor"))
            {
                if (pressEUI != null)
                {
                    if(!accident)
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = dialog.uıUI[0];
                    }
                    pressEUI.SetActive(true);
                    
                }

                currentDoorAnimator = hit.collider.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E) && accident)
                {
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            if (hit.collider.CompareTag("LevyeDoor"))
            {
                currentDoorAnimator = hit.collider.GetComponent<Animator>();
                bool state = currentDoorAnimator.GetBool("Open");
                if (pressEUI != null && !state)
                {
                    if(!levye)
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = dialog.uıUI[1];
                    }
                    else
                    {
                        pressEUIText.text = dialog.uıUI[2];
                    }
                        pressEUI.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E) && levye && !state)
                {
                    if (currentDoorAnimator != null)
                    {
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            
            
            if (hit.collider.CompareTag("EnviroKeypad"))
            {
                pressEUIText.text = dialog.uıUI[3];
                
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.G))
                {
                    if (Input.GetKeyDown(KeyCode.Return) || pressenter)
                    {
                        if (passwordText.text == password)
                        {
                            dialog.CapsuleDia();
                            missions.DisMis(11);
                            ClearKey();
                            keymat.successScreen();
                            hit.collider.tag = "Untagged";
                            inkeypad = false;

                            currentDoorAnimator = hit.collider.transform.parent.Find("Up").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                            bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }
                            currentDoorAnimator = hit.collider.transform.parent.Find("Down").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }
                            currentDoorAnimator = hit.collider.transform.parent.Find("Down").Find("Middle").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }

                            pressenter = false;
                            returncam();

                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;

                            Lara.LaraInEnviro();
                            playeranim.isSetAnimator = false;
                            pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
                        }
                        else
                        {
                            ClearKey();
                            pressenter = false;
                            keymat.deniedScreen();
                        }
                    }

                    if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G)) && inkeypad)
                    {
                        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
                        playeranim.isSetAnimator = false;
                        keymat.novaScreen();
                        returncam();
                        inkeypad = false;
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        keymat.emptyScreen();
                        ClearKey();
                    }
                }


                if (pressEUI != null && !inkeypad)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                    playeranim.SetAnimator();
                    inkeypad = true;
                    ActivateKeypad();
                    pressEUI.SetActive(false);
                    playerMovement.enabled = false;
                    playeranim.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                return;
            }

            if (hit.collider.CompareTag("BoilerLaptop"))
            {
                pressEUIText.text = dialog.uıUI[4];
                
                if (pressEUI != null && !inkeypad)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                    playeranim.SetAnimator();
                    inkeypad = true;
                    ActivateLaptop();
                    pressEUI.SetActive(false);
                    playerMovement.enabled = false;
                    playeranim.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G)) && inkeypad)
                {
                    pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
                    playeranim.isSetAnimator = false;
                    inkeypad = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    returncam();
                }
                return;
            }
            
            if (hit.collider.CompareTag("CupBoard"))
            {
                pressEUIText.text = dialog.uıUI[5];
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.parent.Find("Plane (6)").gameObject.tag = "Untagged";
                    hit.collider.transform.parent.Find("Plane (3)").gameObject.tag = "Untagged";
                    hit.collider.transform.parent.Find("Plane (8)").gameObject.tag = "Untagged";
                    hit.collider.transform.parent.Find("Plane (5)").gameObject.tag = "Untagged";
                    ABS = GetComponent<ActiveBlackScreen>();
                    ABS.outfit = true;
                    ABS.BlackScreenOn();
                    Lara.LaraLocker();
                }
                return;
            }

            if (hit.collider.CompareTag("ElevatorButton"))
            {
                currentDoorAnimator2 = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
                pressEUIText.text = dialog.uıUI[6];
                
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && callElevator)
                {
                    hit.collider.gameObject.tag = "Untagged";
                    if (isbusy) return;
                    Callfloor.floorcall();
                    
                    StartCoroutine(OpenDoorSequence(currentDoorAnimator , currentDoorAnimator2));
                    Lara.LaraFrontElevator();
                }
                return;
            }
            
            if (hit.collider.CompareTag("ElevatorKeypad"))
            {
                if(!inFloor2)
                {
                    currentDoorAnimator2 = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                    currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                    if (pressEUI != null)
                        pressEUI.SetActive(true);
                    
                    if(Lara.elevator)
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = dialog.uıUI[7];
                    }
                    else
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
                        pressEUIText.text = dialog.uıUI[8];
                    }

                    if (Input.GetKeyDown(KeyCode.E) && !Lara.elevator)
                    {
                        dialog.ArcDia();
                        hit.collider.transform.Find("Cube").gameObject.SetActive(true);
                        StartCoroutine(CloseDoorSequence(currentDoorAnimator , currentDoorAnimator2 , hit.collider.transform.Find("Cube").gameObject));
                        inFloor2 = true;
                        Lara.LaraGoTest();
                    }
                    return;
                }
            }

            if (hit.collider.CompareTag("keypad1"))
            {
                pressEUIText.text = dialog.uıUI[3];
                
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.G))
                {
                    if (Input.GetKeyDown(KeyCode.Return) || pressenter)
                    {
                        if (passwordText.text == password)
                        {
                            ClearKey();
                            keymat.successScreen();
                            hit.collider.tag = "Untagged";
                            inkeypad = false;
                            currentDoorAnimator = hit.collider.transform.parent.parent.Find("G07_01").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }
                            currentDoorAnimator = hit.collider.transform.parent.parent.Find("G07_02").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }
                            currentDoorAnimator = hit.collider.transform.parent.parent.Find("G07_03").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }
                            currentDoorAnimator = hit.collider.transform.parent.parent.Find("G07_04").GetComponent<Animator>();
                            if (currentDoorAnimator != null)
                            {
                                bool state = currentDoorAnimator.GetBool("Open");
                                currentDoorAnimator.SetBool("Open", !state);
                            }

                            pressenter = false;
                            returncam();

                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                            playeranim.isSetAnimator = false;
                            pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
                        }
                        else
                        {
                            ClearKey();
                            pressenter = false;
                            keymat.deniedScreen();
                        }
                    }

                    if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G)) && inkeypad)
                    {
                        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
                        playeranim.isSetAnimator = false;
                        keymat.novaScreen();
                        returncam();
                        inkeypad = false;
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    if (Input.GetKeyDown(KeyCode.Backspace))
                    {
                        keymat.emptyScreen();
                        ClearKey();
                    }
                }


                if (pressEUI != null && !inkeypad)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                    playeranim.SetAnimator();
                    inkeypad = true;
                    ActivateKeypad();
                    pressEUI.SetActive(false);
                    playerMovement.enabled = false;
                    playeranim.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                return;
            }


            if (hit.collider.CompareTag("IDCard") || hit.collider.CompareTag("RepairKit") || hit.collider.CompareTag("HeadLight") || hit.collider.CompareTag("Capsule") || hit.collider.CompareTag("EnergyCapsule")
            || hit.collider.CompareTag("PlaceEnergyCapsule") || hit.collider.CompareTag("EnergyCapsuleReady") || hit.collider.CompareTag("Levye") || hit.collider.CompareTag("Gun"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if (inspectSystem.isInspecting)
                    pressEUI.SetActive(false);
                if (hit.collider.CompareTag("IDCard"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("RepairKit"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("HeadLight"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("Capsule"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("EnergyCapsuleReady"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("Levye"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("Gun"))
                    pressEUIText.text = dialog.uıUI[9];
                if (hit.collider.CompareTag("EnergyCapsule") && capsuleAnim)
                {
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
                    pressEUIText.text = dialog.uıUI[9];
                }
                else if(hit.collider.CompareTag("EnergyCapsule") && !capsuleAnim)
                {
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    pressEUIText.text = dialog.uıUI[7];
                }
                if (hit.collider.CompareTag("PlaceEnergyCapsule"))
                {
                    if(capsuleCount>0)
                        pressEUIText.text = dialog.uıUI[10];
                    else
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = dialog.uıUI[11];
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && !inspectSystem.isInspecting)
                {
                    if (!hit.collider.CompareTag("PlaceEnergyCapsule"))
                    {
                        if(hit.collider.CompareTag("EnergyCapsule"))
                        {
                            if(capsuleAnim)
                            {
                                SES.OffLight();
                                SES.ping = false;
                                pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                                inspectSystem.StartInspect(hit.collider.gameObject);
                                pickupSound.Play();
                            }
                        }
                        else
                        {
                            if (hit.collider.CompareTag("Gun"))
                                hit.collider.transform.Find("Bullet_Shell").gameObject.SetActive(false);
                            if (hit.collider.CompareTag("IDCard") || hit.collider.CompareTag("RepairKit"))
                                hit.collider.gameObject.GetComponent<HighlightBlink>().stopPing();
                            if (!hit.collider.CompareTag("RepairKit"))
                            {
                                pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                                inspectSystem.StartInspect(hit.collider.gameObject);
                            }
                            pickupSound.Play();
                        }
                    }
                    if(hit.collider.CompareTag("IDCard"))
                    {
                        HaveCard = true;
                        inventor.takeItem(0);
                    }
                    if(hit.collider.CompareTag("RepairKit"))
                    {
                        missions.DisMis(3);
                        haveRepairKit = true;
                        hit.collider.gameObject.SetActive(false);
                        dialog.EventDia(4f, dialog.dias[18]);
                        checkpoint2.SetActive(true);
                    }
                    if (hit.collider.CompareTag("HeadLight")) 
                    { 
                        hit.collider.transform.Find("Nullo").Find("Body").gameObject.GetComponent<HighlightBlink>().stopPing();
                        inventor.takeItem(1);
                        haveheadlight = true;
                        spotlight.SetActive(true);
                    }
                    if (hit.collider.CompareTag("Capsule")) 
                    { 
                        inventor.takeItem(3);
                        capsuleCount++;
                    }
                    if (hit.collider.CompareTag("EnergyCapsule") && capsuleAnim) 
                    { 
                        inventor.takeItem(4);
                    }
                    if (hit.collider.CompareTag("EnergyCapsuleReady")) 
                    { 
                        EnergyCapsuleCount++;
                        inventor.takeItem(4);
                    }
                    if (hit.collider.CompareTag("Levye")) 
                    { 
                        inventor.takeItem(5);
                    }
                    if (hit.collider.CompareTag("Gun")) 
                    { 
                        inventor.takeItem(6);
                    }
                    
                    if(hit.collider.CompareTag("PlaceEnergyCapsule"))
                    {
                        if(capsuleCount>0)
                        {
                            SEC.TryCapsule();
                            hit.collider.gameObject.tag = "EnergyCapsule";
                            capsuleCount--;
                            inventor.DeleteCapsule();
                            StartCoroutine(StartCapseuleAnim());
                        }
                    }
                }
                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && inspectSystem.isInspecting)
                {
                    inspectSystem.EndInspect();
                    if (hit.collider.CompareTag("HeadLight")) 
                    {
                        missions.DisMis(7);
                        dialog.EventDia(3f, dialog.dias[20]);
                        takelight = true;
                    }
                    if (hit.collider.CompareTag("Levye"))
                    {
                        dialog.EventDia(3f, dialog.dias[21]);
                        levye = true;
                    }
                    if (hit.collider.CompareTag("IDCard"))
                    {
                        dialog.EventDia(2f, dialog.dias[6]);
                        missions.DisMis(1);
                    }
                    if (hit.collider.CompareTag("Gun"))
                    {
                        dialog.EventDia(4f, dialog.dias[22]);
                        havegun = true;
                    }
                    if(hit.collider.CompareTag("EnergyCapsule"))
                    {
                        EnergyCapsuleCount++;
                        hit.collider.gameObject.SetActive(true);
                        hit.collider.gameObject.tag = "PlaceEnergyCapsule";
                        SEC.TryCapsule();
                        SEC.SetParent();
                        capsuleAnim = false;
                        if (EnergyCapsuleCount == 6)
                        {
                            dialog.ComCapDia();
                        }
                        if (hit.collider.transform.Find("check").gameObject.activeSelf)
                        {
                            hit.collider.transform.Find("check").gameObject.SetActive(false);
                            dialog.FindMacDia();
                        }
                    }
                }
                return;
            }

            if (hit.collider.CompareTag("SleepDoor"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if ((Input.GetKeyDown(KeyCode.E) && HaveCard) && ((havesleep && haveheadlight) || (!havesleep && !haveheadlight)))
                {
                    if(firsttimeopen)
                    {
                        dialog.SleepDoor();
                        Lara.LaraShelter();
                        firsttimeopen = false;
                    }
                    currentDoorAnimator = hit.collider.transform.parent.Find("door_01").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        currentDoorAnimator.SetTrigger("Open");
                        repairt.ChangeTag();
                        if(havesleep && horrorSoundOutdoor != null && !isload)
                        {
                            horrorSoundOutdoor.Play();
                            dialog.EventDia(3f, dialog.dias[34], 1.5f);
                        }
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && !HaveCard)
                {
                    pressEUIText.text = dialog.uıUI[12];
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    hit.collider.GetComponent<AudioSource>().Play();
                }
                if ((Input.GetKeyDown(KeyCode.E) && HaveCard) && (havesleep && !haveheadlight))
                {
                    pressEUIText.text = dialog.uıUI[13];

                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }

            if (hit.collider.CompareTag("bed"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                pressEUIText.text = dialog.uıUI[14];

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.parent.Find("bed_02").gameObject.tag = "Untagged";
                    hit.collider.transform.parent.Find("bed_01").gameObject.tag = "Untagged";
                    ABS = GetComponent<ActiveBlackScreen>();
                    ABS.BlackScreenOn();
                    havesleep = true;
                    sig.PasswordActive();
                    Lara.LaraBeach();
                }
                return;
            }

            if (hit.collider.CompareTag("ElectricBox"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if(haveRepairKit)
                    pressEUIText.text = dialog.uıUI[15];
                else
                {
                    pressEUIText.text = dialog.uıUI[16];
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                if (Input.GetKeyDown(KeyCode.E) && haveRepairKit)
                {
                    dialog.EventDia(3f, dialog.dias[19]);
                    missions.DisMis(4);
                    hit.collider.GetComponent<AudioSource>().Play();
                    hit.collider.tag = "Untagged";
                    sig.SignalOn();
                }
                if (Input.GetKeyDown(KeyCode.E) && !haveRepairKit)
                {
                    pressEUIText.text = dialog.uıUI[16];
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }
            if (hit.collider.CompareTag("Security"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[17];
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }

                return;
            }
            if (hit.collider.CompareTag("LabCoat"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[18];
                }
                if (issearching)
                    pressEUIText.text = dialog.uıUI[19];
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playeranim.SetAnimator();
                    Menu.canOpenMenu = false;
                    issearching = true;
                    pressEUIText.text = dialog.uıUI[19];
                    searchSound.Play();
                    StartCoroutine(searchindelay());
                    inventor.takeItem(2);
                }
                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G))&& !issearching)
                {
                    playeranim.isSetAnimator = false;
                    hit.collider.gameObject.tag = "Untagged";
                    paper.offpaper();
                    dialog.EventDia(5f,dialog.dias[74]);
                    playerMovement.enabled = true;
                    playeranim.enabled = true;
                }
                return;
            }
            if (hit.collider.CompareTag("SecurityNote") || hit.collider.CompareTag("GeneratorNote") || hit.collider.CompareTag("LaraNote") || hit.collider.CompareTag("MaterialNote")
             || hit.collider.CompareTag("BoilerNote") || hit.collider.CompareTag("EasterEggNote"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[9];
                }
                if (Input.GetKeyDown(KeyCode.E) && !ispressE)
                {
                    playeranim.SetAnimator();
                    playerMovement.enabled = false;
                    playeranim.enabled = false;
                    pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
                    paperSound.Play();
                    if (hit.collider.CompareTag("SecurityNote"))
                    {
                        paper.showpaper(2);
                        inventor.takeItem(7);
                    }
                    if(hit.collider.CompareTag("GeneratorNote"))
                    {
                        paper.showpaper(3);
                        inventor.takeItem(8);
                    }
                    if(hit.collider.CompareTag("LaraNote"))
                    {
                        paper.showpaper(4);
                        inventor.takeItem(9);
                    }
                    if(hit.collider.CompareTag("MaterialNote"))
                    {
                        StartCoroutine(PlayHorrorSound(hit.collider.gameObject));
                        paper.showpaper(5);
                        inventor.takeItem(10);
                    }
                    if(hit.collider.CompareTag("EasterEggNote"))
                    {
                        paper.showpaper(6);
                        inventor.takeItem(11);
                    }
                    if(hit.collider.CompareTag("BoilerNote"))
                    {
                        hit.collider.transform.parent.gameObject.GetComponent<AudioSource>().Play();
                        paper.showpaper(7);
                        inventor.takeItem(12);
                        dialog.EventDia(3f, dialog.dias[132],2f);
                    }
                    ispressE = true;
                }
                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G))&& ispressE)
                {
                    if(hit.collider.CompareTag("LaraNote"))
                        dialog.EventDia(3f,dialog.dias[99]);
                    if(hit.collider.CompareTag("MaterialNote"))
                        dialog.ShadowDia();
                    if(hit.collider.CompareTag("SecurityNote"))
                        dialog.EventDia(7f,dialog.dias[125],1f);
                    if(hit.collider.CompareTag("EasterEggNote"))
                        dialog.EasterEggDia();
                    hit.collider.gameObject.SetActive(false);
                    playeranim.isSetAnimator = false;
                    hit.collider.gameObject.tag = "Untagged";
                    paper.offpaper();
                    playerMovement.enabled = true;
                    playeranim.enabled = true;
                    ispressE = false;
                }
                return;
            }
            if (hit.collider.CompareTag("RotorCapsule"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[20];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.gameObject.GetComponent<RotorCapsuleAnime>() != null)
                        hit.collider.gameObject.GetComponent<RotorCapsuleAnime>().RotorAnim();
                    inventor.DeleteEnergyCapsule();
                }

                return;
            }
            if (hit.collider.CompareTag("Cable"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[21];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialog.WarpDia();
                    missions.DisMis(14);
                    hit.collider.gameObject.GetComponent<ActiveRotor>().RotorActive();
                    hit.collider.transform.Find("Cable (1)").gameObject.SetActive(false);
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    hit.collider.transform.Find("Cable").gameObject.GetComponent<MeshRenderer>().enabled=true;
                    hit.collider.transform.parent.Find("triangle screens").GetComponent<ScreenController>().ActiveScreen();

                    hit.collider.tag = "Untagged";
                }
                return;
            }
            if (hit.collider.CompareTag("RedButton"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[22];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<TestStart>().StartTest();
                    hit.collider.tag = "Untagged";
                }
                return;
            }
            if (hit.collider.CompareTag("ElevatorDoorOpen"))
            {           
                currentDoorAnimator2 = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[23];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(!havegun)
                    {
                        dialog.EventDia(4f,dialog.dias[172]);
                        return;
                    }
                    hit.collider.gameObject.tag = "Untagged";
                    currentDoorAnimator.SetBool("Open", true);
                    currentDoorAnimator2.SetBool("Open", true);
                }
                return;
            }
            if (hit.collider.CompareTag("GoFloor1"))
            {           
                currentDoorAnimator2 = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[24];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.parent.Find("Elevator sign 002").gameObject.GetComponent<ElevatorFloor>().Floor1();
                    hit.collider.gameObject.tag = "Untagged";
                    hit.collider.transform.Find("Cube").gameObject.SetActive(true);
                    StartCoroutine(CloseDoorFloor1(currentDoorAnimator , currentDoorAnimator2 , hit.collider.transform.Find("Cube").gameObject));
                }
                return;
            }
            if (hit.collider.CompareTag("SpeakLara"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[25];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    dialog.BeachSpeak();
                }
                return;
            }
            if (hit.collider.CompareTag("Generator"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = dialog.uıUI[26];
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.tag = "Untagged";
                    dialog.EventDia(2.5f,dialog.dias[124],1f);
                    hit.collider.gameObject.GetComponents<AudioSource>()[0].Play();
                    hit.collider.gameObject.GetComponents<AudioSource>()[1].Play();
                    hit.collider.gameObject.GetComponent<OpenGenerator>().PowerOn();
                }
                return;
            }
            if (hit.collider.CompareTag("NeedGenerator"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    pressEUIText.text = dialog.uıUI[27];
                }
                return;
            }
        }

        pressEUIText.text = dialog.uıUI[23];
        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
        pressEUI.SetActive(false);
        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").Find("PressG").gameObject.GetComponent<TextMeshProUGUI>().text = dialog.uıUI[30];

        if(takelight)
        {
            pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = LSprite;
            pressEUIText.text = dialog.uıUI[28];
            pressEUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.L))
            {
                pressEUI.SetActive(false);
                takelight = false;
            }
        }
        currentDoorAnimator = null;
        if(ctrlshow)
        {
            pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = CTRLSprite;
            pressEUIText.text = dialog.uıUI[29];
            pressEUI.SetActive(true);
        }
    }
    IEnumerator searchindelay()
    {
        Menu.canOpenMenu = false;
        playerMovement.enabled = false;
        playeranim.enabled = false;
        yield return new WaitForSeconds(2f);
        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
        paperSound.Play();
        paper.showpaper(1);
        Menu.canOpenMenu = true;
        issearching = false;
    }
    IEnumerator OpenDoorSequence(Animator currentDoorAnimator , Animator currentDoorAnimator2)
    {
        currentDoorAnimator.gameObject.GetComponent<AudioSource>().Play();
        isbusy = true;
        yield return new WaitForSeconds(14f);
        if (currentDoorAnimator != null)
        {
            bool state = currentDoorAnimator.GetBool("Open");
            currentDoorAnimator.SetBool("Open", !state);
        }
        if (currentDoorAnimator2 != null)
        {
            bool state = currentDoorAnimator2.GetBool("Open");
            currentDoorAnimator2.SetBool("Open", !state);
        }
        isbusy = false;
        callElevator = false;
    }
    IEnumerator CloseDoorSequence(Animator currentDoorAnimator , Animator currentDoorAnimator2, GameObject GO)
    {
        if (currentDoorAnimator != null)
        {
            bool state = currentDoorAnimator.GetBool("Open");
            currentDoorAnimator.SetBool("Open", false);
        }
        if (currentDoorAnimator2 != null)
        {
            bool state = currentDoorAnimator2.GetBool("Open");
            currentDoorAnimator2.SetBool("Open", false);
        }
        yield return new WaitForSeconds(5f);
        AudioSource[] sources = currentDoorAnimator.gameObject.GetComponents<AudioSource>();
        sources[1].Play();
        yield return new WaitForSeconds(7f);
        if (currentDoorAnimator != null)
        {
            bool state = currentDoorAnimator.GetBool("Open");
            currentDoorAnimator.SetBool("Open", true);
        }
        if (currentDoorAnimator2 != null)
        {
            bool state = currentDoorAnimator2.GetBool("Open");
            currentDoorAnimator2.SetBool("Open", true);
        }
        GO.SetActive(false);
    }
    IEnumerator CloseDoorFloor1(Animator currentDoorAnimator , Animator currentDoorAnimator2, GameObject GO)
    {
        GO.GetComponent<Transform>().parent.Find("shadow").gameObject.SetActive(true);
        GO.GetComponent<Transform>().parent.Find("shadow").gameObject.GetComponent<Animator>().SetTrigger("run");
        GO.GetComponent<Transform>().parent.Find("shadow").Find("MaleBase").gameObject.GetComponent<Animator>().SetBool("start",true);
        if (currentDoorAnimator != null)
        {
            bool state = currentDoorAnimator.GetBool("Open");
            currentDoorAnimator.SetBool("Open", false);
        }
        if (currentDoorAnimator2 != null)
        {
            bool state = currentDoorAnimator2.GetBool("Open");
            currentDoorAnimator2.SetBool("Open", false);
        }
        yield return new WaitForSeconds(3f);
        dialog.EventDia(2f,dialog.dias[129]);
        yield return new WaitForSeconds(2f);
        GO.GetComponent<Transform>().parent.Find("shadow").Find("MaleBase").gameObject.GetComponent<Animator>().SetBool("start",false);
        GO.GetComponent<Transform>().parent.Find("shadow").gameObject.SetActive(false);
        GO.GetComponent<Transform>().parent.parent.parent.Find("light").gameObject.GetComponent<AudioSource>().Play();
        AudioSource[] sources = currentDoorAnimator.gameObject.GetComponents<AudioSource>();
        sources[1].Play();
        yield return new WaitForSeconds(4f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(true);
        dialog.EventDia(2f,dialog.dias[130]);
        yield return new WaitForSeconds(0.4f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        GO.GetComponent<Transform>().parent.parent.parent.Find("elevator light").gameObject.SetActive(false);
        yield return new WaitForSeconds(0.8f);

        if (currentDoorAnimator != null)
        {
            bool state = currentDoorAnimator.GetBool("Open");
            currentDoorAnimator.SetBool("Open", true);
        }
        if (currentDoorAnimator2 != null)
        {
            bool state = currentDoorAnimator2.GetBool("Open");
            currentDoorAnimator2.SetBool("Open", true);
        }
        GO.SetActive(false);
        yield return new WaitForSeconds(4f);
        dialog.EventDia(3f,dialog.dias[131]);
    }
    IEnumerator StartCapseuleAnim()
    {
        yield return new WaitForSeconds(19f);
        capsuleAnim = true;
    }
    IEnumerator PlayHorrorSound(GameObject GO)
    {
        yield return new WaitForSeconds(3f);
        if(GO.activeInHierarchy)
            GO.GetComponent<Transform>().Find("Cube").gameObject.GetComponent<AudioSource>().Play();
    }
    public void KeyButton(string key)
    {      
        keymat.keySound();
        keymat.emptyScreen();
        if (passwordText.text.Length <= 3)
            passwordText.text = passwordText.text + key;
    }
    
    public void ClearKey()
    {
        keymat.keySound();
        keymat.emptyScreen();
        passwordText.text = "";
    }    

    public void EnterKey()
    {
        keymat.keySound();
        pressenter = true;
    }   

    public void ActivateKeypad()
    {
        cameraMove.MoveToKeypad();
    }
    public void ActivateLaptop()
    {
        cameraMove.MoveToLaptop();
    }
    public void returncam()
    {
        cameraMove.ReturnCamera();
    }
}