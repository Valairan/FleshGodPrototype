using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBloom : State
{
	List<Vector3> positions;
	int index = 0;
	float countDown = 2;
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		positions = stateMachine.grid.generateRandomRow();
		Debug.Log("Vertical Bloom");
		foreach (Vector3 pos in positions)
		{
			GameObject.Instantiate(stateMachine.MiniBloomPrefab, pos, Quaternion.identity);
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
			countDown = 2;

		}
	}
}
