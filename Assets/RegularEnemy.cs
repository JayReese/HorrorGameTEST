using UnityEngine;
using System.Collections;

public class RegularEnemy : Enemy
{

	// Use this for initialization
	void Start ()
    {
	        
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();
	}

    protected override void MoveEnemy()
    {
        base.MoveEnemy();
    }

    protected override void SetDefaults() { base.SetDefaults(); }
}
