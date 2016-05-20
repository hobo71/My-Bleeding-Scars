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
    public float attackDamage;

    public GameObject target;

	// Use this for initialization
	void Start () {
        // Aici se va scrie initializarea :P
        crtLevel = 1;
        crtExp = 0;
        crtHealth = maxHealth;
        attackDamage = 10.0f;
        //GameObject target = null;
	}
	
	// Update is called once per frame
	void Update () {
        Evolve();

	}

    void OnGUI()
    {
        GUI.skin = guiSkin;
        GUI.skin.textField.fontSize = 20;

        GUILayout.TextField("Level: " + crtLevel);
        GUILayout.TextField("Health: " + (int)crtHealth  + "/" + (int)maxHealth, 100);
        GUILayout.TextField("Exp: " + (int)crtExp + "/" + (int)maxExp, 100);

        if (target != null)
        {
            // TODO get Health
            //GUILayout.TextField();
        }
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

    public void setTarget(GameObject target)
    {

    }
}
