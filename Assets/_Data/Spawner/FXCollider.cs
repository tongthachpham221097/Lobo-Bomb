//using UnityEngine;

//public class FXCollider : MonoBehaviour
//{
//    public void OnTriggerEnter2D(Collider2D other)
//    {
//        //if (other.CompareTag("Tilemap-Walls") || other.gameObject.name == "RightBoxCollider")
//        //{
//        //    Debug.Log("FXCollision");
//        //    FXSpawner.Instance.Despawn(transform.parent);
//        //}
//        Debug.Log(other.gameObject.name);
//    }

//}
using UnityEngine;

public class FXCollider : MonoBehaviour
{
    public float raycastDistance = 1f; // Khoảng cách raycast

    public void Update()
    {
        // Kiểm tra va chạm với bức tường bằng raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, raycastDistance);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Tilemap-Walls"))
            {
                Debug.Log("Bomb is close to a wall.");
                // Xử lý khi hiệu ứng bomb gần bức tường
            }
        }
    }
}

