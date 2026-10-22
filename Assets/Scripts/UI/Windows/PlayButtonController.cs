using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class PlayButtonController : MonoBehaviour
    {
        [System.Serializable]
        private struct RaceButtonEntry
        {
            public Button button;
 
            [Tooltip("Must match the scene's Addressable address, not just its file name")]
            public string sceneAddress;
        }
 
        [Header("One entry per race/level button")]
        [SerializeField] private RaceButtonEntry[] raceButtons;
 
        private void Awake()
        {
            foreach (var entry in raceButtons)
            {
                // Capture entry.sceneAddress locally so each button
                // remembers its OWN scene, not just the last one in the loop.
                string sceneAddress = entry.sceneAddress;
                entry.button.onClick.AddListener(() => PlayRace(sceneAddress));
            }
        }
 
        private void PlayRace(string sceneAddress)
        {
            var stateMachine = ServiceLocator.Get<GameStateMachine>();
 
            stateMachine.GetState<RaceState>().SetSceneAddress(sceneAddress);
            stateMachine.Enter<RaceState>();
        }
    }
}
