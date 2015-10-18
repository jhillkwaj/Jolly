using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

    HeroController controller = null;

	// Update is called once per frame
	void Update () {
        Debug.Log("check restart");

        if (controller == null)
            controller = this.GetComponent<HeroController>();
        
        if(controller.Fire)
        {
            Application.LoadLevel(Application.loadedLevel);
        }    
	}
}
