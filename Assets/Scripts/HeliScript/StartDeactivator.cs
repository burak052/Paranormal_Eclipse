using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartDeactivator : MonoBehaviour
{
    public GameObject objectToDisable;         
    public Behaviour componentToDisable;    
    public Image blackScreen;    
    public float fadeTime = 1.5f;

    void Start()
    {
        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        if (componentToDisable != null)
            componentToDisable.enabled = false;
        StartCoroutine(FadeAndStart());
    }
    
    IEnumerator FadeAndStart()
    {
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime); // 1'den 0'a fade out
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
