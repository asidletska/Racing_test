using TMPro;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI timerText;
   private float currentTime;
   private bool isRunning;

   private void Update()
   {
      if (!isRunning) return;

      currentTime += Time.deltaTime;
      UpdateUI();
   }

   public void StartTimer()
   {
      currentTime = 0f;
      isRunning = true;
   }

   public void StopTimer()
   {
      isRunning = false;
   }

   public float GetTime()
   {
      return currentTime;
   }

   private void UpdateUI()
   {
      int minutes = Mathf.FloorToInt(currentTime / 60);
      int seconds = Mathf.FloorToInt(currentTime % 60);
      int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 100);

      timerText.text = string.Format("{0:00}:{1:00}:{2:00}", 
         minutes, seconds, milliseconds);
   }
}
