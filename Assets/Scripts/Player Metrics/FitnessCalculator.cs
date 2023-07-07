using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessCalculator : MonoBehaviour
{
   private float w1 = 0.5f;
   private float w2 = 0.5f;
   private float w3 = 0.5f;
   private float w4 = 0.5f;
   private float w5 = 0.5f;
   private float w6 = 0.5f;
   private double fitness;
   PlayerMetrics player;

   void Start() {
        player = GetComponent<PlayerMetrics>();
        InvokeRepeating("CalculateFitness", 15, 10);
   }

   public void CalculateFitness() {
        fitness = w1 * player.getKillCount + w2 * player.getAPM + w3 * player.getTotalDamageTaken + w4 * player.getTimeElapsed;
        Debug.Log(fitness);
   }
}
