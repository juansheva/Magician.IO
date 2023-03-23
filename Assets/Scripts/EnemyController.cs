using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyManager _enemyManager;
    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = FindObjectOfType<EnemyManager>();
        _enemyManager.allEnemy.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
