using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Ball_Movement ballMovement;
    public ScoreManager scoreManager;

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player_1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y ) / racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.name=="Player_1"|| collision.gameObject.name == "Player_2")

        {
            Bounce(collision);
        }

        else if (collision.gameObject.name=="Right border")
        {
            scoreManager.Player1Goal();
        }

        else if ( collision.gameObject.name == "Left border")
        {
            scoreManager.Player2Goal();
        }
    }
    
}
