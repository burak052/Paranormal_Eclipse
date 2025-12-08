using UnityEngine;

public class LaraRoomDoor : MonoBehaviour
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
        if (other.CompareTag("Lara"))
        {
            doorAnimator.SetBool("Open", true);
            doorAnimator2.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lara"))
        {
            doorAnimator.SetBool("Open", false);
            doorAnimator2.SetBool("Open", false);
        }
    }
}