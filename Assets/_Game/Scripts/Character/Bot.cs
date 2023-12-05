using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
	private void Start() {
		Invoke("test", 2f);
	}

	void test() {
		ChangeState(IdleState);
	}
}
