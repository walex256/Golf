using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private float m_minAngelX= 30;
        [SerializeField] private float m_maxAngelX=-30;
        [SerializeField, Min(0)] private float m_speed;

        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                angels.z = Rotate(angels.z, m_minAngelX);
            }
            else
            {
                angels.z = Rotate(angels.z, m_maxAngelX);
            }

            transform.localEulerAngles = angels;
        }

        private float Rotate(float angelX, float target)
            => Mathf.MoveTowardsAngle(angelX, target, Time.deltaTime * m_speed);
    }
}