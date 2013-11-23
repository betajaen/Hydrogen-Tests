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
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
  public enum Outcome
  {
    NotTested,
    Passed,
    Failed
  }

  public class Result
  {
    public String Name;
    public Outcome Outcome;
    public String Note;
  }

  private String testName;
  private List<Result> results;

  void Awake()
  {
    useGUILayout = false;
    testName = GetType().Name;
    results = new List<Result>();
  }

  public void PrepareResult(String name)
  {
    results.Add(new Result()
    {
      Name = name,
      Outcome = Outcome.NotTested
    });
  }

  public void SetResult(String name, bool didPass)
  {
    SetResult(name, didPass ? Outcome.Passed : Outcome.Failed);
  }

  public void SetResult(String name, Outcome outcome)
  {
    foreach (Result result in results)
    {
      if (result.Name == name)
      {
        result.Outcome = outcome;
        result.Note = String.Empty;
        return;
      }
    }
  }

  public void SetNote(String name, String note)
  {
    foreach (Result result in results)
    {
      if (result.Name == name)
      {
        result.Note = note;
        return;
      }
    }
  }

  public int ShowResults(int y)
  {
    GUI.Label(new Rect(0, y, Screen.width, y + 20), testName);
    y += 25;
    foreach (Result result in results)
    {
      if (String.IsNullOrEmpty(result.Note))
      {
        GUI.Label(new Rect(25, y, Screen.width, y + 20), String.Format("{0} -> {1}", result.Name, result.Outcome));
      }
      else
      {
        GUI.Label(new Rect(25, y, Screen.width, y + 20), String.Format("{0} -> {1} '{2}'", result.Name, result.Outcome, result.Note));
      }
      y += 25;
    }
    return y;
  }

}
