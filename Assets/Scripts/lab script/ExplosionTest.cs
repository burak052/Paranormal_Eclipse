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
    public Animator rotor;
    public GameObject rotorSound;
    public ActiveBlackScreen ABS;
    public GameObject laranote;
    public GameObject lara;
    public GameObject beforecrash;
    public GameObject aftercrash;
    public GameObject elevatorcrash;
    public GameObject elevator;
    public ScreenController triangle;
    public Raycast ray;
    public Animator door;

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
        rotor.speed = 0f;    

        yield return new WaitForSeconds(0.5f);
        ABS.StandartBS();
        yield return new WaitForSeconds(0.5f);
        if (rotorSound.GetComponents<AudioSource>()[1].isPlaying)
            rotorSound.GetComponents<AudioSource>()[1].Stop();

        lightning.SetActive(false);
        sparks.SetActive(false);
        Electricity1.SetActive(false);
        Electricity2.SetActive(false);
        Electricity3.SetActive(false);
        yield return new WaitForSeconds(4f);
        Explosion.SetActive(false);

        yield return new WaitForSeconds(2f);
        flame.SetActive(true);
        transform.Find("flame_box").gameObject.SetActive(true);
        transform.Find("Flamethrower").gameObject.SetActive(true);
        transform.Find("Flamethrower (1)").gameObject.SetActive(true);

        //labın enkazlı halini buraya ekle
        laranote.SetActive(true);
        lara.SetActive(false);
        triangle.DisableScreen();
        aftercrash.SetActive(true);
        beforecrash.SetActive(false);
        ray.accident = true;
        elevator.SetActive(false);
        elevatorcrash.SetActive(true);
        door.SetBool("Open",false);
        //////////////////////////////////
        
    }

}
