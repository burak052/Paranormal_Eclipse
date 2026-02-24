using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene5 : MonoBehaviour
{
    public Image blackScreen;   
    void OnTriggerEnter(Collider other)
    {
        blackScreen.gameObject.SetActive(true);
        blackScreen.color = new Color(0, 0, 0, 0);
        StartCoroutine(FadeAndStart());
    }

    IEnumerator FadeAndStart()
    {
        float t = 0f;
        while (t < 1.5f)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / 1.5f);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(5);
    }
}
