using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;

    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    public Collider playerCollider;
    public Collider ultCollider;
    public Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);

    }

    // Update is called once per frame
    public void ToggleRagdoll (bool state)
    {
        animator.enabled = !state;

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
            playerRb.isKinematic = false;
        }

        foreach (Collider collider in ragdollColliders)
        {
            collider.enabled = state;
            playerCollider.enabled = true;
            ultCollider.enabled = true;
        }
    }
}
