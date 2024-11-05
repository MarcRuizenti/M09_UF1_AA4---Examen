using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadeController : MonoBehaviour
{
    Rigidbody rb;
    public LayerMask mask;
    public float launchForce;
    public float timer;
    public float radius;
    public float explosionForce;
    public GameObject particles;
    public Vector3 direction;
    public float counter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(direction * launchForce);
        counter = timer;

    }

    private void Update()
    {

        if (counter < 0)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            RaycastHit hit;
            Physics.SphereCast(transform.position, radius, transform.up, out hit, radius, mask);
            if (hit.collider.GetComponent<EnemyController>() != null)
            {
                hit.collider.gameObject.GetComponent<EnemyController>().Kill();
            }
            Destroy(transform.gameObject);
        }
        else
        {
            counter -= Time.deltaTime;
        }

        Debug.Log(counter);
    }
}
