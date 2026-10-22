using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;

    [Header("Steps")]
    public TutorialStepData[] steps;

    [Header("UI")]
    public GameObject tutorialPanel;
    public TextMeshProUGUI tutorialText;

    private int currentStepIndex = 0;
    private bool tutorialActive = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (steps.Length > 0)
        {
            StartStep(0);
        }
    }

    void StartStep(int index)
    {
        currentStepIndex = index;

        tutorialPanel.SetActive(true);
        tutorialText.text = steps[index].message;

        steps[index].onStepStart?.Invoke();
    }

    public void CompleteStep(TutorialTriggerType trigger)
    {
        if (!tutorialActive) return;

        if (steps[currentStepIndex].triggerType != trigger) return;

        steps[currentStepIndex].onStepComplete?.Invoke();

        currentStepIndex++;

        if (currentStepIndex >= steps.Length)
        {
            EndTutorial();
            return;
        }

        StartStep(currentStepIndex);
    }

    void EndTutorial()
    {
        tutorialActive = false;
        tutorialPanel.SetActive(false);
        Debug.Log("Tutorial Finished");
    }

    public bool IsTutorialActive()
    {
        return tutorialActive;
    }
}
