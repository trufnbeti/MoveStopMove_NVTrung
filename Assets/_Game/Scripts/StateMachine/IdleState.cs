using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
	public void OnEnter(Character character)
	{
		character.ChangeAnim(Anim.idle);
		character.CheckAround();
	}
	public void OnExecute(Character character) 
	{
		character.Move();
	}

	public void OnExit (Character character)
	{

	}
}
