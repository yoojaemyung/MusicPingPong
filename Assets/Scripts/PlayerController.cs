using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEventSubscriber
{
    public void SubscribeEvents()
    {
        InputManager.Instance.OnArrowInput += PlayerArrowInput;
        InputManager.Instance.OnSpaceInput += PlayerSpaceInput;
    }
    public void UnSubscribeEvents()
    {
        InputManager.Instance.OnArrowInput -= PlayerArrowInput;
        InputManager.Instance.OnSpaceInput -= PlayerSpaceInput;
    }

    private void OnEnable()
    {
        EventHelper.AutoSubscribe(this);
    }
    private void OnDisable()
    {
        EventHelper.AutoUnSubscribe(this);
    }

    private void PlayerArrowInput(Direction dir)
    {
        Debug.Log("플레이어 방향키 인풋");
        switch (dir)
        {
            case Direction.Up:
                break;
            case Direction.Down:
                break;
            case Direction.Left:
                break;
            case Direction.Right:
                break;

        }
        // 방향키 입력처리
    }

    private void PlayerSpaceInput()
    {
        Debug.Log("플레이어 스페이스 인풋");
        // 스페이스 인풋 처리
    }
}
