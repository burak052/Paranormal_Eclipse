using UnityEngine;
using System.Collections;

public class ExplosionTest : MonoBehaviour
{
    public GameObject flame;
    public GameObject lightning;
    public GameObject sparks;
    public GameObject Electricity1;
    public GameObject Electricity2;
    public GameObject Electricity3;
    public GameObject Explosion;
    public void StartCinema()
    {
        StartCoroutine(Crash());
    }
    IEnumerator Crash()
    {
        yield return new WaitForSeconds(8f);
        lightning.SetActive(true);
        sparks.SetActive(true);
        yield return new WaitForSeconds(3f);
        Electricity1.SetActive(true);
        yield return new WaitForSeconds(1f);
        Electricity2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Electricity3.SetActive(true);
        yield return new WaitForSeconds(8f);
        Explosion.SetActive(true);
        flame.SetActive(true);
        yield return new WaitForSeconds(2f);
        lightning.SetActive(false);
        sparks.SetActive(false);
        Electricity1.SetActive(false);
        Electricity2.SetActive(false);
        Electricity3.SetActive(false);
        Explosion.SetActive(false);
    }
}
