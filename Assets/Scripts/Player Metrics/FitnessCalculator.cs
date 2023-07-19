using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessCalculator : MonoBehaviour
{
   private float w1 = 1.5f;
   private float w2 = 1.5f;
   private float w3 = 2.5f;
   private float w4 = 2.0f;
   private float w5 = 2.5f;
//    private float w6 = 0.5f;
   private float fitness;
   PlayerMetrics player;

   void Start() {
      player = GetComponent<PlayerMetrics>();
      // InvokeRepeating("CalculateFitness", 3, 2);
   }

   private void CalculateFitness() {
      // Debug.Log(weightedKillCount());
      // Debug.Log(weightedAPM());
      // Debug.Log(weightedTimeElapsed());
      // Debug.Log(weightedHitMissRatio());
      // Debug.Log(weightedHitsTaken());
      fitness = 1.0f/10 * (weightedKillCount() + weightedAPM()  + weightedTimeElapsed() + weightedHitMissRatio() - weightedHitsTaken());
   }

   public float GetFitness() {
      CalculateFitness();
      return fitness;
   }

   private float weightedKillCount() {
      return w1 * player.getKillCount;
   }

   private float weightedAPM() {
      return w2 * player.getAPM;
   }

   private float weightedTimeElapsed() {
      Debug.Log(player.getTimeElapsed);
      return w4 * player.getTimeElapsed;
   }

   private float weightedHitMissRatio() {
      return w5 * player.getHitMissRatio;
   }

   private float weightedHitsTaken() {
      return w3 * player.getHitsTaken;
   }
}
