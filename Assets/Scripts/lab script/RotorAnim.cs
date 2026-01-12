using UnityEngine;
using System.Collections;

public class RotorAnim : MonoBehaviour
{
    public void CapsuleRotate()
    {
        StartCoroutine(StartCapsuleRotate());
    }
    IEnumerator StartCapsuleRotate()
    {
        yield return new WaitForSeconds(2f);

        Vector3 startEuler = transform.localEulerAngles;
        Vector3 targetEuler = startEuler;
        targetEuler.z += 60f;

        Quaternion startRot = Quaternion.Euler(startEuler);
        Quaternion targetRot = Quaternion.Euler(targetEuler);

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.localRotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }
    public void RotorSpin()
    {

    }
}
