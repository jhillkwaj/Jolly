using UnityEngine;
using System.Collections;

public class pitchShift : MonoBehaviour {

    public float startingPitch = 1f;
    public float currentPitch = 0f;
    public float rateOfChange = 0.1f;
    public float maxPitch = 2f;

    AudioSource tone;

	// Use this for initialization
	void Start () {
        currentPitch = startingPitch;
        tone = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        currentPitch += rateOfChange * currentPitch * (1.0f - currentPitch/maxPitch) * Time.deltaTime;
        tone.pitch = currentPitch;
        float ratio = currentPitch / maxPitch;
        tone.volume = (1 - ratio)* 0.95f + 0.05f;
    }
}
