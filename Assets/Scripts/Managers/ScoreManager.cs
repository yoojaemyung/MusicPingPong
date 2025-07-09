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

    // UI와 점수 변수 값과 연동
    private void Awake()
    {
        Text scoreText = GameObject.Find("Score(num)").GetComponent<Text>();
        ScoreText = scoreText;
    }


    // 점수 추가하는 함수
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    // UI 갱신용 함수
    private void UpdateScoreUI()
    {
        if(ScoreText != null)
            ScoreText.text = _score.ToString();
    }
}
