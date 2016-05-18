using UnityEngine;
using System.Collections;

public class AttackGorillaScript : MonoBehaviour {

	public int gorillaId;
	float health;
	float jumpHeight = 1.3f;

	float jumpTime;
	float updTime;
	float attackDistance = 1.0f;
	GameObject player;


	// Use this for initialization
	void Start () {
		jumpTime = Time.realtimeSinceStartup;

		// Fiecare gorila sare la delta t diferit
		updTime = Random.Range (0.5f, 1.5f);
		health = 100.0f;

		//obtine id-ul playerului si verifica distanta si daca e mai mica de x ataca-l
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		// fa gorila sa sara
		// TODO as putea sa o fac sa se miste intre spawner si player mea ca sa para mai real
		if (Time.realtimeSinceStartup - jumpTime > updTime) {
			jumpTime = Time.realtimeSinceStartup;
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpHeight, 0);
			jumpHeight = -jumpHeight;
		}

		// Fa gorila sa se uite la player
		gameObject.transform.LookAt (player.transform.position);

		if (player != null) {
			float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

			if (distance < attackDistance) {
				// Todo apeleaza metoda de getDammage de la player (care o fi aia :)) )
				Debug.Log ("Gorila " + gorillaId + " ataca playerul");
			}
		}

		// Daca health a ajuns la 0 distruge gorila
		if (health <= 0) {
			GameObject spawner = GameObject.FindGameObjectWithTag("MonsterSpawner");
			spawner.GetComponent<MonsterSpawnerScript> ().setDestroyTime (Time.realtimeSinceStartup, gorillaId);
			Destroy (gameObject);
		}
	}

	public void getDammage(float dammage)
	{
		health -= dammage;
	}

	void OnMouseDown()
	{
		Debug.Log ("Click pe gorila");
		// nu lua dammage de la player daca nu e in range-ul tau
		if (player != null) {
			float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

			if (distance < attackDistance) {
				Debug.Log ("Gorila " + gorillaId + " a luat dammage de la player");
				getDammage (50);
			}
		}
	}
}
