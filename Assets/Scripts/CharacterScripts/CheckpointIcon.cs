using UnityEngine;
using System.Collections;

public class SaveIndicatorUI : MonoBehaviour
{
    public GameObject panel;          // SavePanel
    public RectTransform icon;        // D�necek olan ikon

    private bool isShowing = false;

    private void Awake()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (isShowing)
        {
            icon.Rotate(0, 0, -180f * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (gameObject.activeSelf)
            StartCoroutine(ShowRoutine());
    }
    IEnumerator ShowRoutine()
    {
        isShowing = true;
        panel.SetActive(true);

        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
        isShowing = false;

        // Rotasyonu s�f�rlamak istersen:
        icon.rotation = Quaternion.identity;
        gameObject.SetActive(false);
    }
}