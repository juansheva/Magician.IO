
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour
{

    public PlayerAbility[] allPlayerAbility;

    public ShootAbility[] ShootAbilities;
    private EnemyManager _enemyManager;
    public GameObject keluarBullet;
    public GameObject bullet;

    public float fireRate;

    public float fireRateSimpenan;

    // public GameObject closestEnemy
    // {
    //     get
    //     {
    //         var enemy = _enemyManager.allEnemy.OrderBy(x =>
    //             Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    //         return enemy.gameObject;
    //     }
    // }

    private void Awake()
    {
        fireRateSimpenan = fireRate;
        _enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void Update()
    {
        var tempShootAbility = allPlayerAbility.Where(x=>x.GetComponent<ShootAbility>()).Select(x=>x.GetComponent<ShootAbility>()).ToArray();
        //Debug.Log(coba.Count());

        ShootAbilities = tempShootAbility;
        //Debug.Log(tempShootAbility.Count());
        //Debug.Log(shootAbility.Count);
        //transform.right = closestEnemy.transform.position - transform.position;

        // Vector2 targetDirection = closestEnemy.transform.position - transform.position;
        //
        // targetDirection.Normalize();
        //
        // if (fireRate >= 0)
        // {
        //     fireRate -= Time.deltaTime;
        // }
        //
        // if (fireRate < 0)
        // {
        //     fireRate = fireRateSimpenan;
        //     GameObject bulletTemp =Instantiate(bullet,transform.position,Quaternion.identity);
        //     Rigidbody2D rbBulletTemp = bulletTemp.GetComponent<Rigidbody2D>();
        //     rbBulletTemp.AddForce(targetDirection*10,ForceMode2D.Impulse);
        // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GameObject bulletTemp =Instantiate(bullet,transform.position,Quaternion.identity);
        //     Rigidbody2D rbBulletTemp = bulletTemp.GetComponent<Rigidbody2D>();
        //     rbBulletTemp.AddForce(targetDirection*10,ForceMode2D.Impulse);
        //
        // }
    }
}
