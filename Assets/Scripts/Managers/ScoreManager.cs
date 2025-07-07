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
