using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBloom : State
{
	List<Vector3> positions;
	int index = 0;
	float countDown = 2;
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		positions = stateMachine.grid.generateRandomQuadrant();
		Debug.Log("Vertical Bloom");
		foreach (Vector3 pos in positions)
		{
			GameObject.Instantiate(stateMachine.MiniBloomPrefab, pos, Quaternion.identity);
		}
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
		throw new System.NotImplementedException();
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
		throw new System.NotImplementedException();
	}
}
