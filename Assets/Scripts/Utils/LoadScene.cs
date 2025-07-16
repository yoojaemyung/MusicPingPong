using UnityEngine;
using UnityEngine.SceneManagement;  // 씬 로딩용 네임스페이스

public class LoadScene : MonoBehaviour
{
    public string sceneName;  // 인스펙터에서 설정할 씬 이름

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
