using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _expPrefab, _hpPrefab, _magnetPrefab;

    public void DropItem(Player player) {
        var randomNum = Random.Range(1, 30);
        GameObject newDrop;
        switch (randomNum)
        {
            case >= 18 and <= 19:
                newDrop = Instantiate(_hpPrefab, transform.position, transform.rotation);
                newDrop.GetComponent<PickUp>()?.Init(player);
                break;
            
            case 20:
                newDrop = Instantiate(_magnetPrefab, transform.position, transform.rotation);
                newDrop.GetComponent<PickUp>()?.Init(player);
                break;
            
            default:
                newDrop = Instantiate(_expPrefab, transform.position, transform.rotation);
                newDrop.GetComponent<PickUp>()?.Init(player);
                break;
        }
    }
}
