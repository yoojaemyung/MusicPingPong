using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public string GameScene;
    private string _startScene = "1. Start";

    public void LoadTargetScene()
    {
        if(GameScene == _startScene)
            ScoreManager.Instance.ResetScore();

        SceneManager.Instance.LoadScene(GameScene);
    }
}