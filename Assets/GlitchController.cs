using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using System.Collections;

public class GlitchController : MonoBehaviour
{
    Volume volume;

    FilmGrain filmGrain;
    ChromaticAberration chromatic;
    Vignette vignette;

    void Awake()
    {
        volume = GetComponent<Volume>();

        volume.profile.TryGet(out filmGrain);
        volume.profile.TryGet(out chromatic);
        volume.profile.TryGet(out vignette);

        // Başlangıçta kapalı
        filmGrain.intensity.value = 0f;
        chromatic.intensity.value = 0f;
        vignette.intensity.value = 0f;
    }

    public void ActiveGlitch()
    {
        StopAllCoroutines();
        StartCoroutine(GlitchSequence());
    }

    IEnumerator GlitchSequence()
    {
        yield return StartCoroutine(Lerp(
            v => filmGrain.intensity.value = v, 0f, 1f, 2f));

        yield return StartCoroutine(Lerp(
            v => chromatic.intensity.value = v, 0f, 1f, 2f));

        yield return StartCoroutine(Lerp(
            v => vignette.intensity.value = v, 0f, 0.072f, 2f));
    }

    IEnumerator Lerp(System.Action<float> setter, float from, float to, float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            setter(Mathf.Lerp(from, to, t / duration));
            t += Time.deltaTime;
            yield return null;
        }
        setter(to);
    }

    public void DisableGlitchInstant()
    {
        StopAllCoroutines();

        filmGrain.intensity.value = 0f;
        chromatic.intensity.value = 0f;
        vignette.intensity.value = 0f;
    }
}
