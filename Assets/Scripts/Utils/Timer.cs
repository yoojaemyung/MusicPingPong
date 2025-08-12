using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimeText;

    private float _timer = 0f;
    private int _displayTime = 30;
    private string _endScene = "3. End";


    void Start()
    {
        TimeText = GameObject.Find("Time(num)").GetComponent<Text>();
        UpdateTimeUI(_displayTime);
    }

    void Update()
    {
        if (_displayTime <= 0)
            return;

        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _timer -= 1f;
            _displayTime--;
            UpdateTimeUI(_displayTime);

            if (_displayTime == 0)
            {
                SceneManager.Instance.LoadScene(_endScene);
            }
        }
    }

    void UpdateTimeUI(int time)
    {
        TimeText.text = time.ToString();
    }
}
