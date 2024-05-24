using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLifetime : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    private float lifeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime();
    }

    void LifeTime()
    {
        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
