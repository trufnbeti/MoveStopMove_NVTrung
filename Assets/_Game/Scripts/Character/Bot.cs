using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character {
	private float idleTime;
	private float idleTimeCounter = 0;

	private void Awake() {
		idleTime = UnityEngine.Random.Range(1f, 2f);
	}

	public override void Move() {
		idleTimeCounter += Time.deltaTime;
		if (idleTimeCounter >= idleTime) {
			ChangeState(Att);
		}
	}
}
