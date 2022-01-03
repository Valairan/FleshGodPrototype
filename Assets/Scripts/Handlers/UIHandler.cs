using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	private void Start()
	{
		if (canvasHandler == null) canvasHandler = this;

	}

}
