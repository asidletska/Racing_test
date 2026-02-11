
public class MenuState : IState
{
    private GameStateMachine _machine;

    public MenuState(GameStateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        ServiceLocator.Get<SceneLoader>().Load("Menu");
    }

    public void Exit() { }
}
