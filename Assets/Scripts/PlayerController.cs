using UnityEngine;

public class PlayerController : MonoBehaviour, IEventSubscriber
{
    public void SubscribeEvents()
    {
        InputManager.Instance.GetArrowInput += PlayerArrowInput;
        InputManager.Instance.GetSpaceInput += PlayerSpaceInput;
    }
    public void UnSubscribeEvents()
    {
        InputManager.Instance.GetArrowInput -= PlayerArrowInput;
        InputManager.Instance.GetSpaceInput -= PlayerSpaceInput;
    }

    private void OnEnable()
    {
        EventHelper.AutoSubscribe(this);
    }
    private void OnDisable()
    {
        EventHelper.AutoUnSubscribe(this);
    }
    void Start()
    {

    }


    void Update()
    {

    }

    private void PlayerArrowInput(Vector2 arrow)
    {
        Debug.Log("플레이어 방향키 인풋");
        // 방향키 입력처리
    }
    
    private void PlayerSpaceInput()
    {
        Debug.Log("플레이어 스페이스 인풋");
        // 스페이스 인풋 처리
    }
}
