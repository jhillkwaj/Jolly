using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private HeroController HeroController;
    public float maxHSpeed = 10.0f;
    public float maxVSpeed = 10.0f;

    public int PlayerIndex
    {
        get
        {
            return 1 + this.HeroController.PlayerNumber;
        }
    }

    // Use this for initialization
    void Start () {
        this.HeroController = this.GetComponent<HeroController>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update " + this.HeroController.HorizontalMovementAxis);
        this.transform.position = new Vector3(this.transform.position.x + (this.HeroController.HorizontalMovementAxis * maxHSpeed * Time.deltaTime)
            , this.transform.position.y + (this.HeroController.VerticalMovementAxis * maxVSpeed * Time.deltaTime), 0);
    }
}
