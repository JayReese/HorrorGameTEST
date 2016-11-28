using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    // USED TO BE ABSTRACT.
    protected bool IsIllusory;

    public bool isIllusory
    {
        get { return IsIllusory; }
    }

	// Use this for initialization
	void Start ()
    {
        SetDefaults();
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveEnemy();
	}

    protected virtual void MoveEnemy()
    {
        transform.position += transform.right * Time.deltaTime * 1.5f;
    }

    protected virtual void SetDefaults()
    {
        IsIllusory = false;
    }
}
