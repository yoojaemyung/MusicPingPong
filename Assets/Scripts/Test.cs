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
        // >> ���� �߰��ϴ� ���
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScoreManager.Instance.AddScore(1);
        }
    }
}
