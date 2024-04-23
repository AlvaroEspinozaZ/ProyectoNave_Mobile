using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Controller : MonoBehaviour
{

    public Text score;
    public Text Maxscore;
    private float timer;
    public GlobalValues_SO _scoreSO;
    public GlobalValues_SO _MaxscoreSO;
    [Header("BalasUI")]
    public Button fire;
    public Button reload;
    public Slider barraBalas;
    public Text cantBalas;
    public float LasBalas = 70;
    public float denominadorBalas = 0;
    public float balasPorcentaje;
    [Header("VidaUI")]
    public Slider barraVida;
    public Text vidaNave;
    public float LaVida=70;
    public float denominadorLife = 0;
    public float vidaPorcentaje;

    [Header("Lose")]
    public Button dead;
    public GameObject panelLose;
    public Text scoreFinaltxt;
    public Button btnHome;

    [Header("NotisData")]
    public Notifs_SO notiScore;
    public Notifs_SO notiMaxScore;
    private MovementController _movementController;
    private GameController _gameController;
    private AimController _aimController;
    private NotificationSimple _notificationSimple;
    private void Awake()
    {

        _notificationSimple = GetComponent<NotificationSimple>();
         _gameController = GetComponent<GameController>();
        //btnHome.onClick.AddListener(delegate () { SceneGlobalManager.Instance.ChangeScene(5); });
        _gameController.SeSpameoPlayer += DarVidaTxt;
        _gameController.SeSpameoPlayer += DarBalasTxt;
    }
    void Start()
    {
        
        if (Maxscore != null)
        {
            Maxscore.text = "MaxScore: " + _MaxscoreSO.scoreGlobal;
        }
        if (fire != null)
        {
            _aimController.fire = fire;
        }
        if (reload != null)
        {
            _aimController.reload = reload;
        }
        if (dead != null)
        {
            dead.onClick.AddListener(delegate () { PressDied(); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (score != null)
        {
            score.text = "Score: " + (int)timer;
        }
    }

    void DarVidaTxt(GameObject gameObject)
    {
        _aimController = gameObject.GetComponent<AimController>();
        _movementController = gameObject.GetComponent<MovementController>();
        _movementController.ActualizarVidaUI += ActualizarVIdaUI;
        _movementController.ActualizarVidaUI += OnLoseUI;
        LaVida = _movementController.life;
        vidaPorcentaje = (LaVida / LaVida);
        barraVida.value = vidaPorcentaje;
        balasPorcentaje = (LasBalas / LasBalas);
        barraBalas.value = balasPorcentaje;
        denominadorLife = _movementController.life;
        vidaNave.text = "" + _movementController.life;
    }
    void OnLoseUI(MovementController movementController, EnemyController enemyController)
    {
        if(movementController.life <= 0)
        {
            enemyController.gameObject.SetActive(true);
            PressDied();
        }
    }
    void PressDied()
    {
        _scoreSO.scoreGlobal = (int)timer;

        if (_MaxscoreSO.scoreGlobal < _scoreSO.scoreGlobal)
        {
            _MaxscoreSO.scoreGlobal = _scoreSO.scoreGlobal;
            //_notificationSimple.NewMaxScore(_MaxscoreSO.scoreGlobal);
            _notificationSimple.SendNotification(notiMaxScore);
        }
        //panelLose.SetActive(true);
        //_notificationSimple.NotiGameOver(_scoreSO.scoreGlobal);
        _notificationSimple.SendNotification(notiScore);
        scoreFinaltxt.text = "ScoreMax:" + _MaxscoreSO.scoreGlobal;
        SceneGlobalManager.Instance.UnloadScene("GamePlay");
        SceneGlobalManager.Instance.LoadScene("Results");
    }
    void ActualizarVIdaUI(MovementController movementController,EnemyController enemyController)
    {
        vidaPorcentaje -= (enemyController.damage/ denominadorLife);
        vidaNave.text = ""+ movementController.life;
        barraVida.value = vidaPorcentaje;
    }

    void DarBalasTxt(GameObject gameObject)
    {
        _aimController = gameObject.GetComponent<AimController>();
        denominadorBalas = _aimController.poolSize;
        _aimController.ActualizarBalasUI += ActualizarBalasUI;
        _aimController.ReloadBalasUI += ActualizarRecargaBalasUI;
        LasBalas = _aimController.poolSize;
        cantBalas.text = "" + _aimController.poolSize;
    }

    void ActualizarBalasUI(AimController aimController)
    {        
        balasPorcentaje -= (1/ denominadorBalas);
        cantBalas.text = "" + aimController.balasUsed;
        barraBalas.value = balasPorcentaje;

    }
    void ActualizarRecargaBalasUI(AimController aimController)
    {
        balasPorcentaje =1;
        cantBalas.text = "" + aimController.poolSize;
        barraBalas.value = balasPorcentaje;

    }
}
