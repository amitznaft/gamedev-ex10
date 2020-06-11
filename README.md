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


    private void Reload()
    {
        StartCoroutine(ShootingCoolDownRoutine());
    }

    IEnumerator ShootingCoolDownRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        _ammo = _startAmmo;
        _isReloading = false;
    }
    ```
    
   
   
