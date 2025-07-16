using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionUI : MonoBehaviour
{
    [SerializeField] private List<GameObject> _arrowObjects = new(); 
    private List<Image> _arrowImages = new();
    [SerializeField] private DirectionSpriteTable _spriteTable;
    void Awake()
    {
        _arrowObjects.Clear();
        _arrowImages.Clear();

        for(int i = 0; i <  transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            _arrowObjects.Add(child);
            
            Image img = child.GetComponent<Image>();
            _arrowImages.Add(img);
        }

    }

    public void RenderSequence(List<Direction> sequence)
    {
        for (int i = 0; i < _arrowImages.Count; i++)
        {
            _arrowImages[i].sprite = _spriteTable.GetSprite(sequence[i]);
        }
    }
    
    public void SetCorrect(int index)
    {
        _arrowImages[index].color = new Color(1, 1, 1, 0.3f);
    }

    public void SetWrong(int index)
    {
        _arrowImages[index].color = Color.red;
    }


    public void ResetAll()
    {
        foreach (var img in _arrowImages)
        {
            img.color = Color.white;
        }
    }
}
