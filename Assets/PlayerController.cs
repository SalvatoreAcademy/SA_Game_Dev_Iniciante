using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fireballPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Caso o usuário pressione a barra de espaço, entra no if no momento
        // que começou a pressionar a tecla
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atirar();
        }
    }

    private void Atirar()
    {
        // Precisamos do Prefab da Fireball
        // Vamos pegar o Prefab da Fireball e criar uma cópia na mesma posição do jogador
        var playerPosition = transform.position;
        var rotation = Quaternion.identity;
        Instantiate(fireballPrefab, playerPosition, rotation);
    }
}
