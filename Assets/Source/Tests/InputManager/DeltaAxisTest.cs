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

public class DeltaAxisTest : Test
{

  private float mx, my;

  public void Start()
  {
    PrepareResult("Mouse X");
    PrepareResult("Mouse X Action");
    SetResult("Mouse X Action", hInputManager.AddAction("MouseXMovement", OnMouseXMoved));

    PrepareResult("Mouse X Binding");
    SetResult("Mouse X Binding", hInputManager.AddBind("Mouse X", "MouseXMovement"));

    PrepareResult("Mouse Y");
    PrepareResult("Mouse Y Action");
    SetResult("Mouse Y Action", hInputManager.AddAction("MouseYMovement", OnMouseYMoved));

    PrepareResult("Mouse Y Binding");
    SetResult("Mouse Y Binding", hInputManager.AddBind("Mouse Y", "MouseYMovement"));

  }

  public void Update()
  {
    mx = Input.GetAxis("Mouse X");
    my = Input.GetAxis("Mouse Y");
  }

  private void OnMouseXMoved(hInputEvent evt, float value, float time)
  {
    SetResult("Mouse X", Mathf.Abs(value - mx) < Mathf.Epsilon);
  }

  private void OnMouseYMoved(hInputEvent evt, float value, float time)
  {
    SetResult("Mouse Y", Mathf.Abs(value - my) < Mathf.Epsilon);
  }

}
