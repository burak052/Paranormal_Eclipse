using UnityEngine;
using System.Collections;

public class PlayDialogLine : MonoBehaviour
{
    public Dialogs dia;
    public AudioSource Aralsource;
    public AudioSource Larasource;
    public SkinnedMeshRenderer laraFace;   // Body_Geo
    public SkinnedMeshRenderer laraLabFace;   // Body_Geo
    public string mouthBlendShapeName = "O";  // Ağız için kullanacağınız blendshape
    float maxMouthOpen = 40f;
    private Coroutine talkRoutine;
    public bool isLaraChanged = false;

    public IEnumerator PlayVoice(int id)
    {
        if (id != 116 && id != 133)
        {
            if (id == 169)
                id = 34;

            string path = "Line/dialog" + id;

            ResourceRequest req = Resources.LoadAsync<AudioClip>(path);
            yield return req;

            AudioClip clip = req.asset as AudioClip;

            if (clip == null)
                yield break;

            if (dia.dias[id] != "")
            {
                // 🔴 Önce sadece bu iki source'u durdur
                if (Aralsource.isPlaying)
                    Aralsource.Stop();

                if (Larasource.isPlaying)
                    Larasource.Stop();

                // 🎙 Sonra doğru karakteri oynat
                if (dia.dias[id].StartsWith("Aral") || dia.dias[id].StartsWith("Арал"))
                    Aralsource.PlayOneShot(clip);
                else
                {
                    Larasource.PlayOneShot(clip);

                    if (talkRoutine != null)
                        StopCoroutine(talkRoutine);

                    talkRoutine = StartCoroutine(LaraTalk(Larasource));
                }
            }

            yield return new WaitForSeconds(clip.length);
            Resources.UnloadAsset(clip);
        }
        else if (id == 116)
        {
            yield return new WaitForSeconds(2.5f);
        }
        else
        {
            yield return new WaitForSeconds(8f);
        }
    }
    IEnumerator LaraTalk(AudioSource source)
    {
        SkinnedMeshRenderer temp;
        if (!isLaraChanged)
            temp = laraFace;
        else
            temp = laraLabFace;

        int index = temp.sharedMesh.GetBlendShapeIndex(mouthBlendShapeName);
        if (index == -1)
            yield break;

        float currentValue = 0f;
        float targetValue = 0f;
        float changeTimer = 0f;

        while (source.isPlaying)
        {
            // Her 0.08 saniyede bir yeni rastgele hedef üret
            changeTimer -= Time.deltaTime;
            if (changeTimer <= 0f)
            {
                targetValue = Random.Range(0f, 100f); // arası rastgele
                changeTimer = 0.2f;
            }

            // Hedefe doğru yumuşak geçiş
            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * 15f);

            temp.SetBlendShapeWeight(index, currentValue);

            yield return null;
        }

        // Ses bitince ağız kapansın
        temp.SetBlendShapeWeight(index, 0f);
    }
}
