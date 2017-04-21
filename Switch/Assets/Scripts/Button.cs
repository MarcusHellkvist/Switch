using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public LevelManager levelManager;
	public GameObject hiddenBlock;

	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			hiddenBlock.SetActive(true);
		}
	}
}
