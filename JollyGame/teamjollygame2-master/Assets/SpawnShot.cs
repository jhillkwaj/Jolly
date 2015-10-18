using UnityEngine;
using System.Collections;

public class SpawnShot : MonoBehaviour {

    public double shotTime;
    double nextShot = -1;
    public AudioSource fireSound;

    void Start()
    {
        transform.Rotate(Vector3.forward * -90);
        nextShot = shotTime;
    }
    
	
	// Update is called once per frame
	void Update () {
        nextShot -= Time.deltaTime;
	    if(nextShot <= 0)
        {
            fireShot();
            nextShot += shotTime;
            fireSound.Play();
        }
	}

    private void fireShot()
    {
        GameObject shot = Instantiate(Resources.Load("shot"), this.transform.position, this.transform.rotation) as GameObject;

        shot.GetComponent<MoveLaser>().velocity = Vector3.right * 30;
    }
}
