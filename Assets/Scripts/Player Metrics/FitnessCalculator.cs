using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FitnessCalculator : MonoBehaviour
{
   private float w1 = 1.5f;
   private float w2 = 1.5f;
   private float w3 = 2.5f;
   private float w4 = 2.0f;
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
      return w3 * player.getHitsTaken;
   }

   IEnumerator PostStatistics() {
      using (UnityWebRequest www = UnityWebRequest.Post(
         $"www.mdk2023.com/stage_two_stats?kills={player.getKillCount}&actions={player.getAPM}&timer={player.getTimer}&hits_taken={player.getHitsTaken}&total_damage_taken={player.getTotalDamageTaken}&hit_miss_ratio={player.getHitMissRatio}&token={token}", "", "application/json"))
      {
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
