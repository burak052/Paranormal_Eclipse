using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Missions : MonoBehaviour
{
    public int missionCount = 0;
    public TextMeshProUGUI missionText;
    void Start()
    {
        missionText = GetComponent<TextMeshProUGUI>();
        if (missionCount == 0)
        {
            missionText.text = "";
        }
    } 
}
