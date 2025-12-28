using UnityEngine;

public class LookLabLara : MonoBehaviour
{
    public LaraMovement Lara;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Lara.LaraXray();
        }
    }
}
