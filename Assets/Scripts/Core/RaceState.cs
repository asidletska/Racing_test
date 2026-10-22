
public class RaceState : IState
{
    private GameStateMachine _machine;
    private string _sceneAddress = "Race";
    public RaceState(GameStateMachine machine)
    {
        _machine = machine;
    }

    public void Enter()
    {
        ServiceLocator.Get<SceneLoader>().LoadScene("Race");
    }

    public void Exit()
    {
    }

    public void SetSceneAddress(string sceneAddress)
    {
        _sceneAddress = sceneAddress;
    }
}