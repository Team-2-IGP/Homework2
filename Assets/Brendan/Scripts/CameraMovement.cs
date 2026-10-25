using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Camera cam;
    private GameObject player;

    private static float followConstant = 200f;
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame

    Vector3 target = new Vector3();


    float EasingFunction(float t)
    {
        // Ease in-out cubic function
        return t < 0.5f ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    }


    void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = player.transform.position;
            newPosition.z = cam.transform.position.z;
            target = newPosition;
            //cam.transform.position = newPosition;
        }

        cam.transform.position = Vector3.Lerp(cam.transform.position, target, EasingFunction(followConstant * Time.deltaTime));

    }
}
