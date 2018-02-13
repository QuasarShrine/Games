﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{

    public enum Action { Tidy, Reset, EndTurn, EndGame };
    public Action Bowl(int pins) {
        // garde code
        if (pins > 10 || pins < 0) { throw new UnityException("Invalid pins number!"); }

        if (pins == 10) {
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }
}