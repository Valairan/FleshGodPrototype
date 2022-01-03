using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowSeedling : State
{
 	int i = 0;

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		i = 0;
		while (i < stateMachine.seedlingCount)
		{
			GameObject.Instantiate(stateMachine.seedlingPrefab, stateMachine.grid.generateRandomCell(), Quaternion.identity);
			i++;
		}
		Debug.Log("Seedling");

	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{
		
	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{

	}
}
