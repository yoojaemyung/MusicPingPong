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

    private int _score;
    public Text ScoreText;


    public int Score
    {
        get { return _score; }
    }


    // UI 갱신용 함수
    private void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = _score.ToString();
    }

    // 점수 추가하는 함수
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    // 재시작시 점수 초기화용 함수
    public void ResetScore()
    {
        _score = 0;
        UpdateScoreUI();
    }
}
