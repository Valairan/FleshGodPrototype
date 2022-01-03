using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
	public abstract void onStateEnter(NPCBehaviourMachine stateMachine);
	public abstract void onStateUpdate(NPCBehaviourMachine stateMachine);
	public abstract void onStateExit(NPCBehaviourMachine stateMachine);

}
