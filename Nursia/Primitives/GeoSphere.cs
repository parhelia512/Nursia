using Nursia.Utilities;
using Nursia.Attributes;
using DigitalRiseModel;
using DigitalRiseModel.Primitives;

namespace Nursia.Primitives
{
	[EditorInfo("Primitive")]
	public class GeoSphere : PrimitiveMeshNode
	{
		private float _radius = 0.5f;
		private int _tessellation = 3;

		public float Radius
		{
			get => _radius;

			set
			{
				if (value.EpsilonEquals(_radius))
				{
					return;
				}

				_radius = value;
				InvalidateMesh();
			}
		}

		public int Tessellation
		{
			get => _tessellation;

			set
			{
				if (value == _tessellation)
				{
					return;
				}

				_tessellation = value;
				InvalidateMesh();
			}
		}

		protected override DrMeshPart CreateMesh() => MeshPrimitives.CreateGeoSphereMeshPart(Nrs.GraphicsDevice, Radius, Tessellation, UScale, VScale, IsLeftHanded);
	}
}