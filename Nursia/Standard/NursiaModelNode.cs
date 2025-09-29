using AssetManagementBase;
using DigitalRiseModel;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Nursia.Attributes;
using Nursia.Rendering;
using Nursia.Utilities;
using System.ComponentModel;

namespace Nursia.Standard
{
	[EditorInfo("Gltf/Glb Model")]
	public class NursiaModelNode : SceneNode
	{
		[Browsable(false)]
		[JsonIgnore]
		public DrModelInstance ModelInstance { get; } = new DrModelInstance();

		[Browsable(false)]
		[JsonIgnore]
		public DrModel Model
		{
			get => ModelInstance.Model;

			set => ModelInstance.Model = value;
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
				var nodeTransform = ModelInstance.GetBoneGlobalTransform(bone.Index) * rootTransform;
				Matrix transform = bone.Skin != null ? rootTransform : nodeTransform;

				// Apply the effect and render items
				Matrix[] bonesTransforms = null;
				if (bone.Skin != null)
				{
					bonesTransforms = ModelInstance.GetSkinTransforms(bone.Skin.SkinIndex);
				}

				foreach (var part in mesh.MeshParts)
				{
					var material = (IMaterial)part.Tag;
 					batch.BatchJob(material, transform, part, part.BoundingBox.Transform(ref nodeTransform), bonesTransforms);
				}
			}
		}

		public override void Load(AssetManager assetManager)
		{
			base.Load(assetManager);

			Model = assetManager.LoadGltf(Nrs.GraphicsDevice, ModelPath);

			// Set materials
			foreach(var mesh in Model.Meshes)
			{
				foreach(var meshPart in mesh.MeshParts)
				{
					if (meshPart.Material == null)
					{
						continue;
					}

					var material = new DefaultMaterial
					{
						DiffuseColor = meshPart.Material.DiffuseColor,
						Texture = meshPart.Material.DiffuseTexture
					};

					var supportsSkinning = material as ISupportsSkinning;
					if (mesh.ParentBone.Skin != null && supportsSkinning != null)
					{
						supportsSkinning.Skinning = true;
					}

					meshPart.Tag = material;
				}
			}
		}

		public BoundingBox CalculateBoundingBox() => ModelInstance.BoundingBox.Value;
	}
}
