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
    private bool isbusy = false;
    private bool HaveCard = false;
    private bool inkeypad = false;
    private bool haveRepairKit = false;
    public bool haveheadlight = false;
    private bool havesleep = false;
    private bool cansleep = false;
    private bool firsttimeopen = true;
    private bool takelight = false;
    private bool issearching = false;
    private bool capsuleAnim = true;
    private bool callElevator = true;
    private bool inFloor2 = false;
    private bool levye = false;
    private bool uselevye = false;
    private bool ispressE = false;
    public bool accident = false;
    private int capsuleCount = 0;
    private int EnergyCapsuleCount = 0;
    public Sprite LSprite;
    public Sprite ESprite;
    public Sprite redxSprite;
    

    void Start()
    {
        if (pressEUI != null)
        {
            pressEUI.SetActive(false);
            pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);
        }
        pressenter = false;
        passwordText.text = "";
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
                        pressEUIText.text = "Locked";
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
            if (hit.collider.CompareTag("LevyeDoor") && !uselevye)
            {
                if (pressEUI != null)
                {
                    if(!levye)
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = "need crowbar";
                    }
                    else
                    {
                        pressEUIText.text = "to use crowbar";
                    }
                        pressEUI.SetActive(true);
                }

                currentDoorAnimator = hit.collider.GetComponent<Animator>();

                if (Input.GetKeyDown(KeyCode.E) && levye)
                {
                    if (currentDoorAnimator != null)
                    {
                        uselevye = true;
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            
            
            if (hit.collider.CompareTag("EnviroKeypad"))
            {
                pressEUIText.text = "to enter";
                
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

                    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G))
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
                pressEUIText.text = "to Log-in";
                
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
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G))
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
                pressEUIText.text = "to change clothes";
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
                pressEUIText.text = "to call elevator";
                
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
                        pressEUIText.text = "Please Wait...";
                    }
                    else
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
                        pressEUIText.text = "to go floor2";
                    }

                    if (Input.GetKeyDown(KeyCode.E) && !Lara.elevator)
                    {
                        hit.collider.gameObject.GetComponent<Transform>().Find("Cube").gameObject.SetActive(true);
                        StartCoroutine(CloseDoorSequence(currentDoorAnimator , currentDoorAnimator2 , hit.collider.gameObject.GetComponent<Transform>().Find("Cube").gameObject));
                        inFloor2 = true;
                        Lara.LaraGoTest();
                    }
                    return;
                }
            }

            if (hit.collider.CompareTag("keypad1"))
            {
                pressEUIText.text = "to enter";
                
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

                    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.G))
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
                    pressEUIText.text = "to take IDCard";
                if (hit.collider.CompareTag("RepairKit"))
                    pressEUIText.text = "to take RepairKit";
                if (hit.collider.CompareTag("HeadLight"))
                    pressEUIText.text = "to take lapel light";
                if (hit.collider.CompareTag("Capsule"))
                    pressEUIText.text = "to take Empty Capsule";
                if (hit.collider.CompareTag("EnergyCapsuleReady"))
                    pressEUIText.text = "to take Energy Capsule";
                if (hit.collider.CompareTag("Levye"))
                    pressEUIText.text = "to take crowbar";
                if (hit.collider.CompareTag("Gun"))
                    pressEUIText.text = "to take gun";
                if (hit.collider.CompareTag("EnergyCapsule") && capsuleAnim)
                {
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
                    pressEUIText.text = "to take Energy Capsule";
                }
                else if(hit.collider.CompareTag("EnergyCapsule") && !capsuleAnim)
                {
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    pressEUIText.text = "Please Wait...";
                }
                if (hit.collider.CompareTag("PlaceEnergyCapsule"))
                {
                    if(capsuleCount>0)
                        pressEUIText.text = "to place Capsule";
                    else
                    {
                        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                        pressEUIText.text = "You dont have any Capsule!";
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
                                hit.collider.gameObject.GetComponent<Transform>().Find("Bullet_Shell").gameObject.SetActive(false);
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
                        haveRepairKit = true;
                        hit.collider.gameObject.SetActive(false);
                    }
                    if (hit.collider.CompareTag("HeadLight")) 
                    { 
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
                        takelight = true;
                    if (hit.collider.CompareTag("Levye"))
                        levye = true;
                    if(hit.collider.CompareTag("EnergyCapsule"))
                    {
                        EnergyCapsuleCount++;
                        hit.collider.gameObject.SetActive(true);
                        hit.collider.gameObject.tag = "PlaceEnergyCapsule";
                        SEC.TryCapsule();
                        SEC.SetParent();
                        capsuleAnim = false;
                        if (EnergyCapsuleCount == 6)
                            SES.OnElevatorButton();
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
                        Lara.LaraShelter();
                        firsttimeopen = false;
                    }
                    currentDoorAnimator = hit.collider.transform.parent.Find("door_01").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        currentDoorAnimator.SetTrigger("Open");
                        repairt.ChangeTag();
                        if(havesleep && horrorSoundOutdoor != null)
                            horrorSoundOutdoor.Play();
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && !HaveCard)
                {
                    pressEUIText.text = "Need IDCard";
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    hit.collider.GetComponent<AudioSource>().Play();
                }
                if ((Input.GetKeyDown(KeyCode.E) && HaveCard) && (havesleep && !haveheadlight))
                {
                    pressEUIText.text = "Need to take lapel light";

                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }

            if (hit.collider.CompareTag("bed"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if(cansleep)
                    pressEUIText.text = "to sleep";
                else
                {
                    pressEUIText.text = "can't sleep";
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }

                if (Input.GetKeyDown(KeyCode.E) && cansleep)
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
                    pressEUIText.text = "to repair";
                else
                {
                    pressEUIText.text = "Need repairkit";
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                if (Input.GetKeyDown(KeyCode.E) && haveRepairKit)
                {
                    hit.collider.GetComponent<AudioSource>().Play();
                    hit.collider.tag = "Untagged";
                    sig.SignalOn();
                    cansleep = true;
                }
                if (Input.GetKeyDown(KeyCode.E) && !haveRepairKit)
                {
                    pressEUIText.text = "Need repairkit";
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }
            if (hit.collider.CompareTag("Security"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = "Firstly, You have to wear lab coat.";
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }

                return;
            }
            if (hit.collider.CompareTag("LabCoat"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = "To Search";
                }
                if (issearching)
                    pressEUIText.text = "Searching";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    playeranim.SetAnimator();
                    issearching = true;
                    pressEUIText.text = "Searching";
                    searchSound.Play();
                    StartCoroutine(searchindelay());
                    inventor.takeItem(2);
                }
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G))
                {
                    playeranim.isSetAnimator = false;
                    hit.collider.gameObject.tag = "Untagged";
                    paper.offpaper();
                    playerMovement.enabled = true;
                    playeranim.enabled = true;
                }
                return;
            }
            if (hit.collider.CompareTag("SecurityNote") || hit.collider.CompareTag("GeneratorNote") || hit.collider.CompareTag("LaraNote") || hit.collider.CompareTag("MaterialNote"))
            {
                if (pressEUI != null)
                {
                    pressEUI.SetActive(true);
                    pressEUIText.text = "to take note";
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
                    ispressE = true;
                }
                if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.G))&& ispressE)
                {
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
                    pressEUIText.text = "to place energy capsule";
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
                    pressEUIText.text = "to connect the cable";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<ActiveRotor>().RotorActive();
                    hit.collider.gameObject.GetComponent<Transform>().Find("Cable (1)").gameObject.SetActive(false);
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                    hit.collider.gameObject.GetComponent<Transform>().Find("Cable").gameObject.GetComponent<MeshRenderer>().enabled=true;
                    hit.collider.gameObject.GetComponent<Transform>().parent.Find("triangle screens").GetComponent<ScreenController>().ActiveScreen();

                    hit.collider.tag = "Untagged";
                }
                return;
            }
            if (hit.collider.CompareTag("RedButton"))
            {           
                if (pressEUI != null)
                { 
                    pressEUI.SetActive(true);
                    pressEUIText.text = "to press button";
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<TestStart>().StartTest();
                    hit.collider.tag = "Untagged";
                }
                return;
            }
        }

        pressEUIText.text = "to open";
        pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
        pressEUI.SetActive(false);
        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(false);

        if(takelight)
        {
            pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = LSprite;
            pressEUIText.text = "to open lapel light";
            pressEUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.L))
            {
                pressEUI.SetActive(false);
                takelight = false;
            }
        }
        currentDoorAnimator = null;
    }
    IEnumerator searchindelay()
    {
        playerMovement.enabled = false;
        playeranim.enabled = false;
        yield return new WaitForSeconds(2f);
        pressEUI.GetComponent<Transform>().parent.Find("PressGUI").gameObject.SetActive(true);
        paperSound.Play();
        paper.showpaper(1);
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
