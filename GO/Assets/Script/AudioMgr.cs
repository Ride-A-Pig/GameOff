using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 音频管理
/// </summary>
public class AudioMgr : MonoBehaviour
{
    AudioSource bgmSource;
    AudioSource shotSource;
    AudioSource bgSource;
    private static AudioMgr _instance;
    public static AudioMgr Instance
    {
        get {
            if (_instance == null)
            {
                GameObject AudioObj = new GameObject("AudioObj");
                _instance = AudioObj.AddComponent<AudioMgr>();

            }
            return _instance;
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bgSource = gameObject.AddComponent<AudioSource>();
        bgSource.loop = true;
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        shotSource = gameObject.AddComponent<AudioSource>();
        shotSource.loop = false;
        bgmSource.volume = 0.5f;
        bgSource.volume = 0.5f;
        shotSource.volume = 1.5f;
    }
    public void playBg(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        print(bgSource);
        bgSource.clip = clip;
        if (!bgSource.isPlaying)
            bgSource.Play();
    }
    public void playBGM(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        bgmSource.clip = clip;
        if(!bgmSource.isPlaying)
        bgmSource.Play();
    }
    /// <summary>
    /// 表世界音乐
    /// </summary>
    public void playLoveBGM()
    {
        playBGM("爱情音乐");
    }
    public void playHorrorBGM()
    {
        playBGM("恐怖音乐");
    }
    public void playDisasterBGM()
    {
        playBGM("灾难音乐");
    }
    public void playChangeClip()
    {
        playClip("场景切换");
    }
    public void stop()
    {
        bgmSource.Stop();
    }
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    public  void playClip(string name)
    {
        
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        if(!shotSource.isPlaying)
        shotSource.PlayOneShot(clip);
        
    }
}
