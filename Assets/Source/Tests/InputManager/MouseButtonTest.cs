/*
    Hydrogen-Tests
    --------------
    
    Copyright (c) 2013 Robin Southern

                                                                                  
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
                                                                                  
    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.
                                                                                  
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE. 
    
*/

using System;
using UnityEngine;

public class MouseButtonTest : Test
{

  private bool lastShoot, nowShoot;

  enum ShootState
  {
    NotShooting,
    StartingShoot,
    Shooting
  }

  private ShootState testShootState;

  public void Start()
  {
    PrepareResult("Shoot");
    PrepareResult("Shoot Action");
    SetResult("Shoot Action", hInputManager.AddAction("Shoot", OnShoot));

    PrepareResult("Shoot (Left) Binding");
    SetResult("Shoot (Left) Binding", hInputManager.AddBind("Left", "Shoot"));

  }

  public void Update()
  {
    lastShoot = nowShoot;
    nowShoot = Input.GetMouseButton(0);

    testShootState = ShootState.NotShooting;

    if (lastShoot == false && nowShoot)
    {
      testShootState = ShootState.StartingShoot;
    }
    else if (lastShoot && nowShoot == false)
    {
      testShootState = ShootState.NotShooting;
    }
    else if (lastShoot && nowShoot)
    {
      testShootState = ShootState.Shooting;
    }

  }

  private void OnShoot(hInputEvent evt, float value, float time)
  {

    ShootState inputShootState = ShootState.NotShooting;

    if (evt == hInputEvent.Pressed)
    {
      inputShootState = ShootState.StartingShoot;
    }
    else if (evt == hInputEvent.Released)
    {
      inputShootState = ShootState.NotShooting;
    }
    else if (evt == hInputEvent.Down)
    {
      inputShootState = ShootState.Shooting;
    }

    SetResult("Shoot", testShootState == inputShootState);
    if (testShootState == inputShootState)
    {
      SetNote("Shoot", String.Format("Test/Input={0}", testShootState));
    }
    else
    {
      SetNote("Shoot", String.Format("Test={0}, Input={1}", testShootState, inputShootState));
    }
  }

}
