// MiniBloom
using UnityEngine;

public class MiniBloom : State
{
	private float countDown;

	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
		for (int i = 0; i < stateMachine.maxCount; i++)
		{
			Object.Instantiate(stateMachine.MiniBloomPrefab, stateMachine.grid.generateRandomCell(), Quaternion.identity).GetComponent<Seedling>().currentState = seedlingStates.miniBloom;
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
	}
}
