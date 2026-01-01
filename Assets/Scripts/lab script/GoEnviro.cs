using UnityEngine;

public class GoEnviro : MonoBehaviour
{
    public LaraMovement Lara;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Lara.LaraGoEnviro();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
