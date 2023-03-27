using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "win")
        {
            StartCoroutine(MyCoroutine());
        }
    }
    IEnumerator MyCoroutine()
    {

            yield return new WaitForSeconds(2);

        winScreen.SetActive(true);

        yield return null;
        }
}

