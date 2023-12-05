using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
	[SerializeField] private Character owner;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag(GameTag.Character.ToString())) {
			Character target = other.GetComponent<Character>();
			if (owner != target) {
				owner.AddTarget(target);
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag(GameTag.Character.ToString())) {
			Character target = other.GetComponent<Character>();
			if (owner != target) {
				owner.RemoveTarget(target);
			}
		}
	}
}
