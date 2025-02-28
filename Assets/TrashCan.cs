using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Start()
    {
        GetComponent<TriggerZone>().onEnterEvent.AddListener(InsideTrash);
    }

    public void InsideTrash(GameObject o)
    {
        o.SetActive(false);
    }
}
