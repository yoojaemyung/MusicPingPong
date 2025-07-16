using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager s_instance;

    public bool CanInput = true;
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
    //public event Action OnSpaceInput;


    void Update()
    {
        if(CanInput)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                OnArrowInput?.Invoke(Direction.Up);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                OnArrowInput?.Invoke(Direction.Down);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                OnArrowInput?.Invoke(Direction.Left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                OnArrowInput?.Invoke(Direction.Right);
            else if (Input.GetKeyDown(KeyCode.Space))
                OnArrowInput?.Invoke(Direction.Spacebar);
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
