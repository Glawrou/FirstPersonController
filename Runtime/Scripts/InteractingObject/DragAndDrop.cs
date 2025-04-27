using UnityEngine;

namespace naa.FirstPersonController.InteractingObject
{
    public class DragAndDrop : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    }
}
