using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private GameObject ammoCounterObject;
    [SerializeField] private TMP_Text ammoCounter;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerCombat playerCombat;

    private void OnEnable()
    {
        playerController.OnWeaponChangeInput += UpdateCounterOnWeaponSwitch;
    }

    private void OnDisable()
    {
        playerController.OnWeaponChangeInput -= UpdateCounterOnWeaponSwitch;
    }

    private void UpdateCounterOnWeaponSwitch(int index)
    {
        switch(index)
        {
            case 2:
            case 3:
                int ammoCount = playerCombat.GetActiveWeaponAmmoCount();
                ammoCounter.text = ammoCount.ToString();

                if(!ammoCounterObject.activeSelf)
                    ammoCounterObject.SetActive(true);

                break;
            default:
                ammoCounterObject.SetActive(false);
                break;
        }
    }

    public void UpdateAmmoCounter(int ammoCount)
    {
        ammoCounter.text = ammoCount.ToString();
    }
}
