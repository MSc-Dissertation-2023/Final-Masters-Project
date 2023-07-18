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
      fitness = 1.0f/10 * (w1 * player.getKillCount + w2 * player.getAPM + w4 * player.getTimeElapsed + w5 * player.getHitMissRatio - w3 * player.getHitsTaken);
   }

   public float GetFitness() {
      CalculateFitness();
      return fitness;
   }
}
