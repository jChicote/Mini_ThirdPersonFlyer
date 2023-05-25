using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdPersonFlyer.CoreSystems
{

    public class FlightManager : MonoBehaviour
    {

        #region - - - - - - Fields - - - - - -

        // References
        private Rigidbody m_FlightRigidbody;
        private Transform m_CameraTransform;
        private Transform m_CameraRigTransform;
        private Transform m_CameraViewAimTransform;

        // Default values
        private float m_DefaultThrottlePower;

        // Current values
        private float m_ThrottlePower;
        private float m_Speed;
        private Vector3 m_Velocity;
        private float m_Sensitivity;
        private float m_CameraSmoothSpeed;

        private Vector3 m_MouseAimPosition;

        // Flight inputs
        private float m_Yaw = 0f;
        private float m_Pitch = 0f;
        private float m_Roll = 0f;

        #endregion Fields

        #region - - - - - - Properties - - - - - -

        public float Yaw { get; private set; }

        public float Pitch { get; private set; }

        public float Roll { get; private set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        void Start()
        {
            // Get component references
            this.m_FlightRigidbody = this.GetComponent<Rigidbody>();

            // Get initial values
            this.m_DefaultThrottlePower = 1f;
        }

        void Update()
        {
            this.RotateFlyer();
            this.MoveFlyer();
        }

        public void RotateFlyer(Vector2 screenPosition)
        {
            // Scale the input result
            Vector2 _ScaledPosition = screenPosition * this.m_Sensitivity;

            this.m_CameraViewAimTransform.Rotate(this.m_CameraTransform.right, _ScaledPosition.y, Space.World);
            this.m_CameraViewAimTransform.Rotate(this.m_CameraTransform.up, _ScaledPosition.x, Space.World);

            Vector3 _UpVector = (Mathf.Abs(this.m_CameraViewAimTransform.forward.y) > 0.9f) 
                ? this.m_CameraRigTransform.up 
                : Vector3.up;

            this.m_CameraRigTransform.rotation = Damp(this.m_CameraRigTransform.rotation,
                                                    Quaternion.LookRotation(screenPosition.forward, _UpVector),
                                                    this.m_CameraSmoothSpeed,
                                                    Time.deltaTime);
        }

        public void SetThrustControl(float throttlePower)
        {
            this.m_ThrottlePower = throttlePower;
            this.m_Velocity = this.m_Speed * throttlePower * this.gameObject.transform.forward;
        }

        public void MoveFlyer(){

        }

        private Quaternion Damp(Quaternion a, Quaternion b, float lambda, float dt)
        {
            return Quaternion.Slerp(a, b, 1 - Mathf.Exp(-lambda * dt));
        }

        #endregion Methods

    }

}