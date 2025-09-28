﻿using AssetManagementBase;
using System;

namespace NursiaEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			AMBConfiguration.Logger = Console.WriteLine;

			foreach(var arg in args)
			{
				if (arg == "/nf")
				{
					Configuration.NoFixedStep = true;
				}
			}

			using (var game = new StudioGame())
			{
				game.Run();
			}
		}
	}
}
