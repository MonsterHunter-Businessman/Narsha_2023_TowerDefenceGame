using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public float masterVolumeSFX = 1f;
    public float masterVolumeBGM = 1f;
    public AudioClip[] BGMClip;
    public AudioClip[] SFXClip;

    public AudioSource sfxPlayer;
    public AudioSource bgmPlayer;
    public bgmClips bgmClip;
    public sfxClips sfxClip;
    
    public enum bgmClips
    {
        Clip_01,
        Clip_02,
        Clip_03
    }

    public enum sfxClips
    {
        sound1,
        sound2,
        sound3
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        
    }
    
    public void PlaySFXSound(sfxClips clip, float a_volume = 1f)
    {
        sfxPlayer.PlayOneShot(SFXClip[(int)clip], a_volume * masterVolumeSFX);
    }

    public void PlayBGMSound(bgmClips clip, float a_volume = 1f)
    {
        bgmPlayer.loop = true;
        bgmPlayer.clip = BGMClip[(int)clip];
        bgmPlayer.volume = masterVolumeBGM;
        bgmPlayer.Play();
    }

    public void StopBGM()
    {
        bgmPlayer.Stop();
    }

    #region 
    public void SetVolumeSFX(float a_volume)
    {
        masterVolumeSFX = a_volume;
    }

    public void SetVolumeBGM(float a_volume)
    {
        masterVolumeBGM = a_volume;
        bgmPlayer.volume = masterVolumeBGM;
    }

    public void SetMuteBGM()
    {
        bgmPlayer.mute = !bgmPlayer.mute;
    }
    #endregion
}