using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointID;
    bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;
        if (!other.CompareTag("Player")) return;

        SaveManager.Instance.SaveGame(other.transform, checkpointID);

        activated = true;

        Debug.Log("Checkpoint kaydedildi: " + SaveManager.Instance.CurrentSaveData.checkpointID);
        gameObject.SetActive(false);
    }
}