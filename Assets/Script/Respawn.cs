using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Respawn : MonoBehaviour
{
    bool isKill;
    public GameObject respawn;
    bool dying;
    public GameObject block;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject Main;
    public AudioSource source;
    private void Start()
    {
        Main = transform.parent.gameObject;
    }
    public bool isKilled()
    {
        float distToGround = this.GetComponent<CapsuleCollider>().bounds.extents.y;
        return isKill = Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
    }
    public bool isKills()
    {
        float distToGround = this.GetComponent<CapsuleCollider>().bounds.extents.y;
        return isKill = Physics.Raycast(transform.position, Vector3.up, (float)(distToGround + 0.1));
    }
    public bool isFalls()
    {
        if(Main.transform.position.y <= 10)
        {
            print("heelo");
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        if (isKilled() || isKills() || isFalls()    )
        {
            
            StartCoroutine(MyCoroutine());
            
        }
    }
    IEnumerator MyCoroutine()
    {
        if (!dying) {
            block.SetActive(true);
            source.Play();
            transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.parent.gameObject.transform.Rotate(35, 0, 0);
            virtualCamera.Follow =null;
            dying = true;
        yield return new WaitForSeconds(4);
        transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        transform.parent.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        transform.parent.gameObject.transform.transform.rotation = Quaternion.Euler(0, 90, 90);
        transform.parent.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        transform.parent.gameObject.transform.position = respawn.transform.position;
            dying = false;
            block.SetActive(false);
            virtualCamera.Follow = this.transform.parent.transform;

            yield return null;
        }
    }
}
