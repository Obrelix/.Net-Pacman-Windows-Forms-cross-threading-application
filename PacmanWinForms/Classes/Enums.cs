using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public enum Difficulty : byte
    {
        Easy = 0,
        Normal = 1,
        Hard = 2,
        Original_AI = 3
    }
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2,
        GAMEWAIT = 3
    }

    public enum Direction : Int16
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3,
        STOP = 14
    }

    public enum GhostColor : byte
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        PINK = 3,
        NULL = 5
    }

    public enum GhostState : byte
    {
        NORMAL = 0,
        BONUS = 1,
        EATEN = 2,
        BONUSEND = 3
    }

    public enum SoundNames: byte
    {
        Siren1 = 0,
        Siren2 = 1,
        Waka = 2

    }
}

