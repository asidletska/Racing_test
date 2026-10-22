using System;
using UnityEngine;

public class RaceCountDown : MonoBehaviour
{
      public event Action OnFinished;
    
        public void StartCountdown()
        {
            GetComponent<Animator>().SetTrigger("Start");
        }

        public void OnCountdownFinished()
        {
            OnFinished?.Invoke();
        }
}
