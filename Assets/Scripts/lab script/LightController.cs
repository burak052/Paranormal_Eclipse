using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("Bu corridorun ışıkları")]
    public GameObject[] corridorLights;

    private static LightController activeCorridor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Önce önceki corridoru kapat
        if (activeCorridor != null && activeCorridor != this)
        {
            activeCorridor.SetLights(false);
        }

        // Bu corridoru aç
        SetLights(true);
        activeCorridor = this;
    }

    void SetLights(bool state)
    {
        foreach (var light in corridorLights)
            light.SetActive(state);
    }
}
