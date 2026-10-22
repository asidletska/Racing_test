using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TutorialStepData 
{
    public string message;

    public UnityEvent onStepStart;
    public UnityEvent onStepComplete;

    public TutorialTriggerType triggerType;
}

public enum TutorialTriggerType
{
    PressGas,
    TurnLeft,
    TurnRight,
    ReachFinish
}
