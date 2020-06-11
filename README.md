# gamedev-ex10
## homework-2-player
## Type A Task - Developing the Player from the Guide

1. movement:
   Add option to player to jump by space key 
   
   I add this c# code to the Player script:
   ```csharp
   private float _jumpHighet = 5.0f;
   private float _yVelocity;
   void MovementCalc()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(x, 0, z);
        Vector3 velocity = direction * _speed;
        if (_cc.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHighet;
            }
        }
        else
        {
            _yVelocity -= _gravity * Time.deltaTime;
        }
        velocity.y = _yVelocity;

        velocity = transform.transform.TransformDirection(velocity);
        _cc.Move(velocity * Time.deltaTime);
    }
    ```
    that is, a check is made on whether the player is on the ground and also if a space key is pressed, then _yVelocity = _jumpHighet, other _yVelocity -= _gravity * Time.deltaTime (put it back on the floor by gravity) and then move the CharacterController by the velocity.
    
2.  Weapon:
    Create new weapon and option to switch between the two weapons
    
    First I add new other weapon to the player, and put the two weapons under WeaponHolder with the WeaponSwitching c# script:
```csharp
public class WeaponSwitching : MonoBehaviour
{
    public int selectedweapon = 0;
    void Start()
    {
        Selectedweapon();
    }
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
```
    
   
   
