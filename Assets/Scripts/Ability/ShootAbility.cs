using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shoot Ability",menuName = "Ability/Shoot Ability")]
public class ShootAbility : PlayerAbility
{
    public GameObject bulletPrefab;
    public float fireRate;

    private float _fireRateCounter;


    public void Active(GameObject target, GameObject parent)
    {
        if (_fireRateCounter <= 0)
        {
            GameObject tempBullet = Instantiate(bulletPrefab);
            Rigidbody2D tempRbBullet = tempBullet.GetComponent<Rigidbody2D>();
            if (!tempBullet)
            {
                Debug.LogError($"Theres no Rigidbody in {abilityName} prefab");
                return;
            }

            _fireRateCounter = fireRate;

        }

        if (_fireRateCounter > 0)
        {
            _fireRateCounter -= Time.deltaTime;
        }

    }
}
