// Seedling
using UnityEngine;
using UnityEngine.AI;

public class Seedling : MonoBehaviour
{
	private Transform player;

	public seedlingStates currentState;

	[SerializeField]
	private NavMeshAgent agent;

	[SerializeField]
	private NavMeshObstacle wall;

	[SerializeField]
	private CapsuleCollider collider;

	[SerializeField]
	private Transform damageArea;

	public float timer;

	public float detonationRange;

	private float damageHealth;

	private float damageStamina;

	private void Awake()
	{
		player = Object.FindObjectOfType<Player>().transform;
		timer = 3f;
	}

	private void Start()
	{
		switch (currentState)
		{
			case seedlingStates.slowSeedling:
				agent.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.bloodBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.miniBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.fullBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.horizontalBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.verticalBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 20f;
				break;
			case seedlingStates.fleshExplosion:
				break;
		}
	}

	private void Update()
	{
		switch (currentState)
		{
			case seedlingStates.slowSeedling:
				setNavmeshTarget();
				break;
			case seedlingStates.bloodBloom:
				bloodBloom();
				break;
			case seedlingStates.fullBloom:
				destroyAfter();
				break;
			case seedlingStates.horizontalBloom:
				destroyAfter();
				break;
			case seedlingStates.verticalBloom:
				destroyAfter();
				break;
			case seedlingStates.fleshExplosion:
			case seedlingStates.miniBloom:
				break;
		}
	}

	private void bloodBloom()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
			return;
		}
		damageArea.gameObject.SetActive(value: true);
		if (Vector3.Distance(base.transform.position, player.position) < 3f)
		{
			player.GetComponent<Player>().takeDamage(100f, 0f);
		}
		Object.Destroy(base.gameObject);
	}

	private void destroyAfter()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void setNavmeshTarget()
	{
		agent.SetDestination(player.position);
		if (Vector3.Distance(player.position, base.transform.position) < 1f)
		{
			Debug.Log("Destroy");
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Colliding with player");
		if (other.gameObject.TryGetComponent<Player>(out var component))
		{
			component.takeDamage(0f, 0f);
		}
	}
}



// seedlingStates
public enum seedlingStates
{
	slowSeedling,
	fleshExplosion,
	bloodBloom,
	miniBloom,
	fullBloom,
	horizontalBloom,
	verticalBloom
}
