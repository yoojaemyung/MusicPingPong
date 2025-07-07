using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ = GameManager.Instance;
        GameManager.Instance.Input.TestMthod();
    }

    // Update is called once per frame
    void Update()
    {
        // >> 점수 추가하는 방법
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.Score.AddScore(1);
        }
    }
}
