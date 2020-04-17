using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    CharacterA playerCharacter;
    int i;
    void Start()
    {
        playerCharacter = GetComponent<CharacterA>();
    }

    void Update()
    {
        CheakInput();
    }

    /// <summary>
    /// 检测按键输入
    /// </summary>
    void CheakInput()
    {
        playerCharacter.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //GetAxisRaw无加速过程，想要有可以用GetAxis

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCharacter.Speed = playerCharacter.slowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerCharacter.Speed = playerCharacter.fastSpeed;
        }
        if (Input.GetButtonDown("Fire1") && i < 15)
        {
            playerCharacter.Shoot(i);
        }
        if (Input.GetButton("Fire1"))
        {
            i++;
            playerCharacter.Shoot(i);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            i = 0;
            playerCharacter.Shoot(i);
        }

    }
}
