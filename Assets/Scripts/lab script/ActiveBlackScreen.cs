using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActiveBlackScreen : MonoBehaviour
{
    public Image blackScreen;
    public float delay = 3f;          // Bekleme s�resi
    public float fadeTime = 1.5f;
    public AudioSource clothesAudio;
    public MonoBehaviour playerMovement;

      public void BlackScreenOn()
      {
        StartCoroutine(DisableAfterDelay());
      }

    IEnumerator DisableAfterDelay()
    {
        playerMovement.enabled = false;
        float t = 0f;
        clothesAudio.Play();
        blackScreen.gameObject.SetActive(true);

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(delay);

        t = 0f;

        yield return new WaitForSeconds(delay);
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
        playerMovement.enabled = true;
    }
}
