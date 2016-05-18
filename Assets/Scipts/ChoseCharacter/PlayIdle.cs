using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayIdle : MonoBehaviour {
    private float clickTime = 0f;
    const float animTime = 1.0f;

    public string playerName;

	GameObject message;

	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetString("PlayerType", null);
		message = GameObject.FindGameObjectWithTag("ErrorMessage");
		PlayerPrefs.SetString("PlayerType", "");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Time.realtimeSinceStartup - clickTime > animTime) {
			GetComponent<Animation> ().CrossFade ("idle");
			string text = message.GetComponentInChildren<Text> ().text;

			if(text.Equals(playerName + " selected!"))
				message.GetComponentInChildren<Text>().text = "";
		}
	}

    void OnMouseDown()
    {
        clickTime = Time.realtimeSinceStartup;
        Debug.Log("[OnMouseDown] Clicked");
        PlayerPrefs.SetString("PlayerType", playerName);
        GetComponent<Animation>().CrossFade("attack");
		message.GetComponentInChildren<Text>().text = playerName + " selected!";
    }
}
