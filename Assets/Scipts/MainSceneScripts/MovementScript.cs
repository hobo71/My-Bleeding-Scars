using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
    public float speed = 0.5F;
    public float rotationSpeed = 100.0F;

    public float clickTime;
    // Use this for initialization
    void Start () {
        GetComponent<Animation>().CrossFade("idle");
        clickTime = 0;
    }
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis("Vertical") * speed;

        if(translation != 0)
        {
            GetComponent<Animation>().CrossFade("run");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed left click.");
                GetComponent<Animation>().Play("attack");
                clickTime = Time.realtimeSinceStartup;
            }
            
            if(Time.realtimeSinceStartup - clickTime > 3)
            {
               
                GetComponent<Animation>().CrossFade("idle");
            }
        }

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
    }
}
