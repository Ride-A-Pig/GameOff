using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIMethod 
{
    /// <summary>
    /// ��ȡ��ǰ�����µĻ���
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
    /// Ѱ����������������������
    /// </summary>
    /// <param name="panel"></param>
    /// <param name="nameChildren">�����������</param>
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
    /// �ӵ�ǰ�����ȡ���
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="panel">������</param>
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
    /// �ӵ�ǰ����������������
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <param name="panel">������</param>
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
