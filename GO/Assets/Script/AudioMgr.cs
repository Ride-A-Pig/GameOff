using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// “Ù∆µπ‹¿Ì
/// </summary>
public class AudioMgr : MonoBehaviour
{
    AudioSource bgmSource;
    AudioSource shotSource;
    public static AudioMgr _instance;
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
        bgmSource = gameObject.AddComponent<AudioSource>();
        bgmSource.loop = true;
        shotSource = gameObject.AddComponent<AudioSource>();
        shotSource.loop = false;
        bgmSource.volume = 0.5f;
        shotSource.volume = 0.5f;
    }

    public void playBGM(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        bgmSource.clip = clip;
        if(!bgmSource.isPlaying)
        bgmSource.Play();
    }
    /// <summary>
    /// ±Ì ¿ΩÁ“Ù¿÷
    /// </summary>
    public void playLoveBGM()
    {
        playBGM("∞Æ«È“Ù¿÷");
    }
    public void playHorrorBGM()
    {
        playBGM("ø÷≤¿“Ù¿÷");
    }
    public void playDisasterBGM()
    {
        playBGM("‘÷ƒ—“Ù¿÷");
    }
    public void playChangeBGM()
    {
        playClip("≥°æ∞«–ªª");
    }
    /// <summary>
    /// ≤•∑≈“Ù–ß
    /// </summary>
    /// <param name="name"></param>
    public void playClip(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/" + name);
        if(!shotSource.isPlaying)
        shotSource.PlayOneShot(clip);
    }
}
