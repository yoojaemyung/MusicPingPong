using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SoundManager : MonoBehaviour
{
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    public AudioSource[] AudioSources = new AudioSource[(int)Define.Sound.MaxCount];

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
    public void Play(string path, Define.Sound type = Define.Sound.Default, float pitch = 1.0f, float volume = 1f)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;
        if (_audioClips.TryGetValue(path, out audioClip) == false)
        {
            audioClip = ResourceManager.Instance.Load<AudioClip>(path);
            _audioClips.Add(path, audioClip);
        }

        if (audioClip == null)
        {
            Debug.Log($"AudioClip Missing ! {path}");
        }

        AudioSource audioSource = AudioSources[(int)type];
        audioSource.pitch = pitch;
        audioSource.volume = volume;

        // BGM 설정
        if (type == Define.Sound.Bgm)
        {
            audioSource.Play();
        }
        // 효과음 설정
        else if (type == Define.Sound.Effect)
        {
            audioSource.PlayOneShot(audioClip); 
        }
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