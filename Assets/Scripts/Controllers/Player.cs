// Player
using UnityEngine;

public class Player : MonoBehaviour
{
	[Tooltip("The health of the player")]
	public float Health = 100;

	[Tooltip("This is how fast a player can run not how long")]
	public float Stamina = 2;

	public float staminaCountDown;

	public void takeDamage(float health, float stamina, float howLong)
	{
		Health -= health;
		Stamina -= stamina;
		staminaCountDown = howLong;

	}


	private void Update()
	{
		UIHandler.canvasHandler.healthBar_Canvas.fillAmount = Health / 100;
		UIHandler.canvasHandler.staminaBar_Canvas.fillAmount = Stamina / 2;
		if(staminaCountDown > 0)
		{
			staminaCountDown -= Time.deltaTime;
		}
		else
		{
			Stamina = 2;
		}

		if(Health <= 0f)
		{
			Time.timeScale = 0f;
			UIHandler.canvasHandler.gameOver();
		}
	}
}
