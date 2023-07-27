using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

namespace LOD {
    public class LodSettings: SyncScript {
        public CameraComponent mainCamera;
        public List<LodComponent> entitiesWithLods = new List<LodComponent>();

        private TransformComponent transformCamera;

        public override void Start () {
            if (mainCamera != null) {
                transformCamera = Entity.Get<TransformComponent>();
            }
        }

        public override void Update () {

            foreach (var entityWithLods in entitiesWithLods) {
                entityWithLods.CalculateDistanceToCamera(transformCamera);
                entityWithLods.DefineLodModel();
            }
        }
    }
}
