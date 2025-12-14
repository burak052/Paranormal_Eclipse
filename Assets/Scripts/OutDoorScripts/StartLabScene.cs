using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartLabScene : MonoBehaviour
{
    public Image blackScreen;    
    public float fadeTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            blackScreen.gameObject.SetActive(true);
            StartCoroutine(FadeAndStart());
        }
    }
    
    IEnumerator FadeAndStart()
    {
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        Application.LoadLevel(3);
    }
}
