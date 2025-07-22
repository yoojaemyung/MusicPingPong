using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

public class DirectionController : MonoBehaviour, IEventSubscriber
{
    [SerializeField] private DirectionUI _ui;
    private DirectionSequence _sequence = new();
    private bool _canExchange = true;
     

    public void SubscribeEvents()
    {
        InputManager.Instance.OnArrowInput += ArrowInput;
    }
    public void UnSubscribeEvents()
    {
        InputManager.Instance.OnArrowInput -= ArrowInput;
    }

    private void OnEnable() => EventHelper.AutoSubscribe(this);
    private void OnDisable() => EventHelper.AutoUnSubscribe(this);

    void Start()
    {
        ResetSequence();
    }


    private void ArrowInput(Direction dir)
    {
        bool InputArrow = _sequence.CheckInput(dir);

        if (InputArrow)
        {
            _ui.SetCorrect(_sequence.nowIndex);

            if(_sequence.IsComplete)
            {
                ScoreManager.Instance.AddScore(20);
                StartCoroutine(DelayReset());
            }
        }
        else if (_canExchange) // ½ÇÆÐ
        {
            _ui.SetWrong(_sequence._currentIndex);
            _canExchange = false;
            StartCoroutine(DelayReset());
        }
    }

    private void ResetSequence()
    {
        _sequence.CreateSequence();
        _ui.ResetAll();
        _ui.RenderSequence(_sequence.GetSequence());
    }

    private IEnumerator DelayReset()
    {     
        yield return new WaitForSeconds(1f);
        ResetSequence();
        _canExchange = true;
    }

}
