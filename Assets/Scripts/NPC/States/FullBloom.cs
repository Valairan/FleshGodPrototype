// FullBloom
using System.Collections.Generic;
using UnityEngine;

public class FullBloom : State
{
	private List<Vector3> positions;

	private int index;

	private float countDown = 2f;

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		positions = stateMachine.grid.generateRandomQuadrant();
		Debug.Log("Vertical Bloom");
		foreach (Vector3 position in positions)
		{
			Object.Instantiate(stateMachine.MiniBloomPrefab, position, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.fullBloom;
		}
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
	}
}
