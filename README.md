# gamedev-ex10
## homework-2-player
## Type A Task - Developing the Player from the Guide

1. movement:
   Add option to player to jump by space key 
   ```csharp
    public GameObject child;
    public int ChildrenSimulataneusNumber = 2;
    private void ChildInit()
    {
        var childCount = 0;
        //RegularChildTag  - custom tag that we added to child object, so we could count
        //their instances in screen
        var regularChildren = GameObject.FindGameObjectsWithTag("RegularChildTag");
        if (regularChildren != null)
            childCount = regularChildren.Length;
        if (childCount < ChildrenSimulataneusNumber)
        {
            //Initialize child object, notice that child not exist in Hierarchy, only in assets folder.
            //Randomality appearance of child varies only in X axis
            Instantiate(child, new Vector3(GetRandomNumber(-9f, -9.3f), -0.7f, 0), Quaternion.identity);
        }
    }
