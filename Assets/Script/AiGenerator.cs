using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiGenerator : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Spawner;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Enemy_Gen", 4f,40f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enemy_Gen() { 
    Instantiate(Enemy, Spawner.transform);
    }

}
