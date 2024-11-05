using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    public float speedRotation;
    public float speed;
    public float stoppingDistance;
    public GameObject player;
    private Rigidbody rb;
    private Animator animator;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 direcion = player.transform.position - transform.position;
        Vector3 velocity = Vector3.zero;

        if (direcion.magnitude <= 3)
        {
            velocity = direcion.normalized * speed * Time.deltaTime;
        }
        else
        {
            velocity = direcion * ((speed * Time.deltaTime) / 2);
        }

        animator.SetFloat("Velocity", direcion.magnitude);

        velocity.y = transform.position.y;
        transform.position += velocity;


        Quaternion toRotation = Quaternion.LookRotation(direcion, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speedRotation * Time.deltaTime);

    }

    public void Kill()
    {

    }
}
