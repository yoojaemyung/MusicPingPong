using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    // Sound 타입 최대값 필요
    public AudioSource[] AudioSources; // = new AudioSource[(int)Define.Sound.MaxCount];

    private static SoundManager s_instance;
    public static SoundManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = new GameObject("@SoundManager");
                s_instance = go.AddComponent<SoundManager>();
                DontDestroyOnLoad(go);
            }
            return s_instance;
        }
    }

    // Sound 재생하기
    public void Play(string path, /*Define.Sound type = Define.Sound.Effect,*/ float pitch = 1.0f, float volume = 0.5f)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;
        if (_audioClips.TryGetValue(path, out audioClip) == false)
        {
            audioClip = GameManager.Instance.Resource.Load<AudioClip>(path);
            _audioClips.Add(path, audioClip);
        }

        if (audioClip == null)
        {
            Debug.Log($"AudioClip Missing ! {path}");
        }

        // --> Define으로 Sound 타입 정한 후 재생할 때 설정하는 곳
        
        //AudioSource audioSource = AudioSources[(int)Define.Sound.Bgm];
        //audioSource.pitch = pitch;
        //audioSource.volume = volume;
       
        //audioSource.PlayOneShot(audioClip); // 효과음
        //audioSource.Play(); // BGM
    }

    // Sound 멈추기
    public void Clear()
    {
        foreach (AudioSource audioSource in AudioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }

        _audioClips.Clear();
    }
}