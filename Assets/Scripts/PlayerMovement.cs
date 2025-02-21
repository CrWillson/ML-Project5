using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float playerSpeed;
    private Rigidbody _rBody;
    private Vector2 move_dir;
    private PlayerControls input;

    private void Awake()
    {
        input = new PlayerControls();
        _rBody=GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Debug.Log("Enabled");
        input.player.Enable();
    }
    private void OnDisable()
    {
        Debug.Log("Disabled");
        input.player.Disable();
    }

    void FixedUpdate()
    {
        

        move_dir = input.player.Movement.ReadValue<Vector2>();

        _rBody.velocity= new Vector3(move_dir.x * playerSpeed, 0, move_dir.y * playerSpeed);
    }
}
