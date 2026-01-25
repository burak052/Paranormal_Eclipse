using UnityEngine;
using System.Collections;

public class FinalMovement : MonoBehaviour
{
    public ESCMenu Menu;
    public Missions mis;
    public void StartGoBeach()
    {
        StartCoroutine(GoBeach());
    }
    IEnumerator GoBeach()
    {
        Menu.canOpenMenu = false;
        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = false;
        GetComponent<PlayerAnimationController>().enabled = false;
        gameObject.GetComponent<PlayerAnimationController>().SetAnimator();

        transform.position = new Vector3(1451.71f, 4.038f, 1740.93f);
        transform.rotation = Quaternion.Euler(0f, 20.635f, 0f);

        Vector3 startPos = transform.position;
        Vector3 target = new Vector3(1458.55f, 4.03f, 1759.08f);

        float duration = 6f;
        float t = 0f;

        yield return new WaitForSeconds(3f);
        transform.Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",true);

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalizedT = t / duration;

            transform.position = Vector3.Lerp(startPos, target, Mathf.SmoothStep(0f, 1f, normalizedT));
            yield return null;
        }
        transform.Find("aral.v1 (1)").gameObject.GetComponent<Animator>().SetBool("isWalking",false);

        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().SyncRotationFromCamera();
        GetComponent<EasyPeasyFirstPersonController.FirstPersonController>().enabled = true;
        GetComponent<PlayerAnimationController>().enabled = true;
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = false;
        Menu.canOpenMenu = true;
    }
}
