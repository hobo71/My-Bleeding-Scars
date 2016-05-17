using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject button = GameObject.FindGameObjectWithTag("PlayButton");
        button.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, -((Screen.height / 2) - 50));
        button.GetComponentInChildren<Text>().text = "Play";
        button.GetComponent<Button>().onClick.AddListener(onClick);

        GameObject errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage");
        errorMessage.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, (Screen.height / 2) - 100);
        errorMessage.GetComponentInChildren<Text>().text = "";
    }

    void onClick()
    {
        Debug.Log("[PlayButton] Clicked");
        GameObject errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage");
        if (PlayerPrefs.GetString("PlayerType").Equals(""))
        {
            errorMessage.GetComponentInChildren<Text>().text = "Please select character!";
            return;
        }
        // TODO incarca scena urmatoare
        SceneManager.LoadScene(1);
    }
}
