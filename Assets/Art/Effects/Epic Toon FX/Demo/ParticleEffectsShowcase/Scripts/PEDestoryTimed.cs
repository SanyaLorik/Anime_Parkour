using UnityEngine;
using System.Collections;

public class PEDestoryTimed : MonoBehaviour {

    public float Delay;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, Delay);
	}

}
