using System.Collections;
using UnityEngine;

public class SmoothCameraMove : MonoBehaviour
{
    public Transform keypadCameraPoint;
    public Transform laptopCameraPoint;
    public float moveDuration = 1.2f;

    private Vector3 startPos;
    private Quaternion startRot;
    private Quaternion originalLocalRotation;
    public MonoBehaviour playerMovement; 

    public void MoveToKeypad()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        originalLocalRotation = transform.localRotation;

        StopAllCoroutines();
        StartCoroutine(MoveCamera());
    }
    public void MoveToLaptop()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        originalLocalRotation = transform.localRotation;

        StopAllCoroutines();
        StartCoroutine(MoveLaptopCamera());
    }
    public void ReturnCamera()
    {
        StopAllCoroutines();
        StartCoroutine(reCamera());
    }

    IEnumerator MoveCamera()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveDuration;

            transform.position = Vector3.Lerp(startPos, keypadCameraPoint.position, t);
            transform.rotation = Quaternion.Slerp(startRot, keypadCameraPoint.rotation, t);

            yield return null;
        }
    }

    IEnumerator MoveLaptopCamera()
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveDuration;

            transform.position = Vector3.Lerp(startPos, laptopCameraPoint.position, t);
            transform.rotation = Quaternion.Slerp(startRot, laptopCameraPoint.rotation, t);

            yield return null;
        }
    }

    IEnumerator reCamera()
    {
        Vector3 startPos = transform.localPosition;
        Quaternion startRot = transform.localRotation;

        Vector3 targetPos = Vector3.zero;
        Quaternion targetRot = originalLocalRotation;

        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveDuration;
            float eased = Mathf.SmoothStep(0f, 1f, t);

            transform.localPosition = Vector3.Lerp(startPos, targetPos, eased);
            transform.localRotation = Quaternion.Slerp(startRot, targetRot, eased);

            yield return null;
        }
        playerMovement.enabled = true;
    }
}
