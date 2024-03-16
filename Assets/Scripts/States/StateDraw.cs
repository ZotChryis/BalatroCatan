using UnityEngine;
using Utility;

public class StateDraw : IState
{
    public void Enter()
    {
        // temp: just add stuff to the hand. this is super bad lol
        for (int i = 0; i < 5; i++)
        {
            Game.Instance.Hand.AddTile(Game.Instance.Tiles[Random.Range(0, Game.Instance.Tiles.Length)]);
        }
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}
