using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIMethod 
{
    /// <summary>
    /// 获取当前场景下的画布
    /// </summary>
    /// <returns></returns>
    public static GameObject getCanves()
    {
        GameObject canves = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(canves==null)
        {
            Debug.LogError("Cannot find Canves");
        }
        return canves;
    }
    /// <summary>
    /// 寻找在这个物体下面的子物体
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="nameChildren">子物体的名字</param>
    /// <returns></returns>
    public static GameObject findObjInChildren(GameObject panel,string nameChildren)
    {
        Transform[] ts = panel.GetComponentsInChildren<Transform>();
        foreach (var item in ts)
        {
            if(item.gameObject.name==nameChildren)
            {
                return item.gameObject;
            }
        }
        Debug.LogError($"NotFindChildren:{nameChildren}");
        return null;
    }
    /// <summary>
    /// 从当前物体获取组件
    /// </summary>
    /// <typeparam name="T">组件名字</typeparam>
    /// <param name="panel">父物体</param>
    /// <returns></returns>
    public static T AddOrGetComponent<T> (GameObject panel) where T:Component
    {
        T target = panel.GetComponent<T>();
        
        if(target==null)
        {
            Debug.LogError($"NotFindConponent:{panel.name}");
            target=panel.AddComponent<T>();
        }
        return target;
    }
    /// <summary>
    /// 从当前物体的子物体获得组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <param name="panel">父物体</param>
    /// <param name="nameChildren"></param>
    /// <returns></returns>
    public static T AddOrGetComponentInChildren<T>(GameObject panel,string nameChildren) where T:Component
    {
        GameObject obj = findObjInChildren(panel,nameChildren);
        T target = obj.GetComponent<T>();
        if (target == null)
        {
            Debug.LogError($"NotFindConponent:{obj.name}");
            target = obj.AddComponent<T>();
        }
        return target;
    }
}
