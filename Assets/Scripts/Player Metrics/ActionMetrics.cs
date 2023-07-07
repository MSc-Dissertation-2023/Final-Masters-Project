using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMetrics : MonoBehaviour
{
	private int actions = 0;
	public int getActions => actions;

	void Start()
	{

	}

	void Update()
	{
		RegisterActions();
	}

	void RegisterActions() {
		if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") || Input.GetButtonDown("Fire1")) {
			actions += 1;
		}
	}
}
