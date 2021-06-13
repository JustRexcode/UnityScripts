using UnityEngine;

namespace Assets.Project.Scripts.CSharp
{
    public class FirstPersonController : MonoBehaviour
    {
        //Public Variables
        [Header("Components")]
        public Transform player;
        
        [Space]
        
        public Transform mainCamera;
        [Tooltip("Cinemachine Virtual Camera")]
        public Transform virtualCamera;
 
        [Header("Options")]
        public float playerSpeed = 1f;
        public float cameraSensitivity = 100f;

        //Private Variables
        private float _mouseX, _mouseY, _rotationX, _rotationY = 0f;
        private float _movementX, _movementY = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
 
        void Update()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                CameraRotation();
                PlayerMovement();
            }
            
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
 
        void PlayerMovement()
        {
            _movementX = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
            _movementY = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
            
            player.Translate(_movementX, 0, _movementY);
            mainCamera.position = virtualCamera.position;
        }
 
        void CameraRotation()
        {
            _mouseX = Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
            _mouseY = Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
            
            _rotationX -= _mouseY;
            _rotationY += _mouseX;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 35f);
            
            player.localRotation = Quaternion.Euler(0, _rotationY, 0);
            mainCamera.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        }
    }
}
