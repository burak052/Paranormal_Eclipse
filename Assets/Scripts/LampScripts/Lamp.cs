using UnityEngine;

public class HauntedFlickerLightAdvanced : MonoBehaviour
{
    [Header("Lamp Settings")]
    public Light lamp;
    public float baseIntensity = 20f;       // HDRP için full parlaklýk
    public Color baseColor = Color.white;   // tamamen beyaz
    public float minIntensity = 15f;        // ani sönme minimum parlaklýk
    public float maxIntensity = 25f;        // ani sönme maksimum parlaklýk

    [Header("Flicker Timing")]
    public float minFlickerTime = 0.1f;    // yanýp sönme aralýðý min
    public float maxFlickerTime = 0.5f;    // yanýp sönme aralýðý max
    [Range(0f, 1f)]
    public float offProbability = 0.1f;    // tamamen sönme olasýlýðý

    [Header("Subtle Flicker")]
    public bool subtleFlicker = true;
    [Range(0f, 1f)]
    public float flickerAmount = 0.05f;    // hafif titreþim þiddeti
    public float flickerSpeed = 1f;        // hafif titreþim hýzý

    [Header("Sound Effects")]
    public AudioSource sparkSound;
    [Range(0f, 1f)]
    public float soundProbability = 0.2f;

    void Start()
    {
        if (lamp != null)
        {
            lamp.enabled = true;
            lamp.color = baseColor;
            lamp.intensity = baseIntensity;
            lamp.range = 10f; // ihtiyaca göre ayarla
            Flick();           // ani yanýp sönme baþlat
        }
    }

    void Update()
    {
        if (lamp == null) return;

        if (subtleFlicker)
        {
            // Hafif yumuþak titreþim (Perlin noise)
            float flicker = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f) * flickerAmount * baseIntensity;
            lamp.intensity = Mathf.Clamp(lamp.intensity + flicker, 0f, maxIntensity);
        }
    }

    void Flick()
    {
        if (lamp == null) return;

        if (Random.value < offProbability)
        {
            // Ani tamamen sönme
            lamp.intensity = 0f;
            float offTime = Random.Range(0.2f, 0.6f);
            Invoke("Flick", offTime);
        }
        else
        {
            // Normal yanýp sönme
            lamp.intensity = Random.Range(minIntensity, maxIntensity);

            // Ses efekti
            if (sparkSound != null && Random.value < soundProbability)
                sparkSound.Play();

            float nextFlick = Random.Range(minFlickerTime, maxFlickerTime);
            Invoke("Flick", nextFlick);
        }
    }
}
