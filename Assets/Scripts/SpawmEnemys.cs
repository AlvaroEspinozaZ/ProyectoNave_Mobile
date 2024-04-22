    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmEnemys : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    public EnemyController prefabEnemy;

    public Transform PositionInitSpawm;
    public int poolSize = 30;
    public List<EnemyController> objetosActivos;
    public int id = 0;
    private void Awake()
    {
        objetosActivos = new List<EnemyController>();
        //gameController =GetComponent<GameController>();
        
        gameController.PosPlayer += DarTargetAlEnemy;
    }
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            EnemyController objeto = Instantiate(prefabEnemy, PositionInitSpawm.position,Quaternion.identity) ;
            objeto.gameObject.SetActive(false);
            objeto.target = PositionInitSpawm;
            objeto.Esconder += EsconderEnemy;
            objetosActivos.Add(objeto);
        }
    }
    void DarTargetAlEnemy(Transform target)
    {        
        StartCoroutine(SpamearEnemys(target));
    }

    IEnumerator SpamearEnemys(Transform target)
    {
              
        yield return new WaitForSecondsRealtime(3f);
        if (target != null)
        {
            objetosActivos[id].transform.position = PositionInitSpawm.position;
            objetosActivos[id].target = target.transform;
            objetosActivos[id].gameObject.SetActive(true);
            StartCoroutine(EsconderDespues(objetosActivos[id]));
        }
        id = (id + 1) % (objetosActivos.Count);
        gameController.PosPlayer?.Invoke(target);
    }
    public void EsconderEnemy(EnemyController enemyController)
    {
        enemyController.gameObject.SetActive(false);
        enemyController.transform.position = PositionInitSpawm.position;        
    }
    IEnumerator EsconderDespues(EnemyController en)
    {
        yield return new WaitForSecondsRealtime(12f);
        EsconderEnemy(en);
    }
}
