using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibAllocine
{
    public class Constantes
    {

        public static int HauteurThumbnails = 80;
        public static int LargeurThumbnails = 60;
        
        public enum EnumTypeMachine
        {
            INCONNU = 0,
            PC = 10,
            PS4 = 20,
            XBOXONE = 30,
            WIIU = 40,
            PS3 = 50,
            XBOX360 = 60,
            N3DS = 70,
            ANDROID = 100,
            GAMEBOY = 200,
            DREAMCAST = 190,
            GAMECUBE = 220,
            GAMEGEAR = 230,
            MASTERSYSTEM = 290,
            MEGADRIVE = 300,
            MEGADRIVE32X = 310,
            MEGACD = 320,
            N64= 370,
            PSX = 390,
            PS2 = 400,
            SATURN = 420,
            SUPERNES = 430,
            WII = 460,
            XBOX = 470,
        }

        public enum EnumTypeMediaAllocine
        {
            FILM=0,
            SERIE=1,
        }
    }
}
