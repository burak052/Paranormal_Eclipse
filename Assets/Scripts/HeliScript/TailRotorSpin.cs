using UnityEngine;

public class TailRotorSpin : MonoBehaviour
{
    public float rotationSpeed = 2500f; 

    void Update()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
