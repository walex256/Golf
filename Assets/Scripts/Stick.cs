using System;
using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float m_power = 250;
        [SerializeField] private Transform m_point;
        [SerializeField] private float m_minAngelX= 30;
        [SerializeField] private float m_maxAngelX=-30;
        [SerializeField, Min(0)] private float m_speed;
        [SerializeField] private SaundManager m_soundManager;
        [SerializeField] private ParticleSystem m_particleSystem;

        private Vector3 m_direction;

        private Vector3 m_lastPointPosition;

        private bool m_isDown;

        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if (m_isDown)
            {
                angels.z = Rotate(angels.z, m_minAngelX);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngelX);
            }

            transform.localEulerAngles = angels;


            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.position;

            
        }

        private float Rotate(float angelX, float target)
            => Mathf.MoveTowardsAngle(angelX, target, Time.deltaTime * m_speed);
        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                m_particleSystem.Play();
                m_soundManager.SoundPlay(Sound.stickHit);
                stone.AddForce(m_power * m_direction);
            }           
        }

        public void Down()
        {
            m_isDown = true;
        }
        public void Up()
        {
            m_isDown = false;
        }
    }
}