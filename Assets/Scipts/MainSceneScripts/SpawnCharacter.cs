﻿using UnityEngine;
using System.Collections;
// Clasa folosita pentru instantierea caracterului
public class SpawnCharacter : MonoBehaviour {
	
	public GameObject normalPrefab;
	public GameObject magePrefab;
	public GameObject freshPrefab;
	public GameObject darkPrefab;
	public GameObject spawnSpot;

	private GameObject playerObj;

	// Use this for initialization
	void Start () {
		string charType = PlayerPrefs.GetString("PlayerType");

		spawnSpot = GameObject.FindGameObjectWithTag("CharacterSpawner");

		if (charType.Equals ("Normal")) {
			playerObj = (GameObject)Instantiate (normalPrefab, spawnSpot.transform.position, spawnSpot.transform.rotation);
		} else if (charType.Equals ("Mage")) {
			playerObj = (GameObject)Instantiate (magePrefab,  spawnSpot.transform.position, spawnSpot.transform.rotation);
		} else if (charType.Equals ("Fresh")) {
			playerObj = (GameObject)Instantiate (freshPrefab,  spawnSpot.transform.position, spawnSpot.transform.rotation);
		} else if (charType.Equals ("Dark")) {
			playerObj = (GameObject)Instantiate (darkPrefab,  spawnSpot.transform.position, spawnSpot.transform.rotation);
		} else
			playerObj = null;

		if(playerObj != null)
			playerObj.tag = "Player";
		playerObj.gameObject.AddComponent<MovementScript>();
		playerObj.AddComponent<BoxCollider> ();
		//playerObj.gameObject.AddComponent<PlayerScript>(); 

	}

	// Update is called once per frame
	void Update () {

	}
}
