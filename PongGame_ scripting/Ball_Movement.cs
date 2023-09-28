using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball_Movement : MonoBehaviour
{ 

    public float startSpeed;
    public float extraSpeed;
    public float maxextraSpeed;


    private int hitCounter = 0;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

        public IEnumerator Launch()
        {
            hitCounter = 0;
            yield return new WaitForSeconds(1);
            MoveBall(new Vector2(-10, 0));
        }
    

    public void MoveBall(Vector2 direction)
    {
        direction=direction.normalized;
        float ballSpeed = startSpeed + hitCounter * extraSpeed;
        rb.velocity = direction * ballSpeed;
    }
    
    public void IncreaseHitCounter()
    { if(hitCounter * extraSpeed < maxextraSpeed)
        {
            hitCounter++;
        }
                }
}
