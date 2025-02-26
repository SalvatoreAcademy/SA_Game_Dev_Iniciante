using System.Security.Cryptography;
using Cainos.PixelArtTopDown_Basic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject fireballPrefab;

    private TopDownCharacterController topDownCharacterController;

    public GameObject gameOverCanvas;

    private bool isDead;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topDownCharacterController = GetComponent<TopDownCharacterController>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Caso o usuário pressione a barra de espaço, entra no if no momento
        // que começou a pressionar a tecla
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // Caso o jogador esteja morto (isDead = true) e o usuário apertou Z, reinicia a cena
        if (isDead && Input.GetKeyDown(KeyCode.Z))
        {            
            SceneManager.LoadScene(0);
        }
    }

    private void Shoot()
    {
        // Precisamos do Prefab da Fireball
        // Vamos pegar o Prefab da Fireball e criar uma cópia na mesma posição do jogador
        var playerPosition = transform.position;

        // Rotação em Jogo 2D é sempre no Z
        // Player Direita (2) -> Rotação Z 0
        // Player Cima (1) -> Rotação Z 90
        // Player Esquerda (3) -> Rotação Z 180
        // Player Baixo (0) -> Rotação Z 270
        var rotationZ = 0f;
        var direction = topDownCharacterController.direction;
        if (direction == 0) {
            rotationZ = 270;
        } else if (direction == 1) {
            rotationZ = 90;
        } else if (direction == 2) {
            rotationZ = 0;
        } else if (direction == 3) {
            rotationZ = 180;
        }

        // eulerAngles (x, y e z - 0º a 360º)
        // Quaternion (x, y, z e w)
        var fireball = Instantiate(fireballPrefab, playerPosition, Quaternion.Euler(0, 0, rotationZ));
        var fireballScript = fireball.GetComponent<FireballController>();
        fireballScript.isFromPlayer = true;
    }

    // Se algum inimigo tocar no Player, destrói o Player e reinicia a cena
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Define o valor de isDead como true, para saber que o jogador morreu
            isDead = true;

            // Desativar o Rigidbody do Player
            rb.simulated = false;

            // Exibe o GameOver Canvas
            gameOverCanvas.SetActive(true);
        }
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

            // Checamos se a Fireball não foi criada pelo Player
            // if (fireballScript.isFromPlayer == false) {
            if (!fireballScript.isFromPlayer) {
                // Destruir o GameObject do jogador
                Destroy(gameObject);

                // Destruir a Fireball
                Destroy(coll.gameObject);

                // Reiniciar a cena atual
                SceneManager.LoadScene(0);
            }
        }
    }
}
