using UnityEngine;

public class CloseCorridorLigths : MonoBehaviour
{
    public LightController LC;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
            LC.SetLights(false);
    }
}
