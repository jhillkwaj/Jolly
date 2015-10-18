using UnityEngine;
using System.Collections;

public class Slow : MonoBehaviour
{

    float fullSpeedX = 20f;
    float fullSpeedY = 20f;

    Movement movementScript;

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
            movementScript.maxVSpeed = movementScript.maxVSpeed / 2;
            movementScript.maxHSpeed = movementScript.maxHSpeed / 2;
        }else if(other.gameObject.tag == "BigShot")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        movementScript.maxHSpeed = Mathf.Lerp(movementScript.maxHSpeed, fullSpeedX, .1f * Time.deltaTime);
        movementScript.maxVSpeed = Mathf.Lerp(movementScript.maxVSpeed, fullSpeedY, .1f * Time.deltaTime);
    }
}
