using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables Principales
    [SerializeField]
    private Transform _player, _playerCamera, _focusPoint;
    [SerializeField]
    private float _cameraHeight = 2;
    #endregion

    #region Variables Acercamiento Cámara
    [SerializeField]
    private float _zoom = -15f, _zoomSpeed = 3f;
    [SerializeField]
    private float _zoomMax = -5f, _zoomMin = -30f;
    #endregion

    #region Variables Movimiento cámara
    [SerializeField]
    private float _camRotX, _camRotY;
    [SerializeField]
    private float _cameraSentivity = 4;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region Revisar asignaciones
        if(_player == null)
        {
            Debug.LogWarning("El jugador no se asignó en el inspector de la camare");
        }
        if(_playerCamera == null)
        {
            Debug.LogWarning("La camara no se asignó en el inspector de la camare");
        }
        if(_focusPoint == null)
        {
            Debug.LogWarning("El punto de foco o privote no se asignó en el inspector de la camare");
        }
        #endregion

        #region Asignar parentesco
        _focusPoint.SetParent(_player);
        _playerCamera.SetParent(_focusPoint);
        #endregion

        #region Inicializar posición y rotación
        _focusPoint.localPosition = new Vector3(0, _cameraHeight, 0);
        _focusPoint.localRotation = Quaternion.Euler(0, 0, 0);
        _playerCamera.localPosition = new Vector3(0, 0, _zoom);
        _playerCamera.LookAt(_player);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        #region Acercamiento
        _zoom += Input.GetAxis("Mouse ScrollWheel")*_zoomSpeed;
        _zoom = Mathf.Clamp(_zoom, _zoomMin, _zoomMax);
        _playerCamera.localPosition = new Vector3(0, 0, _zoom);
        #endregion

        #region Movimiento cámara
        if(Input.GetMouseButton(1))//1 = Click derecho
        {
            _camRotX += Input.GetAxis("Mouse X") * _cameraSentivity;//Yaw
            _camRotY += Input.GetAxis("Mouse Y") * _cameraSentivity;//Pitch
            _camRotY = Mathf.Clamp(_camRotY, -5, 50);
            _focusPoint.localRotation = Quaternion.Euler(_camRotY, 0, 0);
            _player.localRotation = Quaternion.Euler(0, _camRotX, 0);
        }
        #endregion
        _playerCamera.LookAt(_player);
    }
}
