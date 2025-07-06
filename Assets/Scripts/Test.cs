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
        
    }
}
