// HorizontalBloom
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBloom : State
{
	private List<Vector3> positions;

	private int index;

	private float countDown = 2f;

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		positions = stateMachine.grid.generateRandomRow();
		Debug.Log("Vertical Bloom");
		foreach (Vector3 position in positions)
		{
			Object.Instantiate(stateMachine.seedlingPrefab, position, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.horizontalBloom;
		}
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
		if (countDown > 0f)
		{
			countDown -= Time.deltaTime;
		}
		else
		{
			countDown = 2f;
		}
	}
}
