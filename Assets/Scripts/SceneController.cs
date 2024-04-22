using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int idScene;
    public string nameScene;
    public bool isLoadedScene;
    public bool isDirty;
    private void Start()
    {
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }
    void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        Debug.Log("Se cambió la escena activa.");
        Debug.Log("Escena anterior: " + oldScene.name);
        Debug.Log("Nueva escena: " + newScene.name);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        //SceneManager.activeSceneChanged(sceneName, LoadSceneMode.Additive);
        //SceneManager.sceneLoaded(sceneName, LoadSceneMode.Additive);
        //SceneManager.sceneUnloaded(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
