using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [Header("Raycast Ayarları")]
    public float interactDistance = 3f;  // Kapıya yaklaşma mesafesi
    public LayerMask layerMask;          // "Door" layerı varsa ekleyin (zorunlu değil)

    [Header("UI")]
    public GameObject pressEUI;          // "Press E" UI'si
    public GameObject EnviroKeypad;
    private Animator currentDoorAnimator;

    void Start()
    {
        if (pressEUI != null)
            pressEUI.SetActive(false);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Raycast gönder
        if (Physics.Raycast(ray, out hit, interactDistance, layerMask.value == 0 ? ~0 : layerMask))
        {
            // Objeyi kontrol et
            if (hit.collider.CompareTag("BoilerDoor"))
            {
                // UI görünür olsun
                if (pressEUI != null)
                    pressEUI.SetActive(true);

                // Animator referansı al
                currentDoorAnimator = hit.collider.GetComponent<Animator>();

                // E tuşuna basılırsa animasyon tetikle
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (currentDoorAnimator != null)
                    {
                        bool state = currentDoorAnimator.GetBool("Open");
                        currentDoorAnimator.SetBool("Open", !state);
                    }
                }
                return;
            }
            if (hit.collider.CompareTag("EnviroKeypad"))
            {
                if (pressEUI != null)
                    pressEUI.SetActive(true);

              

                // E tuşuna basılırsa animasyon tetikle
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (EnviroKeypad != null)
                        EnviroKeypad.SetActive(true);
                }
                return;
            }
        }

        // Raycast bir şey bulamazsa UI kapanır
        if (pressEUI != null)
            pressEUI.SetActive(false);

        currentDoorAnimator = null;
    }
}
