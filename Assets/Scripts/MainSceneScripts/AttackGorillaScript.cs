using UnityEngine;
using System.Collections;

public class AttackGorillaScript : MonsterScript {

	public int gorillaId;

	float jumpHeight = 3.5f;

	float jumpTime;
	float updTime;
	float attackDistance = 2.0f;
	GameObject player, spawner;
    PlayerScript playerScript;
	const float animTime = 1.2f;

	float damageTime;
	float atackTime;
	const float coolDown = 1.0f;

	float moveTime;
	const float movingAt = 3.0f;

	Vector3 translateDirection;

    public AttackGorillaScript() : base()
    {
        //attackPower -= 4;
    }


	// Use this for initialization
	void Start () {
		jumpTime = Time.realtimeSinceStartup;

		// Fiecare gorila sare la delta t diferit
		updTime = Random.Range (0.5f, 1.5f);

		//obtine id-ul playerului si verifica distanta si daca e mai mica de x ataca-l
		player = GameObject.FindGameObjectWithTag("Player");
		spawner = GameObject.FindGameObjectWithTag ("MonsterSpawner");
        playerScript = player.gameObject.GetComponent<PlayerScript>();

		atackTime = Time.realtimeSinceStartup;
		damageTime = Time.realtimeSinceStartup;
		moveTime = Time.realtimeSinceStartup;
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


		// Fa gorila sa se miste random
		if (Time.realtimeSinceStartup - moveTime > movingAt) {
			Vector2 Temp = Random.insideUnitCircle;
			float tempDistance = Random.Range (0, 10);
			Temp = Temp * tempDistance;
			translateDirection = new Vector3 (Temp.x, 0, Temp.y);
			moveTime = Time.realtimeSinceStartup;
		}

		gameObject.transform.Translate(translateDirection * Time.deltaTime);

		if (player != null) {
			float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

			if (Time.realtimeSinceStartup - damageTime > coolDown) {
				damageTime = Time.realtimeSinceStartup;
				if (distance < attackDistance) {
					// Todo apeleaza metoda de getDammage de la player (care o fi aia :)) )
					// Todo adauga cooldown intre atacuri (sa nu atace de la 60 de ori pe secunda, ca ne face praf) 
					Debug.Log ("Gorila " + gorillaId + " ataca playerul");
				}
			}
		}

		// Daca health a ajuns la 0 distruge gorila
		if (crtHealth <= 0) {
            playerScript.giveExp((int) crtLevel * 10 + 2);
            Debug.Log("Gorila " + gorillaId + " died");
			GameObject spawner = GameObject.FindGameObjectWithTag("MonsterSpawner");
			spawner.GetComponent<MonsterSpawnerScript> ().setDestroyTime (Time.realtimeSinceStartup, gorillaId);
			Destroy (gameObject);
		}
	}

	public void getDammage()
	{
        float damage = player.GetComponent<PlayerScript>().attackPower;
        crtHealth -= damage;
        Debug.Log("Gorila " + gorillaId + " a luat " + damage + " de la player");
    }

	void OnMouseDown()
	{
        playerScript.setTarget(gameObject);
		Debug.Log ("Click pe gorila " + gorillaId + ".Health: " + crtHealth);
		// nu lua dammage de la player daca nu e in range-ul tau
		if (player != null)
        {
			float distance = Vector3.Distance (gameObject.transform.position, player.transform.position);

			if (Time.realtimeSinceStartup - atackTime > animTime) {
				atackTime = Time.realtimeSinceStartup;
				if (distance < attackDistance) {
					getDammage ();
				}
			}
		}
	}
}
