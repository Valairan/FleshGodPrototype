// MiniBloom
using System.Collections.Generic;
using UnityEngine;

public class MiniBloom : State
{

	private float countDown;
	private List<Vector3> positions = new List<Vector3>();

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		Debug.Log("Mini Bloom");
		countDown = 5f;
		positions = new List<Vector3>();
		for (int i = 0; i < stateMachine.maxCount; i++)
		{
			Vector3 position = stateMachine.grid.generateRandomCell();
			positions.Add(position);
			position.y = 0;
			GameObject.Instantiate(stateMachine.seedlingPrefab, position, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.damagePrefab;
		}
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
		foreach (Vector3 pos in positions)
		{
			GameObject.Instantiate(stateMachine.seedlingPrefab, pos, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.miniBloom;

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
