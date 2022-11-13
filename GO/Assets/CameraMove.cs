using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class CameraMove : MonoBehaviour
{
    public Camera camera;
    public static CameraMove instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        camera = GetComponent<Camera>();
    }
    private void Update()
    {
        if (camera.enabled)
        {
            //鼠标中键相机移动
            if (Input.GetMouseButton(2))
            {
                float changeX = Input.GetAxis("Mouse X")*Time.deltaTime;
                float changeY = Input.GetAxis("Mouse Y")*Time.deltaTime;
                transform.Translate(Vector3.left * changeX);
                transform.Translate(Vector3.down * changeY);
            }
            //鼠标滑轮滑动相机镜头远近逻辑
            float mouseEnter = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(Vector3.forward * Time.deltaTime * mouseEnter * 700);
            //鼠标右键相机旋转逻辑
            if (Input.GetMouseButton(1))
            {
                float changeX = Input.GetAxis("Mouse X");
                float changeY = Input.GetAxis("Mouse Y");
                Vector3 camVec = transform.rotation.eulerAngles;
                Vector3 angleVec = new Vector3(-changeY * 2, changeX * 2, 0);
                camVec += angleVec;
                camVec = new Vector3(Mathf.Clamp(camVec.x, -85, 85), camVec.y, camVec.z);//限制角度，避免万向锁
                transform.eulerAngles = camVec;
            }
        }
    }
}


