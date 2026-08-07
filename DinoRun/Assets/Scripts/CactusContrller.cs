using UnityEngine;

public class CactusContrller : MonoBehaviour
{

    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DestroyObj")
        {
            Destroy(gameObject);
        }
    }
}
