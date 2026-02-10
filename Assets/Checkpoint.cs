using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string checkpointID;
    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        SaveManager.Instance.SaveGame(other.transform);

        if (SaveManager.Instance.CurrentSaveData != null)
            SaveManager.Instance.CurrentSaveData.checkpointID = checkpointID;

        activated = true;

        Debug.Log("Checkpoint kaydedildi: " + checkpointID);
    }
}