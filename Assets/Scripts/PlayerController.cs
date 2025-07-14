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
        Debug.Log("�÷��̾� ����Ű ��ǲ");
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
        // ����Ű �Է�ó��
    }

    private void PlayerSpaceInput()
    {
        Debug.Log("�÷��̾� �����̽� ��ǲ");
        // �����̽� ��ǲ ó��
    }
}
