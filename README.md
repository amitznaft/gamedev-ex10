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
 The weapons can be swapped by the keys 1,2. Each time we perform a test that the weapon changes and updates its SetActive accordingly.  
 
 3. Interaction:
 There is a character on the left when the game starts, when pressed the E key closed to her she will say hey.
 
 I add the character to the game and give her CharacterTalk c# script:
```csharp
public class CharcterTalk : MonoBehaviour
{

    [SerializeField]
    AudioSource _audioS;
    private float lookRadius = 2f;
    [SerializeField] GameObject _player;
    private Vector3 _ppos;
    // Start is called before the first frame update
    void Start()
    {
        _audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _ppos = _player.transform.position;
        float distance = Vector3.Distance(_ppos, transform.position);
        if (distance <= lookRadius && Input.GetKeyDown(KeyCode.E))
        {
            _audioS.Play();
        }
    }
}
```
A radius is set to 2f, if the character distance from the player is smaller than the radius and also the E key is pressed so will play the audio clip of the character that says hey
   
