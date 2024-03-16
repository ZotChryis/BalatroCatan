using System;
using System.Collections.Generic;

public class Hand
{
    public Action<Tile> OnTileAdded;
    public Tile Selected;
    
    private List<Tile> m_tiles = new List<Tile>();
    
    public void AddTile(Tile tile)
    {
        m_tiles.Add(tile);
        OnTileAdded?.Invoke(tile);
    }
}
