using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {


	private PlayerController player;
	public GameObject doorDestination;

	void Start () {
		player = FindObjectOfType<PlayerController>();
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.name == "Player") {
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				Debug.Log ("DOOR ACTIVE!");
				player.transform.position = doorDestination.transform.position;
			}
		}
	}

}
