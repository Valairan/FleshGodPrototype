using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

	public float MouseSensitivity;

	public Transform collisionSphere;


	[Range(0, 1)]     public float cameraSmoothing;
	[HideInInspector] public float HorizontalAxis;
	[HideInInspector] public float VerticalAxis;
	[HideInInspector] public float MouseXAxis;
	[HideInInspector] public float MouseYAxis;

	public const float gravity = -9.81f;
	public float MouseXRotationClamp;
	public float MouseYRotationClamp;


	[HideInInspector] public bool isFiring;
	[HideInInspector] public bool isAiming;
	[HideInInspector] public bool isGrounded;
	[HideInInspector] public bool ThirdPersonView;
	[HideInInspector] public bool camAim;
	/*[HideInInspector]*/
	public bool switchCamera;
	public Transform camera;
	public LayerMask standables;

	[SerializeField] public CharacterController controller;

	public float mouseScrollWheel;
	private void Start()
	{
		Init();
	}

	private void Init()
	{
		HorizontalAxis = 0;
		VerticalAxis = 0;
		MouseXAxis = 0;
		MouseYAxis = 0;
		isGrounded = false;
		isAiming = false;
		ThirdPersonView = false;

		camera = Camera.main.transform;
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{

		isGrounded = Physics.CheckSphere(collisionSphere.position, 0.1f, standables);

		HorizontalAxis = Input.GetAxisRaw("Horizontal");
		VerticalAxis = Input.GetAxisRaw("Vertical");

		MouseXAxis = Input.GetAxisRaw("Mouse X");
		MouseYAxis = Input.GetAxisRaw("Mouse Y");

		isAiming = Input.GetMouseButton(1) && camAim;
		isFiring = Input.GetMouseButton(0);
		switchCamera = Input.GetKeyDown(KeyCode.V);

		if (switchCamera)
		{
			ThirdPersonView = !ThirdPersonView;
			camAim = ThirdPersonView;
			UIHandler.canvasHandler.cameraMode_Canvas.sprite = ThirdPersonView ? UIHandler.canvasHandler.TPV: UIHandler.canvasHandler.FPV;
			UIHandler.canvasHandler.crossHair_Canvas.gameObject.SetActive(ThirdPersonView);
		}
		mouseScrollWheel = Input.GetAxis("Mouse ScrollWheel");		
	}





}
