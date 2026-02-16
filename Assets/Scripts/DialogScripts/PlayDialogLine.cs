using UnityEngine;
using System.Collections;

public class PlayDialogLine : MonoBehaviour
{
    public Dialogs dia;
    public AudioSource Aralsource;
    public AudioSource Larasource;

    public IEnumerator PlayVoice(int id)
    {
        if (id != 116 && id != 133)
        {
            if(id == 169)
                id = 34;
                
            string path = "Line/dialog" + id;

            ResourceRequest req = Resources.LoadAsync<AudioClip>(path);
            yield return req;

            AudioClip clip = req.asset as AudioClip;

            if(dia.dias[id] != "")
            {
                if(dia.dias[id].StartsWith("Aral") || dia.dias[id].StartsWith("Арал"))
                    Aralsource.PlayOneShot(clip);
                else
                    Larasource.PlayOneShot(clip);
            }

            yield return new WaitForSeconds(clip.length);
            Resources.UnloadAsset(clip);
        }
        else if(id == 116)
        {
            yield return new WaitForSeconds(2.5f);
        }
        else
        {
            yield return new WaitForSeconds(8f);
        }
    }
}
