using UnityEngine;
using System.Collections;

public class SaveIndicatorUI : MonoBehaviour
{
    public static SaveIndicatorUI Instance;

    public GameObject panel;          // SavePanel
    public RectTransform icon;        // Dönecek olan ikon
    public float rotateSpeed = 180f;  // Dönme hýzý
    public float showDuration = 2f;   // Ekranda kalma süresi

    private bool isShowing = false;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    private void Update()
    {
        if (isShowing)
        {
            icon.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ShowSaveIcon();
    }
    public void ShowSaveIcon()
    {
        if (!gameObject.activeInHierarchy) return;

        StopAllCoroutines();
        StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        isShowing = true;
        panel.SetActive(true);

        yield return new WaitForSeconds(showDuration);

        panel.SetActive(false);
        isShowing = false;

        // Rotasyonu sýfýrlamak istersen:
        icon.rotation = Quaternion.identity;
    }
}