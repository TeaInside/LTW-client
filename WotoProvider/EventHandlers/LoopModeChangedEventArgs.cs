namespace WotoProvider.EventHandlers
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class LoopModeChangedEventArgs : WotoEventArgs
    {
        //-------------------------------------------------
        #region Properties Region
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public bool LoopModeTurnedOn { get; set; }
        #endregion
        //-------------------------------------------------
        #region Constructor's Region
        public LoopModeChangedEventArgs(bool loopModeTurnedOn, WotoCreation wotoCreation) : base(wotoCreation)
        {
            LoopModeTurnedOn = loopModeTurnedOn;
        }
        #endregion
        //-------------------------------------------------
    }
}
