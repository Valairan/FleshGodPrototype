// NPCBehaviourMachine
using UnityEngine;

public class NPCBehaviourMachine : MonoBehaviour
{
	public Grid grid;

	public State currentState;

	public State idleState = new IdleState();

	public State slowSeedling = new SlowSeedling();

	public State verticalBloom = new VerticalBloom();

	public State horizontalBloom = new HorizontalBloom();

	public State MiniBloom = new MiniBloom();

	public State fullBloom = new FullBloom();

	public State fleshExplosion = new FleshExplosion();

	public State bloodBloom = new BloodBloom();

	public State[] listofStates;

	[Header("State Machine Settings")]
	[SerializeField]
	private float switchStateTime;

	[SerializeField]
	private float currentTime;

	[SerializeField]
	public Player player;

	public GameObject seedlingPrefab;
	public GameObject dangerIndicator;

	[Header("Slow Seedling Settings")]

	public float seedlingSpeed;

	public int seedlingCount;

	[Header("Vertical Bloom Settings")]
	[Header("Horizontal Bloom Settings")]
	[Header("Mini Bloom Settings")]
	public int maxCount;
	public int minCount;
	public float timeBetweenBloom;

	[Header("Full Bloom Settings")]
	[Header("Flesh Explosion Settings")]
	[Header("Blood Bloom Settings")]
	public int seedCount;
	public float detonationMaxTime;
	public float detonationMinTime;
	public float damageRadius;

	private void Awake()
	{
		currentState = idleState;
	}

	private void Start()
	{
		listofStates = new State[5] { slowSeedling, verticalBloom, horizontalBloom, MiniBloom, fullBloom };
	}

	private void Update()
	{
		if (currentTime > 0f)
		{
			currentTime -= Time.deltaTime;
			return;
		}
		currentTime = switchStateTime;
		transitionToState(listofStates[Random.Range(0, listofStates.Length)]);
	}

	private void randomlyChangeState()
	{
		if (currentTime <= 0f)
		{
			transitionToState(listofStates[Random.Range(0, 8)]);
			currentTime = switchStateTime;
		}
	}

	public void transitionToState(State nextState)
	{
		currentState.onStateExit(this);
		currentState = nextState;
		currentState.onStateEnter(this);
	}

	public State randomStateGenerator()
	{
		return listofStates[Random.Range(0, 8)];
	}
}
