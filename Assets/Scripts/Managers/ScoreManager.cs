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

    //private void Awake() // �̰� ���� ������ �� ����? �巡�� ���Ϸ��� �ּ��ϰŰ�����
    //{
    //    Text scoreUI = GameObject.Find("Score(num)").GetComponent<Text>();
    //    Init(scoreUI);
    //}
    //�׽�Ʈ ��� �۵��� �Ȱ��� �� �˴ϴ�.

    public void Init(Text scoreText)
    {
        ScoreText = scoreText;
    }

    // ���� �߰��ϴ� �Լ�
    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreUI();
    }

    // UI ���ſ� �Լ�
    private void UpdateScoreUI()
    {
        if(ScoreText != null)
            ScoreText.text = Score.ToString();
    }
}
