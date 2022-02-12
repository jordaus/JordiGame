﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JordiGame.StateManagement
{
    public interface IScreenFactory
    {
        GameScreen CreateScreen(Type screenType);
    }
}
