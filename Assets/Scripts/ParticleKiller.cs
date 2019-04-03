using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour {
    private ParticleSystem me;
	// Use this for initialization
	void Start () {
        me = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!me.isPlaying)
            Destroy(gameObject);
	}
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
