using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Ayarları")]
    public float interactDistance = 3f;  
    public LayerMask layerMask;          

    [Header("UI")]
    public GameObject pressEUI;          
    public GameObject EnviroKeypad;
    private Animator currentDoorAnimator;
    public MonoBehaviour playerMovement;

    public TextMeshProUGUI passwordText;
    public string password;
    public bool pressenter;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);
        if (EnviroKeypad != null)
            EnviroKeypad.SetActive(false);
        pressenter = false;
        passwordText.text = "";
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
                                        
                    // if(passwordText.text.Length <= 3)
                    // {
                    //     if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                    //         passwordText.text = passwordText.text + "0";
                    //     if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                    //         passwordText.text = passwordText.text + "1";
                    //     if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                    //         passwordText.text = passwordText.text + "2";
                    //     if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                    //         passwordText.text = passwordText.text + "3";
                    //     if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                    //         passwordText.text = passwordText.text + "4";
                    //     if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
                    //         passwordText.text = passwordText.text + "5";
                    //     if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
                    //         passwordText.text = passwordText.text + "6";
                    //     if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
                    //         passwordText.text = passwordText.text + "7";
                    //     if(Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
                    //         passwordText.text = passwordText.text + "8";
                    //     if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
                    //         passwordText.text = passwordText.text + "9";
                    // }
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
