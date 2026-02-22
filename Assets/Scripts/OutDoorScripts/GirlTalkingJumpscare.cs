
using UnityEngine;

public class GirlTalkingJumpscare : MonoBehaviour
{
    public AudioSource scareAudio;
    public Raycast ray;
    private bool hasPlayed = false;
    bool first = false;

    void Update()
    {
        if(!ray.havesleep) return;

        if(!first)
        {
            GetComponent<BoxCollider>().enabled = true;
            first = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed) return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            scareAudio.Play();

            Destroy(gameObject);
        }
    }
}
