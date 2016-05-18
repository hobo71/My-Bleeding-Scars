using UnityEngine;
using System.Collections;

public class HorseAnimScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Animation>().CrossFade("Horse_Idle");
	}
}
