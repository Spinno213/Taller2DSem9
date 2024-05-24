using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmoToPlayer : MonoBehaviour
{
    [SerializeField] private int amountToAdd;
    [SerializeField] private bool toBazooka;
    [SerializeField] private bool toMachinegun;
    private PlayerController player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddAmmo();
            Destroy(gameObject);
        }
    }

    void AddAmmo()
    {
        if(toMachinegun)
        {
            player.AddMachinegunAmmo(amountToAdd);
        }
        if(toBazooka)
        {
            player.AddBazookaAmmo(amountToAdd);
        }
    }
}
