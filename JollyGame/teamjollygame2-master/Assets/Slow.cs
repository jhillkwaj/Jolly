﻿using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour
{

    float fullSpeedX = 20f;
    float fullSpeedY = 20f;

    Movement movementScript;

    public GameObject die;
    public GameObject removeOnDie;
    public GameObject winText;

    public AudioSource hitSound;

    public bool death = false;

    void Start()
    {
        movementScript = this.GetComponent<Movement>();
        fullSpeedX = movementScript.maxHSpeed;
        fullSpeedY = movementScript.maxVSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "BossShot")
        {
            Destroy(other.gameObject);
            movementScript.maxVSpeed = movementScript.maxVSpeed / 1.8f;
            movementScript.maxHSpeed = movementScript.maxHSpeed / 1.8f;
            hitSound.Play();
            GameObject hitEffect = Instantiate(Resources.Load("HitParticles"), other.transform.position, other.transform.rotation) as GameObject;
            hitEffect.transform.parent = transform;
            Destroy(hitEffect, 3);
        } else if (other.gameObject.tag == "BigShot" || death == true)
        {
            removeOnDie.SetActive(false);
            die.SetActive(true);
            winText.SetActive(true);
        }
        else if (other.gameObject.tag == "Stun")
        {
            Destroy(other.gameObject);
            movementScript.maxVSpeed = 0;
            movementScript.maxHSpeed = 0;
            hitSound.Play();
            GameObject hitEffect = Instantiate(Resources.Load("HitParticles"), other.transform.position, other.transform.rotation) as GameObject;
            hitEffect.transform.parent = transform;
            Destroy(hitEffect, 3);
        }
    }

    void Update()
    {
        movementScript.maxHSpeed = Mathf.Lerp(movementScript.maxHSpeed, fullSpeedX, .08f * Time.deltaTime);
        movementScript.maxVSpeed = Mathf.Lerp(movementScript.maxVSpeed, fullSpeedY, .08f * Time.deltaTime);
    }
}
