using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawned : MonoBehaviour
{
    public float speedIsland = 0.1f;
    public float speedMissile = 0.1f;
    private Transform player;
    public GameObject island;
    public GameObject missile;

    private bool isMissile = false;
    private bool isIsland = false;

    public float rotateSpeed = 200f;
    private Rigidbody2D rb;

    private void Awake()
    {
        if (CompareTag("Missile"))
        {
            rb = GetComponent<Rigidbody2D>();
            isMissile = true;
        }
        if (CompareTag("Island"))
        {
            isIsland = true;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Destroy(collision.gameObject);
    }

    private void FixedUpdate()
    {
        if(isIsland) transform.Translate(new Vector2(-speedIsland, 0));
        if (isMissile)
        {
            if (transform.position.x > player.position.x)
            {
                Vector2 direction = (Vector2)player.position - rb.position;
                direction.Normalize();
                float rotateAmount = Vector3.Cross(direction, transform.right).z;
                rb.angularVelocity = -rotateAmount * rotateSpeed;
                rb.velocity = transform.right * speedMissile;
            }
            else rb.angularVelocity = 0; 
        }
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < -screenBounds.x) Destroy(gameObject);
    }
}