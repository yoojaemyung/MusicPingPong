using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour, IEventSubscriber
{
    [SerializeField] private DirectionSequence _sequence;

    public void SubscribeEvents()
    {
        InputManager.Instance.OnArrowInput += PlayerArrowInput;
    }
    public void UnSubscribeEvents()
    {
        InputManager.Instance.OnArrowInput -= PlayerArrowInput;
    }

    private void OnEnable() => EventHelper.AutoSubscribe(this);
    private void OnDisable() => EventHelper.AutoUnSubscribe(this);


    private void PlayerArrowInput(Direction dir)
    {
        Debug.Log("�÷��̾� ����Ű ��ǲ");

        bool PlayerInput = _sequence.CheckInput(dir);

        if(PlayerInput)
        {

            if(_sequence.IsComplete)
            {
                // 9�� �Ϸ�
                _sequence.CreateRandom();
            }
        }
        else
        {
            // ����ó��
        }
    }
}
