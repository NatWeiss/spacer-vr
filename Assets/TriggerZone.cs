using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> onEnterEvent;

    private void onTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            onEnterEvent.Invoke(other.gameObject);
        }
        Debug.Log("Triggered by " + other.name);
    }

}
