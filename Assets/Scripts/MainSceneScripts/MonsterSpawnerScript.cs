using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawnerScript : MonoBehaviour {

	public GameObject gorilla;
	float minX, maxX;
	float minZ, maxZ;
	const int nrInamici = 5;
	GameObject[] inamici;
	float[] destroyTime;
	const float range = 5.0f;

	public void setDestroyTime(float time, int gorillaId)
	{
		destroyTime [gorillaId] = time;
	}

	void Start () {
		minX = transform.position.x;
		minZ = transform.position.z;

		maxX = minX + range;
		maxZ = minZ + range;

		inamici = new GameObject[nrInamici];
		destroyTime = new float[nrInamici];
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < nrInamici; i++) {
			if (inamici [i] == null) {
				if (Time.realtimeSinceStartup - destroyTime [i] > 5) {
					Quaternion rotation = Random.rotation;
					rotation.x = 0; rotation.z = 0;
					inamici [i] = (GameObject)Instantiate (gorilla, new Vector3 (Random.Range (minX, maxX), 0, Random.Range (minZ, maxZ)), rotation);
					inamici [i].GetComponent<AttackGorillaScript>().gorillaId = i;
				}
			}
		}
	}
}
