using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private static SceneManager s_instance;
    public static SceneManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = new GameObject("@SceneManager");
                s_instance = go.AddComponent<SceneManager>();
                DontDestroyOnLoad(go);
            }
            return s_instance;
        }
    }

    private string _startScene = "1. Start";
    private string _gameScene = "2. Game";
    private string _endScene = "3. End";


    // 씬 로드시 구독한 함수 발동
    void Start()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // 씬이름으로 로드
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    //// 추후에 페이드 인/아웃 효과 추가 가능
    //public void LoadSceneWithFade(string sceneName)
    //{
    //    Debug.Log("FadeOut 시작...");
    //    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    //}

   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Score Text 찾기
        GameObject scoreObj = GameObject.Find("Score(num)");
        if (scoreObj != null)
            ScoreManager.Instance.ScoreText = scoreObj.GetComponent<Text>();

        // Sound 설정
        if (scene.name == _startScene)
        {
            SoundManager.Instance.Play("startBGM", Define.Sound.Bgm, 0.4f);
        }
        else if(scene.name == _gameScene)
        {
            SoundManager.Instance.Play("gameBGM", Define.Sound.Bgm, 0.4f);
        }
        else if(scene.name == _endScene)
        {
            SoundManager.Instance.Clear();
            SoundManager.Instance.Play("gameover", Define.Sound.Effect, 0.5f);
        }
    }
}
