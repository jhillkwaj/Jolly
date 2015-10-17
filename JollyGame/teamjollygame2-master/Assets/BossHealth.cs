using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

    public int startingHealth = 1000;
    public int currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeroShot")
        {
            takeDamage(10);
        }

        //play impact sound effect

        //impact particle effect

        Destroy(other.gameObject);
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
