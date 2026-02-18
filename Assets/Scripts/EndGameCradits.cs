using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using EasyPeasyFirstPersonController;
using System.IO;

public class EndGameCradits : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }

    public IEnumerator creditsslider()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 0.008f;

            Vector2 pos = GetComponent<RectTransform>().anchoredPosition;
            pos.y = Mathf.Lerp(-600f, 17600f, t);
            GetComponent<RectTransform>().anchoredPosition = pos;

            yield return null;
        }
    }
}
