using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    private HeroController HeroControllerOne;
    private HeroController HeroControllerTwo;
    private HeroController HeroControllerThree;

    public GameObject HeroOne;
    public GameObject HeroTwo;
    public GameObject HeroThree;

    public GameObject turretOne;
    public GameObject turretTwo;
    public GameObject turretThree;

    public double shotTime;
    double nextShotOne = -1;
    double nextShotTwo = -1;
    double nextShotThree = -1;

    // Use this for initialization
    void Start () {
        this.HeroControllerOne = HeroOne.GetComponent<HeroController>();
        this.HeroControllerTwo = HeroTwo.GetComponent<HeroController>();
        this.HeroControllerThree = HeroThree.GetComponent<HeroController>();
        nextShotOne = nextShotTwo = nextShotThree = shotTime;
    }
	
	// Update is called once per frame
	void Update () {
        nextShotOne -= Time.deltaTime;
        nextShotTwo -= Time.deltaTime;
        nextShotThree -= Time.deltaTime;

        if ((this.HeroControllerOne.RightAxisX != 0 || this.HeroControllerOne.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerOne.RightAxisX, HeroControllerOne.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            turretOne.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotOne <= 0)
            {
                nextShotOne = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Blue"), turretOne.transform.position, turretOne.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }

        if ((this.HeroControllerTwo.RightAxisX != 0 || this.HeroControllerTwo.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerTwo.RightAxisX, HeroControllerTwo.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            turretTwo.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotTwo <= 0)
            {
                nextShotTwo = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Blue"), turretTwo.transform.position, turretTwo.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }

        if ((this.HeroControllerThree.RightAxisX != 0 || this.HeroControllerThree.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerThree.RightAxisX, HeroControllerThree.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            turretThree.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotThree <= 0)
            {
                nextShotThree = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Blue"), turretThree.transform.position, turretThree.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }
    }
}
