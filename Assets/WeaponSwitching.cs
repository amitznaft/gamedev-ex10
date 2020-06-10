
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedweapon = 0;
    void Start()
    {
        Selectedweapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedweapon;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedweapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedweapon = 1;
        }
        if (previousSelectedWeapon != selectedweapon)
        {
            Selectedweapon();
        }
    }
    void Selectedweapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedweapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
