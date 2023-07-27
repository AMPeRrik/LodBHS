﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace LOD {
    public interface ILodComponent {
        void CalculateDistanceToCamera (TransformComponent camera);

        void DefineLodModel ();
    }
}
