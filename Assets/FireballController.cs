using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Velocidade da Fireball
    public float speed = 5;

    // Tempo para destruir a Fireball automaticamente
    public float delayToDestroy = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destrói o gameObject da Fireball depois de delayToDestroy segundos
        Destroy(gameObject, delayToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // Movimenta o transform da Fireball para a direita a uma velocidade declarada em speed
        // Time.deltaTime corrige o movimento para ser independente de quantos FPS o jogo está rodando
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
}
