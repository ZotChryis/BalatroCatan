using System.Collections.Generic;
using UnityEngine;

public class UIHand : MonoBehaviour
{
    [SerializeField] private UITile m_prefab;

    [HideInInspector] public UITile Selected;

    private List<UITile> m_tiles = new List<UITile>();
    
    private void Awake()
    {
        Game.Instance.Hand.OnTileAdded += OnTileAdded;
    }

    private void OnTileAdded(Tile tile)
    {
        UITile uiTile = Instantiate(m_prefab, transform);
        uiTile.Initialize(tile);
        uiTile.OnSelected += () =>
        {
            OnTileSelcted(uiTile);
        };
        m_tiles.Add(uiTile);
    }

    private void OnTileSelcted(UITile uiTile)
    {
        foreach (var tile in m_tiles)
        {
            if (tile == uiTile)
            {
                continue;
            }
            
            tile.Deselect();
        }

        Selected = uiTile;
        Game.Instance.Hand.Selected = uiTile.Tile;
    }
}
