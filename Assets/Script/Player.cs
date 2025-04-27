using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float Speed;
    private Vector3 Movement;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void FixedUpdate()
    {
        rb.linearVelocity=new Vector3 (Movement.x*Speed,rb.linearVelocity.y,Movement.z *Speed);
    }
    private void OnEnable()
    {
        InputReader.movimiento += Movimiento;
    }
    private void OnDisable()
    {
        InputReader.movimiento -= Movimiento;
    }
    private void Movimiento(Vector2 movi)
    {
        Movement = new Vector3(movi.x,0, movi.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscenaNueva"))
        {
            Escenas();
        }
    }
    public void Escenas()
    {
        SceneManager.LoadScene("Mundo 2");
    }
}
