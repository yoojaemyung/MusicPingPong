using UnityEngine;
using UnityEngine.SceneManagement;  // �� �ε��� ���ӽ����̽�

public class LoadScene : MonoBehaviour
{
    public string sceneName;  // �ν����Ϳ��� ������ �� �̸�

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
