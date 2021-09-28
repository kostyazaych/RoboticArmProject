using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AreaManager : MonoBehaviour
{
    public Object StaticScene;
    public Object LightScene;
    public Object MechanicScene;
    private Object[] scenesArray;
    private int sceneIndex;
    
    
    void Start()
    {
        scenesArray = new Object[] {StaticScene, LightScene,MechanicScene};

        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadAreaScene(scenesArray[sceneIndex]);
    }

    
    
    void LoadAreaScene(Object sceneObj)
    {
        if (!SceneManager.GetSceneByName(sceneObj.name).isLoaded)
        {
            SceneManager.LoadScene(sceneObj.name, LoadSceneMode.Additive);
        }

      else if (sceneIndex < scenesArray.Length - 1)
        {
            sceneIndex++;
            LoadAreaScene(scenesArray[sceneIndex]);
        }

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sceneIndex < scenesArray.Length - 1)
        {
            sceneIndex++;
            LoadAreaScene(scenesArray[sceneIndex]);
        }
    }
}
