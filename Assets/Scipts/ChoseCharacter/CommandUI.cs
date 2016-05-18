using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandUI : MonoBehaviour {

    public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
        /*
        GameObject button = GameObject.FindGameObjectWithTag("PlayButton");
        button.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, -((Screen.height / 2) - 50));
        button.GetComponentInChildren<Text>().text = "Play";
        //button.GetComponent<Button>().onClick.AddListener(onClick);

        GameObject quitButton = GameObject.FindGameObjectWithTag("QuitButton");
        quitButton.gameObject.GetComponent<RectTransform>().localPosition = new Vector2((Screen.width / 2) - 100, -((Screen.height / 2) - 50));
        quitButton.GetComponentInChildren<Text>().text = "Quit";
        quitButton.GetComponent<Button>().onClick.AddListener(Quit);
        */
        GameObject errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage");
        errorMessage.gameObject.GetComponent<RectTransform>().localPosition = new Vector2(0, (Screen.height / 2) - 100);
        errorMessage.GetComponentInChildren<Text>().text = "";
    }

    void Play()
    {
        Debug.Log("[PlayButton] Clicked");
        GameObject errorMessage = GameObject.FindGameObjectWithTag("ErrorMessage");
		Debug.Log (PlayerPrefs.GetString ("PlayerType"));

		if (PlayerPrefs.GetString("PlayerType").Equals(""))
        {
            errorMessage.GetComponentInChildren<Text>().text = "Please select character!";
            return;
        }
        // TODO incarca scena urmatoare
       SceneManager.LoadScene(1);
    }

    void Quit()
    {
        Debug.Log("Aplication will close now");
        Application.Quit();
    }

    void OnGUI()
    {
        GUI.skin = guiSkin;
        GUI.skin.button.fontSize = 20;

        const int buttonWidth = 150;
        const int buttonHeight = 70;


        GUILayout.BeginArea(new Rect((Screen.width / 2) - (buttonWidth / 2), Screen.height - buttonHeight - 20, buttonWidth, buttonHeight));
        if (GUILayout.Button("Play", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
        {
            Play();
        }
        GUILayout.EndArea();

        GUILayout.BeginArea(new Rect(Screen.width - buttonWidth - 20, Screen.height - buttonHeight - 20, buttonWidth, buttonHeight));
        if (GUILayout.Button("Quit", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
        {
            Quit();
        }
        GUILayout.EndArea();


    }
}
