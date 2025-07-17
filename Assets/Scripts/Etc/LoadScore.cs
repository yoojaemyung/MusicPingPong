using UnityEngine;
using UnityEngine.UI;

public class LoadScore : MonoBehaviour
{
    public Text ScoreText;

    private void Start()
    {
        ScoreText.text += ScoreManager.Instance.Score.ToString();
    }
}