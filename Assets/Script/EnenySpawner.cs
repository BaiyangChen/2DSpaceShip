using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnenySpawner : MonoBehaviour
{
    public Enemy enemy;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 0.1f, speed); //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
    }

    private void GenerateEnemy(){
        Instantiate(enemy.gameObject, enemy.SpawnPosition(), Quaternion.identity);
    }
}
