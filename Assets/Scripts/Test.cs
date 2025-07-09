using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        _ = GameManager.Instance;
        GameManager.Instance.Input.TestMethod();
    }

    void Update()
    {
        // >> 점수 추가하는 방법
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScoreManager.Instance.AddScore(1);
        }
    }
}
