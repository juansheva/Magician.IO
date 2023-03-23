using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    private EnemyManager _enemyManager;
    public GameObject keluarBullet;
    public GameObject bullet;

    public float fireRate;

    public float fireRateSimpenan;

    public GameObject closestEnemy
    {
        get
        {
            var enemy = _enemyManager.allEnemy.OrderBy(x =>
                Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
            return enemy.gameObject;
        }
    }

    private void Awake()
    {
        fireRateSimpenan = fireRate;
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void Update()
    {
        //transform.right = closestEnemy.transform.position - transform.position;

        if (fireRate >= 0)
        {
            fireRate -= Time.deltaTime;
        }

        if (fireRate < 0)
        {
            fireRate = fireRateSimpenan;
            GameObject bulletTemp =Instantiate(bullet,keluarBullet.transform.position,Quaternion.identity);
            Rigidbody2D rbBulletTemp = bulletTemp.GetComponent<Rigidbody2D>();
            rbBulletTemp.AddForce(transform.right*10,ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletTemp =Instantiate(bullet,keluarBullet.transform.position,Quaternion.identity);
            Rigidbody2D rbBulletTemp = bulletTemp.GetComponent<Rigidbody2D>();
            rbBulletTemp.AddForce(transform.right*10,ForceMode2D.Impulse);

        }
    }
}
