using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rbs;
    Animator anim;
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();

        DeactivateRagdoll();
    }

    public void DeactivateRagdoll()
    {
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic = true;
        }
        anim.enabled = true;
    }
    public void ActivateRagdoll()
    {
        foreach(Rigidbody rb in rbs)
        {
            rb.isKinematic =  false;
        }
        anim.enabled = false;
    }
    public void ApplyForce(Vector3 force)
    {
        Rigidbody rb = anim.GetBoneTransform(HumanBodyBones.Hips).GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.VelocityChange);
    }
}
