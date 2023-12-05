using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Weapon", menuName = "SciptableObjects/Weapons")]
public class WeaponData : ScriptableObject
{
	public int index;
	public string name;
	public Weapon model;
	public Sprite icon;

	public int price;
	public int range;
	public int speed;
}