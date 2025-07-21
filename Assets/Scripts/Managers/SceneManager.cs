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

    // �� �ε�� ������ �Լ� �ߵ�
    void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }


    // ���̸����� �ε�
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }


    //// ���Ŀ� ���̵� ��/�ƿ� ȿ�� �߰� ����
    //public void LoadSceneWithFade(string sceneName)
    //{
    //    Debug.Log("FadeOut ����...");
    //    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    //}

   
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject scoreObj = GameObject.Find("Score(num)");
        if (scoreObj != null)
            ScoreManager.Instance.ScoreText = scoreObj.GetComponent<Text>();
    }
}
