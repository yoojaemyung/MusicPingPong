using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

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



    public event Action<Direction> OnArrowInput;
    public event Action OnSpaceInput;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
            OnArrowInput?.Invoke(Direction.Up);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            OnArrowInput?.Invoke(Direction.Down);
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            OnArrowInput?.Invoke(Direction.Left);
        else if ( Input.GetKeyDown(KeyCode.RightArrow))
            OnArrowInput?.Invoke(Direction.Right);


        if (Input.GetKey(KeyCode.Space))
        {
            OnSpaceInput?.Invoke();
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
