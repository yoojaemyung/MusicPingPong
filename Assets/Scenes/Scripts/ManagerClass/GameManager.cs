using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager Instance { get { Init(); return s_instance; } }

    public InputManager Input => InputManager.Instance;

    void Awake()
    {
        //Init();
    }

    static void Init()
    {
        if (s_instance != null)
            return;

        GameObject go = GameObject.Find("@Managers");

        if (go == null)
        {
            go = new GameObject { name = "@Managers" };
            go.AddComponent<GameManager>();

        }


        s_instance = go.GetComponent<GameManager>();
        
       
        DontDestroyOnLoad(go);

        _ = InputManager.Instance;
    }

}
