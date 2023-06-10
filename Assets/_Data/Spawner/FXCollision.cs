using UnityEngine;

public class FXCollision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "RightBoxCollider")
        {
            Debug.Log("FXCollision");
            FXSpawner.Instance.Despawn(transform.parent);
        }
        Debug.Log(other.gameObject.name);
    }
}
