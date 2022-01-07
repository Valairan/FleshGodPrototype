using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBloom : State
{
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		for (int i = 0; i < stateMachine.maxCount; i++)
		{
			Seedling component = Object.Instantiate(stateMachine.seedlingPrefab, stateMachine.grid.generateRandomCell(), Quaternion.identity).GetComponent<Seedling>();
			component.currentState = seedlingStates.miniBloom;
			component.timer = Random.Range(stateMachine.detonationMinTime, stateMachine.detonationMaxTime);
		}
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
		
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
	}
}
