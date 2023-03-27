using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;
    public bool isGround;
    public float gravity = -10f; // acceleration due to gravity
    float maxSpeed = 30f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public bool IsGrounded()
    {
        float distToGround = this.GetComponent<CapsuleCollider>().bounds.extents.y;
        return isGround = Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        if (!IsGrounded())
        {
            rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);
        }
        // Create a force vector in the Z-axis direction (forward)
        rb.AddForce(new Vector3(0, 0, speed * 1.5f), ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, speed ), ForceMode.Impulse);
            rb.AddForce(new Vector3(0, 5, speed ), ForceMode.Impulse);
        }
    }
}
