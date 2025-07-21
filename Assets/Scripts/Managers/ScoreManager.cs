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


    // UI ���ſ� �Լ�
    private void UpdateScoreUI()
    {
        if (ScoreText != null)
            ScoreText.text = _score.ToString();
    }

    // ���� �߰��ϴ� �Լ�
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    // ����۽� ���� �ʱ�ȭ�� �Լ�
    public void ResetScore()
    {
        _score = 0;
        UpdateScoreUI();
    }
}
