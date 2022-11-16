using System.Collections;
using System.Collections.Generic;
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
        uIManager.push(new StartPanel());
        //SceneControl.getInstance().Load(Scene0.nameScene, new Scene0());
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
    }
}
