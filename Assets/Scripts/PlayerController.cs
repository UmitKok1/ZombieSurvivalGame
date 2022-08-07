using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float MovementSpeed = 5;
    //void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.W)) // Up
    //    {
    //        transform.position += Vector3.forward * MovementSpeed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.S)) // Down
    //    {
    //        transform.position += Vector3.back * MovementSpeed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.A)) // Left
    //    {
    //        transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
    //    }

    //    if (Input.GetKey(KeyCode.D)) // Right
    //    {
    //        transform.position += Vector3.right * MovementSpeed * Time.deltaTime;
    //    }
    //}
    public Rigidbody rb;
    public float speed = 300;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction.Normalize();
        rb.velocity = transform.TransformDirection(direction) * speed * Time.deltaTime;

    }
}
