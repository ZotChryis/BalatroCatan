using Random = UnityEngine.Random;

/// <summary>
/// This class acts as a ServiceLocator root and can be statically accessed via Game.Instance.
/// </summary>

public class Game : SingletonMonoBehavior<Game>
{
    public static Game Instance => ((Game)InternalInstance);

    // Static data refs
    public Tile[] Tiles;
    
    // Game Systems 
    public Hand Hand = new Hand();

    public void Start()
    {
        //  Test: Add a few cards to the hand
        for (int i = 0; i < 8; i++)
        {
            Hand.AddTile(Tiles[Random.Range(0, Tiles.Length)]);
        }
    }
}
