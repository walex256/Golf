using UnityEngine;

public class Pusher : MonoBehaviour
{
    public float pushForce = 15f;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null && !rb.isKinematic)
        {            
            Vector3 pushDirection = collision.contacts[0].point - transform.position;
            pushDirection = pushDirection.normalized;

            rb.AddForce(pushDirection * pushForce, ForceMode.VelocityChange);
        }
    }
}