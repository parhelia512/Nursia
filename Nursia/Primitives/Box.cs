using Microsoft.Xna.Framework;
using Nursia.Utilities;
using Nursia.Attributes;
using DigitalRiseModel;
using DigitalRiseModel.Primitives;

namespace Nursia.Primitives
{
	[EditorInfo("Primitive")]
	public class Box : PrimitiveMeshNode
	{
		private Vector3 _size = Vector3.One;

		public Vector3 Size
		{
			get => _size;

			set
			{
				if (value.EpsilonEquals(_size))
				{
					return;
				}

				_size = value;
				InvalidateMesh();
			}
		}

		protected override DrMeshPart CreateMesh() => MeshPrimitives.CreateBoxMeshPart(Nrs.GraphicsDevice, Size, UScale, VScale, IsLeftHanded);
	}
}