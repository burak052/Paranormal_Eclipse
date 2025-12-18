using UnityEngine;

public class keypadmat : MonoBehaviour
{
    public Material novascreen;
    public Material emptyscreen;
    public Material deniedscreen;
    public Material successscreen;
    public AudioSource successsound;
    public AudioSource deniedsound;
    public AudioSource buttonsound;

    public void emptyScreen()
    {
        GetComponent<Renderer>().material = emptyscreen;
    }
    public void novaScreen()
    {
        GetComponent<Renderer>().material = novascreen;
    }
    public void deniedScreen()
    {
        deniedsound.Play();
        GetComponent<Renderer>().material = deniedscreen;
    }
    public void successScreen()
    {
        successsound.Play();
        GetComponent<Renderer>().material = successscreen;
    }
    public void keySound()
    {
        buttonsound.Play();
    }
}
