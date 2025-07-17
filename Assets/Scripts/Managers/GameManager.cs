using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI; // text 때문에 추가


public class GameManager : MonoBehaviour
{
    static GameManager s_instance;
    public static GameManager Instance { get { Init(); return s_instance; } }

    public InputManager Input => InputManager.Instance;
    public ResourceManager Resource => ResourceManager.Instance;
    public SoundManager Sound => SoundManager.Instance;
    public ScoreManager Score => ScoreManager.Instance;
    public SceneManager Scene => SceneManager.Instance;


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
        _ = ResourceManager.Instance;
        _ = SoundManager.Instance;
        _ = ScoreManager.Instance;
        _ = SceneManager.Instance;
    }

}
