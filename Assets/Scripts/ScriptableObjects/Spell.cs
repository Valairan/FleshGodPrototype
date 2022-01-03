using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/New Spell")]
public class Spell : ScriptableObject
{
	public string spellName;
	public Sprite spellIcon;
	public GameObject particleSystem_Main;
	public GameObject particleSystem_Damage;
	public GameObject bulletPefab;
	public GameObject spellRing;
	public int Damage;
	public float fireRate;
	
}
