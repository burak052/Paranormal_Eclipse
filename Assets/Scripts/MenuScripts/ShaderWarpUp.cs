using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ShaderWarpUp : MonoBehaviour
{
    public Image blackScreen;  
    float fadeTime = 1.5f;
    void Start()
    {
        StartCoroutine(SceneStart());
    }
    IEnumerator SceneStart() 
    { 
        blackScreen.color = new Color(1, 1, 1, 1); 
        float t = 0f; 
        yield return new WaitForSeconds(10f); 
        SceneManager.LoadScene(1);
    }
}
