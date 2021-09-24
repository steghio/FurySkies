using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset = new Vector3(10,0,0);

    private void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
