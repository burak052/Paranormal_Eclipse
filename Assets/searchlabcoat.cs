using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class searchlabcoat : MonoBehaviour
{
    public GameObject paper;
    
    void Start()
    {
        paper.SetActive(false);
    }

    public void showpaper()
    {
        paper.SetActive(true);
    }

    public void offpaper()
    {
        paper.SetActive(false);
    }

}
