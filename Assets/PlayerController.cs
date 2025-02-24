using Cainos.PixelArtTopDown_Basic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject fireballPrefab;

    private TopDownCharacterController topDownCharacterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        topDownCharacterController = GetComponent<TopDownCharacterController>();
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
        Instantiate(fireballPrefab, playerPosition, Quaternion.Euler(0, 0, rotationZ));
    }
}
