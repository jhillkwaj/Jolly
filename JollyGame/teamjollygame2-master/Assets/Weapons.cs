using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    private HeroController HeroController;

    public GameObject turretOne;

    public double shotTime;
    double nextShot = -1;

    // Use this for initialization
    void Start () {
        this.HeroController = this.GetComponent<HeroController>();
        nextShot = shotTime;
    }
	
	// Update is called once per frame
	void Update () {
        nextShot -= Time.deltaTime;
        if(nextShot <= 0 && (this.HeroController.RightAxisX != 0 || this.HeroController.RightAxisY != 0))
        {
            nextShot = shotTime;
            Vector2 vector = new Vector2(HeroController.RightAxisX, HeroController.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            Debug.Log(angle);
            turretOne.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //fire the shot
            GameObject shot = Instantiate(Resources.Load("Shot Blue"), turretOne.transform.position, turretOne.transform.rotation) as GameObject;
            shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
        }
    }
}
