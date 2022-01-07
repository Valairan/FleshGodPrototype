using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIHandler : MonoBehaviour
{
	public static UIHandler canvasHandler;

	[SerializeField] public Image equippedItem_Canvas;
	[SerializeField] public Image cameraMode_Canvas;

	[SerializeField] public Sprite FPV;
	[SerializeField] public Sprite TPV;

	[SerializeField] public Image healthBar_Canvas;
	[SerializeField] public Image staminaBar_Canvas;
	[SerializeField] public Image crossHair_Canvas;

	[SerializeField] public GameObject gameOverScreen;

	private void Start()
	{
		if (canvasHandler == null) canvasHandler = this;

	}

	public void gameOver()
	{
		gameOverScreen.SetActive(true) ;
	}

	public void mainMenuLoader()
	{
		SceneManager.LoadScene(2);
	}

}
