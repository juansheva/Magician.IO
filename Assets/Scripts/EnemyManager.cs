using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public LayerMask enviLayer;
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

    public GameObject prefab;



    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSomething();
        }
    }

    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapAreaAll(cameraRightTop+new Vector2(cameraWidth,cameraHeight)*0.25f, cameraLeftBottom-new Vector2(cameraWidth,cameraHeight)*0.25f,enviLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;
            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;
            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }
        
        return true;

    }

    public void SpawnSomething()
    {
        Vector3 spawnPos=Vector3.zero;
        bool canSpawnHere = false;
        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(cameraWidthPoint.x*1.5f, cameraWidthPoint.y*1.5f);
            float spawnPosY = Random.Range(cameraHeightPoint.x*1.5f, cameraHeightPoint.y*1.5f);
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

        }
        Debug.Log(spawnPos);
        Instantiate(prefab, spawnPos, quaternion.identity);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireCube(Camera.main.gameObject.transform.position,new Vector3(cameraRightPoint-cameraLeftPoint,cameraTopPoint - cameraBottomPoint,0f)*1.5f);

        
    }
}
