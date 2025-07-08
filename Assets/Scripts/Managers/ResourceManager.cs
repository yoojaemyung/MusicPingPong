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

    private void Awake() // �� �����Ǿ����� üũ
    {
        if (s_instance != null && s_instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // ��ο��� Resource Load �ϱ�
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    // Load�� GameObject �����ϱ�
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

    // GameObject �ı��ϱ�
    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy(go);
    }
}