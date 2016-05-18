using UnityEngine;
using System.Collections;

public class SunScript : MonoBehaviour {

    private GameObject sun;
	// Use this for initialization
	void Start () {
        sun = GameObject.FindGameObjectWithTag("Sun");
	}
	
	// Update is called once per frame
	void Update () {
        sun.transform.Rotate(new Vector3(0.1f, 0f, 0f));
        if (sun.transform.rotation.x == 360)
            sun.transform.rotation = Quaternion.identity;
    }
}
