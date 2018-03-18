using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
	public GameObject ballPrefab;

	void Start ()
	{
		StartCoroutine (Spawn (5));
	}

	void Update ()
	{
		
	}

	IEnumerator Spawn (int count)
	{
		yield return new WaitForSeconds (1f);
	}
}
