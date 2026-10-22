using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerTutorial : MonoBehaviour
{
    private void Update()
    {
        if (!TutorialManager.Instance.IsTutorialActive())
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            TutorialManager.Instance.CompleteStep(TutorialTriggerType.PressGas);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            TutorialManager.Instance.CompleteStep(TutorialTriggerType.TurnLeft);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TutorialManager.Instance.CompleteStep(TutorialTriggerType.TurnRight);
        }
    }
}
