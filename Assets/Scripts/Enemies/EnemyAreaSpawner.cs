using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAreaSpawner : MonoBehaviour
{
    [SerializeField] private float areaRange;
    [SerializeField] private GameObject enemyToSpawn;

    void Spawn()
    {
        GameObject obj = Instantiate(enemyToSpawn);
        Vector2 pos = transform.position;
        obj.transform.position = new Vector2(
            Random.Range(pos.x - areaRange, pos.x + areaRange),
            Random.Range(pos.y - areaRange, pos.y + areaRange));
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, areaRange);
    }

}
