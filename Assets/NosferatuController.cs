using UnityEngine;

public class NosferatuController : MonoBehaviour
{
    // Prefab da Fireball referenciado direto pela Unity
    public GameObject fireballPrefab;

    // Tempo entre cada ataque
    public float delayToAttack = 1;

    private Rigidbody2D rb;

    private int dirX = -1;
    private int dirY = 0;

    public float intervalRandomDirection = 4f;
    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Pegamos o componente do tipo Rigidbody2D que está no GameObject do Nosferatu
        rb = GetComponent<Rigidbody2D>();

        // Executará o método "Shoot" uma vez a cada delayToAttack segundos
        InvokeRepeating(nameof(Shoot), 0, delayToAttack);

        InvokeRepeating(nameof(SetRandomDirection), 0, intervalRandomDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void SetRandomDirection()
    {
        dirX = Random.Range(-1, 2);
        dirY = Random.Range(-1, 2);
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(dirX * speed, dirY * speed);
    }

    // TODO: Saiu da Area, quero identificar e inverter a direção

    private void Shoot()
    {
        // Precisamos do Prefab da Fireball
        // Vamos pegar o Prefab da Fireball e criar uma cópia na mesma posição do jogador
        var playerPosition = transform.position;
        var rotation = Quaternion.identity;
        Instantiate(fireballPrefab, playerPosition, rotation);
    }
}
