using UnityEngine;
using System.Collections;

/* Comment */
public class CameraScript : MonoBehaviour {
    public float turningSpeed = 100f;
    GameObject player = null;

    public float height = 1.5f;
    public float distance = -2.5f;

    private Vector3 offsetX;

	// Use this for initialization
	void Start () {
        offsetX = new Vector3(0, height, distance);
    }
	
	// Update is called once per frame
	void Update () {
	    if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("[CameraScript] Am gasit jucatorul");
        }
	}

    void LateUpdate() {

        offsetX = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime, Vector3.up) * offsetX;

		offsetX = Quaternion.AngleAxis(5 * Input.GetAxis("Mouse Y") * turningSpeed * Time.deltaTime, player.transform.right) * offsetX;

        transform.position = player.transform.position + offsetX;

        transform.LookAt(player.transform.position);
    }
}
