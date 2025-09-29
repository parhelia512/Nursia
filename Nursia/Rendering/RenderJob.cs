using DigitalRiseModel;
using Microsoft.Xna.Framework;
using System;

namespace Nursia.Rendering
{
	internal struct RenderJob
	{
		public int EffectBatchId => Material.EffectBinding.BatchId;
		public IMaterial Material;
		public Matrix Transform;
		public DrMeshPart Mesh;
		public Matrix[] BonesTransforms;
		public BoundingBox BoundingBox;

		public RenderJob(IMaterial material, Matrix transform, DrMeshPart mesh, BoundingBox boundingBox, Matrix[] bonesTransforms = null)
		{
			Material = material ?? throw new ArgumentNullException(nameof(material));
			Transform = transform;
			Mesh = mesh ?? throw new ArgumentNullException(nameof(mesh));
			BonesTransforms = bonesTransforms;
			BoundingBox = boundingBox;
		}
	}
}
