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

public class KeyboardButtonTest : Test
{

  private bool lastRun, nowRun;
  private bool lastUse, nowUse;

  enum RunState
  {
    NotRunning,
    StartingRun,
    Running
  }

  enum UseState
  {
    NotUsing,
    StartingUse,
    Using
  }

  private RunState testRunState;
  private UseState testUseState;

  public void Start()
  {
    PrepareResult("Run");
    PrepareResult("Run Action");
    SetResult("Run Action", hInputManager.AddAction("Run", OnRun));

    PrepareResult("Run (W) Binding");
    SetResult("Run (W) Binding", hInputManager.AddControl("W", "Run"));

    PrepareResult("Run (UpArrow) Binding");
    SetResult("Run (UpArrow) Binding", hInputManager.AddControl("UpArrow", "Run"));


    PrepareResult("Use");
    PrepareResult("Use Action");
    SetResult("Use Action", hInputManager.AddAction("Use", OnUse));

    PrepareResult("Use (E) Binding");
    SetResult("Use (E) Binding", hInputManager.AddControl("E", "Use"));
  }

  public void Update()
  {
    lastRun = nowRun;
    nowRun = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

    testRunState = RunState.NotRunning;

    if (lastRun == false && nowRun)
    {
      testRunState = RunState.StartingRun;
    }
    else if (lastRun && nowRun == false)
    {
      testRunState = RunState.NotRunning;
    }
    else if (lastRun && nowRun)
    {
      testRunState = RunState.Running;
    }

    lastUse = nowUse;
    nowUse = Input.GetKey(KeyCode.E);

    testUseState = UseState.NotUsing;

    if (lastUse == false && nowUse)
    {
      testUseState = UseState.StartingUse;
    }
    else if (lastUse && nowUse == false)
    {
      testUseState = UseState.NotUsing;
    }
    else if (lastUse && nowUse)
    {
      testUseState = UseState.Using;
    }
  }

  private void OnRun(hInputEvent evt, float value, float time)
  {

    RunState inputRunState = RunState.NotRunning;

    if (evt == hInputEvent.Pressed)
    {
      inputRunState = RunState.StartingRun;
    }
    else if (evt == hInputEvent.Released)
    {
      inputRunState = RunState.NotRunning;
    }
    else if (evt == hInputEvent.Down)
    {
      inputRunState = RunState.Running;
    }

    SetResult("Run", testRunState == inputRunState);
    if (testRunState == inputRunState)
    {
      SetNote("Run", String.Format("Test/Input={0}", testRunState));
    }
    else
    {
      SetNote("Run", String.Format("Test={0}, Input={1}", testRunState, inputRunState));
    }
  }


  private void OnUse(hInputEvent evt, float value, float time)
  {

    UseState inputUseState = UseState.NotUsing;

    if (evt == hInputEvent.Pressed)
    {
      inputUseState = UseState.StartingUse;
    }
    else if (evt == hInputEvent.Released)
    {
      inputUseState = UseState.NotUsing;
    }
    else if (evt == hInputEvent.Down)
    {
      inputUseState = UseState.Using;
    }

    SetResult("Use", testUseState == inputUseState);
    if (testUseState == inputUseState)
    {
      SetNote("Use", String.Format("Test/Input={0}", testUseState));
    }
    else
    {
      SetNote("Use", String.Format("Test={0}, Input={1}", testUseState, inputUseState));
    }
  }

}
