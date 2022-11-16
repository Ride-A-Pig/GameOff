using UnityEngine;

/// <summary>
/// 瞄准系统
/// </summary>
public class AimSystem : MonoBehaviour
{
    public static AimSystem Instance { get; private set; }

    private void Awake() => Instance = this;

    public  bool canOpr = true;
    
    /// <summary>
    /// 当前所瞄准的物体
    /// </summary>
    public IAimableObject CurrentAimableObject { get; private set; }
    //射线
    Ray ray;
    //是否检测到碰撞
    bool isHit;
    //碰撞信息
    RaycastHit hit;

    private void Update()
    {
        //从主相机视角中央发出射线
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);
        //是否检测到碰撞
        isHit = Physics.Raycast(ray, out hit);
        
        Debug.DrawRay(ray.origin,ray.direction, Color.red);
        if (isHit)
        {
            /*  所检测到的物体是否继承 IAimableObject 接口
             *  即是否为可瞄准物体   
             */
            GameObject aimTarget = hit.collider.gameObject;
            print(aimTarget.name);
            IAimableObject aimObject = aimTarget.GetComponent<IAimableObject>();


            //如果与当前可瞄准物体不一致 表示检测到新的可瞄准物体
            if (aimObject != CurrentAimableObject)
            {
                /* 
                 * 如果上一个可瞄准物体不为空  执行其瞄准离开事件
                 * 将当前可瞄准物体 赋值为新检测到的
                 * 执行当前可瞄准物体的 瞄准进入事件
                 */
                CurrentAimableObject?.OnAimExit();
                CurrentAimableObject = aimObject;
                CurrentAimableObject?.OnAimEnter();
            }
            //如果点击鼠标左键且当前可瞄准物体不为空  执行其鼠标点击事件
            if(Input.GetMouseButtonDown(0)&&canOpr)
            {
                CurrentAimableObject?.DoInteract();
            }
            
        }
        /* 
         * 此处表示没有碰撞信息
         * 如果当前可瞄准物体不为空
         * 执行其瞄准离开事件 并将其置为空
         */
        else
        {
            if (null != CurrentAimableObject)
            {
                CurrentAimableObject.OnAimExit();
                CurrentAimableObject = null;
            }
        }
        //如果当前可瞄准物体不为空 不停执行其瞄准停留事件
        CurrentAimableObject?.OnAimStay();
    }

    private void OnDestroy()
    {
        Instance = null;
       
    }
}
