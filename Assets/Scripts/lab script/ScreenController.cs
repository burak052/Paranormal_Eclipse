using UnityEngine;

public class ScreenController : MonoBehaviour
{
    public void ActiveScreen()
    {
        transform.Find("light").gameObject.SetActive(true);
        transform.Find("point light").gameObject.SetActive(true);
        transform.Find("dark").gameObject.SetActive(false);
        transform.parent.Find("pcs").gameObject.SetActive(true);
        transform.parent.Find("pcs (1)").gameObject.SetActive(false);
        transform.parent.Find("wall").gameObject.SetActive(true);
        transform.parent.Find("wall (1)").gameObject.SetActive(false);
    }
}
