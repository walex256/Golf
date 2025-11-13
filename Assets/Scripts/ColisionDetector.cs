using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [Header("Слои для отслеживания столкновений")]
    [SerializeField] private int groundLayer; 
    [SerializeField] private int StickLayer;   

    private void OnCollisionEnter(Collision collision)
    {
        int otherLayer = collision.gameObject.layer;

        if (otherLayer == groundLayer)
        {
            Debug.Log($"{name} столкнулся с землей ({collision.gameObject.name})");
        }
        else if (otherLayer == StickLayer)
        {
            Debug.Log($"{name} столкнулся с клюшкой ({collision.gameObject.name})");
        }
    }
}
