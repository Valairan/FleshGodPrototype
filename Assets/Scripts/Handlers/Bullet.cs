using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField]float speed;
	Rigidbody rb;
	private void Awake()
	{
		rb = transform.GetComponent<Rigidbody>();
	}
	private void Start()
	{
		rb.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
	}


}
