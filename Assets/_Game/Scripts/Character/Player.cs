using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
	[SerializeField] private DynamicJoystick joystick;
	[SerializeField] private float moveSpeed;
	[SerializeField] private Rigidbody rb;
	
	private void Move() {
		if (GameManager.Ins.IsState(GameState.GamePlay)) {
			Vector3 direct = new Vector3(joystick.Horizontal, 0, joystick.Vertical).normalized;
			Vector3 nextPos = direct * moveSpeed * Time.deltaTime + TF.position;

			rb.velocity = direct * moveSpeed;
			if (Vector3.Distance(direct, Vector3.zero) > 0) {
				transform.forward = direct;
					ChangeAnim(Anim.run);
			} else {
				ChangeState(IdleState);
				ChangeAnim(Anim.idle);
			}

			// CanMove(nextPos);
			// if (Vector3.Distance(direct, Vector3.zero) > 0) {
			// 	characterModel.forward = direct;
			// 	ChangeAnim(Anim.run);
			// } else {
			// 	ChangeAnim(Anim.idle);
			// }
		}
	}
	
	private void Update() {
		Move();
	}
}
