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


    private void Start()
    {
        _sequence = new();
        _sequence.CreateSequence();
    }

    private void PlayerArrowInput(Direction dir)
    {
        Debug.Log("플레이어 방향키 인풋 " + dir);

        bool PlayerInput = _sequence.CheckInput(dir);

        if(PlayerInput)
        {

            if(_sequence.IsComplete)
            {
                // 9개 완료
                _sequence.CreateSequence();
            }
        }
        else
        {
            // 오답처리
        }
    }
}
