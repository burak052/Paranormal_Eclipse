using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public ShadowDisable shad;
    public Dialogs dia;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shad.DisableShadow();
            dia.EventDia(7f, dia.dias[35]); 
        }
    }
}
