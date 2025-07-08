using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager s_instance;
    public static ScoreManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = new GameObject("@ScoreManager");
                s_instance = go.AddComponent<ScoreManager>();
                DontDestroyOnLoad(go);      
            }
            return s_instance;
        }
    }

    public int Score { get; private set; }
    public Text ScoreText;

    //private void Awake() // 이게 낫지 않을까 란 생각? 드래그 안하려면 최선일거같은데
    //{
    //    Text scoreUI = GameObject.Find("Score(num)").GetComponent<Text>();
    //    Init(scoreUI);
    //}
    //테스트 결과 작동은 똑같이 잘 됩니다.

    public void Init(Text scoreText)
    {
        ScoreText = scoreText;
    }

    // 점수 추가하는 함수
    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreUI();
    }

    // UI 갱신용 함수
    private void UpdateScoreUI()
    {
        if(ScoreText != null)
            ScoreText.text = Score.ToString();
    }
}
