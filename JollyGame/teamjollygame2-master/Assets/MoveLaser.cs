using UnityEngine;
using System.Collections;

public class MoveLaser : MonoBehaviour {

    public Vector3 velocity = new Vector3(0, 0, 0);
	
	// Update is called once per frame
	void Update () {
        this.transform.position += velocity * Time.deltaTime;
        if(this.transform.position.x > 50 || this.transform.position.x < -50 || this.transform.position.y > 50 || this.transform.position.y < -50)
        {
            Destroy(this.gameObject);
        }
    }
}
