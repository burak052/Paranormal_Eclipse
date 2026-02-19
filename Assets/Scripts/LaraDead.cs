using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations.Rigging;

public class LaraDead : MonoBehaviour
{
    public GameObject muzzle;
    public GameObject Laradead;
    public GameObject Laralab;
    public GameObject Aral;
    public GameObject sail;
    public ActiveBlackScreen ABS;
    public Dialogs dia;
    private bool triggered = false;

    public int finalSelect = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(Dead());
            ABS.Black();
        }
    }

    IEnumerator Dead()
    {
        Transform tra = Aral.GetComponent<Transform>();
        dia.EventDia(170);
        ABS.DisablePlayer();
        Laradead.SetActive(true);
        Laralab.SetActive(true);
        yield return new WaitForSeconds(1.6f);
        tra.position = new Vector3(1562.45f,51.42f,1505.96f);
        tra.rotation = Quaternion.Euler(0f,25.24f,0f);
        tra.Find("CameraParent").Find("Camera").localRotation = Quaternion.Euler(0f,0f,0f);
        Laralab.GetComponent<Transform>().position = new Vector3(1564.291f,51.454f,1512.486f);
        Laralab.GetComponent<Transform>().rotation = Quaternion.Euler(0f,203f,0f);
        Laradead.GetComponent<Transform>().position = new Vector3(1566.54f,51.45f,1510.73f);
        Laradead.GetComponent<Transform>().rotation = Quaternion.Euler(0f,132.785f,0f);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.6f);
        dia.EventDia(171,0.5f);
        float t = 0f;
        while (t < 3f)
        {
            t += Time.deltaTime;
            float normalizedT = t / 3f;
            tra.Find("CameraParent").Find("Camera").localPosition = Vector3.Lerp(new Vector3(0f,0f,0f), new Vector3(0f,0f,2f), Mathf.SmoothStep(0f, 1f, normalizedT));
            yield return null;
        }
        muzzle.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        ABS.blackScreen.gameObject.SetActive(true);
        ABS.blackScreen.color = new Color(0, 0, 0, 1f);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(1.6f); //ateşten sonraki siyah ekran
        tra.Find("CameraParent").Find("Camera").localPosition = new Vector3(0f,0f,0f);
        tra.position = new Vector3(1563.84f,51.42f,1511.276f);
        Laralab.GetComponent<Animator>().SetBool("idle",true);
        Laralab.GetComponent<Transform>().Find("gun").gameObject.SetActive(false);
        yield return new WaitForSeconds(4f);

        ABS.DisBlack();
        muzzle.SetActive(false);
        Laradead.SetActive(false);
        yield return StartCoroutine(dia.FinalDialog());
        yield return new WaitForSeconds(1f);

        dia.gameObject.GetComponent<Transform>().parent.Find("Selections").gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitUntil(() => finalSelect != 0);       //seçim ekranı beklemesi
        Cursor.lockState = CursorLockMode.Locked;
        if(finalSelect == 1)    //Larayı bırak
        {
            StartCoroutine(dia.FirstEndDialog());
            yield return new WaitForSeconds(6f);
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.3f;
                tra.rotation = Quaternion.Slerp(tra.rotation, Quaternion.Euler(0f, 205f, 0f), normalizedT);
                yield return null;
            }
            tra.Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",true);
            t = 0f;
            while (t < 3f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.02f;
                tra.position = Vector3.Lerp(tra.position, new Vector3(1561.28f,51.42f,1505.8f), normalizedT);
                yield return null;
            }
            tra.Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",false);
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.3f;
                tra.rotation = Quaternion.Slerp(tra.rotation, Quaternion.Euler(0f, 23.726f, 0f), normalizedT);
                yield return null;
            }
            yield return new WaitForSeconds(30f);
            ABS.Black();                                        //Vector3(1561.28003,51.4199982,1505.80005)
            yield return new WaitForSeconds(1.6f);
            tra.position = new Vector3(1585f,-0.73f,1900f);
            tra.rotation = Quaternion.Euler(0f,218f,0f);
            sail.SetActive(true);

            yield return new WaitForSeconds(5f);
            ABS.Black();                        
            yield return new WaitForSeconds(2f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits").gameObject.SetActive(true); 
            yield return new WaitForSeconds(3f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/End Logo").gameObject.SetActive(false); 
            yield return new WaitForSeconds(1f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/Credits").gameObject.SetActive(true); 
            yield return StartCoroutine(dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/Credits").gameObject.GetComponent<EndGameCradits>().creditsslider());
            yield return new WaitForSeconds(3f);   
            SceneManager.LoadScene(0);
        }
        else if(finalSelect == 2)       //killyourself
        {
            
            tra.Find("aral.v1 (1)/Rig 1").gameObject.GetComponent<Rig>().weight = 0.7f;
            
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.2f;
                tra.Find("CameraParent").localRotation = Quaternion.Slerp(tra.Find("CameraParent").localRotation, Quaternion.Euler(30f, 0f, 0f), normalizedT);
                yield return null;
            }
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.1f;
                tra.Find("aral.v1 (1)/Rig 1").gameObject.GetComponent<Rig>().weight = Mathf.Lerp(tra.Find("aral.v1 (1)/Rig 1").gameObject.GetComponent<Rig>().weight, 1f, normalizedT);
                yield return null;
            }
            tra.Find("aral.v1 (1)/Rig 1").gameObject.GetComponent<Rig>().weight = 1f;
            yield return new WaitForSeconds(1f);   
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime;
                float normalizedT = t * 0.2f;
                tra.Find("CameraParent").localRotation = Quaternion.Slerp(tra.Find("CameraParent").localRotation, Quaternion.Euler(20f, 0f, 0f), normalizedT);
                yield return null;
            }
            yield return StartCoroutine(dia.SecondEndDialog());
            yield return new WaitForSeconds(0.5f); 
            tra.Find("aral.v1 (1)/MaleBaseRig_SHJntGrp/MaleBaseRig_ROOTSHJnt/MaleBaseRig_Spine_01SHJnt/MaleBaseRig_Spine_02SHJnt/MaleBaseRig_Spine_TopSHJnt/MaleBaseRig_r_Arm_ClavicleSHJnt/MaleBaseRig_r_Arm_ShoulderSHJnt/MaleBaseRig_r_Arm_Elbow_CurveSHJnt/MaleBaseRig_r_Arm_WristSHJnt/gun/vfx_MuzzleFlash_01").gameObject.SetActive(true);
            yield return new WaitForSeconds(0.2f); 
            ABS.blackScreen.gameObject.SetActive(true);
            ABS.blackScreen.color = new Color(0, 0, 0, 1f);
            yield return new WaitForSeconds(3f); 


            SceneManager.LoadScene(5);
        }
        else if(finalSelect == 3)       //secret
        {
            yield return StartCoroutine(dia.ThirdEndDialog());
            yield return StartCoroutine(dia.ThirdEndDialogPart2());
            


            ABS.Black();                        
            yield return new WaitForSeconds(2f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits").gameObject.SetActive(true); 
            yield return new WaitForSeconds(3f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/End Logo").gameObject.SetActive(false); 
            yield return new WaitForSeconds(1f);   
            dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/Credits").gameObject.SetActive(true); 
            yield return StartCoroutine(dia.gameObject.GetComponent<Transform>().parent.Find("EndCredits/Credits").gameObject.GetComponent<EndGameCradits>().creditsslider());
            yield return new WaitForSeconds(3f);   
            SceneManager.LoadScene(0);
        }
    }
}
