using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour
{
  ActionMetrics actions;
  TimerMetrics timer;
  ShootingMetrics shooting;
  KillCountMetrics kills;
  DamageMetrics damage;
  private float APM = 0;

  private int maxAPM = 500;
  public float getHitMissRatio => shooting.hitMissRatio();
  public float getAPM => Mathf.Min(APM, maxAPM) / maxAPM;
  public float getKillCount => kills.getKillCount();
  public float getHitsTaken => damage.getHitsTakenCount();
  public float getTotalDamageTaken => damage.getTotalDamageTaken;
  public float getTimeElapsed => timer.getTimer;

  void Start()
  {
    actions = GetComponent<ActionMetrics>();
    timer = GetComponent<TimerMetrics>();
    shooting = GetComponent<ShootingMetrics>();
    kills = GetComponent<KillCountMetrics>();
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
