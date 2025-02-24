using UnityEngine;

public class NosferatuController : MonoBehaviour
{
    // Prefab da Fireball referenciado direto pela Unity
    public GameObject fireballPrefab;

    // Tempo entre cada ataque
    public float delayToAttack = 1f;

    private Rigidbody2D rb;

    private float directionX = 0f;
    private float directionY = 0f;

    private int randomDirectionX = -1;
    private int randomDirectionY = 0;

    public float intervalRandomDirection = 4f;
    public float speed = 2f;

    // TODO: Temos que ter um modo de Patrulha ou de Perseguição

    private bool isPlayerOnSight = false;

    private GameObject player;

    public float distanceToSeePlayer = 6f;

    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Pegamos o componente do tipo Rigidbody2D que está no GameObject do Nosferatu
        rb = GetComponent<Rigidbody2D>();

        // Pegamos o componente do tipo SpriteRenderer que está no GameObject do Nosferatu
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");

        // Executará o método "Shoot" uma vez a cada delayToAttack segundos
        InvokeRepeating(nameof(Shoot), 0, delayToAttack);

        InvokeRepeating(nameof(SetRandomDirection), 0, intervalRandomDirection);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        UpdateIsPlayerOnSight();

        UpdateSprite();
    }

    void UpdateSprite()
    {
        spriteRenderer.flipX = directionX > 0f;
    }

    void UpdateIsPlayerOnSight()
    {
        var playerPosition = player.transform.position;
        var nosferatuPosition = transform.position;
        var playerDistance = Vector3.Distance(playerPosition, nosferatuPosition);

        if (playerDistance <= distanceToSeePlayer)
        {
            isPlayerOnSight = true;
        }
        else
        {
            isPlayerOnSight = false;
        }
        // DICA: If/Else poderia ser removido e substituído pela linha a seguir
        // isPlayerOnSight = playerDistance <= distanceToSeePlayer;
    }

    void SetRandomDirection()
    {
        randomDirectionX = Random.Range(-1, 2);
        randomDirectionY = Random.Range(-1, 2);
    }

    void Move()
    {
        directionX = randomDirectionX;
        directionY = randomDirectionY;

        if (isPlayerOnSight)
        {
            // Direção do movimento para seguir o jogador, deve ser calculada da seguinte maneira:
            // (Posição do Player - Posição do Nosferatu)
            // Quando subtraímos dois vetores, o resultado é a direção + a intensidade (também é conhecido como magnitude)
            // Para pegar esse resultado e extrair apenas a direção, vamos usar a declaração `normalized` (magnitude = 1)
            var playerPosition = player.transform.position;
            var nosferatuPosition = transform.position;

            var playerDirection = (playerPosition - nosferatuPosition).normalized;
            directionX = playerDirection.x;
            directionY = playerDirection.y;
        }

        rb.linearVelocity = new Vector2(directionX * speed, directionY * speed);
    }

    private void Shoot()
    {
        // Precisamos do Prefab da Fireball
        // Vamos pegar o Prefab da Fireball e criar uma cópia na mesma posição do jogador
        var playerPosition = transform.position;
        var rotation = Quaternion.identity;
        Instantiate(fireballPrefab, playerPosition, rotation);
    }

    // OnTriggerEnter2D é chamado por todos os Collider2D que estiverem marcados como `IsTrigger`
    // e tocaram o Rigidbody/Collider2D do GameObject em questão (no caso, PlayerController)
    void OnTriggerEnter2D(Collider2D coll)
    {
        // Caso o Collider2D (Trigger) detectado possua a Tag "Fireball"
        if (coll.CompareTag("Fireball"))
        {
            // Pegamos o script FireballController que está no mesmo GameObject da variável `coll`
            var fireballScript = coll.GetComponent<FireballController>();

            // Checamos se a Fireball foi criada pelo Player
            // if (fireballScript.isFromPlayer == true) {
            if (fireballScript.isFromPlayer) {
                // Destruir o GameObject do Nosferatu
                Destroy(gameObject);

                // Destruir a Fireball
                Destroy(coll.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.name == "Nosferatu Area")
        {
            randomDirectionX *= -1;
            randomDirectionY *= -1;
        }
    }
}
