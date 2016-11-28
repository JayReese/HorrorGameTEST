using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    Status PlayerStatus;
    [SerializeField] Sprite HideSprite;
    [SerializeField] SpriteRenderer SRenderer;

    bool CanHide;
    float MovementSpeed, MovementVector, MovementXAxis;

	// Use this for initialization
	void Start ()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        MovementSpeed = 4f;
	}

    // Update is called once per frame
    void Update()
    {
        MovementXAxis = Input.GetAxisRaw("Horizontal");

        transform.position += (transform.right * MovementXAxis) * (Time.deltaTime * MovementSpeed);

        if (Input.GetKeyDown(KeyCode.W))
            Hide();
    }

    private void Hide()
    {
        SRenderer.sprite = HideSprite;
        //SRenderer.color = new Color(SRenderer.color.r, SRenderer.color.g, SRenderer.color.b, 1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Safety")
        {
            CanHide = true;
            //Debug.Log("Can hide");
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Safety")
        {
            CanHide = false;
            //Debug.Log("Left hiding place");
        }
    }
}