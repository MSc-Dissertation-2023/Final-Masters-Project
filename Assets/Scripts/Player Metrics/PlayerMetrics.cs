using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour
{
  ActionMetrics actions;
  TimerMetrics timer;
  ShootingMetrics shooting;
  KillMetrics kills;
  DamageMetrics damage;
  private int APM = 0;
  public float getHitMissRatio => shooting.hitMissRatio();
  public int getAPM => APM;
  public int getKillCount => kills.getKillCount();
  public float getTotalDamageTaken => damage.getTotalDamageTaken;
  public int getTimeElapsed => timer.getTimer;

  void Start()
  {
    actions = GetComponent<ActionMetrics>();
    timer = GetComponent<TimerMetrics>();
    shooting = GetComponent<ShootingMetrics>();
    kills = GetComponent<KillMetrics>();
    damage = GetComponent<DamageMetrics>();
    InvokeRepeating("CalculateAPM", 3, 3);
  }

  void CalculateAPM() {
		if(timer.getTimer < 60) {
      APM = actions.getActions;
    } else {
      APM = actions.getActions / (timer.getTimer/60);
    }
	}
}
