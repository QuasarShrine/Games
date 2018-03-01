using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster
{
    private int[] bowls = new int[21];
    private int bowl = 1;

    public enum Action { Tidy, Reset, EndTurn, EndGame };

    public Action Bowl(int pins) {
        // garde code
        if (pins > 10 || pins < 0) { throw new UnityException("Invalid pins number!"); }

        bowls[bowl - 1] = pins;

        if (bowl == 21) {
            return Action.EndGame;
        }

        // Other behaviour here, e.g last frame
        if (bowl >= 19 && pins == 10) {
            bowl++;
            return Action.Reset;
        } else if (bowl == 20) {
            bowl++;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] != 10) {
                return Action.Tidy;
            } else if ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0) {
                return Action.Reset;
            } else if (Bowl21Awareded()) {
                return Action.Tidy;
            } else {
                return Action.EndGame;
            }
        }

        if (bowl % 2 != 0) { // First bowl of frame 
            if (pins == 10) {
                bowl += 2;
                return Action.EndTurn;
            } else {
                bowl += 1;
                return Action.Tidy;
            }
        } else if (bowl % 2 == 0) { // Second bowl of frame
            bowl += 1;
            return Action.EndTurn;
        }

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awareded() {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
