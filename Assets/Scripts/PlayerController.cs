using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float speedRotation;
    private Rigidbody rb;
    public Transform target;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.velocity = direction * speed * Time.deltaTime;

        Vector3 rotacion = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(rotacion, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speedRotation * Time.deltaTime);
    }
}
