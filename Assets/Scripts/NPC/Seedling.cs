using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Seedling : MonoBehaviour
{
	Transform player;
	private void Awake()
	{
		player = FindObjectOfType<Player>().transform;
	}
	void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);

		if (Vector3.Distance(player.position, transform.position) < 1f)
		{
			Debug.Log("Destroy");
			Destroy(this.gameObject);
		}
	}

 
}
