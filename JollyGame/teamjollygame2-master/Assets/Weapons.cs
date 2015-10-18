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

    public SpriteRenderer overheatingEffect;
    float overheatingAlpha = 1;

    public double shotTime;
    double nextShotOne = -1;
    double nextShotTwo = -1;
    double nextShotThree = -1;

    public double timeToCharge = 3;

    double chargeTime1 = 0;
    double chargeTime2 = 0;
    double chargeTime3 = 0;

    Vector2 lastRot1 = new Vector2(-1, 0);
    Vector2 lastRot2 = new Vector2(-1, 0);
    Vector2 lastRot3 = new Vector2(-1, 0);

    public float maxVSpeed = 6.0f;

    public float bigLaserCooldown;
    float bigLaserTime = 0;
    bool bigLaserOn = false;

    public ParticleSystem chargeParticles1;
    public ParticleSystem chargeParticles2;
    public ParticleSystem chargeParticles3;

    public AudioSource chargeSound1;
    public AudioSource chargeSound2;
    public AudioSource chargeSound3;

    public ParticleSystem bigLaser;
    public GameObject gitLaserObj;
    public GameObject[] indicatorArray;



    // Use this for initialization
    void Start () {
        this.HeroControllerOne = HeroOne.GetComponent<HeroController>();
        this.HeroControllerTwo = HeroTwo.GetComponent<HeroController>();
        this.HeroControllerThree = HeroThree.GetComponent<HeroController>();
        nextShotOne = nextShotTwo = nextShotThree = shotTime;
        bigLaserTime = bigLaserCooldown;
        chargeTime1 = 0;
        chargeTime2 = 0;
        chargeTime3 = 0;
    }
	
	// Update is called once per frame
	void Update () {
        nextShotOne -= Time.deltaTime;
        nextShotTwo -= Time.deltaTime;
        nextShotThree -= Time.deltaTime;
        bigLaserTime -= Time.deltaTime;

        if(this.HeroControllerThree.VerticalMovementAxis > 0)
        {
            indicatorArray[0].GetComponent<SpriteRenderer>().color = new Color(123/255f, 231/255f, 51/255f);
            indicatorArray[1].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85/255f);
        }
        else if (this.HeroControllerThree.VerticalMovementAxis < 0)
        {
            indicatorArray[1].GetComponent<SpriteRenderer>().color = new Color(123 / 255f, 231 / 255f, 51 / 255f);
            indicatorArray[0].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        } else
        {
            indicatorArray[0].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
            indicatorArray[1].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }

        if (this.HeroControllerOne.VerticalMovementAxis > 0)
        {
            indicatorArray[2].GetComponent<SpriteRenderer>().color = new Color(250 / 255f, 90 / 255f, 90 / 255f);
            indicatorArray[3].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }
        else if (this.HeroControllerOne.VerticalMovementAxis < 0)
        {
            indicatorArray[3].GetComponent<SpriteRenderer>().color = new Color(250 / 255f, 90 / 255f, 90 / 255f);
            indicatorArray[2].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }
        else
        {
            indicatorArray[2].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
            indicatorArray[3].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }

        if (this.HeroControllerTwo.VerticalMovementAxis > 0)
        {
            indicatorArray[4].GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 204 / 255f, 0 / 255f);
            indicatorArray[5].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }
        else if (this.HeroControllerTwo.VerticalMovementAxis < 0)
        {
            indicatorArray[5].GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 204 / 255f, 0 / 255f);
            indicatorArray[4].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }
        else
        {
            indicatorArray[4].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
            indicatorArray[5].GetComponent<SpriteRenderer>().color = new Color(74 / 255f, 60 / 255f, 85 / 255f);
        }

        //move the ship
        if (!bigLaserOn && !HeroControllerOne.FireBig && !HeroControllerTwo.FireBig && !HeroControllerThree.FireBig)
            this.transform.position = new Vector3(this.transform.position.x
                , Mathf.Clamp(this.transform.position.y + (this.HeroControllerOne.VerticalMovementAxis * (maxVSpeed/3) * Time.deltaTime)
                + (this.HeroControllerTwo.VerticalMovementAxis * (maxVSpeed / 3) * Time.deltaTime)
                + (this.HeroControllerThree.VerticalMovementAxis * (maxVSpeed / 3) * Time.deltaTime),-14.25f,14.25f), 0);

        if (!HeroControllerOne.FireBig && (this.HeroControllerOne.RightAxisX != 0 || this.HeroControllerOne.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerOne.RightAxisX, HeroControllerOne.RightAxisY);
            lastRot1 = vector;
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
            }
            angle += 90;
            turretOne.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (!HeroControllerOne.FireBig && nextShotOne <= 0 && HeroControllerOne.Fire)
        {
            nextShotOne = shotTime;
            //fire the shot
            GameObject shot = Instantiate(Resources.Load("Shot Red"), fireOne.transform.position, turretOne.transform.rotation) as GameObject;
            shot.GetComponent<MoveLaser>().velocity = lastRot1.normalized * 10;
        }

        if (!HeroControllerTwo.FireBig && (this.HeroControllerTwo.RightAxisX != 0 || this.HeroControllerTwo.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerTwo.RightAxisX, HeroControllerTwo.RightAxisY);
            lastRot2 = vector;
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
            }
            angle += 90;
            turretTwo.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (!HeroControllerTwo.FireBig && nextShotTwo <= 0 && HeroControllerTwo.Fire)
        {
            nextShotTwo = shotTime;
            //fire the shot
            GameObject shot = Instantiate(Resources.Load("Shot Yellow"), fireTwo.transform.position, turretTwo.transform.rotation) as GameObject;
            shot.GetComponent<MoveLaser>().velocity = lastRot2.normalized * 10;
        }

        if (!HeroControllerThree.FireBig && (this.HeroControllerThree.RightAxisX != 0 || this.HeroControllerThree.RightAxisY != 0))
        {
            Vector2 vector = new Vector2(HeroControllerThree.RightAxisX, HeroControllerThree.RightAxisY);
            lastRot3 = vector;
            float angle = Vector2.Angle(Vector2.right, vector); //set the rotation of the turret to angle
            if (vector.y < 0)
            {
                angle = -angle;
            }
            angle += 90;
            turretThree.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (!HeroControllerThree.FireBig && nextShotThree <= 0 && HeroControllerThree.Fire)
        {
            nextShotThree = shotTime;
            //fire the shot
            GameObject shot = Instantiate(Resources.Load("Shot Green"), fireThree.transform.position, turretThree.transform.rotation) as GameObject;
            shot.GetComponent<MoveLaser>().velocity = lastRot3.normalized * 10;
        }

        if (HeroControllerOne.FireBig && bigLaserTime < 0)
        {
            if (chargeTime1 == timeToCharge)
            {
                chargeParticles1.Play();
                chargeSound1.Play();
            }
            chargeTime1 -= Time.deltaTime;
        }
        else
        {
            chargeTime1 = timeToCharge;
            chargeParticles1.Stop();
            chargeSound1.Stop();
        }

        if (HeroControllerTwo.FireBig && bigLaserTime < 0)
        {
            if (chargeTime2 == timeToCharge)
                chargeParticles2.Play();
            chargeTime2 -= Time.deltaTime;
        }
        else
        {
            chargeTime2 = timeToCharge;
            chargeParticles2.Stop();
        }

        if (HeroControllerThree.FireBig && bigLaserTime < 0)
        {
            if (chargeTime3 == timeToCharge)
                chargeParticles3.Play();
            chargeTime3 -= Time.deltaTime;
        }
        else
        {
            chargeTime3 = timeToCharge;
            chargeParticles3.Stop();
        }

        if (bigLaserTime < 0)
        {
            bigLaserTime = 0;
            bool charged1 = chargeTime1 <= 0;
            bool charged2 = chargeTime2 <= 0;
            bool charged3 = chargeTime3 <= 0;
            overheatingAlpha = 0;

            if (bigLaserOn)
            {
                bigLaser.Stop();
                bigLaserTime = bigLaserCooldown;
                bigLaserOn = false;
                gitLaserObj.SetActive(false);
            }
            else if (charged1 || charged2 && charged3)
            {
                bigLaser.Play();
                chargeParticles1.Stop();
                chargeParticles1.Clear();
                chargeParticles2.Stop();
                chargeParticles2.Clear();
                chargeParticles3.Stop();
                chargeParticles3.Clear();
                bigLaserTime = 2.5f;
                bigLaserOn = true;
                gitLaserObj.SetActive(true);
            }
        }
        else
        {
            if (bigLaserOn)
                overheatingAlpha = (2.5f-bigLaserTime) / 2.5f;
            else //on cooldown
                overheatingAlpha = bigLaserTime / bigLaserCooldown;
        }

        Color newColor = overheatingEffect.color;
        newColor.a = overheatingAlpha;
        overheatingEffect.color = newColor;

    }
}
