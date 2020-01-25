using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector2 yMinMax;
    [SerializeField]
    private Vector2 xMinMax;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(xMinMax.y, Random.Range(yMinMax.x, yMinMax.y));
    }

    // Update is called once per frame
    void Update()
    {
        // move the obstacle to the left
        transform.position -= Vector3.right * speed * Time.deltaTime;

        // destroy it if it went far enough
        if (transform.position.x < xMinMax.x)
            Destroy(gameObject);
    }
}
