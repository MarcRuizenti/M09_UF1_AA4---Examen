using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies;

    private void Awake()
    {

    }

    void Update()
    {

    }


    public void DeleteList(GameObject delete)
    {
        enemies.Remove(delete);
    }
}
