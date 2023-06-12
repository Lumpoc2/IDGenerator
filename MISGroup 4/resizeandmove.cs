using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MISGroup_4
{
    internal class ControlMoverOrResizer
    {
        private static bool _moving;
        private static Point _cursorStartPoint;
        private static bool _moveIsInterNal;
        private static bool _resizing;
        private static Size _currentControlStartSize;
       
        internal static bool MouseIsInLeftEdge { get; set; }
        internal static bool MouseIsInRightEdge { get; set; }
        internal static bool MouseIsInTopEdge { get; set; }
        internal static bool MouseIsInBottomEdge { get; set; }

        internal enum MoveOrResize
        {
            Move,
            Resize,
            MoveAndResize,
         

        }
        internal enum stop
        {
            StopDragOrResizing,

        }

        internal static MoveOrResize WorkType { get; set; }
        internal static stop stopdragandresize { get; set; }

        internal static void Init(Control control)
        {
            Init(control, control);
        }

        internal static void Init(Control control, Control container)
        {
           

            _moving = false;
            _resizing = false;
            _moveIsInterNal = false;
            _cursorStartPoint = Point.Empty;
            MouseIsInLeftEdge = false;
            MouseIsInLeftEdge = false;
            MouseIsInRightEdge = false;
            MouseIsInTopEdge = false;
            MouseIsInBottomEdge = false;

            WorkType = MoveOrResize.MoveAndResize;
            control.MouseDown += (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp += (sender, e) => StopDragOrResizing(control);
            control.MouseMove += (sender, e) => MoveControl(container, e);
            stopdragandresize = stop.StopDragOrResizing;
            WorkType = MoveOrResize.MoveAndResize;



        }

        public static void RemoveEventHandler(Control control)
        {
            control.MouseDown -= (sender, e) => StartMovingOrResizing(control, e);
            control.MouseUp -= (sender, e) => StopDragOrResizing(control);
            control.MouseMove -= (sender, e) => MoveControl(control, e);
        }

        private static void UpdateMouseEdgeProperties(Control control, Point mouseLocationInControl)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            MouseIsInLeftEdge = Math.Abs(mouseLocationInControl.X) <= 2;
            MouseIsInRightEdge = Math.Abs(mouseLocationInControl.X - control.Width) <= 2;
            MouseIsInTopEdge = Math.Abs(mouseLocationInControl.Y) <= 2;
            MouseIsInBottomEdge = Math.Abs(mouseLocationInControl.Y - control.Height) <= 2;
        }

        private static void UpdateMouseCursor(Control control)
        {
            if (WorkType == MoveOrResize.Move)
            {
                return;
            }
            if (MouseIsInLeftEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInRightEdge)
            {
                if (MouseIsInTopEdge)
                {
                    control.Cursor = Cursors.SizeNESW;
                }
                else if (MouseIsInBottomEdge)
                {
                    control.Cursor = Cursors.SizeNWSE;
                }
                else
                {
                    control.Cursor = Cursors.SizeWE;
                }
            }
            else if (MouseIsInTopEdge || MouseIsInBottomEdge)
            {
                control.Cursor = Cursors.SizeNS;
            }
            else
            {
                control.Cursor = Cursors.Default;
            }
        }
        private static void StartMovingOrResizing(Control control, MouseEventArgs e)
        {
            if (_moving || _resizing)
            {
                return;
            }
            if (WorkType != MoveOrResize.Move &&
                (MouseIsInRightEdge || MouseIsInLeftEdge || MouseIsInTopEdge || MouseIsInBottomEdge))
            {
                _resizing = true;
                _currentControlStartSize = control.Size;
            }
            else if (WorkType != MoveOrResize.Resize)
            {
                _moving = true;
                control.Cursor = Cursors.Hand;
            }
            _cursorStartPoint = new Point(e.X, e.Y);
            control.Capture = true;
        }

        private static void MoveControl(Control control, MouseEventArgs e)
        {
            if (!_resizing && !_moving)
            {
                UpdateMouseEdgeProperties(control, new Point(e.X, e.Y));
                UpdateMouseCursor(control);
            }
            if (_resizing)
            {
              

                Rectangle newBounds = control.Bounds;

                // Check if the control's new position or size would extend beyond the bounds of its container
                if (newBounds.Left < 0 || newBounds.Top < 0 || newBounds.Right > control.Parent.ClientSize.Width || newBounds.Bottom > control.Parent.ClientSize.Height)
                {
                    // If the control's new bounds would extend beyond the container, try to move the control back into the container
                    int newLeft = Math.Max(0, Math.Min(control.Left, control.Parent.ClientSize.Width - control.Width));
                    int newTop = Math.Max(0, Math.Min(control.Top, control.Parent.ClientSize.Height - control.Height));
                    control.Location = new Point(newLeft, newTop);

                    // Check if the control's size needs to be adjusted to fit within the container
                    newBounds = control.Bounds;
                    if (newBounds.Left < 0 || newBounds.Top < 0 || newBounds.Right > control.Parent.ClientSize.Width || newBounds.Bottom > control.Parent.ClientSize.Height)
                    {
                        // Determine the maximum width and height that the control can have while still fitting within the container
                        int maxWidth = control.Parent.ClientSize.Width - control.Left;
                        int maxHeight = control.Parent.ClientSize.Height - control.Top;
                        int newWidth = Math.Min(control.Width, maxWidth);
                        int newHeight = Math.Min(control.Height, maxHeight);

                        // If the control's size needs to be adjusted, resize the control and move it to the nearest valid position within the container
                        if (newWidth < control.Width || newHeight < control.Height)
                        {
                            control.Size = new Size(newWidth, newHeight);
                            newBounds = control.Bounds;

                            int newLeft2 = Math.Max(0, Math.Min(control.Left, control.Parent.ClientSize.Width - control.Width));
                            int newTop2 = Math.Max(0, Math.Min(control.Top, control.Parent.ClientSize.Height - control.Height));
                            control.Location = new Point(newLeft2, newTop2);
                        }
                    }
                }


                else
                {
                    if (MouseIsInLeftEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                            control.Height -= (e.Y - _cursorStartPoint.Y);
                            control.Top += (e.Y - _cursorStartPoint.Y);
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        }
                        else
                        {
                            control.Width -= (e.X - _cursorStartPoint.X);
                            control.Left += (e.X - _cursorStartPoint.X);
                        }
                    }
                    else if (MouseIsInRightEdge)
                    {
                        if (MouseIsInTopEdge)
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                            control.Height -= (e.Y - _cursorStartPoint.Y);
                            control.Top += (e.Y - _cursorStartPoint.Y);
                        }
                        else if (MouseIsInBottomEdge)
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                            control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                        }
                        else
                        {
                            control.Width = (e.X - _cursorStartPoint.X) + _currentControlStartSize.Width;
                        }
                    }
                    else if (MouseIsInTopEdge)
                    {
                        control.Height -= (e.Y - _cursorStartPoint.Y);
                        control.Top += (e.Y - _cursorStartPoint.Y);
                    }
                    else if (MouseIsInBottomEdge)
                    {
                        control.Height = (e.Y - _cursorStartPoint.Y) + _currentControlStartSize.Height;
                    }
                    else
                    {
                        StopDragOrResizing(control);
                    }
                }
            }

            else if (_moving)
            {
                _moveIsInterNal = !_moveIsInterNal;
                if (!_moveIsInterNal)
                {
                    int x = (e.X - _cursorStartPoint.X) + control.Left;
                    int y = (e.Y - _cursorStartPoint.Y) + control.Top;

                    // Restrict the movement within the bounds of the panel
                    int panelWidth = 228;
                    int panelHeight = 332;
                    x = Math.Min(Math.Max(x, 0), panelWidth - control.Width);
                    y = Math.Min(Math.Max(y, 0), panelHeight - control.Height);

                    control.Location = new Point(x, y);
                }
            }
        }


        public static void StopDragOrResizing(Control control)
        {
            _resizing = false;
            _moving = false;
            control.Capture = false;
            UpdateMouseCursor(control);
        }

      
        public void MyControl_MouseUp(object sender, MouseEventArgs e)

        {
            Control control = sender as Control;

            if (_resizing || _moving)
            {
                StopDragOrResizing(control);
            }
        }

    }
}
    

