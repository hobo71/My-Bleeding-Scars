using UnityEngine;
using System.Collections;

/* Comment */
public class CameraScript : MonoBehaviour {

    public float turningSpeed = 100f;
    GameObject player = null;

    public float height = 1.5f;
    public float distance = -2.5f;

	public const float minAngle = 30;
	public const float maxAngle = 80;

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

		/* Camera se va roti cu mouseul doar la click dreata */
		if (Input.GetMouseButton (1)) {
			Vector3 cameraView = Quaternion.AngleAxis (Input.GetAxis ("Mouse Y"), player.transform.right) * offsetX;

			/* Unghiul dintre normala playerului si camera */
			float upCameraAngle = Vector3.Angle (cameraView, player.transform.up);

			/* Unghiul dintre directia de privire a playerului si camera */
			float forwardCameraAngle = Vector3.Angle (cameraView, player.transform.forward);

			/* Daca unghiul dintre normala si camera este in intervalul (30, 60) si camera este in spatele playerului */
			if (upCameraAngle > minAngle && upCameraAngle < maxAngle && forwardCameraAngle > 90)
				offsetX = cameraView;
		}
			
		transform.position = player.transform.position + offsetX;
		transform.LookAt(player.transform.position + new Vector3(0, 1, 0));
   }
}
