using UnityEngine;
using System.Collections;
using InControl;

public class DetectStart : MonoBehaviour {

    public int PlayerNumber;

    // Use this for initialization
    void Start () {
	
	}

    public InputDevice InputDevice
    {
        get
        {
            if (this.PlayerNumber >= InputManager.Devices.Count)
            {
                return null;
            }
            return InputManager.Devices[this.PlayerNumber];
        }
    }

    public bool StartGame
    {
        get
        {
            InputDevice inputDevice = this.InputDevice;
            return (inputDevice != null) ? inputDevice.RightTrigger : (this.PlayerNumber == 1 ? Input.GetButtonUp("Fire2") : false);
        }
    }

    // Update is called once per frame
    void Update () {
	    /*if(StartGame)
        {
            Application.LoadLevel("main");
        }*/
	}
}
