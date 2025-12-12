using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Ayarları")]
    public float interactDistance = 1f;  
    public LayerMask layerMask;          

    [Header("UI")]
    public GameObject disableFloor1;
    public GameObject pressEUI;          
    public GameObject EnviroKeypad;
    private Animator currentDoorAnimator;
    public MonoBehaviour playerMovement;

    public TextMeshProUGUI passwordText;
    public string password;
    public bool pressenter;
    private ActiveBlackScreen ABS;

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
                if (pressEUI != null)
                    pressEUI.SetActive(true);



                if (Input.GetKeyDown(KeyCode.E))
                {
                    ABS = GetComponent<ActiveBlackScreen>();
                    ABS.BlackScreenOn();
                }
                return;
            }

            if (hit.collider.CompareTag("ElevatorButton"))
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

                    //disableFloor1.SetActive(false);
                }
                return;
            }
        }

        if (pressEUI != null)
            pressEUI.SetActive(false);

        currentDoorAnimator = null;
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
