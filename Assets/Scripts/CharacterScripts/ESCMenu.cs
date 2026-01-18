using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;

public class ESCMenu : MonoBehaviour
{  
    public PlayerAnimationController playeranim;
    public MonoBehaviour playerMovement;
    public bool canOpenMenu = true;
    bool isOpenMenu = false;
    private Transform menu;

    void Start()
    {
        menu = transform.Find("Canvas").Find("Menu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canOpenMenu)
        {
            isOpenMenu = !isOpenMenu;
            if(isOpenMenu)
                OpenMenu();
            else
                CloseMenu();
        }
    }

    public void LoadGame()
    {

    }

    public void OpenMenu()
    {
        menu.Find("BlackScreen").gameObject.SetActive(true);
        menu.Find("Missions").gameObject.SetActive(true);
        menu.Find("Menu").gameObject.SetActive(true);
        menu.Find("Settings").gameObject.SetActive(false);
        playeranim.SetAnimator();
        playerMovement.enabled = false;
        playeranim.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseMenu()
    {
        menu.Find("BlackScreen").gameObject.SetActive(false);
        menu.Find("Missions").gameObject.SetActive(false);
        menu.Find("Menu").gameObject.SetActive(false);
        menu.Find("Settings").gameObject.SetActive(false);
        playerMovement.enabled = true;
        playeranim.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GotoSettings()
    {
        menu.Find("Settings").gameObject.SetActive(true);
        menu.Find("Missions").gameObject.SetActive(false);
        menu.Find("Menu").gameObject.SetActive(false);
    }

    public void BacktoMenu()
    {
        menu.Find("Settings").gameObject.SetActive(false);
        menu.Find("Missions").gameObject.SetActive(true);
        menu.Find("Menu").gameObject.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
