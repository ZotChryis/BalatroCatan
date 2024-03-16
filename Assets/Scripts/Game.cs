using System;
using Utility;
using Random = UnityEngine.Random;

/// <summary>
/// This class acts as a ServiceLocator root and can be statically accessed via Game.Instance.
/// </summary>

public class Game : SingletonMonoBehavior<Game>
{
    public static Game Instance => ((Game)InternalInstance);

    // Static data refs
    public Tile[] Tiles;
    
    // Mono Game Systems
    public MapGenerator MapGenerator;
    
    // Non-Mono Game Systems... these probably need to be in a real ServiceLocator long term. For now I am just hacking all
    // stuff inside of this huge Game class
    public StateMachine StateMachine = new StateMachine();
    public Hand Hand = new Hand();
    public Deck Deck = new Deck();
    
    public void Awake()
    {
        MapGenerator.Initialize();
    }

    public void Start()
    {
        // Start the game in the setup phase
        StateMachine.ChangeState(new StateSetup());
    }

    public void Update()
    {
        StateMachine.Update();
    }
}
