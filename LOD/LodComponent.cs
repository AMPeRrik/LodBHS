using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Rendering;

namespace LOD {
    public class LodComponent: SyncScript, ILodComponent {
        public List<ModelComponent> lods = new();
        public List<int> lodsEnableDistance = new();
        private ModelComponent activeModelComponent;

        public float distanceToCamera;
        private Model cacheModel;


        public override void Start () {
            base.Start();

            lods.Add(null);

            activeModelComponent = Entity.Get<ModelComponent>();
            cacheModel = Entity.Get<ModelComponent>().Model;
        }

        public override void Update () {

        }


        public void CalculateDistanceToCamera (TransformComponent camera) {
            distanceToCamera = (Entity.Transform.Position - camera.Position).Length();
        }


        public void DefineLodModel () {
            for (int i = lodsEnableDistance.Count - 1; i >= 0; i--) {
                if (lodsEnableDistance[i] > distanceToCamera) {
                    continue;
                }

                activeModelComponent.Model = lods[i + 1].Model;
                return;
            }
            activeModelComponent.Model = cacheModel;
        }
    }
}
