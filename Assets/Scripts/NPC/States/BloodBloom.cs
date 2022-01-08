using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBloom : State
{
	private int index;
	private List<Vector3> positions = new List<Vector3>();

	private float countDown = 5f;
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		countDown = 5f;
		positions = new List<Vector3>();
		Debug.Log("Blood Bloom");

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
			GameObject.Instantiate(stateMachine.seedlingPrefab, pos, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.bloodBloom;

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
