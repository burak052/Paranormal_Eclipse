using UnityEngine;
using System.Collections;

public class LabMovement : MonoBehaviour
{
    public ESCMenu Menu;
    public void XRayCinematic()
    {
        StartCoroutine(StartCinematic());
    }
    IEnumerator StartCinematic()
    {
        Menu.canOpenMenu = false;
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = true;
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isRunning", false);
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isJumping", false);
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalkingCrounching", false);
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalkingCrounchingBack", false);
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isCrouching", false);
        Transform camParent = transform.Find("CameraParent").Find("Camera");
        Vector3 start = transform.position;
        Vector3 target = new Vector3(1376.07f,4.71f,1564.65f);
        Vector3 targetcamparent = new Vector3(0f,1.7f,0.246f);
        Quaternion startRot = camParent.localRotation;
        Quaternion targetRot = Quaternion.Euler(0f, 0f, 0f);
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1f;
            transform.position = Vector3.Lerp(start, target, t);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -135.42f, 0f), t);
            camParent.localRotation = Quaternion.Slerp(startRot, targetRot, t);
            camParent.parent.localPosition = Vector3.Lerp(camParent.parent.localPosition, targetcamparent, t);
            camParent.parent.localRotation = Quaternion.Slerp(camParent.parent.localRotation, Quaternion.Euler(0f, 0f, 0f), t);
            yield return null;
        }
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", false);
        yield return new WaitForSeconds(1f);
        t = 0f; 

        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, -203.87f, 0f);
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        t = 0f;

        startRot = transform.rotation;
        targetRot = Quaternion.Euler(0f, -135.42f, 0f);
        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        start = transform.position;
        target = new Vector3(1374.81f,4.71f,1563.33f);
        t = 0f;

        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", true);
        while (t < 1f)
        {
            t += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        
        start = transform.position;
        target = new Vector3(1374.42f,4.90f,1562.93f);
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1.2f;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }
        transform.Find("aral_lab").gameObject.GetComponent<Animator>().SetBool("isWalking", false);


        startRot = camParent.localRotation;
        targetRot = Quaternion.Euler(75f, 0f, 0f);

        t = 0f;

        yield return new WaitForSeconds(0.5f);
        while (t < 1f)
        {
            t += Time.deltaTime * 1.5f;
            camParent.localRotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        startRot = camParent.localRotation;
        targetRot = Quaternion.Euler(0f, 0f, 0f);
        t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * 1.5f;
            camParent.localRotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }

        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().SyncRotationFromCamera();
        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = true;
        GetComponent<PlayerAnimationController>().enabled = true;
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = false;
        Menu.canOpenMenu = true;
    }
}
