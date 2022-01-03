using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
	[SerializeField] InputHandler inputs;
	[SerializeField] Spell currentlyEquipped;
	[SerializeField] List<Spell> AvailableSpells;
	[SerializeField] int currentWeaponIndex;

	[SerializeField] Transform weaponHand;
	float timeToFire;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (inputs.ThirdPersonView)
		{
			if (inputs.isFiring && Time.time > timeToFire)
			{
				Shoot();
			}
			if (inputs.mouseScrollWheel != 0f)
			{
				SwitchWeapon();
			}

		}
	}
	void Shoot()
	{
		if (currentlyEquipped == null)
			return;

		timeToFire = Time.time + (1 / currentlyEquipped.fireRate);
		RaycastHit hit;
		Vector3 aimTarget = inputs.camera.position + inputs.camera.forward * 100;
		if (Physics.Raycast(inputs.camera.position, inputs.camera.forward, out hit))
		{
			aimTarget = hit.point;
		}

		Instantiate(currentlyEquipped.bulletPefab, weaponHand.position, Quaternion.LookRotation((aimTarget - weaponHand.position).normalized, Vector3.up)).GetComponent<Bullet>();
		
	}

	void SwitchWeapon()
	{
		if (AvailableSpells.Count < 1)
			return;

		if (inputs.mouseScrollWheel > 0)
		{
			if (currentWeaponIndex >= AvailableSpells.Count - 1)
			{
				currentWeaponIndex = 0;
			}
			else
				currentWeaponIndex++;
		}
		else if(inputs.mouseScrollWheel < 0)
		{
			if (currentWeaponIndex <= 0)
			{
				currentWeaponIndex = AvailableSpells.Count - 1;
			}
			else
				currentWeaponIndex--;
		}


		
		EquipItem(AvailableSpells[currentWeaponIndex]);

	}

	private void EquipItem(Spell spell)
	{
		currentlyEquipped = spell;

		if(weaponHand.childCount > 0)
			Destroy(weaponHand.GetChild(0).gameObject);
		Instantiate(currentlyEquipped.particleSystem_Main, weaponHand.transform);

		UIHandler.canvasHandler.equippedItem_Canvas.sprite = currentlyEquipped.spellIcon;
	}

	private void OnTriggerEnter(Collider hit)
	{
		if (hit.transform.CompareTag("Weapon"))
		{
			AvailableSpells.Add(hit.transform.GetComponent<SpellMB>().spell);
			EquipItem(hit.transform.GetComponent<SpellMB>().spell);
			Destroy(hit.gameObject);
		}

		

	}

}
