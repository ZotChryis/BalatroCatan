using Utility;

public class StateSetup : IState
{
    public void Enter()
    {
        Game.Instance.MapGenerator.GenerateMap();
    }

    public void Update()
    {
        // Exit as soon as the map is generated. There is no callback for it, but ideally there is
        // When the map is done generating, we can move on to Draw
        Game.Instance.StateMachine.ChangeState(new StateDraw());
    }

    public void Exit()
    {
    }
}
