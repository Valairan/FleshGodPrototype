using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbsHandler : MonoBehaviour
{
	[SerializeField] LineRenderer ArmRenderer_L;
	[SerializeField] LineRenderer ArmRenderer_R;
	[SerializeField] LineRenderer LegRenderer_L;
	[SerializeField] LineRenderer LegRenderer_R;

	[SerializeField] Transform armStart_L;
	[SerializeField] Transform armControl_L;
	[SerializeField] Transform armEnd_L;
	[SerializeField] Transform armStart_R;
	[SerializeField] Transform armControl_R;
	[SerializeField] Transform armEnd_R;
	[SerializeField] Transform LegStart_L;
	[SerializeField] Transform LegControl_L;
	[SerializeField] Transform LegEnd_L;
	[SerializeField] Transform LegStart_R;
	[SerializeField] Transform LegControl_R;
	[SerializeField] Transform LegEnd_R;

	[SerializeField] int segments;

	private void Update()
	{

	}

	private void LateUpdate()
	{
		HandleLimbs();
	}
	void HandleLimbs()
	{
		ArmRenderer_L.positionCount = segments + 1;
		ArmRenderer_R.positionCount = segments + 1;
		LegRenderer_L.positionCount = segments + 1;
		LegRenderer_R.positionCount = segments + 1;
		ArmRenderer_L.SetPositions(Curves.generateQuadraticBezier(armStart_L.position, armControl_L.position, armEnd_L.position, segments));
		ArmRenderer_R.SetPositions(Curves.generateQuadraticBezier(armStart_R.position, armControl_R.position, armEnd_R.position, segments));
		LegRenderer_L.SetPositions(Curves.generateQuadraticBezier(LegStart_L.position, LegControl_L.position, LegEnd_L.position, segments));
		LegRenderer_R.SetPositions(Curves.generateQuadraticBezier(LegStart_R.position, LegControl_R.position, LegEnd_R.position, segments));


	}
}
