// SAO : LT
// Copyright (C) wotoTeam, TeaInside, MODAnime Foundation
// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of the source code.

using SAO.Client;
using SAO.SandBox;
using SAO.Constants;
using SAO.GameObjects.WMath;
using SAO.SandBox.ErrorSandBoxes;

namespace SAO.Controls.Elements
{
    public sealed partial class ElementManager
    {
        //-------------------------------------------------
        #region Constant's Region

        #endregion
        //-------------------------------------------------
        #region static Properties Region
        public static GameClient Father
        {
            get => ThereIsConstants.Forming.GameClient;
        }
        #endregion
        //-------------------------------------------------
        #region Properties Region
        public ElementList<GraphicElements> VeryLowElements { get; private set; }
        public ElementList<GraphicElements> LowElements { get; private set; }
        public ElementList<GraphicElements> NormalElements { get; private set; }
        public ElementList<GraphicElements> HighElements { get; private set; }
        public ElementList<GraphicElements> VeryHighElements { get; private set; }
        public ElementList<GraphicElements> SuperHighElements { get; private set; }
        public ElementList<GraphicElements> BeyondHighElements { get; private set; }
        public ElementList<GraphicElements> TopMostElements { get; private set; }
        public ListW<ElementList<GraphicElements>> Elements { get; private set; }
        public ElementList<SandBoxElement> LowSandBoxes { get; private set; }
        public ElementList<SandBoxElement> TopMostSandBoxes { get; private set; }
        public ErrorSandBox LowErrorSandBox { get; private set; }
        public ErrorSandBox TopMostErrorSandBox { get; private set; }
        public GraphicElements Owner { get; }
        /// <summary>
        /// if this manager has a <see cref="GraphicElements"/> Owner,
        /// I mean <see cref="Owner"/>, then,
        /// it cannot have error sandboxes.
        /// </summary>
        public bool HasOwner { get; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public ElementManager()
        {
            HasOwner = false;
            InitializeComponent();
        }
        public ElementManager(GraphicElements _owner_)
        {
            Owner = _owner_;
            HasOwner = true;
            InitializeComponent();
        }
        #endregion
        //-------------------------------------------------
        #region Special Method's Region
#if MOUSE

        public void OnMouseEnter()
        {

        }
#endif
        #endregion
        //-------------------------------------------------
    }
}
