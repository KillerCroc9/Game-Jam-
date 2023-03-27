using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int level;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(1);
    }
}
