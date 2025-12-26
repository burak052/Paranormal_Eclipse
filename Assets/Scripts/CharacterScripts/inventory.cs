using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class inventory : MonoBehaviour
{
    public GameObject playerInventory;
    public MonoBehaviour playerMovement;
    public PlayerAnimationController playeranim;
    public Sprite IDCardSprite;
    public Sprite LightSprite;
    public Sprite PaperSprite;
    int itemCount = 0;
    bool InventoryState = false;
    string[] itemName = new string[16];
    string[] itemDesc = new string[16];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i<16; i++)
        {
            itemName[i] = "";
            itemDesc[i] = "";
            if(i == 0)
            {
                itemName[i] = "IDCard";
                itemDesc[i] = "A card that can open some of the doors at Nova Lab";
            }
            if (i == 1)
            {
                itemName[i] = "Light";
                itemDesc[i] = "A light worn on the lapel";
            }
        }

        for (int i = 1; i <= 16; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");

            if (slotImage != null)
            {
                slotImage.gameObject.SetActive(false);
            }
        }
        playerInventory.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryState = !InventoryState;
            playermove();
        }
    }

    public void takeItem(string st)
    {
        itemCount++;
            Transform slotImage = playerInventory.transform.Find($"Image/slot{itemCount}/Image");

        if (slotImage != null)
        {
            if (st == "IDCard")
                slotImage.gameObject.GetComponent<Image>().sprite = IDCardSprite;
            else if (st == "Light")
                slotImage.gameObject.GetComponent<Image>().sprite = LightSprite;
            else
                slotImage.gameObject.GetComponent<Image>().sprite = PaperSprite;
            slotImage.gameObject.SetActive(true);
        }
    }

    public void playermove()
    {
        if (InventoryState)
        {
            playerInventory.SetActive(true);
            playerMovement.enabled = false;
            playeranim.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            playerInventory.SetActive(false);
            playerMovement.enabled = true;
            playeranim.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerInventory.transform.Find($"Image/description/name").gameObject.GetComponent<TextMeshProUGUI>().text = "";
            playerInventory.transform.Find($"Image/description/desc").gameObject.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    public void showDescription(int slot)
    {
        if (slot < itemCount)
        {
            playerInventory.transform.Find($"Image/description/name").gameObject.GetComponent<TextMeshProUGUI>().text = itemName[slot];
            playerInventory.transform.Find($"Image/description/desc").gameObject.GetComponent<TextMeshProUGUI>().text = itemDesc[slot];
        }
    }
}
