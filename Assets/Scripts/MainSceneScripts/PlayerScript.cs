using UnityEngine;
using System.Collections;

public class PlayerScript : MonsterScript
{
    public GUISkin guiSkin;

    public int maxExp = 100;
    public int crtExp;

    public GameObject target;

	// Use this for initialization
	void Start () {
        // Aici se va scrie initializarea :P
        crtExp = 0;
        target = null;
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnGUI()
    {
        GUI.skin = guiSkin;
        GUI.skin.textField.fontSize = 20;

        GUILayout.TextField("Level: " + crtLevel);
        GUILayout.TextField("Health: " + (int)crtHealth  + "/" + (int)maxHealth, 100);
        GUILayout.TextField("Exp: " + (int)crtExp + "/" + (int)maxExp, 100);

        /* Display Target Health and level */
        GUILayout.BeginArea(new Rect(200, 0, 200, 100));
        if (target != null)
        {
            // TODO get Health
            MonsterScript _monsterScript = target.gameObject.GetComponent<MonsterScript>();
            if (_monsterScript != null)
            {
                float targetMaxHealth = _monsterScript.maxHealth;
                float targetCrtHealth = _monsterScript.crtHealth;

                int targetLevel = _monsterScript.crtLevel;

                GUILayout.TextField("Level: " + targetLevel);
                GUILayout.TextField("Health: " + (int)targetCrtHealth + "/" + (int)targetMaxHealth, 100);
            }
        }
        GUILayout.EndArea();
    }


    // Functie folosita pentru a verifica experienta curenta 
    void Evolve()
    {
        if (crtLevel < maxLevel)
        {
            if (crtExp > maxExp)
            {
                crtExp = crtExp - maxExp;
                maxExp += (int)(0.75f * maxExp);
                crtLevel++;

                maxHealth += (0.38f * maxHealth);
                crtHealth = maxHealth;
            }
        }
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public void giveExp(int exp)
    {
        crtExp += exp;
        // Verifica daca a trecut la urmatorul nivel
        Evolve();
    }

    public void Attack()
    {
        isAttacked = true;
    }

    public void StopAttacking()
    {
        isAttacked = false;
    }
}
