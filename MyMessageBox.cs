/**************************************************************************************
File name: MyMessageBox.cs
Purpose:   1. Mimics the functionality of the MessageBox class including the form format
              and resizing in relation to message contents, title, and number of buttons
           2. Added the functionality of stating the parent form so the message box
              appears over the parent application instead of the middle of the screen
              - the built-in MessageBox has this function however it doesn't work as
                Microsoft overrides it and always puts the box in the middle of the screen
Version: 1.0
Author: ┬  ┬ ┬┬┌─┌─┐┬ ┬┌─┐╦╔╦╗
        │  │ │├┴┐├┤ │││├─┤║ ║
        ┴─┘└─┘┴ ┴└─┘└┴┘┴ ┴╩ ╩
Date: February 14, 2023
License: MIT License

GitHub Repository: https://github.com/LukeWait/my-messagebox
**************************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomMessageBox
{
    public static class MyMessageBox
    {

        /****************************************************************************
        Method:     Show() --- parameterised contructor method
        Purpose:    Creates a MessageBox to display passed in data
        Input:      Form parentForm           --- Form that the message box is being called from
                    string message            --- message to display
                    string title              --- text to display in title bar
                    MessageBoxButtons buttons --- the combination of buttons required
                    MessageBoxIcon icon       --- the icon to be displayed in the message box
        Output:     Constructor method/no return type
        ****************************************************************************/
        public static DialogResult Show(Form parentForm, string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // calculate the position of the message box relative to the parent form
            int x = parentForm.Left + (parentForm.Width - 250) / 2;
            int y = parentForm.Top + (parentForm.Height - 250) / 2;

            // create the message box form
            Form messageBox = new Form();
            messageBox.StartPosition = FormStartPosition.Manual;
            messageBox.Location = new Point(x, y);
            messageBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            messageBox.MaximizeBox = false;
            messageBox.MinimizeBox = false;
            messageBox.ShowInTaskbar = false;
            messageBox.SizeGripStyle = SizeGripStyle.Hide;           
            messageBox.Text = title;

            // create the details panel
            Panel bodyPanel = new Panel();
            bodyPanel.Dock = DockStyle.Top;
            bodyPanel.BackColor = Color.White;
            messageBox.Controls.Add(bodyPanel);
            // create the button panel
            Panel footerPanel = new Panel();
            footerPanel.Height = 49;
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.BackColor = Color.CornflowerBlue;
            messageBox.Controls.Add(footerPanel);


            // create the icon
            PictureBox iconBox = new PictureBox();
            iconBox.Location = new Point(20, 20);
            iconBox.Size = new Size(32, 32);
            iconBox.SizeMode = PictureBoxSizeMode.StretchImage;
            switch (icon)
            {
                case MessageBoxIcon.Error:
                    iconBox.Image = SystemIcons.Error.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    iconBox.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    iconBox.Image = SystemIcons.Question.ToBitmap();
                    break;
                case MessageBoxIcon.Warning:
                    iconBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
                default:
                    iconBox.Image = null;
                    break;
            }

            // create the message box text
            Label messageLabel = new Label();
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(52, 18);
            messageLabel.Text = message;
            messageLabel.MaximumSize = new Size(250, 800);
            messageLabel.Padding = new Padding(10);
            messageLabel.Font = new Font("Microsoft Sans Serif", 8);

            // add the details to the body panel
            bodyPanel.Controls.Add(messageLabel);
            bodyPanel.Controls.Add(iconBox);


            // create the buttons
            Button[] buttonsArray;
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    buttonsArray = new Button[] { new Button() };
                    buttonsArray[0].DialogResult = DialogResult.OK;
                    buttonsArray[0].Text = "&OK";

                    break;
                case MessageBoxButtons.OKCancel:
                    buttonsArray = new Button[] { new Button(), new Button() };
                    buttonsArray[0].DialogResult = DialogResult.OK;
                    buttonsArray[0].Text = "&OK";
                    buttonsArray[1].DialogResult = DialogResult.Cancel;
                    buttonsArray[1].Text = "&Cancel";
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    buttonsArray = new Button[] { new Button(), new Button(), new Button() };
                    buttonsArray[0].DialogResult = DialogResult.Abort;
                    buttonsArray[0].Text = "&Abort";
                    buttonsArray[1].DialogResult = DialogResult.Retry;
                    buttonsArray[1].Text = "&Retry";
                    buttonsArray[2].DialogResult = DialogResult.Ignore;
                    buttonsArray[2].Text = "&Ignore";
                    break;
                case MessageBoxButtons.YesNoCancel:
                    buttonsArray = new Button[] { new Button(), new Button(), new Button() };
                    buttonsArray[0].DialogResult = DialogResult.Yes;
                    buttonsArray[0].Text = "&Yes";
                    buttonsArray[1].DialogResult = DialogResult.No;
                    buttonsArray[1].Text = "&No";
                    buttonsArray[2].DialogResult = DialogResult.Cancel;
                    buttonsArray[2].Text = "&Cancel";
                    break;
                case MessageBoxButtons.YesNo:
                    buttonsArray = new Button[] { new Button(), new Button() };
                    buttonsArray[0].DialogResult = DialogResult.Yes;
                    buttonsArray[0].Text = "&Yes";
                    buttonsArray[1].DialogResult = DialogResult.No;
                    buttonsArray[1].Text = "&No";
                    break;
                case MessageBoxButtons.RetryCancel:
                    buttonsArray = new Button[] { new Button(), new Button() };
                    buttonsArray[0].DialogResult = DialogResult.Retry;
                    buttonsArray[0].Text = "&Retry";
                    buttonsArray[1].DialogResult = DialogResult.Cancel;
                    buttonsArray[1].Text = "&Cancel";
                    break;
                default:
                    throw new ArgumentException("Invalid button set.", "buttons");
            }

            // add buttons to the footer panel
            // position according to number of buttons
            int buttonCount = buttonsArray.Length;
            int buttonSpacing = 10;
            int buttonX = footerPanel.ClientSize.Width;
            for (int i = buttonCount - 1; i >= 0; i--)
            {
                Button button = buttonsArray[i];
                button.BackColor = SystemColors.Control;
                button.FlatAppearance.BorderColor = SystemColors.Control;
                button.FlatStyle = FlatStyle.System;
                button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                button.Cursor = Cursors.Hand;
                if (i == buttonCount - 1)
                {
                    buttonX -= button.Width + buttonSpacing + 10;
                }
                else
                {
                    buttonX -= button.Width + buttonSpacing;
                }
                button.Location = new Point(buttonX, footerPanel.ClientSize.Height - button.Height - 10);
                footerPanel.Controls.Add(button);
            }         


            // mock label for title width minimum requirement
            Label messageLabelTitle = new Label();
            messageLabelTitle.AutoSize = true;
            messageLabelTitle.Text = title;
            int minWidth = messageLabelTitle.Width + 150;

            // size the body panel according to content
            int bodyPanelHeight = Math.Max(messageLabel.Height + 28, 72);
            int bodyPanelWidth = messageLabel.Width + 82;
            bodyPanel.Size = new Size(bodyPanelWidth, bodyPanelHeight);

            // size the footer panel according to number of buttons or bodyPanelWidth
            int footerPanelWidth = Math.Max((buttonCount * 75) + ((buttonCount + 1) * 15) + 20, bodyPanelWidth);
            footerPanel.Size = new Size(footerPanelWidth, footerPanel.Height);

            // compare panel widths to get the largest
            int largestPanelWidth = Math.Max(bodyPanelWidth, footerPanelWidth);
            // size the messageBox according to largest width requirement
            int messageBoxWidth = Math.Max(largestPanelWidth, minWidth);
            // size the messageBox according to top panel height and fixed footer height
            int messageBoxHeight = bodyPanelHeight + footerPanel.Height + 34/*title bar*/;
            messageBox.Size = new Size(messageBoxWidth, messageBoxHeight);

            // Display the message box and return the result
            DialogResult result = messageBox.ShowDialog(parentForm);
            messageBox.Dispose();

            return result;
        }
    }
}
