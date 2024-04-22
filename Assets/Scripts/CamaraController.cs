using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamaraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera myCamera;
    private GameController gameController;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
        gameController.SeSpameoPlayer += SettearCamara;
    }
    void Start()
    {
        
        
    }

    public void SettearCamara(GameObject target)
    {
        Debug.Log("SE INCIAN CAMARA");
        myCamera.LookAt = target.transform;
        myCamera.Follow= target.transform;
    }
}
