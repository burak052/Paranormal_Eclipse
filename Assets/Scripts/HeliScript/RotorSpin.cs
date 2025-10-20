using UnityEngine;

public class RotorSpin : MonoBehaviour
{
    public float rotationSpeed = 2000f;

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
