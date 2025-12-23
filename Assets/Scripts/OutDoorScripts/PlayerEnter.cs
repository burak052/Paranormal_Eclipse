using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public ShadowDisable shad;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shad.DisableShadow();
        }
    }
}
