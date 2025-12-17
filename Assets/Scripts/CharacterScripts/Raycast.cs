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
    public GameObject EnviroKeypad;
    private Animator currentDoorAnimator;
    private Animator currentDoorAnimator2;
    public MonoBehaviour playerMovement;
    public ElevatorFloor Callfloor;
    public TextMeshProUGUI passwordText;
    public TextMeshProUGUI pressEUIText;
    public string password;
    public bool pressenter;
    private ActiveBlackScreen ABS;
    private int fscreen = 4;
    private bool isbusy = false;
    private bool HaveCard = false;
    public Sprite ESprite;
    public Sprite redxSprite;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);
        if (EnviroKeypad != null)
            EnviroKeypad.SetActive(false);
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
                if(EnviroKeypad != null && EnviroKeypad.activeSelf)
                {
                    if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace))
                    {
                        if(Input.GetKeyDown(KeyCode.Return) || pressenter)
                        {
                            
                            if(passwordText.text == password)
                            {   
                                EnviroKeypad.SetActive(false);
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
                                EnviroKeypad.SetActive(false);
                                
                                playerMovement.enabled = true;

                                Cursor.visible = false;
                                Cursor.lockState = CursorLockMode.Locked;
                            }
                            else
                            {
                                ClearKey();
                                pressenter = false;
                            }
                        }

                        if(Input.GetKeyDown(KeyCode.Escape))
                        {
                            EnviroKeypad.SetActive(false);
                            
                            playerMovement.enabled = true;

                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                        }

                        if(Input.GetKeyDown(KeyCode.Backspace))
                        {
                            ClearKey();
                        }
                    }
                }
                

                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (EnviroKeypad != null)
                        EnviroKeypad.SetActive(true);
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
                pressEUIText.text = "to enterddddddddddddddddddddddddddddddddd";
                if (EnviroKeypad != null && EnviroKeypad.activeSelf)
                {
                    if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || pressenter || Input.GetKeyDown(KeyCode.Backspace))
                    {
                        if (Input.GetKeyDown(KeyCode.Return) || pressenter)
                        {

                            if (passwordText.text == password)
                            {
                                EnviroKeypad.SetActive(false);
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
                                EnviroKeypad.SetActive(false);

                                playerMovement.enabled = true;

                                Cursor.visible = false;
                                Cursor.lockState = CursorLockMode.Locked;
                            }
                            else
                            {
                                ClearKey();
                                pressenter = false;
                            }
                        }

                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            EnviroKeypad.SetActive(false);

                            playerMovement.enabled = true;

                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                        }

                        if (Input.GetKeyDown(KeyCode.Backspace))
                        {
                            ClearKey();
                        }
                    }
                }


                if (pressEUI != null)
                    pressEUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (EnviroKeypad != null)
                        EnviroKeypad.SetActive(true);
                    playerMovement.enabled = false;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                return;
            }


            if (hit.collider.CompareTag("IDCard"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                pressEUIText.text = "to take";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    HaveCard = true;
                    hit.collider.gameObject.SetActive(false);
                }
                return;
            }

            if (hit.collider.CompareTag("SleepDoor"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && HaveCard)
                {
                    currentDoorAnimator = hit.collider.transform.parent.Find("door_01").GetComponent<Animator>();
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && !HaveCard)
                {
                    pressEUIText.text = "Need IDCard";
    
                    pressEUI.transform.Find("img").gameObject.GetComponent<Image>().sprite = redxSprite;
                    hit.collider.GetComponent<AudioSource>().Play();
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
        if (passwordText.text.Length <= 3)
            passwordText.text = passwordText.text + key;
    }
    
    public void ClearKey()
    {
        passwordText.text = "";
    }    

    public void EnterKey()
    {
        pressenter = true;
    }   
}
