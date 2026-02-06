using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightController : MonoBehaviour
{
    [Header("Bu corridorun ışıkları")]
    public GameObject[] corridorLights;
    int x = 0;
    public bool generator = false;

    private static LightController activeCorridor;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (!generator) return;

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
        StartCoroutine(SetLightsRandom(state));
    }

    IEnumerator SetLightsRandom(bool state)
    {
        // Listeyi kopyala ki orijinali bozulmasın
        List<GameObject> shuffledLights = new List<GameObject>(corridorLights);

        // Rastgele sırala
        for (int i = 0; i < shuffledLights.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledLights.Count);
            GameObject temp = shuffledLights[i];
            shuffledLights[i] = shuffledLights[randomIndex];
            shuffledLights[randomIndex] = temp;
        }

        // 0.2 saniye arayla aktif et
        foreach (var light in shuffledLights)
        {
            light.SetActive(state);
            AudioSource audio = light.GetComponent<AudioSource>();
            if (audio != null && x % 2 == 1 && audio.gameObject.activeInHierarchy)
            {
                audio.Play();
                yield return new WaitForSeconds(0.2f);
            }
            x++;
        }
    }

}
