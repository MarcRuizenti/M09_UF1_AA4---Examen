using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    public LineRenderer line;
    public float lineFadeSpeed;
    public LayerMask mask;
    public float knockbackForce = 10;
    void Update()
    {
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - Time.deltaTime * lineFadeSpeed);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - Time.deltaTime * lineFadeSpeed);

        if (Input.GetButtonDown("Fire1"))
        {

            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 10, mask);
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<EnemyController>() != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyController>().Kill();
                }
                if (hit.collider.GetComponent<Rigidbody>() != null) hit.collider.GetComponent<Rigidbody>().AddForce(transform.forward * knockbackForce);
            }

            line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, 1);
            line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, 1);

            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position + transform.forward * hit.distance);

            
        }
    }
}
