using UnityEngine;

public class PressCTRL : MonoBehaviour
{
    public Raycast ray;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ray.ctrlshow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ray.ctrlshow = false;
        }
    }
}
