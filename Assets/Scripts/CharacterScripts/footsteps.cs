using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] concreteSteps;
    public AudioClip[] metalSteps;
    public AudioClip[] dirtSteps;

    public float rayDistance = 2f;
    int lastIndex = -1;

    [Header("Ground Check")]
    public float sphereRadius = 0.25f;
    public float rayOffsetY = 0.5f; 
    public void PlayFootstep()
    {
        RaycastHit hit;
        
        Vector3 origin = transform.position + Vector3.up * rayOffsetY;

        if (Physics.SphereCast(origin, sphereRadius, Vector3.down, out hit, rayDistance))
        {
            AudioClip clip = null;

            switch (hit.collider.tag)
{
                case "Ground_Concrete":
                    clip = GetRandomClip(concreteSteps);
                    break;

                case "Ground_Metal":
                    clip = GetRandomClip(metalSteps);
                    break;

                case "Ground_Dirt":
                    clip = GetRandomClip(dirtSteps);
                    break;
                
                default:
                    // Tag yoksa sessizlik olmasın
                    clip = GetRandomClip(concreteSteps);
                    break;
            }

            if (clip != null)
            {
                audioSource.pitch  = Random.Range(0.95f, 1.05f);
                audioSource.volume = Random.Range(0.85f, 1f);

                audioSource.PlayOneShot(clip);
            }
        }
    }

    AudioClip GetRandomClip(AudioClip[] clips)
    {
        if (clips.Length == 0) return null;

        int index;
        do
        {
            index = Random.Range(0, clips.Length);
        }
        while (index == lastIndex && clips.Length > 1);

        lastIndex = index;
        return clips[index];
    }
}
