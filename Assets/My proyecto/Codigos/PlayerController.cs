using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    #region Variable Movimiento
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float _MovementSpeed = 5f;
    [SerializeField] //Mostrar en pantalla las caracteristicas
    private float _horizontalInput, _forwardInput;
    #endregion

    private Rigidbody _PlayerRB;

    private PlayerAnimation _playerAnimator;

    private bool _isRunning = true;
    private float _maxMovementSpeed = 21f;

    // Start is called before the first frame update

    private void Start()
    {
        #region Rigidbody
        _PlayerRB = GetComponent<Rigidbody>();
        if (_PlayerRB == null)
        {
            Debug.LogWarning("El jugador no tiene un componente de cuerpo rigido");
        }
        #endregion

        #region Obtener Animación
        _playerAnimator = GetComponentInChildren<PlayerAnimation>();
        if (_playerAnimator == null)
        {
            Debug.LogWarning("El jugador no tiene animator");
        }
        #endregion

        if (_isRunning)
        {
            _MovementSpeed = _maxMovementSpeed;
        }
        else
        {
            _MovementSpeed = _maxMovementSpeed * 0.4f;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        _MovementSpeed = _maxMovementSpeed * 0.5f;
        #region Movimiento
        _horizontalInput = Input.GetAxis("Horizontal");//Teclas A, D: izquierda dererecha
        _forwardInput = Input.GetAxis("Vertical");//Teclas D, W: arriba abajo
        Vector3 movement = new Vector3(_horizontalInput, 0, _forwardInput);
        transform.Translate(movement * Time.deltaTime * _MovementSpeed);
        #endregion
        float velocity = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_forwardInput));
        velocity *= _MovementSpeed / _maxMovementSpeed;

        _playerAnimator.setSpeed(velocity);

    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Se encontró un trigger (objeto)");
        if (other.gameObject.CompareTag("Interactable"))
        {
            //Debug.Log("Tiene tag Interactable (interactuable)");
            Interactable interacted = other.GetComponent<Interactable>();
            if (interacted == null)
            {
                //Debug.Log("El objeto no tiene script (codigo) para interactuar");
            }
            else
            {
                //Debug.Log("Tiene script (codigo) para interactuar");
                interacted.Interact(this);
            }
        }
    } 
}
