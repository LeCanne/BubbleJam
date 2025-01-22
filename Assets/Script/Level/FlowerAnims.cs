using System;
using UnityEngine;

public class FlowerAnims : MonoBehaviour
{

    public float speed;
    public float speedRotation;
    public float height;
    private Rigidbody2D rb;
    Vector3 origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origin = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         rb.angularVelocity = speedRotation * Time.fixedDeltaTime;
        
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height;
        //set the object’s Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, origin.y + newY, transform.position.z);
    }
}
