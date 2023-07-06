using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetrics : MonoBehaviour
{
  ActionMetrics actions;
  TimerMetrics timer;
  int APM = 0;
  // Start is called before the first frame update
  void Start()
  {
    actions = GetComponent<ActionMetrics>();
    timer = GetComponent<TimerMetrics>();
    InvokeRepeating("CalculateAPM", 5, 3);
  }

  void CalculateAPM() {
		if(timer.getTimer < 60) {
      APM = actions.getActions;
    } else {
      APM = actions.getActions / (timer.getTimer/60);
    }
    Debug.Log(APM);
	}

  void Update() {

  }
}
