using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;


    private void Update()
    {

        if (gm.enemies.Count() == 0)
        {
            transform.position = player.transform.position;
        }
        else{
            Transform nClosest = gm.enemies.OrderBy(t => (t.transform.position - player.transform.position).magnitude)
                   .FirstOrDefault().transform;

            transform.position = nClosest.position;
        }

    }
}
