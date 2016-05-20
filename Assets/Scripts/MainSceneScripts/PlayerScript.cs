using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public GUISkin guiSkin;

    public float maxHealth = 100f;
    public int maxExp = 100;
    public int maxLevel = 20;

    public float crtHealth;
    public int crtExp;
    public int crtLevel;

	// Use this for initialization
	void Start () {
	    // Aici se va scrie initializarea :P
	}
	
	// Update is called once per frame
	void Update () {
        Evolve();

	}

    void OnGUI()
    {

    }


    // Functie folosita pentru a verifica experienta curenta 
    void Evolve()
    {
        if (crtLevel < maxLevel)
        {
            if (crtExp > maxExp)
            {
                crtExp = maxExp - crtExp;
                maxExp += (int)(0.75f * maxExp);
                crtLevel++;

            }
        }
    }
}
