using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
