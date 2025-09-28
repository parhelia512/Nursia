using AssetManagementBase;
using DigitalRiseModel;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Nursia.Attributes;
using Nursia.Rendering;
using System.ComponentModel;

namespace Nursia.Standard
{
	[EditorInfo("Gltf/Glb Model")]
	public class DrModelNode : SceneNode
	{
		private readonly DrModelInstance _modelInstance = new DrModelInstance();

		[Browsable(false)]
		[JsonIgnore]
		public DrModel Model
		{
			get => _modelInstance.Model;

			set => _modelInstance.Model = value;
		}

		[Browsable(false)]
		public string ModelPath { get; set; }

		protected internal override void Render(RenderBatch batch)
		{
			base.Render(batch);

			if (Model == null)
			{
				return;
			}

			// Render meshes
			var rootTransform = GlobalTransform;
			foreach (var mesh in Model.Meshes)
			{
				// If mesh has bones, then parent node transform had been already
				// applied to bones transform
				// Thus to avoid applying parent transform twice, we use
				// ordinary Transform(not AbsoluteTransform) for parts with bones
				var bone = mesh.ParentBone;
				Matrix transform = bone.Skin != null ? rootTransform : _modelInstance.GetBoneGlobalTransform(bone.Index) * rootTransform;

				// Apply the effect and render items
				Matrix[] bonesTransforms = null;
				if (bone.Skin != null)
				{
					bonesTransforms = _modelInstance.GetSkinTransforms(bone.Skin.SkinIndex);
				}

				batch.BatchJob(mesh.Material, transform, mesh);
			}
		}

		public override void Load(AssetManager assetManager)
		{
			base.Load(assetManager);

			Model = assetManager.LoadGltf(Nrs.GraphicsDevice, ModelPath);
		}

		public BoundingBox CalculateBoundingBox() => _modelInstance.BoundingBox.Value;
	}
}
