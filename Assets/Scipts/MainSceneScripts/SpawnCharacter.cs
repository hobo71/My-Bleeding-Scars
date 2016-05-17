using UnityEngine;
using System.Collections;
// Clasa folosita pentru instantierea caracterului
public class SpawnCharacter : MonoBehaviour {
	
	public GameObject normalPrefab;
	public GameObject magePrefab;
	public GameObject freshPrefab;
	public GameObject darkPrefab;

	private GameObject playerObj;

	// Use this for initialization
	void Start () {
		string charType = PlayerPrefs.GetString("PlayerType");

		if (charType.Equals ("Normal")) {
			playerObj = (GameObject)Instantiate (normalPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (charType.Equals ("Mage")) {
			playerObj = (GameObject)Instantiate (magePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (charType.Equals ("Fresh")) {
			playerObj = (GameObject)Instantiate (freshPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		} else if (charType.Equals ("Dark")) {
			playerObj = (GameObject)Instantiate (darkPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
		} else
			playerObj = null;

		if(playerObj != null)
			playerObj.tag = "Player";
		playerObj.gameObject.AddComponent<MovementScript>();

		//playerObj.gameObject.AddComponent<PlayerScript>(); 

	}

	// Update is called once per frame
	void Update () {

	}
}
