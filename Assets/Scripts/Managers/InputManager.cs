using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager s_instance;
    public static InputManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = new GameObject("@InputManager");
                s_instance = go.AddComponent<InputManager>();
                DontDestroyOnLoad(go);
            }

            return s_instance;
        }

    }


    public event Action<Vector2> GetArrowInput;
    public event Action GetSpaceInput;


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 Arrowkey = new Vector2(x, y).normalized;

        if (Arrowkey != null)
        {
            GetArrowInput?.Invoke(Arrowkey);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            GetSpaceInput?.Invoke();
        }


        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Å°´Ù¿î ");
        }
    }

    public void TestMethod()
    {
        Debug.Log("¤¡¤¡");
    }
}
