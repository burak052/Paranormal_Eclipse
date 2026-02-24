using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuBlackScreen : MonoBehaviour
{
    void Start()
    {
        Image img = GetComponent<Image>();
        Color c = img.color;

        float duration = 2f;
        float timer = 0f;

        StartCoroutine(Fade());
        IEnumerator Fade()
        {
            while (timer < duration)
            {
                timer += Time.deltaTime;
                c.a = Mathf.Lerp(1f, 0f, timer / duration);
                img.color = c;
                yield return null;
            }

            c.a = 0f;
            img.color = c;
            gameObject.SetActive(false);
        }
    }
}
