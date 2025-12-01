using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    public float moveSpeed = 5f; // İlerleme hızı
    public bool move = true;     // Hareketi durdurup başlatmak için
    public bool teleport = false;
    public bool landing = false;

    void Update()
    {
        if (move)
        {
            // X ve Z ekseninde eşit miktarda azalma (çapraz hareket)
            Vector3 moveDirection = new Vector3(-1f, 0f, -1f).normalized;
            
            // Yüksekliği sabit tutarak ilerleme
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        if (teleport)
        {
            transform.localPosition  = new Vector3(-24.73f,99.83f,-306.17f);
            transform.localEulerAngles = new Vector3(-3f, transform.localEulerAngles.y, transform.localEulerAngles.z);
            teleport = false;
        }
        if (landing)
        {
            Vector3 moveDirection = new Vector3(-2f, -1f, -2f).normalized;
            transform.position += moveDirection * 5 * Time.deltaTime;
        }
    }
}
