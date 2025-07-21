using System.Collections.Generic;
using UnityEngine;
using static Define;

public class SoundManager : MonoBehaviour
{
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

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    public AudioSource[] AudioSources = new AudioSource[(int)Define.Sound.MaxCount];


    public void Start()
    {
        // 시작시 각 사운드별 AudioSource가 있는 GameObj 생성
        for (int i = 0; i < AudioSources.Length; i++)
        {
            GameObject audioObj = new GameObject($"AudioSource_{((Define.Sound)i).ToString()}");
            audioObj.transform.parent = this.transform;
            AudioSources[i] = audioObj.AddComponent<AudioSource>();

            if ((Define.Sound)i == Define.Sound.Bgm)
            {
                AudioSources[i].loop = true;
            }
        }

        SoundManager.Instance.Play("startBGM", Define.Sound.Bgm, 0.4f);
    }


    // Sound 재생하기
    public void Play(string path, Define.Sound type, float volume = 1f, float pitch = 1.0f)
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
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        // 효과음 설정
        else
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