/* Generated by MyraPad at 9/25/2024 8:34:20 PM */
using Myra;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI.Properties;
using FontStashSharp.RichText;
using AssetManagementBase;

#if STRIDE
using Stride.Core.Mathematics;
#elif PLATFORM_AGNOSTIC
using System.Drawing;
using System.Numerics;
using Color = FontStashSharp.FSColor;
#else
// MonoGame/FNA
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endif

namespace NursiaEditor.UI
{
	partial class MainForm: VerticalStackPanel
	{
		private void BuildUI()
		{
			_menuItemNew = new MenuItem();
			_menuItemNew.Text = "&New";
			_menuItemNew.Id = "_menuItemNew";

			_menuItemOpenSolution = new MenuItem();
			_menuItemOpenSolution.Text = "&Open Solution";
			_menuItemOpenSolution.Id = "_menuItemOpenSolution";

			_menuItemSaveCurrentItem = new MenuItem();
			_menuItemSaveCurrentItem.Text = "&Save Current Item";
			_menuItemSaveCurrentItem.Id = "_menuItemSaveCurrentItem";

			_menuItemSaveEverything = new MenuItem();
			_menuItemSaveEverything.Text = "&Save Everything";
			_menuItemSaveEverything.Id = "_menuItemSaveEverything";

			_menuItemQuit = new MenuItem();
			_menuItemQuit.Text = "&Quit";
			_menuItemQuit.Id = "_menuItemQuit";

			var menuItem1 = new MenuItem();
			menuItem1.Text = "&File";
			menuItem1.Items.Add(_menuItemNew);
			menuItem1.Items.Add(_menuItemOpenSolution);
			menuItem1.Items.Add(_menuItemSaveCurrentItem);
			menuItem1.Items.Add(_menuItemSaveEverything);
			menuItem1.Items.Add(_menuItemQuit);

			_menuItemAbout = new MenuItem();
			_menuItemAbout.Text = "&About";
			_menuItemAbout.Id = "_menuItemAbout";

			var menuItem2 = new MenuItem();
			menuItem2.Text = "&Help";
			menuItem2.Items.Add(_menuItemAbout);

			var horizontalMenu1 = new HorizontalMenu();
			horizontalMenu1.Items.Add(menuItem1);
			horizontalMenu1.Items.Add(menuItem2);

			_panelSceneExplorer = new Panel();
			_panelSceneExplorer.Id = "_panelSceneExplorer";

			_panelSolution = new Panel();
			_panelSolution.Id = "_panelSolution";

			_leftSplitPane = new VerticalSplitPane();
			_leftSplitPane.Id = "_leftSplitPane";
			_leftSplitPane.Widgets.Add(_panelSceneExplorer);
			_leftSplitPane.Widgets.Add(_panelSolution);

			var label1 = new Label();
			label1.Text = "Grid";

			_buttonGrid = new ToggleButton();
			_buttonGrid.Id = "_buttonGrid";
			_buttonGrid.Content = label1;

			var label2 = new Label();
			label2.Text = "Bounding Boxes";

			_buttonBoundingBoxes = new ToggleButton();
			_buttonBoundingBoxes.Id = "_buttonBoundingBoxes";
			_buttonBoundingBoxes.Content = label2;

			var label3 = new Label();
			label3.Text = "Light View Frustum";

			_buttonLightViewFrustum = new ToggleButton();
			_buttonLightViewFrustum.Id = "_buttonLightViewFrustum";
			_buttonLightViewFrustum.Content = label3;

			var label4 = new Label();
			label4.Text = "Shadow Map";

			_buttonShadowMap = new ToggleButton();
			_buttonShadowMap.Id = "_buttonShadowMap";
			_buttonShadowMap.Content = label4;

			var horizontalStackPanel1 = new HorizontalStackPanel();
			horizontalStackPanel1.Spacing = 8;
			horizontalStackPanel1.Widgets.Add(_buttonGrid);
			horizontalStackPanel1.Widgets.Add(_buttonBoundingBoxes);
			horizontalStackPanel1.Widgets.Add(_buttonLightViewFrustum);
			horizontalStackPanel1.Widgets.Add(_buttonShadowMap);

			_tabControlScenes = new TabControl();
			_tabControlScenes.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_tabControlScenes.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			_tabControlScenes.CloseableTabs = true;
			_tabControlScenes.Id = "_tabControlScenes";
			StackPanel.SetProportionType(_tabControlScenes, Myra.Graphics2D.UI.ProportionType.Fill);

			_panelScenes = new VerticalStackPanel();
			_panelScenes.Id = "_panelScenes";
			_panelScenes.Widgets.Add(horizontalStackPanel1);
			_panelScenes.Widgets.Add(_tabControlScenes);

			_tabControlEffects = new TabControl();
			_tabControlEffects.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Stretch;
			_tabControlEffects.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Stretch;
			_tabControlEffects.CloseableTabs = true;
			_tabControlEffects.Id = "_tabControlEffects";

			_splitPaneEditor = new VerticalSplitPane();
			_splitPaneEditor.Id = "_splitPaneEditor";
			_splitPaneEditor.Widgets.Add(_panelScenes);
			_splitPaneEditor.Widgets.Add(_tabControlEffects);

			_labelFps = new Label();
			_labelFps.Text = "FPS: 60.0";
			_labelFps.Id = "_labelFps";

			_labelMeshes = new Label();
			_labelMeshes.Text = "Meshes: 15";
			_labelMeshes.Id = "_labelMeshes";

			_labelCamera = new Label();
			_labelCamera.Text = "Camera: 0/50/0;270;0";
			_labelCamera.Id = "_labelCamera";

			var verticalStackPanel1 = new VerticalStackPanel();
			verticalStackPanel1.HorizontalAlignment = Myra.Graphics2D.UI.HorizontalAlignment.Right;
			verticalStackPanel1.VerticalAlignment = Myra.Graphics2D.UI.VerticalAlignment.Bottom;
			verticalStackPanel1.Widgets.Add(_labelFps);
			verticalStackPanel1.Widgets.Add(_labelMeshes);
			verticalStackPanel1.Widgets.Add(_labelCamera);

			var panel1 = new Panel();
			panel1.Widgets.Add(_splitPaneEditor);
			panel1.Widgets.Add(verticalStackPanel1);

			_propertyGrid = new PropertyGrid();
			_propertyGrid.Id = "_propertyGrid";

			_topSplitPane = new HorizontalSplitPane();
			_topSplitPane.Id = "_topSplitPane";
			_topSplitPane.Widgets.Add(_leftSplitPane);
			_topSplitPane.Widgets.Add(panel1);
			_topSplitPane.Widgets.Add(_propertyGrid);

			var panel2 = new Panel();
			StackPanel.SetProportionType(panel2, Myra.Graphics2D.UI.ProportionType.Fill);
			panel2.Widgets.Add(_topSplitPane);

			
			Id = "_mainPanel";
			Widgets.Add(horizontalMenu1);
			Widgets.Add(panel2);
		}

		
		public MenuItem _menuItemNew;
		public MenuItem _menuItemOpenSolution;
		public MenuItem _menuItemSaveCurrentItem;
		public MenuItem _menuItemSaveEverything;
		public MenuItem _menuItemQuit;
		public MenuItem _menuItemAbout;
		public Panel _panelSceneExplorer;
		public Panel _panelSolution;
		public VerticalSplitPane _leftSplitPane;
		public ToggleButton _buttonGrid;
		public ToggleButton _buttonBoundingBoxes;
		public ToggleButton _buttonLightViewFrustum;
		public ToggleButton _buttonShadowMap;
		public TabControl _tabControlScenes;
		public VerticalStackPanel _panelScenes;
		public TabControl _tabControlEffects;
		public VerticalSplitPane _splitPaneEditor;
		public Label _labelFps;
		public Label _labelMeshes;
		public Label _labelCamera;
		public PropertyGrid _propertyGrid;
		public HorizontalSplitPane _topSplitPane;
	}
}
