using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class inventory : MonoBehaviour
{
    public GameObject playerInventory;
    public Sprite IDCardSprite;
    public Sprite LightSprite;
    public Sprite PaperSprite;
    int itemCount = 0;
    bool InventoryState = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInventory.SetActive(false);
        for (int i = 1; i <= 16; i++)
        {
            Transform slotImage = playerInventory.transform.Find($"Image/slot{i}/Image");

            if (slotImage != null)
            {
                slotImage.gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            InventoryState = !InventoryState;
        if (InventoryState)
            playerInventory.SetActive(true);
        else
            playerInventory.SetActive(false);
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
}
