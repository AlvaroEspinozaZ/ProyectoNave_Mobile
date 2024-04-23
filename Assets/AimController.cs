using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class AimController : MonoBehaviour
{
    public Button fire;
    public Button reload;
    public BulletController prefabBullet;
    public int poolSize = 10;
    public List<BulletController> objetosActivos;
    public int id = 0;
    public int balasUsed = 0;
    public Action<AimController> ActualizarBalasUI;
    public Action<AimController> ReloadBalasUI;
    private void Awake()
    {
        objetosActivos = new List<BulletController>();
    }
    void Start()
    {
        fire.onClick.AddListener(delegate () { PressFire(); });
        reload.onClick.AddListener(delegate () { PressReload(); });
        balasUsed = poolSize;
        for (int i = 0; i < poolSize; i++)
        {
            BulletController objeto = Instantiate(prefabBullet, transform.position, Quaternion.identity);
            objeto.gameObject.SetActive(false);
            objeto.target = transform;
            objeto.Esconder += EsconderBullet;
            objetosActivos.Add(objeto);
        }
        ReloadBalasUI +=Reload;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PressFire();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            PressReload();
            
        }
    }
    public void PressFire()
    {
        Vector3 posInit = new Vector3(0, 1, 1);
        objetosActivos[id].transform.position = transform.position + posInit;

        if (balasUsed > -1)
        {
            objetosActivos[id].gameObject.SetActive(true);
            StartCoroutine(EsconderDespues(objetosActivos[id]));
            id = (id + 1) % (objetosActivos.Count);
            balasUsed--;
            ActualizarBalasUI?.Invoke(this);
        }
    }
    public void PressReload()
    {
        ReloadBalasUI?.Invoke(this); 
    }
    void Reload(AimController aim)
    {
        balasUsed = aim.poolSize;
    }
    public void EsconderBullet(BulletController bulletController)
    {
        Debug.Log("SeEsconde la bala");
        bulletController.gameObject.SetActive(false);
        bulletController.transform.position = transform.position;
    }

    IEnumerator EsconderDespues(BulletController b)
    {
        yield return new WaitForSecondsRealtime(12f);
        EsconderBullet(b);
    }
}
