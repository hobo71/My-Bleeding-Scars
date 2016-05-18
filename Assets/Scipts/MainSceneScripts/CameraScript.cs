using UnityEngine;
using System.Collections;

/* Comment */
public class CameraScript : MonoBehaviour {

    public float turningSpeed = 100f;
    GameObject player = null;

    public float height = 1.5f;
    public float distance = -2.5f;

	public const float distMax = -2.5f;
	public const float distMin = -0.5f;

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


		Vector3 cameraView = Quaternion.AngleAxis (Input.GetAxis ("Mouse Y") * turningSpeed * Time.deltaTime, player.transform.right) * offsetX;
		float upCameraAngle = Vector3.Angle (cameraView, player.transform.up);
		float forwardCameraAngle = Vector3.Angle (cameraView, player.transform.forward);
		if( upCameraAngle > 30 && upCameraAngle < 60 && forwardCameraAngle > 90)
			offsetX = cameraView;



		transform.position = player.transform.position + offsetX;
		transform.LookAt(player.transform.position + new Vector3(0, 1, 0));
   }
}
