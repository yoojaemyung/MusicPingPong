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


    // �� �ε�� ������ �Լ� �ߵ�
    void Start()
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
        // Score Text ã��
        GameObject scoreObj = GameObject.Find("Score(num)");
        if (scoreObj != null)
            ScoreManager.Instance.ScoreText = scoreObj.GetComponent<Text>();

        // Sound ����
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
