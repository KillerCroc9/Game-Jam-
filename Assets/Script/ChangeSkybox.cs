using UnityEngine;
using UnityEngine.Rendering;

public class ChangeSkybox : MonoBehaviour
{
    public Material[] skyboxMaterials; // Array of skybox materials to cycle through
    private int currentSkyboxIndex = 0; // Index of the current skybox material

    void Start()
    {
        // Set the initial skybox to the first material in the array
        RenderSettings.skybox = skyboxMaterials[0];
    }

    void Update()
    {
        
            RenderSettings.skybox = skyboxMaterials[PlayerPrefs.GetInt("Level")];
        
    }
}
