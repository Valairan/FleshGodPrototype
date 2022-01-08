// FullBloom
using System.Collections.Generic;
using UnityEngine;

public class FullBloom : State
{
	private List<Vector3> positions = new List<Vector3>();

	private int index;

	private float countDown = 5f;

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		countDown = 5f;
		positions = new List<Vector3>();
		positions = stateMachine.grid.generateRandomQuadrant();
		foreach (Vector3 position in positions)
		{
			Object.Instantiate(stateMachine.seedlingPrefab, new Vector3(position.x, 0, position.z), Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.damagePrefab;
		}

	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
		foreach (Vector3 position in positions)
		{
			Object.Instantiate(stateMachine.seedlingPrefab, position, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.fullBloom;
		}
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
		if (countDown <= 0f)
		{
			stateMachine.transitionToState(stateMachine.randomStateGenerator());
		}
		else
			countDown -= Time.deltaTime;

	}
}
