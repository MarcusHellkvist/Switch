using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	void Start () {
		player = FindObjectOfType<PlayerController>();
	}
	
	void Update () {
		
	}

	public void RespawnPlayer ()
	{
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		yield return new WaitForSeconds (respawnDelay);
		player.transform.position = currentCheckpoint.transform.position;
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
