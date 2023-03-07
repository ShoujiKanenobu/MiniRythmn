using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    //left = 0, mid = 1, right = 2
    private int currentPosition;
    public GameObject[] lanes;

    public GameEvent StartGame;
    public GameEvent PlayerDeath;
    public GameEvent LoadNewSong;

    public VisualEffect deathVFX;

    private PlayerInput playerInput;
    private InputAction leftAction;
    private InputAction rightAction;
    private InputAction selectAction;
    private InputAction rAction;

    private bool dead;

    void Start()
    {
        dead = true;
        playerInput = GetComponent<PlayerInput>();
        leftAction  = playerInput.currentActionMap.FindAction("Left");
        rightAction  = playerInput.currentActionMap.FindAction("Right");
        selectAction = playerInput.currentActionMap.FindAction("Select");
        rAction = playerInput.currentActionMap.FindAction("NewSong");


        selectAction.performed += RestartGame;
        leftAction.performed += MoveLeft;
        rightAction.performed += MoveRight;
        rAction.performed += NewSong;


        currentPosition = 1;
        UpdatePosition();
        StartGame.Raise();
        PlayerDeath.Raise();
    }

    public void NewSong(InputAction.CallbackContext context)
    {
        if(dead)
            LoadNewSong.Raise();
    }

    private void RestartGame(InputAction.CallbackContext context)
    {
        if (!dead)
            return;

        dead = false;
        currentPosition = 1;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        this.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = lanes[currentPosition].transform.position;
        StartGame.Raise();
    }



    public void UpdatePosition()
    {
        transform.DOMove(lanes[currentPosition].transform.position, 0.2f);
    }

    public void MoveLeft(InputAction.CallbackContext context)
    {
        if (currentPosition > 0 && !dead)
            currentPosition--;
        UpdatePosition();
    }
    public void MoveRight(InputAction.CallbackContext context)
    {
        if (currentPosition < 2 && !dead)
            currentPosition++;
        UpdatePosition();
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
            Die();
    }

    public void Die()
    {
        dead = true;
        deathVFX.Play();
        PlayerDeath.Raise();
    }

}
