using DigitalRiseModel;
using DigitalRiseModel.Primitives;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nursia;
using Nursia.Rendering;
using Nursia.Standard;
using Nursia.Utility;

namespace NursiaEditor.Utility
{
	internal static class _3DUtils
	{
		private static DrMeshPart _selectionMesh;
		private static EditorNode _selectionNode;

		private static DrMeshPart SelectionMesh
		{
			get
			{
				if (_selectionMesh == null)
				{
					_selectionMesh = MeshPrimitives.CreateBoxLinesMeshPart(Nrs.GraphicsDevice, new BoundingBox(Vector3.Zero, Vector3.One));
				}

				return _selectionMesh;
			}
		}

		private static EditorNode SelectionNode
		{
			get
			{
				if (_selectionNode == null)
				{
					_selectionNode = new EditorNode(
						SelectionMesh,
						new ColorMaterial
						{
							Color = Color.Orange
						});
				}

				return _selectionNode;
			}
		}


		public static BoundingBox? GetPickBox(this object obj)
		{
			BoundingBox? result = null;

			var asMeshNode = obj as MeshNodeBase;
			if (asMeshNode != null)
			{
				result = asMeshNode.BoundingBox;
			}

			if (obj is BaseLight || obj is Camera)
			{
				result = MathUtils.CreateBoundingBox(
					0, 1,
					0, 1,
					0, 1);
			}

			var asModel = obj as NursiaModelNode;
			if (asModel != null)
			{
				result = asModel.CalculateBoundingBox();
			}

			return result;
		}

		public static EditorNode GetSelectionNode(this SceneNode node)
		{
			if (node == null)
			{
				return null;
			}

			var box = node.GetPickBox();
			if (box == null)
			{
				return null;
			}

			var result = SelectionNode;

			var scale = Matrix.CreateScale(box.Value.ToScale());
			result.Transform = scale * node.GlobalTransform;

			return result;
		}
	}
}