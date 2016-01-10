using UnityEngine;
using System.Collections;

public class Atmo : MonoBehaviour {

    private FMOD.Studio.EventInstance atmo_lvl2;

	// Use this for initialization
	void Start () {
        atmo_lvl2 = FMODUnity.RuntimeManager.CreateInstance("event:/atmo_lvl2");
        atmo_lvl2.start();
	}
	
	// Update is called once per frame
	void Update () {
        atmo_lvl2.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
	}
}
