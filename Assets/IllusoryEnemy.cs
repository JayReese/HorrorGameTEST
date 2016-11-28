using UnityEngine;
using System.Collections;

public class IllusoryEnemy : Enemy
{

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    protected override void SetDefaults() { IsIllusory = true; }
}
