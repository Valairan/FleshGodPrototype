// HorizontalBloom
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBloom : State
{
	private List<Vector3> positions = new List<Vector3>();

	private int index;

	private float countDown1 = 3f;
	private float countDown2 = 2f;
	private bool isFinishedInstantiating = false;
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		countDown1 = stateMachine.delayAfterIndicator;
		countDown2 = stateMachine.delayBetweenStates;
		isFinishedInstantiating = false;
		positions = new List<Vector3>();
		positions = stateMachine.grid.generateRandomRow();
		foreach (Vector3 position in positions)
		{
			Object.Instantiate(stateMachine.seedlingPrefab, new Vector3(position.x, 0, position.z), Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.damagePrefab;
		}

	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{

	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
		if (countDown1 <= 0f)
		{
			//Instantiate
			if (!isFinishedInstantiating)
			{
				foreach (Vector3 position in positions)
				{
					Object.Instantiate(stateMachine.seedlingPrefab, position, Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.horizontalBloom;
				}
				isFinishedInstantiating = true;
			}
			if (countDown2 <= 0f)
			{
				//Transition to different state
				stateMachine.transitionToState(stateMachine.randomStateGenerator());

			}
			else
			{
				countDown2 -= Time.deltaTime;
			}
		}
		else
			countDown1 -= Time.deltaTime;



	}
}
