using UnityEngine;
using UnityEngine.EventSystems;

public class PlayButtonSound : MonoBehaviour, IPointerClickHandler
{
    private string _soundPath = "click";

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.Play(_soundPath, Define.Sound.UI);
    }
}
