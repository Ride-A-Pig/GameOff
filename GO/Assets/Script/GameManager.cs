using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager _instance;
    public static GameManager getInstance()
    {
        if(_instance==null)
        {
            Debug.LogError("NotHaveInstance");

        }
        return _instance;
    }
    private UIManager _uIManager;
    public UIManager uIManager { get => _uIManager; }

    private SceneControl _sceneControl;
    public SceneControl sceneControl { get => _sceneControl; }

    public HorrorScenePanel horrorScenePanel;
    public LoveScenePanel LoveScenePanel;
    public DisasterScenePanel disasterScenePanel;

    public float timer=0;
    public float interval = 5f;

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
        }
        else
        {
            GameManager.Destroy(this.gameObject);
        }
        _uIManager = new UIManager();
        _sceneControl = new SceneControl();
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
        LoveScenePanel = new LoveScenePanel();
        uIManager.push(LoveScenePanel);
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(uIManager.sta_ui.Count>0&& uIManager.sta_ui.Peek().uIType.Name=="StartPanel")
            {
                uIManager.pop(false);
            }
            else
            {
                uIManager.push(new StartPanel());
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (uIManager.sta_ui.Count > 0 && uIManager.sta_ui.Peek().uIType.Name == "HorrorScenePanel")
            {
                uIManager.pop(true);
                horrorScenePanel = null;
            }
            else
            {
                uIManager.pop(true);
                horrorScenePanel = new HorrorScenePanel();
                uIManager.push(horrorScenePanel);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (uIManager.sta_ui.Count > 0 && uIManager.sta_ui.Peek().uIType.Name == "DisasterScenePanel")
            {
                uIManager.pop(true);
                disasterScenePanel = null;
            }
            else
            {
                uIManager.pop(true);
                disasterScenePanel = new DisasterScenePanel();
                uIManager.push(disasterScenePanel);
            }
        }
        if(disasterScenePanel!=null&&disasterScenePanel.isPlaying==false)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        //Debug.Log(timer);
        if(timer>interval)
        {
            disasterScenePanel.doNothing();
            timer = 0;
        }
    }
}
