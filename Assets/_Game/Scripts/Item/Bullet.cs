using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : GameUnit {
    [SerializeField] private Rigidbody rb;
    private Character owner;
    private float range;
    private float speed;

    public void OnInit(Character owner, Vector3 direction, WeaponData weaponData) {
        this.owner = owner;
        range = 3;
        speed = weaponData.speed - 0.1f;
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(GameTag.Character.ToString())) {
            Character character = CacheComponent.GetCharacter(other);
            if (character != owner) {
                OnDespawn();
                character.SetAttacker(owner);
                character.OnHit();
            }
        }
    }
}
