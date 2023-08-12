using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FitnessCalculator : MonoBehaviour
{
   // kill count
   private float w1 = 1.5f;
   // APM
   private float w2 = 1.5f;
   // hits taken
   private float w3 = 3.0f;
   // time elapsed
   private float w4 = 1.5f;
   // hit miss ratio
   private float w5 = 2.5f;
   private float fitness;
   PlayerMetrics player;
   private string token = TokenManager.token;

   void Start() {
      player = GetComponent<PlayerMetrics>();
   }

   private void CalculateFitness() {
      fitness = 1.0f/10 * (weightedKillCount() + weightedAPM()  + weightedTimeElapsed() + weightedHitMissRatio() - weightedHitsTaken());
   }

   public float GetFitness() {
      CalculateFitness();
      StartCoroutine(PostStatistics());
      return fitness;
   }

   private float weightedKillCount() {
      return w1 * player.getKillMetrics;
   }

   private float weightedAPM() {
      return w2 * player.getAPMetrics;
   }

   private float weightedTimeElapsed() {
      return w4 * player.getTimerMetrics;
   }

   private float weightedHitMissRatio() {
      return w5 * player.getHitMissRatio;
   }

   private float weightedHitsTaken() {
      return w3 * player.getHitsTakenMetrics;
   }

   IEnumerator PostStatistics() {
      using (UnityWebRequest www = UnityWebRequest.Post(
         $"www.mdk2023.com/stage_two_stats?kills={player.getKillCount}&actions={player.getAPM}&timer={player.getTimer}&hits_taken={player.getHitsTaken}&total_damage_taken={player.getTotalDamageTaken}&hit_miss_ratio={player.getHitMissRatio}&token={token}", "", "application/json"))
      {
         www.SetRequestHeader("Content-Type", "application/json"); // Set content type for the data you're sending.
         www.SetRequestHeader("Accept", "application/json"); // Set the type of data you're expecting back.
         yield return www.SendWebRequest();

         if (www.result != UnityWebRequest.Result.Success)
         {
            Debug.Log(www.error);
         }
         else
         {
            Debug.Log("Post Statistics API Request complete!");
         }
      }
    }
}
