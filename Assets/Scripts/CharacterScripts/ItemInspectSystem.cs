using UnityEngine;

public class ItemInspectSystem : MonoBehaviour
{
    public MonoBehaviour playerMovement;
    public Transform inspectPoint;
    public float rotateSpeed = 120f;
    public ESCMenu Menu;
    public Transform boxex2;

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
        Menu.canOpenMenu = false;
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = true;
        if (item.tag != "RepairKit" && item.tag != "PlaceEnergyCapsule")
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
        else {
            if (item.tag!="watch") 
                item.SetActive(false);
        }
    }

    public void EndInspect()
    {
        Menu.canOpenMenu = true;
        gameObject.GetComponent<PlayerAnimationController>().isSetAnimator = false;
        playerMovement.enabled = true;
        inspectedObject.transform.SetParent(null);
        if (inspectedObject.tag != "watch")
        {
            inspectedObject.SetActive(false);
        }
        if (inspectedObject.tag == "watch")
        {
            inspectedObject.transform.SetParent(boxex2);
            inspectedObject.transform.localPosition = new Vector3(-0.71f, 0.53f, 0.05f);
            inspectedObject.transform.localRotation = Quaternion.Euler(0f, 6.02f, 0f);
        }
        isInspecting = false;
        inspectedObject = null;
    }
}
