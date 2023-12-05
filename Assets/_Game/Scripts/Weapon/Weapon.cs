using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Bullet bulletPrefab;
	[SerializeField] private WeaponData weaponData;

	public void Shoot(Character owner, Vector3 direction) {
		Bullet bullet = SimplePool.Spawn<Bullet>(bulletPrefab, owner.transform.position + Vector3.up * 0.5f, owner.transform.rotation);
		bullet.OnInit(owner, direction, weaponData);
	}
	
}
