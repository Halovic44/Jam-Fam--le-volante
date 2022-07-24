using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 pos = Vector3.zero;

    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime / 3;
        verticalMovement = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime / 3;
        MovePlayer(horizontalMovement, verticalMovement);
    }

    private void MovePlayer(float horizontalMovement, float verticalMovement)
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (transform.position.x < -screenBounds.x+1 && horizontalMovement<0) horizontalMovement = 0;
        if (transform.position.x > screenBounds.x-1 && horizontalMovement>0) horizontalMovement = 0;
        if (transform.position.y < -screenBounds.y+1 && verticalMovement<0) verticalMovement = 0;
        if (transform.position.y > screenBounds.y-1 && verticalMovement>0) verticalMovement = 0;
        transform.Translate(new Vector2(horizontalMovement, verticalMovement));

    }
}