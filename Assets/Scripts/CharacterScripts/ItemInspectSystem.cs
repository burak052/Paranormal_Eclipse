using UnityEngine;

public class ItemInspectSystem : MonoBehaviour
{
    public MonoBehaviour playerMovement;
    public Transform inspectPoint;
    public float rotateSpeed = 120f;

    GameObject inspectedObject;
    public bool isInspecting = false;

    void Update()
    {
        if (!isInspecting) return;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        inspectedObject.transform.Rotate(Vector3.up, -mouseX * rotateSpeed * Time.unscaledDeltaTime, Space.World);
        inspectedObject.transform.Rotate(Vector3.right, mouseY * rotateSpeed * Time.unscaledDeltaTime, Space.World);
    }

    public void StartInspect(GameObject item)
    {
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = true;
        if(item.tag != "RepairKit" && item.tag != "PlaceEnergyCapsule")
        {
            playerMovement.enabled = false;
            isInspecting = true;
            inspectedObject = item;

            if (item.TryGetComponent(out Rigidbody rb))
                rb.isKinematic = true;

            item.transform.SetParent(inspectPoint);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
        }
        else
            item.SetActive(false);
    }

    public void EndInspect()
    {
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = false;
        playerMovement.enabled = true;
        inspectedObject.transform.SetParent(null);
        inspectedObject.SetActive(false);

        isInspecting = false;
        inspectedObject = null;
    }
}
