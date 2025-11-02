using UnityEngine;

public class FixJawPose : MonoBehaviour
{
    Transform head;
    Transform jaw;

    Quaternion headRestRotation;
    Quaternion jawRestRotation;

    void Start()
    {
        head = transform.Find("MaleBaseRig_SHJntGrp/MaleBaseRig_ROOTSHJnt/MaleBaseRig_Spine_02SHJnt/MaleBaseRig_Neck_02SHJnt/MaleBaseRig_Head_JawSHJnt/..");
        jaw = transform.Find("MaleBaseRig_SHJntGrp/MaleBaseRig_ROOTSHJnt/MaleBaseRig_Spine_02SHJnt/MaleBaseRig_Neck_02SHJnt/MaleBaseRig_Head_JawSHJnt");

        if (head != null)
            headRestRotation = head.localRotation;

        if (jaw != null)
            jawRestRotation = Quaternion.Euler(-10f, 0f, 0f);
    }

    void LateUpdate()
    {
        // Baş animasyondan sonra kendi doğal pozuna dönsün
        if (head != null)
            head.localRotation = headRestRotation;

        // Çene de kapalı pozda sabit kalsın
        if (jaw != null)
            jaw.localRotation = jawRestRotation;
    }
}
