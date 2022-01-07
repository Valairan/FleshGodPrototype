using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

	private void OnTriggerEnter(Collider other)
	{
		SceneManager.LoadSceneAsync(2);
	}
}
