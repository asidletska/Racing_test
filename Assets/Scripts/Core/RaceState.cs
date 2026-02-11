
public class RaceState : IState
{
    private GameStateMachine _machine;

    public RaceState(GameStateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        ServiceLocator.Get<SceneLoader>().Load("Race");
    }

    public void Exit()
    {
    }
}