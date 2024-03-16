using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image m_icon;
    
    public Action OnSelected;
    public Tile Tile;
    
    public void Initialize(Tile tile)
    {
        Tile = tile;
        m_icon.sprite = tile.HandIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
    }

    public void Select()
    {
        OnSelected?.Invoke();
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
    }

    public void Deselect()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
