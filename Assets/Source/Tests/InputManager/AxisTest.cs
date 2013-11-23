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

public class AxisTest : Test
{

  private float mx, my;

  public void Start()
  {
    PrepareResult("Horizontal");
    PrepareResult("Horizontal Action");
    SetResult("Horizontal Action", hInputManager.AddAction("HorizontalMovement", OnHorizontalMoved));

    PrepareResult("Horizontal Binding");
    SetResult("Horizontal Binding", hInputManager.AddControl("Horizontal", "HorizontalMovement"));

    PrepareResult("Vertical");
    PrepareResult("Vertical Action");
    SetResult("Vertical Action", hInputManager.AddAction("VerticalMovement", OnVerticalMoved));

    PrepareResult("Vertical Binding");
    SetResult("Vertical Binding", hInputManager.AddControl("Vertical", "VerticalMovement"));

  }

  public void Update()
  {
    mx = Input.GetAxis("Horizontal");
    my = Input.GetAxis("Vertical");
  }

  private void OnHorizontalMoved(hInputEvent evt, float value, float time)
  {
    bool passed = Mathf.Abs(value - mx) < Mathf.Epsilon;
    SetResult("Horizontal", passed);
    if (passed)
    {
      SetNote("Horizontal", value.ToString());
    }
  }

  private void OnVerticalMoved(hInputEvent evt, float value, float time)
  {
    bool passed = Mathf.Abs(value - my) < Mathf.Epsilon;
    SetResult("Vertical", passed);
    if (passed)
    {
      SetNote("Vertical", value.ToString());
    }
  }

}
