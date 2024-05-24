using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;

    [Header("Velocidad del jugador")]
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    [Space]
    [Header("Cámara para apuntar")]
    [SerializeField] private Camera cam;
    Vector2 mousePosition;
    private float angle;

    [Space]
    [Header("Vida")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    [Space]
    [Header("Punto de Disparo")]
    [SerializeField] private Transform shootingPoint;

    [Space]
    [Header("Metralleta")]
    [SerializeField] private GameObject machinegunBulletPrefab;
    [SerializeField] private float machinegunBulletSpeed;
    [SerializeField] private bool canShootMachinegun;
    [SerializeField] private float machinegunShootCooldown;
    [SerializeField] private int machinegunAmmo;

    [Space]
    [Header("Bazooka")]
    [SerializeField] private GameObject bazookaBulletPrefab;
    [SerializeField] private float bazookaBulletSpeed;
    [SerializeField] private bool canShootBazooka;
    [SerializeField] private float bazookaShootCooldown;
    [SerializeField] private int bazookaAmmo;

    public static PlayerController Instance { get { return instance; } }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        instance = this;
    }

    private void Update()
    {
        Move();
        GetMousePosition();
        MachineGun();
        Bazooka();
    }

    private void FixedUpdate()
    {
        PlayerRotation();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2 (horizontal, vertical)  * speed;
        rb2d.velocity = movement;
    }

    void GetMousePosition()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void PlayerRotation()
    {
        Vector2 lookDir = mousePosition - rb2d.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    void MachineGun()
    {        
        if(Input.GetButton("Fire1"))
        {
            if (!canShootMachinegun) return;
            else
            {
                
                if (machinegunAmmo > 0)
                {
                    GameObject playerMachinegunBullet = Instantiate(machinegunBulletPrefab);
                    playerMachinegunBullet.transform.position = shootingPoint.transform.position;

                    Rigidbody2D playerMachinegunBulletRB2D = playerMachinegunBullet.GetComponent<Rigidbody2D>();
                    playerMachinegunBulletRB2D.AddForce(shootingPoint.up * machinegunBulletSpeed, ForceMode2D.Impulse);

                    machinegunAmmo--;
                    canShootMachinegun = false;

                    Invoke(nameof(ResetMachinegun), machinegunShootCooldown);
                }
            }
        }
    }

    void ResetMachinegun() { canShootMachinegun = true; }

    public void AddMachinegunAmmo(int amount)
    {
        if (amount > 30) amount = 30;
        machinegunAmmo += amount;
    }

    void Bazooka()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if (!canShootBazooka) return;
            else
            {
                if(bazookaAmmo > 0)
                {
                    GameObject playerBazookaBullet = Instantiate(bazookaBulletPrefab);
                    playerBazookaBullet.transform.position = shootingPoint.transform.position;

                    Rigidbody2D playerBazookaBulletRB2D = playerBazookaBullet.GetComponent<Rigidbody2D>();
                    playerBazookaBulletRB2D.AddForce(shootingPoint.up * bazookaBulletSpeed, ForceMode2D.Impulse);

                    bazookaAmmo--;
                    canShootBazooka = false;

                    Invoke(nameof(ResetBazooka), bazookaShootCooldown);
                }
            }
        }
    }

    public void AddBazookaAmmo(int amount)
    {
        if (amount > 3) amount = 3;
        bazookaAmmo += amount;
    }

    void ResetBazooka() { canShootBazooka = true; }
}
