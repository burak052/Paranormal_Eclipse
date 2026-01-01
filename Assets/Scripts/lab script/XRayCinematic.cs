using UnityEngine;
using System.Collections;

public class XRayCinematic : MonoBehaviour
{
    public GameObject Lara;
    public GameObject Aral;
    EasyPeasyFirstPersonController.FirstPersonController aralfps;
    LabMovement aralMove;
    LaraMovement laraMove;

    void Start()
    {
        aralfps = Aral.GetComponent<EasyPeasyFirstPersonController.FirstPersonController>();
        aralMove = Aral.GetComponent<LabMovement>();
        laraMove = Lara.GetComponent<LaraMovement>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Aral.GetComponent<PlayerAnimationController>().enabled = false;
            aralfps.enabled = false;
            GetComponent<Collider>().enabled = false;
            aralMove.XRayCinematic();
            laraMove.XRayCinematic();
            //StartCoroutine(LaserMove());
            //aralMove.LookDown();
        }
    }
}
