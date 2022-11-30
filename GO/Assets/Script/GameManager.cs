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
    public Script_StartUI script_StartUI;

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
        script_StartUI = GetComponent<Script_StartUI>();
    }
    private void Start()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
    }
    private void Update()
    {
        if (disasterScenePanel != null && disasterScenePanel.isPlaying == false)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        //Debug.Log(timer);
        if (disasterScenePanel!=null&&timer>interval&&!disasterScenePanel.isPlaying)
        {
            disasterScenePanel.doNothing();
            timer = 0;
        }
        if(disasterScenePanel!=null&& disasterScenePanel.a&& !disasterScenePanel.isPlaying)
        {
            disasterScenePanel.bulbClick();
            //disasterScenePanel.a = false;
        }
        BasePanel cur = null;
        if (UIManager.getInstance().sta_ui.Count>0)
        {
            AudioMgr.Instance.playBg("InGameBackground");
            cur = UIManager.getInstance().sta_ui.Peek();
            if(!(cur is DisasterScenePanel))
            {
                if (cur.isPlaying)
                {
                    cur.cg.interactable = false;
                }
                else
                {
                    cur.cg.interactable = true;
                }
            }
            else
            {
                if(cur.a&&!cur.isPlaying)
                {
                    cur.a = false;
                    (cur as DisasterScenePanel).f();
                }
            }
        }
        else
        {
            AudioMgr.Instance.playBg("MainMenuMusic");
        }
        
    }
    public void close(bool isClearAll)
    {
        UIManager.getInstance().pop(isClearAll);
    }
}
