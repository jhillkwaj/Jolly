using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    private DetectStart startDetectorOne;
    private DetectStart startDetectorTwo;
    private DetectStart startDetectorThree;
    private DetectStart startDetectorFour;

    public GameObject HeroOne;
    public GameObject HeroTwo;
    public GameObject HeroThree;
    public GameObject HeroFour;

    // Use this for initialization
    void Start () {
        this.startDetectorOne = HeroOne.GetComponent<DetectStart>();
        this.startDetectorTwo = HeroTwo.GetComponent<DetectStart>();
        this.startDetectorThree = HeroThree.GetComponent<DetectStart>();
        this.startDetectorFour = HeroFour.GetComponent<DetectStart>();
    }
	
	// Update is called once per frame
	void Update () {
        /*if(Time.timeSinceLevelLoad > 0.01f && (startDetectorOne.StartGame || startDetectorTwo.StartGame || startDetectorThree.StartGame || startDetectorFour.StartGame))
            Application.LoadLevel(1);*/
        if (Time.timeSinceLevelLoad > 0.01f && (startDetectorOne.InputDevice.MenuWasPressed || startDetectorTwo.InputDevice.MenuWasPressed || startDetectorThree.InputDevice.MenuWasPressed || startDetectorFour.InputDevice.MenuWasPressed))
        {
            Application.LoadLevel(1);
        }

    }
}
