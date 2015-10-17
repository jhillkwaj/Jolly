using UnityEngine;
using System.Collections;
using InControl;

public class HeroController : MonoBehaviour
{
	public int PlayerNumber;

	void Start ()
	{

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

	public float HorizontalMovementAxis
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.LeftStickX : (this.PlayerNumber == 1 ? Input.GetAxis ("Horizontal") : 0.0f);
		}
	}

    public float VerticalMovementAxis
    {
        get
        {
            InputDevice inputDevice = this.InputDevice;
            return (inputDevice != null) ? inputDevice.LeftStickY : (this.PlayerNumber == 1 ? Input.GetAxis("Vertical") : 0.0f);
        }
    }

    public float RightAxisX
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.RightStickX: 0.0f;
		}
	}

    public float RightAxisY
    {
        get
        {
            InputDevice inputDevice = this.InputDevice;
            return (inputDevice != null) ? inputDevice.RightStickY : 0.0f;
        }
    }

    public bool FireBig
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.LeftTrigger: (this.PlayerNumber == 1 ? Input.GetButtonUp ("Fire1") : false);
		}
	}

	public bool GetBiggerStart
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.Action2.WasPressed : (this.PlayerNumber == 1 ? Input.GetButtonDown ("Fire2") : false);
		}
	}

	public bool GetBiggerHold
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.Action2.IsPressed : (this.PlayerNumber == 1 ? Input.GetButton ("Fire2") : false);
		}
	}

	public bool GetBiggerEnd
	{
		get
		{
			InputDevice inputDevice = this.InputDevice;
			return (inputDevice != null) ? inputDevice.Action2.WasReleased : (this.PlayerNumber == 1 ? Input.GetButtonUp ("Fire2") : false);
		}
	}

	public bool GetResetGame
	{
		get
		{
			if (this.PlayerNumber == 1)
			{
				return Input.GetButtonUp ("Fire5");
			}
			return false;
		}
	}

}
