using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

// 씬 전환 파괴 x, 환경설정 유지하도록 구현
public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;

    private AudioSource bgmSound;
    public AudioClip bgmClip;

    private ObjectPool objectPool;
 
    [Range(0f, 1f)] public float volumBGM = 0.5f;
    [Range(0f, 1f)] public float volumSE = 0.5f;

    public float mouseSensitivity = 0.5f;

    public KeyCode interactionKey = KeyCode.E;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
        bgmSound = GetComponent<AudioSource>();

        bgmSound.volume = volumBGM;
        bgmSound.loop = true;

        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        ChangeBackGroundMusic(bgmClip);
    }

    private static void ChangeBackGroundMusic(AudioClip music)
    {
        Instance.bgmSound.Stop();
        Instance.bgmSound.clip = music;
        Instance.bgmSound.Play();
    }

    public static void PlayClip(AudioClip clip)
    {   
        GameObject obj = Instance.objectPool.SpawnFromPool("SoundSource");
        obj.SetActive(true);
        SoundSource soundSource = obj.GetComponent<SoundSource>();
        soundSource.Play(clip, Instance.volumSE);
    }

    public void VolumSet()
    {
        bgmSound.volume = volumBGM;
    }
}
