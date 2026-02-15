using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;
    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        OpenGenerator generator = FindObjectOfType<OpenGenerator>();
        if(generator != null)
        {
            if(generator.L1.activeSelf)
                SaveManager.Instance.SaveGame(other.transform, checkpointID, other.transform.Find("CameraParent/Camera").GetComponent<inventory>().inventoryData.ownedItemIDs, true);
            else    
                SaveManager.Instance.SaveGame(other.transform, checkpointID, other.transform.Find("CameraParent/Camera").GetComponent<inventory>().inventoryData.ownedItemIDs);
        }
        else
            SaveManager.Instance.SaveGame(other.transform, checkpointID, other.transform.Find("CameraParent/Camera").GetComponent<inventory>().inventoryData.ownedItemIDs);

        activated = true;
    }
}