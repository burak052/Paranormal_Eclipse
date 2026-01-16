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
    public PlayerInventoryData inventoryData;
    public ShowNotes notes;
    public Sprite IDCardSprite;
    public Sprite LightSprite;
    public Sprite CapsuleSprite;
    public Sprite EnergyCapsuleSprite;
    public Sprite CrowbarSprite;
    public Sprite GunSprite;
    public Sprite PaperSprite;
    bool InventoryState = false;
    string[] itemName = new string[16];
    public string[] itemDesc = new string[16];
    
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
            if (i == 2)
            {
                itemName[i] = "Artur's note";
                itemDesc[i] = notes.noteTextEN1;
            }
            if (i == 3)
            {
                itemName[i] = "Empty Capsule";
                itemDesc[i] = "An empty capsule.";
            }
            if (i == 4)
            {
                itemName[i] = "Energy Capsule";
                itemDesc[i] = "A capsule that holds an unimaginable amount of energy, enough to power the city of Los Angeles for 12 years.";
            }
            if (i == 5)
            {
                itemName[i] = "Crowbar";
                itemDesc[i] = "a crowbar you can use to open jammed doors.";
            }
            if (i == 6)
            {
                itemName[i] = "glock 17";
                itemDesc[i] = "A Glock 17 taken from the security room. Only one bullet remains. There will be no second chance.";
            }
            if (i == 7)
            {
                itemName[i] = "Security Protokol";
                itemDesc[i] = notes.noteTextEN2;
            }
            if (i == 8)
            {
                itemName[i] = "Bob's Note";
                itemDesc[i] = notes.noteTextEN3;
            }
            if (i == 9)
            {
                itemName[i] = "Lara's Note";
                itemDesc[i] = notes.noteTextEN4;
            }
            if (i == 10)
            {
                itemName[i] = "Aral's Note";
                itemDesc[i] = notes.noteTextEN5;
            }


        }

        for (int i = inventoryData.ownedItemIDs.Count+1; i <= 16; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");

            if (slotImage != null)
            {
                slotImage.gameObject.SetActive(false);
            }
        }

        for (int i = 1; i <= inventoryData.ownedItemIDs.Count; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");
            slotImage.gameObject.GetComponent<Image>().sprite = PaperSprite;

            if (inventoryData.ownedItemIDs[i-1] == 0)
                slotImage.gameObject.GetComponent<Image>().sprite = IDCardSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 1)
                slotImage.gameObject.GetComponent<Image>().sprite = LightSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 3)
                slotImage.gameObject.GetComponent<Image>().sprite = CapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 4)
                slotImage.gameObject.GetComponent<Image>().sprite = EnergyCapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 5)
                slotImage.gameObject.GetComponent<Image>().sprite = CrowbarSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 6)
                slotImage.gameObject.GetComponent<Image>().sprite = GunSprite;
        }

        playerInventory.SetActive(false);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !playeranim.isSetAnimator) /////////////////////////////////////buraya değişkenler ekle
        {
            InventoryState = !InventoryState;
            playermove();
        }
    }

    public void takeItem(int id)
    {
        inventoryData.ownedItemIDs.Add(id);
        Transform slotImage = playerInventory.transform.Find($"Image/slot{inventoryData.ownedItemIDs.Count}/Image");

        slotImage.gameObject.GetComponent<Image>().sprite = PaperSprite;
        if (id == 0)
            slotImage.gameObject.GetComponent<Image>().sprite = IDCardSprite;
        else if (id == 1)
            slotImage.gameObject.GetComponent<Image>().sprite = LightSprite;
        else if (id == 3)
            slotImage.gameObject.GetComponent<Image>().sprite = CapsuleSprite;
        else if (id == 4)
            slotImage.gameObject.GetComponent<Image>().sprite = EnergyCapsuleSprite;
        else if (id == 5)
            slotImage.gameObject.GetComponent<Image>().sprite = CrowbarSprite;
        else if (id == 6)
            slotImage.gameObject.GetComponent<Image>().sprite = GunSprite;

        slotImage.gameObject.SetActive(true);
    }

    public void DeleteCapsule()
    {
        inventoryData.ownedItemIDs.Remove(3);

        for (int i = inventoryData.ownedItemIDs.Count+1; i <= 16; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");

            if (slotImage != null)
            {
                slotImage.gameObject.SetActive(false);
            }
        }

        for (int i = 1; i <= inventoryData.ownedItemIDs.Count; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");
            slotImage.gameObject.GetComponent<Image>().sprite = PaperSprite;

            if (inventoryData.ownedItemIDs[i-1] == 0)
                slotImage.gameObject.GetComponent<Image>().sprite = IDCardSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 1)
                slotImage.gameObject.GetComponent<Image>().sprite = LightSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 3)
                slotImage.gameObject.GetComponent<Image>().sprite = CapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 4)
                slotImage.gameObject.GetComponent<Image>().sprite = EnergyCapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 5)
                slotImage.gameObject.GetComponent<Image>().sprite = CrowbarSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 6)
                slotImage.gameObject.GetComponent<Image>().sprite = GunSprite;
        }
    }

    
    public void DeleteEnergyCapsule()
    {
        inventoryData.ownedItemIDs.Remove(4);

        for (int i = inventoryData.ownedItemIDs.Count+1; i <= 16; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");

            if (slotImage != null)
            {
                slotImage.gameObject.SetActive(false);
            }
        }

        for (int i = 1; i <= inventoryData.ownedItemIDs.Count; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");
            slotImage.gameObject.GetComponent<Image>().sprite = PaperSprite;

            if (inventoryData.ownedItemIDs[i-1] == 0)
                slotImage.gameObject.GetComponent<Image>().sprite = IDCardSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 1)
                slotImage.gameObject.GetComponent<Image>().sprite = LightSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 3)
                slotImage.gameObject.GetComponent<Image>().sprite = CapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 4)
                slotImage.gameObject.GetComponent<Image>().sprite = EnergyCapsuleSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 5)
                slotImage.gameObject.GetComponent<Image>().sprite = CrowbarSprite;
            else if (inventoryData.ownedItemIDs[i-1] == 6)
                slotImage.gameObject.GetComponent<Image>().sprite = GunSprite;
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
            playeranim.SetAnimator();
            playeranim.isSetAnimator = false;
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
        if(slot < inventoryData.ownedItemIDs.Count)
        {
            for(int i = 0; i < 16; i++)
            {
                if (inventoryData.ownedItemIDs[slot] == i)
                {
                    playerInventory.transform.Find($"Image/description/name").gameObject.GetComponent<TextMeshProUGUI>().text = itemName[i];
                    playerInventory.transform.Find($"Image/description/desc").gameObject.GetComponent<TextMeshProUGUI>().text = itemDesc[i];
                }
            }
        }
    }
}
