using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject level;
    public GameObject Menu;

    public void Play()
    {
        Menu.SetActive(false);
        level.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
