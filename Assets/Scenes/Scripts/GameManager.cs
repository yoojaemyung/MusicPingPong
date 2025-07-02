using UnityEngine;

public class GameManager: MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager Instance { get { Init();  return s_instance; } }
    void Awake()
    {
        Init();
    }

    void Update()
    {
        
    }


    static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if(go == null)
        {
            go = new GameObject { name = "@Managers" };
            go.AddComponent<GameManager>();
        }

        DontDestroyOnLoad(go);
        s_instance = go.GetComponent<GameManager>();
    }
}
