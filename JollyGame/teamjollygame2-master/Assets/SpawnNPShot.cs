using UnityEngine;
using System.Collections;

public class SpawnNPShot : MonoBehaviour {

    public GameObject target;
    public float fireTime;
    float timeToFire;

    void Update()
    {
        timeToFire -= Time.deltaTime;
        if (timeToFire < 0)
        {
            timeToFire = fireTime;
            fire();
        }
    }

    void fire()
    {
        GameObject shot = Instantiate(Resources.Load("Shot NP"), this.transform.position + new Vector3(0,0,5), this.transform.rotation) as GameObject;

        shot.GetComponent<MoveLaser>().velocity = Vector3.Normalize((target.transform.position + (Random.insideUnitSphere*10)) - this.transform.position) * 5;
    }
}
