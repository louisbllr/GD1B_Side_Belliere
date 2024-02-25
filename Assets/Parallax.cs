using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxSpeed = 1f;
    private Transform playerTransform;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        float parallax = (lastPlayerPosition.x - playerTransform.position.x) * parallaxSpeed;
        transform.Translate(new Vector3(parallax, 0, 0));
        lastPlayerPosition = playerTransform.position;
    }
}
