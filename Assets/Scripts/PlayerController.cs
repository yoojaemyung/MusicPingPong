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
        Debug.Log("�÷��̾� ����Ű ��ǲ");
        // ����Ű �Է�ó��
    }
    
    private void PlayerSpaceInput()
    {
        Debug.Log("�÷��̾� �����̽� ��ǲ");
        // �����̽� ��ǲ ó��
    }
}
