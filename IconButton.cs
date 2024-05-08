using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomUserControls
{
    public partial class IconButton : Button
    {
        private Image icon;
        private Size iconSize;
        private PictureBoxSizeMode iconSizeMode;
        private Point iconPosition;
        private Padding iconMargin;

        public IconButton()
        {
            // Set default values
            iconSizeMode = PictureBoxSizeMode.Zoom;
            iconPosition = Point.Empty;
            iconMargin = new Padding(5); // Default margin

            // Subscribe to the SizeChanged event to update the icon size when the button size changes
            this.SizeChanged += IconButton_SizeChanged;
        }

        private void IconButton_SizeChanged(object sender, EventArgs e)
        {
            UpdateIconSizeAndTextPosition();
            Refresh();
        }

        public Image Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                if (icon != null)
                {
                    // Initialize the icon size when the icon is set
                    UpdateIconSizeAndTextPosition();
                }
                Refresh();
            }
        }

        public PictureBoxSizeMode IconSizeMode
        {
            get
            {
                return iconSizeMode;
            }
            set
            {
                iconSizeMode = value;
                if (icon != null)
                {
                    UpdateIconSizeAndTextPosition();
                }
                Refresh();
            }
        }

        public Point IconPosition
        {
            get
            {
                return iconPosition;
            }
            set
            {
                iconPosition = value;
                if (icon != null)
                {
                    UpdateIconSizeAndTextPosition();
                }
                Refresh();
            }
        }

        public Padding IconMargin
        {
            get
            {
                return iconMargin;
            }
            set
            {
                iconMargin = value;
                if (icon != null)
                {
                    UpdateIconSizeAndTextPosition();
                }
                Refresh();
            }
        }

        private void UpdateIconSizeAndTextPosition()
        {
            if (icon != null)
            {
                // Update the icon size based on the new button height
                int iconHeight = this.Height - iconMargin.Vertical;
                iconSize = new Size(iconHeight, iconHeight);

                // Adjust the padding dynamically based on the icon size and margin
                this.Padding = new Padding(iconSize.Width + iconMargin.Right, this.Padding.Top, this.Padding.Right, this.Padding.Bottom);
            }
            else
            {
                // If no icon, reset the padding to default
                this.Padding = new Padding(0);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            if (Icon != null)
            {
                // Calculate icon position based on IconPosition and IconMargin
                int x = IconPosition.X + iconMargin.Left;
                int y = IconPosition.Y + iconMargin.Top;

                // Draw the icon on the button
                pevent.Graphics.DrawImage(Icon, new Rectangle(x, y, iconSize.Width, iconSize.Height));
            }
        }
    }
}
