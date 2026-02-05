using UnityEngine;

public class Platform_Power : MonoBehaviour
{
    [SerializeField]private float Aspect;
    [SerializeField]private float ForcePower;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Aspect, 90, 0) * ForcePower, ForceMode.Force);
    }
}
