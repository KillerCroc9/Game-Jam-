using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild( PlayerPrefs.GetInt("Level")).gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
