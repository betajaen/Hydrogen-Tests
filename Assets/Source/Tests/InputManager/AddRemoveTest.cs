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

public class AddRemoveTest : Test
{

  public void Start()
  {
    PrepareResult("AnAction");
    SetResult("AnAction", hInputManager.AddAction("AnAction", OnAnAction));

    PrepareResult("F2 Binding");
    SetResult("F2 Binding", hInputManager.AddControl("F2", "AnAction"));

    PrepareResult("F2 Unbinding (Press F2 - To test for AnAction)");
    SetResult("F2 Unbinding (Press F2 - To test for AnAction)", Outcome.ExpectingPassed);
    hInputManager.RemoveControl("F2");
  }

  private void OnAnAction(hInputEvent evt, float value, float time)
  {
    SetResult("F2 Unbinding (Press F2 - To test for AnAction)", Input.GetKey(KeyCode.F2));
  }

}
