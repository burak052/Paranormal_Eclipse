using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [Header("Door Animator")]
    public Animator doorAnimator;

    [Header("Trigger Area")]
    public Collider triggerCollider;

    private void Reset()
    {
        // Trigger collider otomatik olarak atanýrsa iyi olur
        triggerCollider = GetComponent<Collider>();
        if (triggerCollider != null) triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool("Open", false);
        }
    }
}