﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle
{
    void OnHit(GameObject someObject);
}