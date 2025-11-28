using UnityEngine;

public class StartDeactivator : MonoBehaviour
{
    public GameObject objectToDisable;         // Kapatılacak obje
    public Behaviour componentToDisable;       // Kapatılacak component

    void Start()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (componentToDisable != null)
            componentToDisable.enabled = false;
    }
}
