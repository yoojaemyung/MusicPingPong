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

    // 씬 로드시 구독한 함수 발동
    void Awake()
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
        GameObject scoreObj = GameObject.Find("Score(num)");
        if (scoreObj != null)
            ScoreManager.Instance.ScoreText = scoreObj.GetComponent<Text>();
    }
}
