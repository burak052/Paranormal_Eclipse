using UnityEngine;

public class HelicopterMove : MonoBehaviour
{
    public float moveSpeed = 5f; // İlerleme hızı
    public bool move = true;     // Hareketi durdurup başlatmak için

    void Update()
    {
        if (move)
        {
            // X ve Z ekseninde eşit miktarda azalma (çapraz hareket)
            Vector3 moveDirection = new Vector3(-1f, 0f, -1f).normalized;
            
            // Yüksekliği sabit tutarak ilerleme
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
