using WotoProvider.Enums;

namespace WotoProvider.EventHandlers
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class MouseEventArgs : WotoEventArgs
	{
		//-------------------------------------------------
		#region Properties Region
		public MouseButtons Button { get; }
		#endregion
		//-------------------------------------------------
		#region Constructor's Region
		public MouseEventArgs(WotoCreation wotoCreation, MouseButtons _button) : base(wotoCreation)
		{
			Button = _button;
		}
		#endregion
		//-------------------------------------------------
	}
}