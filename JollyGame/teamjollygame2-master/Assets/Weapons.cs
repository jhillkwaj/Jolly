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

    public GameObject fireOne;
    public GameObject fireTwo;
    public GameObject fireThree;

    public double shotTime;
    double nextShotOne = -1;
    double nextShotTwo = -1;
    double nextShotThree = -1;

    public float maxVSpeed = 6.0f;

    public float bigLaserCooldown;
    float bigLaserTime = 0;
    bool bigLaserOn = false;
    public ParticleSystem bigLaser;

    // Use this for initialization
    void Start () {
        this.HeroControllerOne = HeroOne.GetComponent<HeroController>();
        this.HeroControllerTwo = HeroTwo.GetComponent<HeroController>();
        this.HeroControllerThree = HeroThree.GetComponent<HeroController>();
        nextShotOne = nextShotTwo = nextShotThree = shotTime;
        bigLaserTime = bigLaserCooldown;
    }
	
	// Update is called once per frame
	void Update () {
        nextShotOne -= Time.deltaTime;
        nextShotTwo -= Time.deltaTime;
        nextShotThree -= Time.deltaTime;
        bigLaserTime -= Time.deltaTime;

        //move the ship
        if (!bigLaserOn && !HeroControllerOne.FireBig && !HeroControllerTwo.FireBig && !HeroControllerThree.FireBig)
            this.transform.position = new Vector3(this.transform.position.x
                , this.transform.position.y + (this.HeroControllerOne.VerticalMovementAxis * (maxVSpeed/3) * Time.deltaTime)
                + (this.HeroControllerTwo.VerticalMovementAxis * (maxVSpeed / 3) * Time.deltaTime)
                + (this.HeroControllerThree.VerticalMovementAxis * (maxVSpeed / 3) * Time.deltaTime), 0);

        if (!HeroControllerOne.FireBig && (this.HeroControllerOne.RightAxisX != 0 || this.HeroControllerOne.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerOne.RightAxisX, HeroControllerOne.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            angle += 90;
            turretOne.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotOne <= 0 && HeroControllerOne.Fire)
            {
                nextShotOne = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Red"), fireOne.transform.position, turretOne.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }

        if (!HeroControllerTwo.FireBig && (this.HeroControllerTwo.RightAxisX != 0 || this.HeroControllerTwo.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerTwo.RightAxisX, HeroControllerTwo.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            angle += 90;
            turretTwo.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotTwo <= 0 && HeroControllerTwo.Fire)
            {
                nextShotTwo = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Yellow"), fireTwo.transform.position, turretTwo.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }

        if (!HeroControllerThree.FireBig && (this.HeroControllerThree.RightAxisX != 0 || this.HeroControllerThree.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerThree.RightAxisX, HeroControllerThree.RightAxisY);
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
                Debug.Log("fix");
            }
            angle += 90;
            turretThree.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (nextShotThree <= 0 && HeroControllerThree.Fire)
            {
                nextShotThree = shotTime;
                //fire the shot
                GameObject shot = Instantiate(Resources.Load("Shot Green"), fireThree.transform.position, turretThree.transform.rotation) as GameObject;
                shot.GetComponent<MoveLaser>().velocity = vector.normalized * 10;
            }
        }

        if (bigLaserTime < 0)
        {
            if(bigLaserOn)
            {
                bigLaser.Stop();
                bigLaserTime = bigLaserCooldown;
                bigLaserOn = false;
            }
            else if(HeroControllerOne.FireBig && HeroControllerTwo.FireBig && HeroControllerThree.FireBig || HeroControllerOne.FireBig)
            {
                bigLaser.Play();
                bigLaserTime = 2;
                bigLaserOn = true;
            }
        }
            
    }
}
