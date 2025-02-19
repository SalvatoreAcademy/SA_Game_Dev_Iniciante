using UnityEngine;

public class NosferatuController : MonoBehaviour
{
    // Prefab da Fireball referenciado direto pela Unity
    public GameObject fireballPrefab;

    // Tempo entre cada ataque
    public float delayToAttack = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Executará o método "Shoot" uma vez a cada delayToAttack segundos
        InvokeRepeating(nameof(Shoot), 0, delayToAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        // Precisamos do Prefab da Fireball
        // Vamos pegar o Prefab da Fireball e criar uma cópia na mesma posição do jogador
        var playerPosition = transform.position;
        var rotation = Quaternion.identity;
        Instantiate(fireballPrefab, playerPosition, rotation);
    }
}
