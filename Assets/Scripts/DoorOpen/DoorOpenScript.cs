using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    [Header("Door Animator")]
    public Animator doorAnimator;

    public Animator doorAnimator2;

    [Header("Trigger Area")]
    public Collider triggerCollider;

    private void Reset()
    {
        // Trigger collider otomatik olarak atanırsa iyi olur
        triggerCollider = GetComponent<Collider>();
        if (triggerCollider != null) triggerCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(doorAnimator != null)
                doorAnimator.SetBool("Open", true);
            if(doorAnimator2 != null)
                doorAnimator2.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(doorAnimator != null)
                doorAnimator.SetBool("Open", false);
            if(doorAnimator2 != null)
                doorAnimator2.SetBool("Open", false);
        }
    }
}