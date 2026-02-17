using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisableImageAfterDelay : MonoBehaviour
{
    public FinalMovement FM;
    public Image blackScreen;  
    public float delay = 3f;          // Bekleme süresi
    public float fadeTime = 1.5f;

    void Start()
    {
        // if (FM != null)
        //     FM.StartGoBeach();
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(DisableAfterDelay());
    }

    IEnumerator DisableAfterDelay()
    {
        float t = 0f;

        yield return new WaitForSeconds(delay);
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(delay);

        blackScreen.gameObject.SetActive(false);
    }
}
