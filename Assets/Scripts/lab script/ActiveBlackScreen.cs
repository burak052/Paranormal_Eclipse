using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActiveBlackScreen : MonoBehaviour
{
    public Image blackScreen;
    public float delay = 3f;
    public float fadeTime = 1.5f;
    public AudioSource clothesAudio;
    public MonoBehaviour playerMovement;
    public GameObject day;
    public GameObject sunLight;
    public GameObject night;
    public GameObject moonLight;
    public GameObject headlight;
    public GameObject security;
    public GameObject looklara;
    public AudioSource forestSound;
    public AudioClip nightSound;
    public ShadowDisable Shaddis;
    public PlayerAnimationController pac;
    public Missions missions;
    public ESCMenu Menu;
    public Dialogs dia;
    public GlitchController GC;
    public Sprite GlitchSprite1;
    public Sprite GlitchSprite2;
    public bool outfit = false;

    public void BlackScreenOn()
      {
        StartCoroutine(DisableAfterDelay());
      }

    IEnumerator DisableAfterDelay()
    {
        Menu.canOpenMenu = false;
        pac.SetAnimator();
        pac.enabled = false;
        playerMovement.enabled = false;

        float t = 0f;
        if(clothesAudio != null)
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
        if(day != null)
        day.SetActive(false);
        if(sunLight != null)
        sunLight.SetActive(false);
        if(night != null)
        night.SetActive(true);
        if(moonLight != null)
        moonLight.SetActive(true);
        if (headlight != null)
        headlight.SetActive(true);
        if (forestSound != null && nightSound != null)
        forestSound.PlayOneShot(nightSound);
        if (Shaddis != null)
        {
          Shaddis.EnableShadow();
          Shaddis.gameObject.GetComponent<Transform>().Find("Cube").gameObject.SetActive(true);
          Shaddis.gameObject.GetComponent<Transform>().Find("Cube1").gameObject.SetActive(true);
          Shaddis.gameObject.GetComponent<Transform>().Find("Cube2").gameObject.SetActive(true);
        }
        if (outfit)
        {
          looklara.SetActive(true);
          pac.ChangeOutfit(); 
          outfit = false;
        }

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
        pac.enabled = true;
        if (security != null)
        {
            security.GetComponent<BoxCollider>().isTrigger = true;
            security.tag = "Untagged";  
            missions.DisMis(10);
        }
        pac.isSetAnimator = false;
        
        Menu.canOpenMenu = true;
        if(night != null)
        {
          dia.WakeUp();
          missions.DisMis(6);
        }
    }

    public void StandartBS()
      {
        StartCoroutine(StartStandartBS());
      }

    IEnumerator StartStandartBS()
    {
        Menu.canOpenMenu = false;
        pac.SetAnimator();
        pac.enabled = false;
        playerMovement.enabled = false;

        blackScreen.gameObject.SetActive(true);
        blackScreen.color = new Color(0, 0, 0, 1f);

        yield return new WaitForSeconds(4f);

        blackScreen.gameObject.GetComponent<AudioSource>().Play();
        dia.EventDia(116);      /////comeback alive



        // yield return new WaitForSeconds(2.5f);     //demo satırı
        // AudioListener.volume = 0f;
        // transform.Find("Canvas/Demo thanks").gameObject.SetActive(true);
        // yield return new WaitForSeconds(6f);
        // SceneManager.LoadScene(0);

        yield return new WaitForSeconds(4f);    
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
        playerMovement.gameObject.GetComponent<LabMovement>().ExplosionAfter();

        missions.DisMis(16);  ///////
    }

    public void GlassBroke()
      {
        StartCoroutine(StartGlassBroke());
      }

    IEnumerator StartGlassBroke() //7 saniyede ekran kararıyor 4 saniye siyah ekrandan sonra 1.5 saniyede geri açılıyor.
    {
        GC.ActiveGlitch();
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponents<AudioSource>()[1].Play();
        yield return new WaitForSeconds(4f);
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().enabled = true;
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().sprite = GlitchSprite1;
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.5f);
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().enabled = false;
        yield return new WaitForSeconds(1f);
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().enabled = true;
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().sprite = GlitchSprite2;
        blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<AudioSource>().Play();
        blackScreen.color = new Color(0, 0, 0, 0f);
        
        float t = 0f;
        blackScreen.gameObject.SetActive(true);

        while (t < fadeTime)
        {
            if(t > 0.5f)
                blackScreen.gameObject.GetComponent<Transform>().parent.Find("Broke").gameObject.GetComponent<Image>().enabled = false;
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        GC.DisableGlitchInstant();
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(2f);
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
    }

    public void ActivePlayer()
    {
        Menu.canOpenMenu = true;
        pac.enabled = true;
        playerMovement.enabled = true;
        pac.isSetAnimator = false;
        pac.gameObject.GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().SyncRotationFromCamera();
    }
    public void DisablePlayer()
    {
        Menu.canOpenMenu = false;
        pac.SetAnimator();
        pac.enabled = false;
        playerMovement.enabled = false;
    }

    public void Black()
    {
      StartCoroutine(StartBlack());
    }

    IEnumerator StartBlack()
    {
        blackScreen.color = new Color(0, 0, 0, 0f);
        
        float t = 0f;
        blackScreen.gameObject.SetActive(true);

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
    }

    public void DisBlack()
    {
      StartCoroutine(StartDisBlack());
    }

    IEnumerator StartDisBlack()
    {
        float t = 0f;
        blackScreen.gameObject.SetActive(true);
        blackScreen.color = new Color(0, 0, 0, 1f);
        yield return new WaitForSeconds(1f);
        t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, t / fadeTime);
            blackScreen.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        blackScreen.gameObject.SetActive(false);
    }
}