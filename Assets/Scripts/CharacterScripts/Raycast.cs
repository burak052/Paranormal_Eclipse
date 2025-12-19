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
    public GameObject disableFloor1;
    public GameObject pressEUI;
    public GameObject spotlight;
    private Animator currentDoorAnimator;
    private Animator currentDoorAnimator2;
    public MonoBehaviour playerMovement;
    public ElevatorFloor Callfloor;
    public TextMeshProUGUI passwordText;
    public TextMeshProUGUI pressEUIText;
    public string password;
    public bool pressenter;
    private ActiveBlackScreen ABS;
    public SmoothCameraMove cameraMove;
    public repairtool repairt;
    public keypadmat keymat;
    private int fscreen = 4;
    private bool isbusy = false;
    private bool HaveCard = false;
    private bool inkeypad = false;
    private bool haveRepairKit = false;
    public bool haveheadlight = false;
    private bool havesleep = false;
    public Sprite ESprite;
    public Sprite redxSprite;
    

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);
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
            
            
            if (hit.collider.CompareTag("EnviroKeypad"))
            {
                pressEUIText.text = "to enter";
                
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace))
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
                        }
                        else
                        {
                            ClearKey();
                            pressenter = false;
                            keymat.deniedScreen();
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
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
                    inkeypad = true;
                    ActivateKeypad();
                    pressEUI.SetActive(false);
                    playerMovement.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
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
                    ABS.BlackScreenOn();
                }
                return;
            }

            if (hit.collider.CompareTag("ElevatorButton"))
            {
                pressEUIText.text = "to call elevator";
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Callfloor.floorcall();
                    
                    //yield return new WaitForSeconds(12f);
                    currentDoorAnimator2 = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                    currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                    if (isbusy) return;
                    StartCoroutine(OpenDoorSequence(currentDoorAnimator , currentDoorAnimator2));
                    
                }
                return;
            }
            
            if (hit.collider.CompareTag("ElevatorKeypad"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentDoorAnimator = hit.collider.transform.parent.parent.Find("RightDoor").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                    currentDoorAnimator = hit.collider.transform.parent.parent.Find("LeftDoor").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            if (hit.collider.CompareTag("keypad1"))
            {
                pressEUIText.text = "to enter";
                
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace))
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
                        }
                        else
                        {
                            ClearKey();
                            pressenter = false;
                            keymat.deniedScreen();
                        }
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
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
                    inkeypad = true;
                    ActivateKeypad();
                    pressEUI.SetActive(false);
                    playerMovement.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                return;
            }


            if (hit.collider.CompareTag("IDCard") || hit.collider.CompareTag("RepairKit") || hit.collider.CompareTag("HeadLight"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if(hit.collider.CompareTag("IDCard"))
                    pressEUIText.text = "to take IDCard";
                if(hit.collider.CompareTag("RepairKit"))
                    pressEUIText.text = "to take RepairKit";
                if (hit.collider.CompareTag("HeadLight"))
                    pressEUIText.text = "to take HeadLight";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.CompareTag("IDCard"))
                        HaveCard = true;
                    if(hit.collider.CompareTag("RepairKit"))
                        haveRepairKit = true;
                    if (hit.collider.CompareTag("HeadLight")) 
                    { 
                        haveheadlight = true;
                        spotlight.SetActive(true);
                    }
                    hit.collider.gameObject.SetActive(false);
                }
                return;
            }

            if (hit.collider.CompareTag("SleepDoor"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if ((Input.GetKeyDown(KeyCode.E) && HaveCard) && ((havesleep && haveheadlight) || (!havesleep && !haveheadlight)))
                {
                    currentDoorAnimator = hit.collider.transform.parent.Find("door_01").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        currentDoorAnimator.SetTrigger("Open");
                        repairt.ChangeTag();
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
                    pressEUIText.text = "Need to take headlight";

                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }

            if (hit.collider.CompareTag("bed"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                pressEUIText.text = "to sleep";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.parent.Find("bed_02").gameObject.tag = "Untagged";
                    hit.collider.transform.parent.Find("bed_01").gameObject.tag = "Untagged";
                    ABS = GetComponent<ActiveBlackScreen>();
                    ABS.BlackScreenOn();
                    havesleep = true;
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
                }
                if (Input.GetKeyDown(KeyCode.E) && !haveRepairKit)
                {
                    pressEUIText.text = "Need repairkit";
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                }
                return;
            }
        }


        if (pressEUI != null)
            pressEUIText.text = "to open";
            pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = ESprite;
            pressEUI.SetActive(false);

        currentDoorAnimator = null;
    }
    IEnumerator OpenDoorSequence(Animator currentDoorAnimator2 , Animator currentDoorAnimator)
    {

        isbusy = true;
        yield return new WaitForSeconds(14f);
        isbusy = false;
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
    public void returncam()
    {
        cameraMove.ReturnCamera();
    }
}
