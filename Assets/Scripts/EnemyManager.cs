using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public LayerMask enviLayer;
    public List<EnemyController> allEnemy;
    private float cameraRightPoint => Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    private float cameraLeftPoint => Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
    public Vector2 cameraWidthPoint=>new Vector2(cameraLeftPoint, cameraRightPoint);
    public float cameraWidth => cameraWidthPoint.y - cameraWidthPoint.x;
    
    private float cameraTopPoint => Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    private float cameraBottomPoint => Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    public Vector2 cameraHeightPoint=>new Vector2(cameraBottomPoint, cameraTopPoint);
    public float cameraHeight => cameraHeightPoint.y - cameraHeightPoint.x;

    public Vector2 cameraRightTop=>new Vector2(cameraRightPoint, cameraTopPoint);
    public Vector2 cameraLeftBottom=>new Vector2(cameraLeftPoint, cameraBottomPoint);



    public Collider2D[] colliders;

    private void Update()
    {
        colliders = Physics2D.OverlapAreaAll(cameraRightTop+new Vector2(cameraWidth,cameraHeight)*0.25f, cameraLeftBottom-new Vector2(cameraWidth,cameraHeight)*0.25f,enviLayer);
        //
        Debug.Log(cameraRightTop);
        //
        // Debug.Log(cameraRightTop*1.5f);

        //Debug.Log(cameraLeftBottom*1.5f);

        //PreventSpawnOverlap(transform.position);
    }

    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapAreaAll(cameraRightTop+new Vector2(cameraWidth,cameraHeight)*0.25f, cameraLeftBottom-new Vector2(cameraWidth,cameraHeight)*0.25f,enviLayer);
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(transform.position,new Vector3(cameraRightPoint-cameraLeftPoint,cameraTopPoint - cameraBottomPoint,0f)*1.5f);

        
    }
}
