using UnityEngine;

public class Drop : MonoBehaviour
{
    float dropSpeed = 0.1f;
    public Vector2 stopPos;

    private void Awake()
    {
        stopPos = new Vector2(transform.position.x, Random.Range(3, -3));
    }

    private void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, stopPos, dropSpeed);
    }
}
