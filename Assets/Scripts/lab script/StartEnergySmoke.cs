using UnityEngine;
using System.Collections;

public class StartEnergySmoke : MonoBehaviour
{
    public ParticleSystem particle1;
    public ParticleSystem particle2;
    public AudioSource sound;
    public AudioSource pingsound;
    public GameObject light1;
    public GameObject light2;
    public GameObject elevatorButton;
    public bool ping = false;
    bool isPinging;

    void Update()
    {
        if (ping && !isPinging)
        {
            StartCoroutine(StartPing());
        }
    }

    public void OffLight()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        isPinging = false;
    }
    public void OnElevatorButton()
    {
        elevatorButton.tag = "ElevatorButton";
    }

    IEnumerator StartPing()
    {
        isPinging = true;
        pingsound.Play();
        light1.SetActive(true);
        light2.SetActive(true);
        yield return new WaitForSeconds(1f);
        light1.SetActive(false);
        light2.SetActive(false);
        yield return new WaitForSeconds(1f);
        isPinging = false;
    }
    IEnumerator PlayParticles()
    {
        particle1.Play();
        particle2.Play();
        sound.Play();

        yield return new WaitForSeconds(13f);

        particle1.Stop();
        particle2.Stop();
        yield return new WaitForSeconds(6f);
        ping = true;
    }
}
