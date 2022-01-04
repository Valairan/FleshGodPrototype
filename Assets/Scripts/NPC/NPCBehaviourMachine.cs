using System;
using System.Collections;
using System.Collections.Generic;
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
	[SerializeField] float switchStateTime;
	[SerializeField] float currentTime;
	[SerializeField] public Player player;

	[Header("Slow Seedling Settings")]
	public GameObject seedlingPrefab;
	public float seedlingSpeed;
	public int seedlingCount;

	[Header("Vertical Bloom Settings")]
	public float vertBloom1;
	[Header("Horizontal Bloom Settings")]
	public float vertBloom2;
	[Header("Mini Bloom Settings")]
	public GameObject MiniBloomPrefab;
	public int maxCount;
	public int minCount;
	public float timeBetweenBloom;
	[Header("Full Bloom Settings")]
	public float vertBloom4;
	[Header("Flesh Explosion Settings")]
	public float vertBloom5;
	[Header("Blood Bloom Settings")]
	public float vertBloom6;

	private void Awake()
	{
		currentState = idleState;

	}

	private void Start()
	{
 		listofStates = new State[]{slowSeedling, verticalBloom, horizontalBloom, MiniBloom, fullBloom};
 	}

	private void Update()
	{
		if(currentTime > 0f)
		{
			currentTime -= Time.deltaTime;
		}
		else
		{
			currentTime = switchStateTime;
			transitionToState(listofStates[UnityEngine.Random.Range(0, listofStates.Length)]);
		}

	}

	private void randomlyChangeState()
	{
		if (currentTime <= 0)
		{
			transitionToState(listofStates[UnityEngine.Random.Range(0, 8)]);
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
		return listofStates[UnityEngine.Random.Range(0, 8)];
	}


}
