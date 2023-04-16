using UnityEngine;

public class TransformBind : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private void Update()
    {
        transform.position = target.position;
    }
}
