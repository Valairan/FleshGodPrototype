using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	public override void onStateEnter(NPCBehaviourMachine stateMachine)
	{
			stateMachine.transitionToState(stateMachine.randomStateGenerator());
	}

	public override void onStateExit(NPCBehaviourMachine stateMachine)
	{

	}

	public override void onStateUpdate(NPCBehaviourMachine stateMachine)
	{
 

	}
	
}
