using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Missions : MonoBehaviour
{
    public int missionCount = 0;
    public TextMeshProUGUI missionText;
    string[] missions = new string[50];
    string[] missionsOP = new string[50];
    void Start()
    {
        missions[0] = "—Find the ID card in the hangar";
        missions[1] = "—Go to shelter";
        missions[2] = "—Find the repair kit in the hangar";
        missions[3] = "—fix the electric box on the radio tower";
        missions[4] = "—speak with lara";
        missions[5] = "—go to sleep in bed";
        missions[6] = "—take lapel light";
        missions[7] = "—meet with lara in the beach";
        missions[8]  = "—open the door in the cave";
        missions[9]  = "—put on your lab coat";
        missions[10]  = "—find a way to open the enviro door";
        missionsOP[10]  = "—Search to boiler and locker room";
        missions[11] = "—take 6 energy capsules";
        missions[12] = "—go up to the 2nd floor";
        missions[13] = "—connect the cable";
        missions[14] = "—place 6 capsules";
        missions[15] = "—start the Chronal Synchronization Protocol";
        missions[16] = "—Find lara.";
        missions[17] = "—Find the password for the enviro room.";
        missions[18] = "—Find the password for the enviro room.";
        missions[19] = "—Find the password for the enviro room.";
        missions[20] = "—Find the password for the enviro room.";
        if (missionCount == 0)
        {
            DisMis(missionCount);
        }
    } 
    public void DisMis(int i)
    {
        StartCoroutine(DisMission(missions[i]));
    }
    public IEnumerator DisMission(string s)
    {
        missionText.text = s;
        transform.Find("Missions").gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        transform.Find("Missions").gameObject.SetActive(false);
    }
}
