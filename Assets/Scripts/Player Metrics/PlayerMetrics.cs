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
  public float getAPMetrics => Mathf.Min(APM, maxAPM) / maxAPM;
  public float getTimerMetrics => timer.getTimerMetrics;
  public float getKillMetrics => kills.getKillMetrics();
  public float getHitsTakenMetrics => damage.getHitsTakenMetrics;
  public float getTimer => timer.getTimer;
  public float getAPM => APM;
  public float getHitsTaken => damage.getTotalHitsTaken;
  public float getTotalDamageTaken => damage.getTotalDamageTaken;
  public float getKillCount => kills.getKillCount();

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
