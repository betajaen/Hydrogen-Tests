using System;
using UnityEngine;
using System.Collections;

public class ExampleInput : MonoBehaviour
{
  private GameObject turret, muzzle, ammo;
  private Plane ground;
  void Start()
  {
    hInputManager.AddAction("Move", OnMove);
    hInputManager.AddAction("Turn", OnTurn);
    hInputManager.AddAction("Rotate", OnRotate);
    hInputManager.AddAction("Shoot", OnShoot);

    hInputManager.AddControl("Mouse X", "Rotate");

    hInputManager.AddControl("Horizontal", "Turn");
    hInputManager.AddControl("Vertical", "Move");

    hInputManager.AddControl("Left", "Shoot");
    hInputManager.AddControl("Space", "Shoot");

    turret = GameObject.Find("Turret");
    muzzle = GameObject.Find("Muzzle");
    ammo = Hydrogen.Resources.Load<GameObject>("MiniCube");
    ground = new Plane(Vector3.up, 0);
  }

  private void OnRotate(hInputEvent evt, float value, float time)
  {
    // Mouse X Axes are relative movements only. So we only turn the turret - never directly set the rotation.
    turret.transform.localRotation *= Quaternion.AngleAxis(value * 180.0f * Time.deltaTime, Vector3.up);
  }

  private void OnShoot(hInputEvent evt, float value, float time)
  {
    if (evt == hInputEvent.Released)
    {
      GameObject shell = Instantiate(ammo, muzzle.transform.position, Quaternion.identity) as GameObject;
      shell.rigidbody.velocity = turret.transform.rotation * Vector3.forward * 10.0f * (time * time + 0.1f);
    }
  }

  private void OnMove(hInputEvent evt, float value, float time)
  {
    // Vertical Axes give it's state of absolute values of -1.0, 1.0 only.
    // So this is used to move the box along it's looking direction (horizontal). This will handle forward and backward movement in one go.
    transform.transform.position += transform.rotation * Vector3.forward * value * 4.0f * Time.deltaTime;
  }

  private void OnTurn(hInputEvent evt, float value, float time)
  {
    // Horizontal Axes give it's state of absolute values of -1.0, 1.0 only.
    // We normalised this to a steering range, then use this to turn the tank.
    transform.transform.localRotation *= Quaternion.AngleAxis(value * 90.0f * Time.deltaTime, Vector3.up);
  }



}
