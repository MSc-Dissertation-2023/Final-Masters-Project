using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessCalculator : MonoBehaviour
{
   private float w1 = 0.4f;
   private float w2 = 0.35f;
   private float w3 = 0.6f;
   private float w4 = 0.7f;
   private float w5 = 0.7f;
//    private float w6 = 0.5f;
   private float fitness;
   PlayerMetrics player;

   void Start() {
      player = GetComponent<PlayerMetrics>();
      InvokeRepeating("CalculateFitness", 15, 10);
   }

   private void CalculateFitness() {
      fitness = w1 * player.getKillCount + w2 * player.getAPM + w3 * player.getTotalDamageTaken + w4 * player.getTimeElapsed + w5 * player.getHitMissRatio;

      int maxValue = 800;
      int minValue = 0;

      // normalize between 0 and 1
      fitness = (fitness - minValue) / (maxValue - minValue);
      Debug.Log($"Player Fitness: {fitness}");
   }

   public float GetFitness() {
      return fitness;
   }
}
