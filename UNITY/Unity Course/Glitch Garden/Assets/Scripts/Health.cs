using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int healthPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetHealthPoints(int hp) {
        healthPoints = hp;
    }

    public void LoseHealthPoints(int hp) {
        int newHp = healthPoints - hp;

        if (newHp > 0) {
            SetHealthPoints(newHp);
        } else {
            Die();
        }
    }

    int GetHealthPoints() {
        return healthPoints;
    }

    void Die() {
        SetHealthPoints(0);
        Destroy(gameObject);
    }
}
