using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Audio;

public class ShaderWarpUp : MonoBehaviour
{
    public Image blackScreen;  
    public AudioSource menumusic;
    float fadeTime = 1.5f;
    void Start()
    {
        StartCoroutine(SceneStart());
    }
    IEnumerator SceneStart() 
    { 
        blackScreen.color = new Color(1, 1, 1, 1); 
        float t = 0f; 
        yield return new WaitForSeconds(8f); 
        menumusic.Play();
        while (t < fadeTime) 
        { 
            t += Time.deltaTime; 
            float alpha = Mathf.Lerp(1, 0, t / fadeTime); 
            blackScreen.color = new Color(1, 1, 1, alpha); 
            yield return null; 
        } 
        blackScreen.gameObject.SetActive(false); 
    }
}
