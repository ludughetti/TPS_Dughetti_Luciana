using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private ItemSpawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DoAction(other.gameObject);
            spawner.IsItemAvailable(false);
        }
    }

    protected virtual void DoAction(GameObject player)
    {
        Debug.Log($"{name}: DoAction() is not implemented for PickUpItem");
    }
}
