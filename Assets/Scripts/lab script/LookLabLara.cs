using UnityEngine;

public class LookLabLara : MonoBehaviour
{
    public LaraMovement Lara;
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            Lara.LaraXray();
        }
    }
}
