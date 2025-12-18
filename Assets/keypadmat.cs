using UnityEngine;

public class keypadmat : MonoBehaviour
{
    public Material novascreen;
    public Material emptyscreen;
    public Material deniedscreen;
    public Material successscreen;

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
        GetComponent<Renderer>().material = deniedscreen;
    }
    public void successScreen()
    {
        GetComponent<Renderer>().material = successscreen;
    }
}
