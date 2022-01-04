using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seedling : MonoBehaviour
{
	Transform player;
	public seedlingStates currentState;
	[SerializeField] NavMeshAgent agent;
	[SerializeField] NavMeshObstacle wall;
	[SerializeField] CapsuleCollider collider;

	float timer;

	private void Awake()
	{
		player = FindObjectOfType<Player>().transform;
		timer = 2;
	}

	private void Start()
	{
		switch (currentState)
		{
			case seedlingStates.slowSeedling:
				agent.enabled = true;
				collider.enabled = true;
				 break;
			case seedlingStates.fleshExplosion: break;
			case seedlingStates.bloodBloom: break;
			case seedlingStates.miniBloom: wall.enabled = true; collider.enabled = true; break;
			case seedlingStates.fullBloom: wall.enabled = true; collider.enabled = true; break;
			case seedlingStates.horizontalBloom: wall.enabled = true; collider.enabled = true; break;
			case seedlingStates.verticalBloom: wall.enabled = true; collider.enabled = true; break;

			default: break;
		}
	}
	void Update()
    {
		switch (currentState)
		{
			case seedlingStates.slowSeedling: setNavmeshTarget(); break;
			case seedlingStates.fleshExplosion: break;
			case seedlingStates.bloodBloom: break;
			case seedlingStates.miniBloom: break;
			case seedlingStates.fullBloom: destroyAfter(); break;
			case seedlingStates.horizontalBloom: destroyAfter(); break;
			case seedlingStates.verticalBloom: destroyAfter(); break;

			default: break;
		}
	}

 
	void destroyAfter()
	{

		if(timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
	void setNavmeshTarget()
	{
		agent.SetDestination(player.position);

		if (Vector3.Distance(player.position, transform.position) < 1f)
		{
			Debug.Log("Destroy");
			Destroy(this.gameObject);
		}
	}
}


public enum seedlingStates{

	slowSeedling,
	fleshExplosion,
	bloodBloom,
	miniBloom,
	fullBloom,
	horizontalBloom,
	verticalBloom

}

