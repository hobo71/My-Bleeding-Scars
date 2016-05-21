using UnityEngine;
using System.Collections;

public class MonsterScript : MonoBehaviour {
    public float maxHealth;
    public float crtHealth;

    public int level;
    public int attackPower;

    public float healthRegenRate;
    public bool isAttacked;

    public MonsterScript()
    {
        maxHealth = 100;
        crtHealth = 100;
        healthRegenRate = 0.2f;

        level = 1;
        attackPower = 10;

        isAttacked = false;
    }
    	
	// Update is called once per frame
	void Update () {
        RegenHealth();
	}

    public void RegenHealth()
    {
        if (!isAttacked && crtHealth < maxHealth)
        {
            Debug.Log("Regenerating Hp");
            crtHealth += healthRegenRate;
            if (crtHealth > maxHealth)
                crtHealth = maxHealth;
        }
    }
}
