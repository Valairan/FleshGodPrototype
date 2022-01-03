using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Tooltip("The health of the player")]public float Health;
	[Tooltip("This is how fast a player can run not how long")] public float Stamina;

	public void takeDamage(float health, float stamina)
	{
		Health -= health;
		Stamina -= stamina;
	}
}
