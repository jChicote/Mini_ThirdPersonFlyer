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

        // Default values
        private float m_DefaultThrottlePower;

        // Current values
        private float m_ThrottlePower;
        private float m_Speed;
        private Vector3 m_Velocity;
        private float m_Sensitivity;

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
        }

        public void RotateFlyer()
        {
            // Scale the input result


            // Rotate the reference tr
        }

        public void SetThrustControl(float throttlePower)
        {
            this.m_ThrottlePower = throttlePower;
            this.m_Velocity = this.m_Speed * throttlePower * this.gameObject.transform.forward;
        }

        #endregion Methods

    }

}