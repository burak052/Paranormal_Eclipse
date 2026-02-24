using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cinemachine; 
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public Image blackScreen;    
    public float fadeTime = 1.5f;
    public float waitTime = 3f;

    public GameObject object1;
    public GameObject object2;
  
    public Behaviour componentToactive; 
    public Behaviour componentTodeactive;   

    public CinemachineVirtualCamera activeCam;      
    public CinemachineVirtualCamera inactiveCam; 

    private void OnTriggerEnter(Collider other)
    {
        // Diğer obje ile tag kontrolü (isteğe bağlı)
        if (other.CompareTag("Heli"))
        {
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

        HelicopterMove heliMove = object1.GetComponent<HelicopterMove>();
        if (heliMove != null)
        {
            heliMove.move = false; // Hareketi durdur
            heliMove.teleport = true;
            heliMove.landing = true;
        }
                
        //if (object1 != null) object1.transform.position = new Vector3(-42,95,-325);  // yeni konum
        if (object2 != null) object2.transform.position = new Vector3(1572,57,1519); // yeni konum

        // Virtual camera değiştir
        if (activeCam != null) activeCam.gameObject.SetActive(false);
        if (inactiveCam != null) inactiveCam.gameObject.SetActive(true);

        yield return new WaitForSeconds(waitTime);

        if (componentTodeactive != null)
            componentTodeactive.enabled = false;
        if (componentToactive != null)
            componentToactive.enabled = true;
        t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        yield return new WaitForSeconds(waitTime-1);
        
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(2);
    }
}
