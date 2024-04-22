using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class GameController : MonoBehaviour
{
    public string nameScene="World1";
    public int NextScene = 0;
    [SerializeField] Button[] botonesColors;
    [SerializeField] Button[] botonesNavesSelection;
    [SerializeField] Prefabs_SO[] naves;
    private StyleSystem _styleSystem;
    public Action<GameObject> SeSpameoPlayer;
    public Action<Transform> PosPlayer;

    [Header("PanelCofig")]
    public Button[] btnSettignsColors;
    public GameObject pnlSettignsColors;
    private bool panelActivado = false;
    private void Awake()
    {
    }
    void Start()
    {
        _styleSystem=GetComponent<StyleSystem>();
        if (botonesColors != null)
        {
            for (int i = 0; i < botonesColors.Length; i++)
            {
                int id = i;
                botonesColors[i].onClick.AddListener(delegate () { _styleSystem.ChangeColor(id); });
            }
        }
        if (botonesNavesSelection != null)
        {
            for (int i = 0; i < botonesNavesSelection.Length; i++)
            {
                int id = i;
                botonesNavesSelection[i].onClick.AddListener(delegate () { PressButtonPrefabs(id); });
            }
            
        }
        if(btnSettignsColors != null)
        {
            for (int i = 0; i < btnSettignsColors.Length; i++)
            {
                btnSettignsColors[i].onClick.AddListener(delegate () { ActivarPanel(); });
            }
        }
        
        SpawmPlayer();       
        SceneGlobalManager.Instance.LoadScene("SplashScreen");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneGlobalManager.Instance.ChangeScene(NextScene);

        }
    }
    void ActivarPanel()
    {
        if (panelActivado)
        {
            pnlSettignsColors.SetActive(false);
            panelActivado = false;
        }
        else
        {
            pnlSettignsColors.SetActive(true);
            panelActivado = true;
        }
    }
    void PressButtonPrefabs(int id)
    {
        if (naves != null)
        {
            naves[naves.Length - 1].id = id;
            naves[naves.Length - 1].estatico = false;
        }      
        SceneGlobalManager.Instance.UnloadScene(nameScene);
        SceneGlobalManager.Instance.ChangeScene(NextScene);

    }
    void SpawmPlayer()
    {
        if (SceneGlobalManager.Instance.sceneIsLoaded)
        {
            if (naves != null)
            {
                GameObject tmp = Instantiate(naves[naves[naves.Length - 1].id].nave);
                tmp.GetComponent<MovementController>().estatico = naves[naves.Length - 1].estatico;
                SeSpameoPlayer?.Invoke(tmp);
                PosPlayer?.Invoke(tmp.transform);
            }           
        }
    }
    public void ReinicarJUego()
    {
        SceneGlobalManager.Instance.UnloadScene("Results");
        SceneGlobalManager.Instance.LoadScene("Inicio");
        SceneGlobalManager.Instance.UnloadScene("SplashScreen");
        SceneGlobalManager.Instance.UnloadScene("SplashScreen");
    }
}
