using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
	public void OnEnter(Character character) {
		character.ChangeAnim(Anim.run);
	}

	public void OnExecute(Character character) { }

	public void OnExit(Character character) { }
}
