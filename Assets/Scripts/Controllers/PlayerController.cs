using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	#region Declarations
	[SerializeField] InputHandler inputs;
	public Transform mPlayer;
	public Vector3 mOTS_Offset = new Vector3(0.0f, 1.0f, -2.5f);
	public Vector3 mADS_Offset = new Vector3(0.0f, 1.0f, -2.5f);
	public Vector3 mBEV_Offset = new Vector3(0.0f, 1.0f, -2.5f);
	public Vector3 mAngleOffset = new Vector3(0.0f, 0.0f, 0.0f);
	public float mDamping;
	[SerializeField] Player player;

	[HideInInspector]
	public Animator mAnimator;
	public float mWalkSpeed = 1.5f;
	public float mRunSpeed = 3.0f;
	private Vector3 direction;
	private Vector3 MoveDirection;
	private float horizontalAxis;
	private float verticalAxis;
	private float smoothSpeed;
	private float angleX = 0.0f;
	[SerializeField]
	private float smoothTime;
	Vector3 velocity;

	#endregion



	void Update()
	{
		horizontalAxis = inputs.HorizontalAxis;
		verticalAxis = inputs.VerticalAxis;
		direction = new Vector3(horizontalAxis, 0, verticalAxis).normalized;
		Move();
		HandleAnimations();
	}


	private void LateUpdate()
	{
		if (inputs.ThirdPersonView)
		{
			Follow_IndependentRotation();
		}
		else
		{
			CameraMove_TopDown();
		}
	}
	public void Move()
	{
		float angle = 0;
		if (inputs.ThirdPersonView)
		{
			if (inputs.isAiming)
			{
				float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + inputs.camera.transform.eulerAngles.y;
				transform.rotation = Quaternion.LookRotation(inputs.camera.forward);
			}
			else
			{
				float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + inputs.camera.transform.eulerAngles.y;
				angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothSpeed, smoothTime);
				transform.rotation = Quaternion.Euler(0f, angle, 0f);
			}
		}
		
		if (direction.magnitude > 0f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + inputs.camera.transform.eulerAngles.y;
			angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothSpeed, smoothTime);
			MoveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			transform.rotation = Quaternion.Euler(0f, angle, 0f);
			inputs.controller.Move(MoveDirection * mRunSpeed * (player.Stamina) * Time.deltaTime);
		}

		velocity.y += InputHandler.gravity * Time.deltaTime;
		if (!inputs.isGrounded)
			inputs.controller.Move(velocity * Time.deltaTime);
		else
			velocity.y = 0;


	}
	void Follow_IndependentRotation()
	{

		float mx, my;
		mx = inputs.MouseXAxis;
		my = inputs.MouseYAxis;

		// We apply the initial rotation to the camera.
		Quaternion initialRotation = Quaternion.Euler(mAngleOffset);

		Vector3 eu = inputs.camera.rotation.eulerAngles;

		angleX -= my * inputs.MouseSensitivity;

		// We clamp the angle along the X axis to be between 
		// the min and max pitch.
		angleX = Mathf.Clamp(angleX, -inputs.MouseXRotationClamp, inputs.MouseXRotationClamp);

		eu.y += mx * inputs.MouseSensitivity;
		Quaternion newRot = Quaternion.Euler(angleX, eu.y, 0.0f) *
		  initialRotation;

		inputs.camera.rotation = newRot;

		Vector3 forward = inputs.camera.rotation * Vector3.forward;
		Vector3 right = inputs.camera.rotation * Vector3.right;
		Vector3 up = inputs.camera.rotation * Vector3.up;

		Vector3 targetPos = mPlayer.position;
		Vector3 desiredPosition = new Vector3();

		if (inputs.isAiming)
		{
			desiredPosition = targetPos
			+ forward * mADS_Offset.z
			+ right * mADS_Offset.x
			+ up * mADS_Offset.y;

		}
		else
		{
			desiredPosition = targetPos
			+ forward * mOTS_Offset.z
			+ right * mOTS_Offset.x
			+ up * mOTS_Offset.y;

		}

		Vector3 position = Vector3.Lerp(inputs.camera.position,
			desiredPosition, mDamping);
		inputs.camera.position = position;
	}

	void CameraMove_TopDown()
	{
		// For topdown camera we do not use the x and z offsets.
		Vector3 targetPos = mPlayer.position;
		targetPos.y += mBEV_Offset.y;
		targetPos.z += mBEV_Offset.z;
		Vector3 position = Vector3.Lerp(
		  inputs.camera.position,
		  targetPos, mDamping);
		inputs.camera.position = position;

		inputs.camera.LookAt(transform.position);
	}
	void HandleAnimations()
	{
		mAnimator.SetFloat("PosX", horizontalAxis);
		mAnimator.SetFloat("PosZ", verticalAxis);
		mAnimator.SetBool("aiming", inputs.isAiming);
	}
	private void OnAnimatorIK(int layerIndex)
	{
		RaycastHit hit;
		Vector3 aimtTarget = new Vector3();
		if (inputs.isAiming || inputs.isFiring && inputs.ThirdPersonView)
		{
			if (Physics.Raycast(inputs.camera.position, inputs.camera.forward, out hit))
			{
				aimtTarget = hit.point;
			}
			else
			{
				aimtTarget = inputs.camera.position + inputs.camera.forward * 100;
			}
			mAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
			mAnimator.SetIKPosition(AvatarIKGoal.RightHand, aimtTarget);
			mAnimator.SetLookAtWeight(1);
			mAnimator.SetLookAtPosition(aimtTarget);
		}
	}

	private void OnDrawGizmos()
	{
		if (inputs.camera)
		{
			RaycastHit hit;
			if (Physics.Raycast(inputs.camera.position, inputs.camera.forward, out hit))
			{
				Vector3 aimtTarget = hit.point;
				Gizmos.DrawSphere(aimtTarget, 1f);
				Gizmos.DrawLine(inputs.camera.position, aimtTarget);
			}
			else
			{
				Vector3 aimtTarget = inputs.camera.position + inputs.camera.forward * 100;
				Gizmos.DrawSphere(aimtTarget, 1f);
				Gizmos.DrawLine(inputs.camera.position, inputs.camera.position + inputs.camera.forward * 100);

			}

		}
	}

}


