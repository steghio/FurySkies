using UnityEngine;

public class PropellerX : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 500f) * Time.deltaTime);
    }
}
