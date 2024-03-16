using UnityEngine;

[CreateAssetMenu]
public class Tile : ScriptableObject
{
    public enum ResourceType
    {
        Wood,
        Meat,
        Bread,
        Brick,
        Ore,
        Fish
    }
    
    public GameObject WorldPrefab;
    public Sprite HandIcon;
    public ResourceType Resource;
}

