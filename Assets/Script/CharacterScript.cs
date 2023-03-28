using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public Rigidbody rb;
    float angleX = 0;
    public int rotateSpeed;
    private float speed = 10f;
    float maxSpeed = 30f;
    public bool isGround;
    bool Race;
    bool Back;
    bool Up;
    public Respawn respawn;
    //public GameObject particle;
    // public GameObject particle1;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>(); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(5, 0, 0), ForceMode.Impulse);
            respawn.kill = true;
        }
    }
    public bool IsGrounded(){
        float distToGround = this.GetComponent<CapsuleCollider>().bounds.extents.y;
        return isGround=Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
        }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow) && IsGrounded())
        {
            Physics.gravity = new Vector3(0, -2f, 0);
            rb.AddForce(new Vector3(0, 0, speed * 1.5f), ForceMode.Acceleration);
            //  this.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, -90, 0);
            //  animator.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && IsGrounded())
        {
            Physics.gravity = new Vector3(0, -2f, 0);
            rb.AddForce(new Vector3(0, 0, -speed * 1.5f), ForceMode.Acceleration);
            //  this.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 90, 0);
            //  animator.SetBool("isRunning", true);

        }
        if (IsGrounded()) {
            if (Input.GetKey(KeyCode.UpArrow))
        {
            //    particle1.SetActive(true);
            //    particle.SetActive(true);
            Physics.gravity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0, speed*45, 0), ForceMode.Acceleration);
            //   animator.SetBool("isRunning", false);
        }
        }
        else
        {
            Physics.gravity = new Vector3(0, -10f, 0);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow))
        {
            //  animator.SetBool("isRunning", false);
        }
       
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(0, -speed, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !IsGrounded())
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 0, rotateSpeed) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
/*            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
*/        }
        if (Input.GetKey(KeyCode.LeftArrow) && !IsGrounded())
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 0, -rotateSpeed) * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
/*            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
*/        }
    }
    public void racePressed()
    {
        Race = true;
    }
    public void raceLeft()
    {
        Race = false;
    }
    public void backdown()
    {
        Back = true;
    }
    public void backno()
    {
        Back = false;
    }
    public void up()
    {
        Up = true;
    }
    public void down()
    {
        Up = false;
    }

}
