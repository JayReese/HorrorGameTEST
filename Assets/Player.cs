using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public enum Status { WALKING, HIDING };

    [SerializeField] Affliction PlayerAffliction;
    [SerializeField] Status PlayerStatus;
    [SerializeField]
    Sprite HideSprite, WalkSprite; // Walk sprite is a test.
    [SerializeField] SpriteRenderer SRenderer;
    [SerializeField]
    BoxCollider2D PlayerCollider;

    [SerializeField] bool CanHide;
    float MovementSpeed, MovementVector, MovementXAxis;
    [SerializeField]
    byte PlayerHealth;

	// Use this for initialization
	void Start ()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        MovementSpeed = 4f;
        PlayerHealth = 5;

        PlayerStatus = Status.WALKING;
	}

    // Update is called once per frame
    void Update()
    {
        MovementXAxis = Input.GetAxisRaw("Horizontal");

        Move();

        ChangeParadigm();

        if (Input.GetKeyDown(KeyCode.W) && CanHide)
            Hide();
    }

    private void Move()
    {
        if(MovementXAxis != 0)
            PlayerStatus = Status.WALKING;

        transform.position += (transform.right * MovementXAxis) * (Time.deltaTime * MovementSpeed);
    }

    private void Hide()
    {
        PlayerStatus = Status.HIDING;
        //SRenderer.color = new Color(SRenderer.color.r, SRenderer.color.g, SRenderer.color.b, 1);
    }

    void ChangeParadigm()
    {
        if (PlayerStatus == Status.HIDING)
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
            SRenderer.sprite = HideSprite;
        }
        else
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), false);
            SRenderer.sprite = WalkSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Safety")
            CanHide = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Safety")
            CanHide = false; 
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Enemy")
            Debug.Log("BAD TOUCH, BADDDDDD TOUCH");
    }
}