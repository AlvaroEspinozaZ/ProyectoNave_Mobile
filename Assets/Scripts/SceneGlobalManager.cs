using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneGlobalManager : MonoBehaviour
{
    private static SceneGlobalManager instance;
    public static SceneGlobalManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("SceneGlobalManager");
                instance = go.AddComponent<SceneGlobalManager>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }


    public string[] sceneNames;
    public int[] sceneId;
    public bool sceneIsLoaded = false;


    private void Start()
    {
        //Solo dan Info...supongo q para seguimiento...?
        //Este evento sirve para decirme si una escena cambia , es decir recibe 2 escenas, la anterior y luego la nueva,
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
        //Esta solo sirve para cuando se cargar escena y bota el modo de carga, no se para q usarlo
        SceneManager.sceneLoaded += OnSceneLoaded;
        //Esta solo me dice si una escena se quita
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    void OnActiveSceneChanged(Scene oldScene, Scene newScene)
    {
        //Debug.Log("Se cambió la escena activa.");
        //Debug.Log("Escena anterior: " + oldScene.name);
        //Debug.Log("Nueva escena: " + newScene.name);
        if (newScene.name == "GamePlay")
        {
            sceneIsLoaded = true;
        }
        else
        {
            sceneIsLoaded = false;
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Se cargó una nueva escena.");
        //Debug.Log("Nombre de la escena: " + scene.name);
        //Debug.Log("Modo de carga: " + mode);
        
    }
    void OnSceneUnloaded(Scene scene)
    {
        //Debug.Log("Se descargó una escena.");
        //Debug.Log("Nombre de la escena: " + scene.name);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);

    }
}
