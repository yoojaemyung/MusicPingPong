using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager s_instance;
    public static ResourceManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject go = new GameObject("@ResourceManager");
                s_instance = go.AddComponent<ResourceManager>();
                DontDestroyOnLoad(go);
            }
            return s_instance;
        }
    }

    private void Awake() // 잘 생성되었는지 체크
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 경로에서 Resource Load 하기
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // Load한 GameObject 생성하기
    public GameObject Instantiate(string path, Vector3? pos = null, Quaternion? rot = null, Transform parent = null)
    {
        GameObject original = Resources.Load<GameObject>($"Prefabs/{path}");
        pos = pos ?? Vector3.zero;
        rot = rot ?? Quaternion.identity;

        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        return Object.Instantiate(original, (Vector3)pos, (Quaternion)rot, parent);
    }

    // GameObject 파괴하기
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}