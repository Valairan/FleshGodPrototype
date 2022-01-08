// Seedling
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Seedling : MonoBehaviour
{
	IEnumerator SpriteCoroutine(SpriteRenderer renderer, float duration)
	{
		// Fading animation
		float start = Time.time;
		while (Time.time <= start + duration)
		{
			Color color = renderer.color;
			color.a = 1f - Mathf.Clamp01((Time.time - start) / duration);
			renderer.color = color;
			yield return new WaitForEndOfFrame();
		}
		Destroy(this.gameObject);
	}

	private Transform player;
	public SpriteRenderer damageIndicator;

	public seedlingStates currentState;
	[SerializeField] 
	private Transform graphic;

	[SerializeField]
	private NavMeshAgent agent;

	[SerializeField]
	private NavMeshObstacle wall;

	[SerializeField]
	private CapsuleCollider collider;

	[SerializeField]
	private Transform damageArea;

	[SerializeField]
	private ParticleSystem explosion;

	public float timer;

	public float detonationRange;

	private float damageHealth;

	private float damageStamina;

	private float staminaCountdown = 5;



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
				damageStamina = 1f;
				break;
			case seedlingStates.bloodBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 0f;
				damageStamina = 1f;
				break;
			case seedlingStates.miniBloom:
				wall.enabled = true;
				collider.enabled = true;
				collider.isTrigger = false;
				damageHealth = 0f;
				damageStamina = 1f;
				break;
			case seedlingStates.fullBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 10f;
				damageStamina = 1f;
				break;
			case seedlingStates.horizontalBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 10f;
				damageStamina = 1f;
				break;
			case seedlingStates.verticalBloom:
				wall.enabled = true;
				collider.enabled = true;
				damageHealth = 10f;
				damageStamina = 1f;
				break;
			case seedlingStates.fleshExplosion:break;
			case seedlingStates.damagePrefab: damageIndicator.gameObject.SetActive(true); StartCoroutine(SpriteCoroutine(damageIndicator, 2f)); graphic.gameObject.SetActive(false); break;

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
			case seedlingStates.fleshExplosion:break;
			case seedlingStates.miniBloom:
				break;
			}
		if(!currentState.Equals(seedlingStates.damagePrefab))
			moveUpwards();
	}

	public void moveUpwards()
	{
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), .1f);
	}


	private void bloodBloom()
	{
		if (timer > 0f)
		{
			timer -= Time.deltaTime;
		}
		else
		{
			damageArea.gameObject.SetActive(true);
			if (Vector3.Distance(base.transform.position, player.position) < 2f)
			{
				player.GetComponent<Player>().takeDamage(50f, 0f, staminaCountdown);
			}
			explosion.Play();
			Object.Destroy(base.gameObject);
		}

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
		if (Vector3.Distance(player.position, base.transform.position) < .5f)
		{
 			Object.Destroy(base.gameObject);
			player.GetComponent<Player>().takeDamage(damageHealth, damageStamina, staminaCountdown);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
 		if (other.gameObject.TryGetComponent<Player>(out var component))
		{
			component.takeDamage(damageHealth, damageStamina, staminaCountdown);
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
	verticalBloom,
	damagePrefab
}
